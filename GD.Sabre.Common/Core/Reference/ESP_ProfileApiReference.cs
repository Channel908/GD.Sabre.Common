using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

[assembly: ContractNamespace("http://webservices.sabre.com", ClrNamespace = "webservices.sabre.com")]


namespace GD.Sabre.Common.Core.Reference;

public enum Sabre_OTA_ProfileRQTarget
{
    Test,
    Production,
}

public partial class AccessInfoType
{

    [XmlAttribute()]
    public string EPRDomainID { get; set; }

    [XmlAttribute()]
    public string DutyCd { get; set; }
    [XmlAttribute()]
    public string UserID { get; set; }
    [XmlAttribute()]
    public string LDAPDomain { get; set; }
    [XmlAttribute()]
    public string LNIATA { get; set; }
    [XmlAttribute()]
    public string AgentSine { get; set; }
    [XmlAttribute()]
    public string AgentGivenName { get; set; }
    [XmlAttribute()]
    public string AgentMiddleName { get; set; }
    [XmlAttribute()]
    public string AgentSurName { get; set; }
}


[System.Diagnostics.DebuggerStepThrough()]
[System.CodeDom.Compiler.GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Namespace = "http://www.sabre.com/eps/schemas")]
public partial class Sabre_OTA_ProfileCreateRQ : object, IExtensibleDataObject
{
    //[System.Xml.Serialization.XmlElementAttribute("Filter", typeof(FilterType))]
    //[System.Xml.Serialization.XmlElementAttribute("Profile", typeof(ProfileType))]
    [DataMember(EmitDefaultValue = false)]
    [XmlAnyElement]
    public XmlElement[] Content { get; set; }

    public ExtensionDataObject ExtensionData { get; set; }

    public Sabre_OTA_ProfileCreateRQ()
    {
        Target = Sabre_OTA_ProfileRQTarget.Production;
        Version = "6.19";
        IgnoreDataErrors = YesNoType.N;
        UpdateByDataSourceInfo = YesNoType.N;
        ProfileDuplicateCheck = YesNoType.N;
        GenerateLoginID = YesNoType.N;
        GeneratePassword = YesNoType.N;
        GenerateMembershipID = YesNoType.N;
        IgnoreStatusCheck = YesNoType.N;
    }

    public AccessInfoType CreateAccessInfo { get; set; }

    [XmlAttribute()]
    public DateTime TimeStamp { get; set; }

    [XmlIgnore()]
    public bool TimeStampSpecified { get; set; }

    [XmlAttribute()]
    //[System.ComponentModel.DefaultValueAttribute(Sabre_OTA_ProfileRQTarget.Production)]
    public Sabre_OTA_ProfileRQTarget Target { get; set; }

    [XmlAttribute()]
    public string Version { get; set; }

    [XmlAttribute()]
    [System.ComponentModel.DefaultValueAttribute(YesNoType.N)]
    public YesNoType IgnoreDataErrors { get; set; }

    [XmlAttribute()]
    [System.ComponentModel.DefaultValueAttribute(YesNoType.N)]
    public YesNoType UpdateByDataSourceInfo { get; set; }

    [XmlAttribute()]
    [System.ComponentModel.DefaultValueAttribute(YesNoType.N)]
    public YesNoType ProfileDuplicateCheck { get; set; }

    [XmlAttribute()]
    [System.ComponentModel.DefaultValueAttribute(YesNoType.N)]
    public YesNoType GenerateLoginID { get; set; }

    [XmlAttribute()]
    [System.ComponentModel.DefaultValueAttribute(YesNoType.N)]
    public YesNoType GeneratePassword { get; set; }

    [XmlAttribute()]
    [System.ComponentModel.DefaultValueAttribute(YesNoType.N)]
    public YesNoType GenerateMembershipID { get; set; }

    [XmlAttribute()]
    public YesNoType IgnoreStatusCheck { get; set; }

    [XmlAttribute()]
    public string RequestTrackingID { get; set; }
}


[System.Diagnostics.DebuggerStepThrough()]
[System.CodeDom.Compiler.GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Namespace = "http://www.sabre.com/eps/schemas")]
public partial class Sabre_OTA_ProfileUpdateRQ : object, IExtensibleDataObject
{
    //[System.Xml.Serialization.XmlElementAttribute("Filter", typeof(FilterType))]
    //[System.Xml.Serialization.XmlElementAttribute("ProfileInfo", typeof(ProfileInfoType))]
    [DataMember(EmitDefaultValue = false)]
    [XmlAnyElement]
    public XmlElement[] Content { get; set; }

    public ExtensionDataObject ExtensionData { get; set; }


    public Sabre_OTA_ProfileUpdateRQ()
    {
        Version = "6.19";
        Target = Sabre_OTA_ProfileRQTarget.Production;
        IgnoreDataErrors = YesNoType.N;
        UpdateByDataSourceInfo = YesNoType.N;
        IgnoreTimeStampCheck = YesNoType.Y;
        IgnoreStatusCheck = YesNoType.N;
    }

    public AccessInfoType UpdateAccessInfo { get; set; }

    [XmlAttribute()]
    public DateTime TimeStamp { get; set; }

    /// <remarks/>
    [XmlIgnore()]
    public bool TimeStampSpecified { get; set; }

