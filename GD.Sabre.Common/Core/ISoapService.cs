using GD.Sabre.Common.Core.Models;

namespace GD.Sabre.Common.Core;

public interface ISoapService
{
    ISoapService WithBaseUri(string baseUri);

    ISoapService WithServiceUri(string serviceUri);

    ISoapService WithBasicAuth(string userName, string password);

    ISoapService WithCustomFaultParser(CustomFaultParser customFault);

    ISoapService WithLoggingStrategy(SoapRequestLoggingStrategy requestLoggingStrategy);

    ISoapService WithLoggingExternalId(string? externalId);

    ISoapService WithPayload<T>(T payload);

    ISoapService WithHeaders(IEnumerable<object> headers);

    Task<T> PostAsync<T>();

    T GetLastResultHeader<T>(string elementName);
}