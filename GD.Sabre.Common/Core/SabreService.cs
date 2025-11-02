using GD.Sabre.Common.Core.Models;
using GD.Sabre.Common.Core.Models.Options;
using Microsoft.Extensions.Options;
using System.Xml.Linq;

namespace GD.Sabre.Common.Core;

public abstract class SabreService(
    IOptions<SabreServicesOptions> options,
    ISoapServiceFactory soapServiceFactory) : ISabreService
{
    private SabreRequestLoggingStrategy? _loggingStrategy;

    private readonly IOptions<SabreServicesOptions> _options = options ??
                                                     throw new ArgumentNullException(nameof(options));

    private readonly ISoapServiceFactory _soapServiceFactory =
        soapServiceFactory ?? throw new ArgumentNullException(nameof(soapServiceFactory));

    public virtual void WithLoggingStrategy(SabreRequestLoggingStrategy loggingStrategy)
    {
        ArgumentNullException.ThrowIfNull(loggingStrategy);
        _loggingStrategy = loggingStrategy;
    }

    public string? GetSoapFaultFromEnvelope(XDocument soapEnvelope)
    {
        var faultElement = soapEnvelope.Descendants()
            .FirstOrDefault(element =>
                element.Name.LocalName.Equals("faultstring", StringComparison.InvariantCultureIgnoreCase)
                || element.Name.LocalName.Equals("ErrorMessage", StringComparison.InvariantCultureIgnoreCase));

        return faultElement?.Value;
    }

    protected ISoapService CreateSabreSoapService()
    {
        var soapService = _soapServiceFactory
            .Create()
            .WithBaseUri(_options.BaseUri() ?? throw new ArgumentException("Null BaseUri"))
            .WithServiceUri(_options.ServiceUri() ?? throw new ArgumentException("Null ServiceUri"))
            .WithCustomFaultParser(GetSoapFaultFromEnvelope);

        if (_loggingStrategy != null)
            soapService.WithLoggingStrategy(async (soapRequestLog) =>
                await _loggingStrategy(new SabreRequestLog(soapRequestLog.UtcDateTime, soapRequestLog.Success,
                    soapRequestLog.Request, soapRequestLog.Response, soapRequestLog.Exception,
                    soapRequestLog.ExternalId)));

        return soapService;
    }
}