    [XmlAttribute()]
    //[System.ComponentModel.DefaultValueAttribute(Sabre_OTA_ProfileRQTarget.Production)]
    public Sabre_OTA_ProfileRQTarget Target { get; set; }

    [XmlAttribute()]
    public string Version { get; set; }

    [XmlAttribute()]
    [System.ComponentModel.DefaultValueAttribute(YesNoType.N)]
    public YesNoType IgnoreDataErrors { get; set; }

    [XmlAttribute()]
    [System.ComponentModel.DefaultValueAttribute(YesNoType.N)]
    public YesNoType UpdateByDataSourceInfo { get; set; }

    [XmlAttribute()]
    [System.ComponentModel.DefaultValueAttribute(YesNoType.N)]
    public YesNoType IgnoreTimeStampCheck { get; set; }

    [XmlAttribute()]
    [System.ComponentModel.DefaultValueAttribute(YesNoType.N)]
    public YesNoType IgnoreStatusCheck { get; set; }
}

[System.Diagnostics.DebuggerStepThrough()]
[System.CodeDom.Compiler.GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "Sabre_OTA_ProfileCreateRS", Namespace = "http://www.sabre.com/eps/schemas")]
public partial class Sabre_OTA_ProfileCreateRS : Sabre_OTA_ProfileRS { }

[System.Diagnostics.DebuggerStepThrough()]
[System.CodeDom.Compiler.GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "Sabre_OTA_ProfileUpdateRS", Namespace = "http://www.sabre.com/eps/schemas")]
public partial class Sabre_OTA_ProfileUpdateRS : Sabre_OTA_ProfileRS { }

public abstract class Sabre_OTA_ResponseBase : object, IExtensibleDataObject
{
    public ExtensionDataObject ExtensionData { get; set; }

    public ResponseMessageType ResponseMessage { get; set; }

    [XmlAttribute()]
    public DateTime TimeStamp { get; set; }

    [XmlIgnore()]
    public bool TimeStampSpecified { get; set; }

    [XmlAttribute()]
    [System.ComponentModel.DefaultValue(Sabre_OTA_ProfileRQTarget.Production)]
    public Sabre_OTA_ProfileRQTarget Target { get; set; }

    [XmlAttribute()]
    public string Version { get; set; }
    [XmlAttribute()]
    public string RequestTrackingID { get; set; }


    [XmlAnyElement()]
    public XmlElement[] Any { get; set; }

    [XmlAnyAttribute()]
    public XmlAttribute[] AnyAttr { get; set; }
}

public abstract class Sabre_OTA_ProfileRS : Sabre_OTA_ResponseBase
{
    //[System.Xml.Serialization.XmlElementAttribute("Association", typeof(AssociationIdentityType))]
    //[System.Xml.Serialization.XmlElementAttribute("Filter", typeof(FilterIdentityType))]
    //[System.Xml.Serialization.XmlElementAttribute("Format", typeof(FormatIdentityType))]
    //[System.Xml.Serialization.XmlElementAttribute("Metadata", typeof(MetadataIdentityType))]
    //[System.Xml.Serialization.XmlElementAttribute("Profile", typeof(TPAIdentityType))]
    //[System.Xml.Serialization.XmlElementAttribute("Template", typeof(TemplateIdentityType))]
    //[System.Xml.Serialization.XmlElementAttribute("Validator", typeof(ValidatorIdentityType))]
    [XmlElement(IsNullable = true)]
    public FilterIdentityType Filter { get; set; }
    [XmlElement(IsNullable = true)]
    public TPAIdentityType Profile { get; set; }

    //[DataMember(EmitDefaultValue = false)]
    //public System.Xml.XmlElement SubmitXmlResult { get; set; }

    [XmlAttribute()]
    public DateTime CreateDateTime { get; set; }

    [XmlIgnore()]
    public bool CreateDateTimeSpecified { get; set; }

    [XmlAttribute()]
    public DateTime UpdateDateTime { get; set; }

    [XmlIgnore()]
    public bool UpdateDateTimeSpecified { get; set; }

}

public partial class ResponseMessageType
{
    public ErrorsType Errors { get; set; }
    public SuccessType Success { get; set; }
    public WarningsType Warnings { get; set; }
}


public partial class ErrorsType
{

    [XmlElement("ErrorMessage")]
    public ErrorMessageType[] ErrorMessage { get; set; }
}


public partial class ErrorMessageType
{
    [XmlAttribute()]
    public string ErrorCode { get; set; }

    [XmlText()]
    public string Value { get; set; }
}

public partial class SuccessType { }


public partial class WarningsType
{
    [XmlElement("WarningMessage")]
    public WarningMessageType[] WarningMessage { get; set; }
}

public partial class WarningMessageType
{
    [XmlAttribute()]
    public string WarningCode { get; set; }

    [XmlText()]
    public string Value { get; set; }
}

public partial class FilterIdentityType
{
    [XmlAttribute()]
    public string FilterID { get; set; }

    [XmlAttribute()]
    public string FilterName { get; set; }

    [XmlAttribute()]
    public string DomainID { get; set; }

    [XmlAttribute()]
    public string ClientCode { get; set; }

    [XmlAttribute()]
    public string ClientContextCode { get; set; }
}


