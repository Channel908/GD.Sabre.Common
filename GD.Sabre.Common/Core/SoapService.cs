using GD.Sabre.Common.Core.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;

namespace GD.Sabre.Common.Core;

public class SoapService : ISoapService
{
    private const string XmlMediaType = "text/xml";

    private readonly HttpClient _httpClient;
    private readonly ISoapEnvelopeService _soapEnvelopeService;

    private string? _baseUri;
    private string? _serviceUri;

    //These parameters are used when an XML serializable and properly attributed payload is provided
    private object? _payload;
    private Type? _payloadType;
    private IEnumerable<object>? _headers;

    //Logging strategy
    private SoapRequestLoggingStrategy? _loggingStrategy;
    private string? _loggingExternalId;

    //Retention of the last full soap response for analysis
    private XDocument? _lastSoapResponseDocument;

    //Custom soap fault parser
    private CustomFaultParser? _customFaultParser;

    public SoapService(
     HttpClient httpClient,
     ISoapEnvelopeService soapEnvelopeService)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNull(soapEnvelopeService);

        _httpClient = httpClient;
        _soapEnvelopeService = soapEnvelopeService;
    }

    public ISoapService WithBaseUri(string baseUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri)) throw new ArgumentNullException(nameof(baseUri));
        _baseUri = baseUri;

        return this;
    }

    public ISoapService WithServiceUri(string serviceUri)
    {
        if (string.IsNullOrWhiteSpace(serviceUri)) throw new ArgumentNullException(nameof(serviceUri));
        _serviceUri = serviceUri;

        return this;
    }

    public ISoapService WithBasicAuth(string userName, string password)
    {
        if (string.IsNullOrWhiteSpace(userName)) throw new ArgumentNullException(nameof(userName));
        if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            scheme: "Basic",
            parameter: Convert.ToBase64String(
                System.Text.Encoding.ASCII.GetBytes($"{userName}:{password}"))
        );

        return this;
    }

    public ISoapService WithCustomFaultParser(CustomFaultParser customFault)
    {
        ArgumentNullException.ThrowIfNull(customFault);

        _customFaultParser = customFault;

        return this;
    }

    public ISoapService WithPayload<T>(T payload)
    {
        if (payload == null) throw new ArgumentNullException(nameof(payload));

        _payload = payload;
        _payloadType = payload.GetType();

        return this;
    }

    public ISoapService WithHeaders(IEnumerable<object> headers)
    {
        _headers = headers ?? throw new ArgumentNullException(nameof(headers));

        return this;
    }

    public ISoapService WithLoggingStrategy(SoapRequestLoggingStrategy requestLoggingStrategy)
    {
        ArgumentNullException.ThrowIfNull(requestLoggingStrategy);

        _loggingStrategy = requestLoggingStrategy;

        return this;
    }

    public ISoapService WithLoggingExternalId(string? externalId)
    {
        _loggingExternalId = string.IsNullOrWhiteSpace(externalId) ? null : externalId;

        return this;
    }

    public async Task<T> PostAsync<T>()
    {
        if (_baseUri == null) throw new Exception("No baseUri endpoint specified");
        if (_serviceUri == null) throw new Exception("No serviceUri endpoint specified");
        if (_payload == null) throw new Exception("No payload has been provided");

        _lastSoapResponseDocument = null;

        var soapRequestDocument = _soapEnvelopeService.SerializeEnvelope(_payload, _headers);

        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_baseUri}/{_serviceUri}")
        {
            Content = new StringContent(soapRequestDocument, Encoding.UTF8, XmlMediaType),
        };

        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(XmlMediaType));

        HttpResponseMessage? httpResponseMessage;
        Stream? soapResponseStream;

        try
        {
            httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);
            soapResponseStream = await httpResponseMessage.Content.ReadAsStreamAsync();
        }
        catch (Exception ex)
        {
            var exceptionMessage =
                $"Unexpected error during soap request for {_payloadType?.Name}: {ex.GetCombinedExceptionMessages()}";

            if (_loggingStrategy != null)
                await _loggingStrategy.Invoke(new SoapRequestLog(false, soapRequestDocument, null, exceptionMessage,
                    _loggingExternalId));

            throw new SoapServiceException(exceptionMessage, ex, soapRequestDocument, null);
        }

        await using (soapResponseStream)
        {
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                var soapResponseFaultString =
                    await GetFaultStringFromStreamAsync(soapResponseStream) ?? "Unknown fault";

                var exceptionMessage =
                    $"Unexpected error response from soap call for {_payloadType?.Name}: " +
                    $"({httpResponseMessage.StatusCode}): {httpResponseMessage.ReasonPhrase} - {soapResponseFaultString}";

                var soapResponseDocument = await GetSoapResponseMessageFromStreamAsync(soapResponseStream);

                if (_loggingStrategy != null)
                    await _loggingStrategy.Invoke(new SoapRequestLog(false, soapRequestDocument,
                        soapResponseDocument, exceptionMessage, _loggingExternalId));

                throw new SoapServiceException(exceptionMessage, soapRequestDocument, soapResponseDocument);
            }

            try
            {
                var soapResponseDocument =
                    await XDocument.LoadAsync(soapResponseStream, LoadOptions.None, CancellationToken.None);

                var soapResponseFaultString = await GetFaultStringFromStreamAsync(soapResponseStream);

                if (soapResponseFaultString != null)
                {
                    var exceptionMessage =
                        $"Unexpected error response from soap call for {_payloadType?.Name}: " +
                        $"{soapResponseFaultString}";

                    if (_loggingStrategy != null)
                        await _loggingStrategy.Invoke(new SoapRequestLog(false, soapRequestDocument,
                            soapResponseDocument.ToString(), exceptionMessage, _loggingExternalId));

                    throw new SoapServiceException(exceptionMessage, soapRequestDocument,
                        soapResponseDocument.ToString());
                }

                var deserializedEnvelope = _soapEnvelopeService.DeserializeEnvelope<T>(soapResponseDocument);

                if (_loggingStrategy != null)
                    await _loggingStrategy.Invoke(new SoapRequestLog(true, soapRequestDocument,
                        soapResponseDocument.ToString(), null, _loggingExternalId));

                _lastSoapResponseDocument = soapResponseDocument;

                return deserializedEnvelope;
            }
            catch (SoapServiceException)
            {
                throw;
            }
            catch (Exception ex)
            {
                var exceptionMessage = $"Unexpected error processing soap response: {ex.GetCombinedExceptionMessages()}";

                _loggingStrategy?.Invoke(new SoapRequestLog(false, soapRequestDocument,
                    await GetSoapResponseMessageFromStreamAsync(soapResponseStream), exceptionMessage,
                    _loggingExternalId));

                throw new SoapServiceException(exceptionMessage, ex, soapRequestDocument, null);
            }
        }
    }

    public T GetLastResultHeader<T>(string elementName)
    {
        if (_lastSoapResponseDocument == null)
            throw new Exception("No last soap response document available");

        return _soapEnvelopeService.DeserializeEnvelopeHeader<T>(_lastSoapResponseDocument, elementName);
    }

    private static async Task<string?> GetSoapResponseMessageFromStreamAsync(Stream soapResponseStream)
    {
        try
        {
            soapResponseStream.Seek(0, SeekOrigin.Begin);

            var soapResponseStreamReader = new StreamReader(soapResponseStream);
            return await soapResponseStreamReader.ReadToEndAsync();
        }
        catch
        {
            return null;
        }
    }

    private async Task<string?> GetFaultStringFromStreamAsync(Stream soapResponseStream)
    {
        try
        {
            soapResponseStream.Seek(0, SeekOrigin.Begin);

            var soapResponseDocument =
                await XDocument.LoadAsync(soapResponseStream, LoadOptions.None, CancellationToken.None);

            return _customFaultParser != null
                ? _customFaultParser.Invoke(soapResponseDocument)
                : _soapEnvelopeService.GetSoapFaultFromEnvelope(soapResponseDocument);
        }
        catch
        {
            return null;
        }
    }



}