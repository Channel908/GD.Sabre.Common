namespace GD.Sabre.Common.Core.Models.Options;

public class XmlProfileServiceApiOptions
{
    public string BaseUri { get; set; } = "https://webservices.havail.sabre.com";
    public string NamespaceUri { get; set; } = "http://webservices.sabre.com/sabreXML/2011/10";
    public string NamespacePrefix { get; set; } = "ota";
    public string ServiceUri { get; set; } = "websvc";
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Organization { get; set; } = "CC61";

}