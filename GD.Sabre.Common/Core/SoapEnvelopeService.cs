using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GD.Sabre.Common.Core;

public class SoapEnvelopeService : ISoapEnvelopeService
{
    private const string SoapEnvNamespacePrefix = "soapenv";
    private const string SoapEnvNamespaceUri = "http://schemas.xmlsoap.org/soap/envelope/";

    public string SerializeEnvelope(object? payload, IEnumerable<object>? headers = null)
    {
        ArgumentNullException.ThrowIfNull(payload);

        var headerList = headers?.ToList();

        var serializedPayload = SerializeObject(payload);

        var serializedHeaders = headerList?
            .Select(SerializeObject)
            .ToList();

        return SerializeEnvelopeFromBodyElement(serializedPayload, serializedHeaders);
    }

    public T DeserializeEnvelope<T>(XDocument soapEnvelope)
    {
        var soapBodyContentElement = soapEnvelope.Descendants()
            .FirstOrDefault(element =>
                element.Name.LocalName.Equals("body", StringComparison.InvariantCultureIgnoreCase))?.FirstNode;

        if (soapBodyContentElement == null)
            throw new Exception("No body element found");

        var defaultNamespaceUri = GetNamespaceUriForType(typeof(T));

        using var soapBodyReader = soapBodyContentElement.CreateReader();
        var xmlSerializer = new XmlSerializer(typeof(T), defaultNamespaceUri);

        var deserializedBodyObj = (T?)xmlSerializer.Deserialize(soapBodyReader);

        return deserializedBodyObj ??
               throw new Exception("The soap body did not deserialize to an object instance");
    }

    public T DeserializeEnvelopeHeader<T>(XDocument soapEnvelope, string elementName)
    {
        var soapHeaderElement = soapEnvelope.Descendants()
            .FirstOrDefault(element =>
                element.Name.LocalName.Equals("header", StringComparison.InvariantCultureIgnoreCase));

        if (soapHeaderElement == null)
            throw new Exception("No header element found");

        var soapHeaderContentElement = soapHeaderElement.Descendants()
            .FirstOrDefault(element =>
                element.Name.LocalName.Equals(elementName, StringComparison.InvariantCultureIgnoreCase));

        if (soapHeaderContentElement == null)
            throw new Exception($"No header content element found with the name {elementName}");

        var defaultNamespaceUri = GetNamespaceUriForType(typeof(T));

        using var soapHeaderReader = soapHeaderContentElement.CreateReader();

        var xmlSerializer = new XmlSerializer(typeof(T), defaultNamespaceUri);
        var deserializedHeaderObj = (T?)xmlSerializer.Deserialize(soapHeaderReader);

        return deserializedHeaderObj ??
               throw new Exception("The soap header did not deserialize to an object instance");
    }

    public string? GetSoapFaultFromEnvelope(XDocument soapEnvelope)
    {
        var faultElement = soapEnvelope.Descendants()
            .FirstOrDefault(element =>
                element.Name.LocalName.Equals("faultstring", StringComparison.InvariantCultureIgnoreCase));

        return faultElement?.Value;
    }

    private static string SerializeEnvelopeFromBodyElement(
      XElement bodyElement,
      IEnumerable<XElement>? headerElements = null)
    {
        ArgumentNullException.ThrowIfNull(bodyElement);

        XNamespace soapEnvNs = SoapEnvNamespaceUri;

        var soapNsAttribute = new List<XAttribute>
            {
                new(XNamespace.Xmlns + SoapEnvNamespacePrefix, soapEnvNs)
            };

        var soapEnvelope = new XElement(
            soapEnvNs + "Envelope",
            soapNsAttribute,
            new XElement(soapEnvNs + "Header", headerElements),
            new XElement(soapEnvNs + "Body", bodyElement));

        return new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                soapEnvelope)
            .ToString();
    }

    private static string GetNamespaceUriForType(Type type)
    {
        var xmlTypeAttribute =
            type.GetTypeInfo().GetCustomAttributes(typeof(XmlTypeAttribute), false).FirstOrDefault();

        if (xmlTypeAttribute is XmlTypeAttribute { Namespace: not null } xmlAttribute)
            return xmlAttribute.Namespace;

        var dataContractAttribute =
            type.GetTypeInfo().GetCustomAttributes(typeof(DataContractAttribute), false).FirstOrDefault();

        if (dataContractAttribute is DataContractAttribute { Namespace: not null } dcAttribute)
            return dcAttribute.Namespace;

        throw new InvalidOperationException("The type provided does not have an associated xml namespace");
    }

    private static XElement SerializeObject(object payload)
    {
        var payloadType = payload.GetType();
        var namespaceUri = GetNamespaceUriForType(payloadType);

        var namespaces = new XmlSerializerNamespaces();

        namespaces.Add(string.Empty, namespaceUri);

        var serializer = new XmlSerializer(payloadType, namespaceUri);

        using var stringWriter = new StringWriter();

        serializer.Serialize(stringWriter, payload, namespaces);

        return XElement.Parse(stringWriter.ToString(), LoadOptions.PreserveWhitespace);
    }
}
