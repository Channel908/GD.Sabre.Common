using System.Xml.Linq;

namespace GD.Sabre.Common.Core;

public interface ISoapEnvelopeService
{
    string SerializeEnvelope(object? payload, IEnumerable<object>? headers = null);

    T DeserializeEnvelope<T>(XDocument soapEnvelope);

    T DeserializeEnvelopeHeader<T>(XDocument soapEnvelope, string elementName);

    string? GetSoapFaultFromEnvelope(XDocument soapEnvelope);
}