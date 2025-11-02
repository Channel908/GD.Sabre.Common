using System.Runtime.Serialization;


namespace GD.Sabre.Common.Core.Reference;


[System.Diagnostics.DebuggerStepThrough()]
[System.CodeDom.Compiler.GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(IsReference = true, Name = "eb", Namespace = "http://www.ebxml.org/namespaces/messageHeader")]
public partial class MessageHeader
{

    public MessageHeader()
    {
        mustUnderstand = "1";
    }
    public From? From { get; set; }
    public To? To { get; set; }
    public string? CPAId { get; set; }
    public string? ConversationId { get; set; }
    public Service? Service { get; set; }
    public string? Action { get; set; }
    public MessageData? MessageData { get; set; }
    public object DuplicateElimination { get; set; }
    public Description[]? Description { get; set; }

    [System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, DataType = "ID")]
    public string? id { get; set; }

    [System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.ebxml.org/namespaces/messageHeader")]
    public string? version { get; set; }

    [System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public string mustUnderstand { get; set; }

    [System.Xml.Serialization.XmlAnyElement()]
    public System.Xml.XmlElement[]? Any { get; set; }

    [System.Xml.Serialization.XmlAnyAttribute()]
    public System.Xml.XmlAttribute[]? AnyAttr { get; set; }
}

[System.Diagnostics.DebuggerStepThrough()]
[System.CodeDom.Compiler.GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "eb", Namespace = "http://www.ebxml.org/namespaces/messageHeader")]
public partial class From
{

    [System.Xml.Serialization.XmlElement("PartyId")]
    public PartyId[]? PartyId { get; set; }
    public string? Role { get; set; }
}

[System.Diagnostics.DebuggerStepThrough()]
[System.CodeDom.Compiler.GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "eb", Namespace = "http://www.ebxml.org/namespaces/messageHeader")]
public partial class PartyId
{
    [System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
    public string? type { get; set; }
    [System.Xml.Serialization.XmlText()]
    public string? Value { get; set; }
}

[System.Diagnostics.DebuggerStepThrough()]
[System.CodeDom.Compiler.GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "eb", Namespace = "http://www.ebxml.org/namespaces/messageHeader")]
public partial class To
{
    [System.Xml.Serialization.XmlElement("PartyId")]
    public PartyId[]? PartyId { get; set; }
    public string? Role { get; set; }
}

[System.Diagnostics.DebuggerStepThrough()]
[System.CodeDom.Compiler.GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "eb", Namespace = "http://www.ebxml.org/namespaces/messageHeader")]
public partial class MessageData
{
    private DateTime? timeToLiveField { get; set; }
    public string? MessageId { get; set; }

    public string? Timestamp { get; set; }
    public string? RefToMessageId { get; set; }
    public string? TimeToLive
    {
        get { return timeToLiveField?.ToString("yyyy-MM-ddTHH:mm:ssZ"); }
        set { timeToLiveField = DateTime.Parse(value); }
    }

    [System.Xml.Serialization.XmlIgnore()]
    public bool TimeToLiveSpecified { get; set; }

    [System.Xml.Serialization.XmlElement(DataType = "nonNegativeInteger")]
    public string? Timeout { get; set; }
}

[System.Diagnostics.DebuggerStepThrough()]
[System.CodeDom.Compiler.GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "eb", Namespace = "http://www.ebxml.org/namespaces/messageHeader")]
public partial class Description
{
    [System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string? lang { get; set; }

    [System.Xml.Serialization.XmlText()]
    public string? Value { get; set; }
}

[System.Diagnostics.DebuggerStepThrough()]
[System.CodeDom.Compiler.GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "eb", Namespace = "http://www.ebxml.org/namespaces/messageHeader")]
public partial class Service
{
    [System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
    public string? type { get; set; }

    [System.Xml.Serialization.XmlText()]
    public string? Value { get; set; }

}

[System.Diagnostics.DebuggerStepThrough()]
[System.CodeDom.Compiler.GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "wsse", Namespace = "http://schemas.xmlsoap.org/ws/2002/12/secext")]
public partial class Security
{

    public SecurityUsernameToken? UsernameToken { get; set; }
    public string? SabreAth { get; set; }
    public string? BinarySecurityToken { get; set; }
}


[System.Diagnostics.DebuggerStepThrough()]
[System.CodeDom.Compiler.GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "wsse", Namespace = "http://schemas.xmlsoap.org/ws/2002/12/secext")]
public partial class SecurityUsernameToken
{
    public string? Username { get; set; }
    public string? Password { get; set; }

    [System.Xml.Serialization.XmlElement("NewPassword")]
    public string[]? NewPassword { get; set; }

    [System.Xml.Serialization.XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string? Organization { get; set; }

    [System.Xml.Serialization.XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string? Domain { get; set; }

    [System.Xml.Serialization.XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string? Lniata { get; set; }

    [System.Xml.Serialization.XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string? LockId { get; set; }
}

