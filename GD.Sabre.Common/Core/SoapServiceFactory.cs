using GD.Sabre.Common.Core.Models;

namespace GD.Sabre.Common.Core;

public class SoapServiceFactory : ISoapServiceFactory
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ISoapEnvelopeService _soapEnvelopeService;

    public SoapServiceFactory(IHttpClientFactory httpClientFactory,
        ISoapEnvelopeService soapEnvelopeService)
    {
        ArgumentNullException.ThrowIfNull(httpClientFactory);
        ArgumentNullException.ThrowIfNull(soapEnvelopeService);

        _httpClientFactory = httpClientFactory;
        _soapEnvelopeService = soapEnvelopeService;
    }

    public ISoapService Create()
    {
        var httpClient = _httpClientFactory.CreateClient(HttpClientSetup.DefaultSoapClientName);
        return new SoapService(httpClient, _soapEnvelopeService);
    }
}

