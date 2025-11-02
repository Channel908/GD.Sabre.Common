using System.Runtime.Serialization;
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://webservices.sabre.com", ClrNamespace = "webservices.sabre.com")]
namespace GD.Sabre.Common.Service.AAA;

[DataContract(Namespace = "http://webservices.sabre.com/sabreXML/2003/07")]


public partial class ChangeAAARQ
{

    private ChangeAAARQPOS pOSField;

    private ChangeAAARQTPA_Extensions tPA_ExtensionsField;

    private ChangeAAARQAAA aAAField;

    private string echoTokenField;

    private string timeStampField;

    private string targetField;

    private string versionField;

    private string sequenceNmbrField;

    private string primaryLangIDField;

    private string altLangIDField;

    public ChangeAAARQ()
    {
        this.targetField = "Production";
    }

    /// <remarks/>
    public ChangeAAARQPOS POS
    {
        get
        {
            return this.pOSField;
        }
        set
        {
            this.pOSField = value;
        }
    }

    /// <remarks/>
    public ChangeAAARQTPA_Extensions TPA_Extensions
    {
        get
        {
            return this.tPA_ExtensionsField;
        }
        set
        {
            this.tPA_ExtensionsField = value;
        }
    }

    /// <remarks/>
    public ChangeAAARQAAA AAA
    {
        get
        {
            return this.aAAField;
        }
        set
        {
            this.aAAField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string EchoToken
    {
        get
        {
            return this.echoTokenField;
        }
        set
        {
            this.echoTokenField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string TimeStamp
    {
        get
        {
            return this.timeStampField;
        }
        set
        {
            this.timeStampField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute("Production")]
    public string Target
    {
        get
        {
            return this.targetField;
        }
        set
        {
            this.targetField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Version
    {
        get
        {
            return this.versionField;
        }
        set
        {
            this.versionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "nonNegativeInteger")]
    public string SequenceNmbr
    {
        get
        {
            return this.sequenceNmbrField;
        }
        set
        {
            this.sequenceNmbrField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "language")]
    public string PrimaryLangID
    {
        get
        {
            return this.primaryLangIDField;
        }
        set
        {
            this.primaryLangIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "language")]
    public string AltLangID
    {
        get
        {
            return this.altLangIDField;
        }
        set
        {
            this.altLangIDField = value;
        }
    }
}
public partial class ChangeAAARQPOS
{

    private ChangeAAARQPOSSource sourceField;

    /// <remarks/>
    public ChangeAAARQPOSSource Source
    {
        get
        {
            return this.sourceField;
        }
        set
        {
            this.sourceField = value;
        }
    }
}
public partial class ChangeAAARQPOSSource
{

    private ChangeAAARQPOSSourceRequestorID requestorIDField;

    private ChangeAAARQPOSSourcePosition positionField;

    private ChangeAAARQPOSSourceBookingChannel bookingChannelField;

    private string agentSineField;

    private string pseudoCityCodeField;

    private string iSOCountryField;

    private string iSOCurrencyField;

    private string agentDutyCodeField;

    private string airlineVendorIDField;

    private string airportCodeField;

    private string firstDepartPointField;

    private string eRSP_UserIDField;

    /// <remarks/>
    public ChangeAAARQPOSSourceRequestorID RequestorID
    {
        get
        {
            return this.requestorIDField;
        }
        set
        {
            this.requestorIDField = value;
        }
    }

    /// <remarks/>
    public ChangeAAARQPOSSourcePosition Position
    {
        get
        {
            return this.positionField;
        }
        set
        {
            this.positionField = value;
        }
    }

    /// <remarks/>
    public ChangeAAARQPOSSourceBookingChannel BookingChannel
    {
        get
        {
            return this.bookingChannelField;
        }
        set
        {
            this.bookingChannelField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string AgentSine
    {
        get
        {
            return this.agentSineField;
        }
        set
        {
            this.agentSineField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string PseudoCityCode
    {
        get
        {
            return this.pseudoCityCodeField;
        }
        set
        {
            this.pseudoCityCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ISOCountry
    {
        get
        {
            return this.iSOCountryField;
        }
        set
        {
            this.iSOCountryField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ISOCurrency
    {
        get
        {
            return this.iSOCurrencyField;
        }
        set
        {
            this.iSOCurrencyField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string AgentDutyCode
    {
        get
        {
            return this.agentDutyCodeField;
        }
        set
        {
            this.agentDutyCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string AirlineVendorID
    {
        get
        {
            return this.airlineVendorIDField;
        }
        set
        {
            this.airlineVendorIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string AirportCode
    {
        get
        {
            return this.airportCodeField;
        }
        set
        {
            this.airportCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string FirstDepartPoint
    {
        get
        {
            return this.firstDepartPointField;
        }
        set
        {
            this.firstDepartPointField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ERSP_UserID
    {
        get
        {
            return this.eRSP_UserIDField;
        }
        set
        {
            this.eRSP_UserIDField = value;
        }
    }
}
public partial class ChangeAAARQPOSSourceRequestorID
{

    private ChangeAAARQPOSSourceRequestorIDCompanyName companyNameField;

    private string uRLField;

    private string typeField;

    private string instanceField;

    private string idField;

    private string iD_ContextField;

    /// <remarks/>
    public ChangeAAARQPOSSourceRequestorIDCompanyName CompanyName
    {
        get
        {
            return this.companyNameField;
        }
        set
        {
            this.companyNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
    public string URL
    {
        get
        {
            return this.uRLField;
        }
        set
        {
            this.uRLField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Instance
    {
        get
        {
            return this.instanceField;
        }
        set
        {
            this.instanceField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ID_Context
    {
        get
        {
            return this.iD_ContextField;
        }
        set
        {
            this.iD_ContextField = value;
        }
    }
}
public partial class ChangeAAARQPOSSourceRequestorIDCompanyName
{

    private string companyShortNameField;

    private string travelSectorField;

    private string codeField;

    private string codeContextField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CompanyShortName
    {
        get
        {
            return this.companyShortNameField;
        }
        set
        {
            this.companyShortNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string TravelSector
    {
        get
        {
            return this.travelSectorField;
        }
        set
        {
            this.travelSectorField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CodeContext
    {
        get
        {
            return this.codeContextField;
        }
        set
        {
            this.codeContextField = value;
        }
    }
}
public partial class ChangeAAARQPOSSourcePosition
{

    private string latitudeField;

    private string longitudeField;

    private string altitudeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Latitude
    {
        get
        {
            return this.latitudeField;
        }
        set
        {
            this.latitudeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Longitude
    {
        get
        {
            return this.longitudeField;
        }
        set
        {
            this.longitudeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Altitude
    {
        get
        {
            return this.altitudeField;
        }
        set
        {
            this.altitudeField = value;
        }
    }
}
public partial class ChangeAAARQPOSSourceBookingChannel
{

    private ChangeAAARQPOSSourceBookingChannelCompanyName companyNameField;

    private string typeField;

    private bool primaryField;

    private bool primaryFieldSpecified;

    /// <remarks/>
    public ChangeAAARQPOSSourceBookingChannelCompanyName CompanyName
    {
        get
        {
            return this.companyNameField;
        }
        set
        {
            this.companyNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool Primary
    {
        get
        {
            return this.primaryField;
        }
        set
        {
            this.primaryField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool PrimarySpecified
    {
        get
        {
            return this.primaryFieldSpecified;
        }
        set
        {
            this.primaryFieldSpecified = value;
        }
    }
}
public partial class ChangeAAARQPOSSourceBookingChannelCompanyName
{

    private string companyShortNameField;

    private string travelSectorField;

    private string codeField;

    private string codeContextField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CompanyShortName
    {
        get
        {
            return this.companyShortNameField;
        }
        set
        {
            this.companyShortNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string TravelSector
    {
        get
        {
            return this.travelSectorField;
        }
        set
        {
            this.travelSectorField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CodeContext
    {
        get
        {
            return this.codeContextField;
        }
        set
        {
            this.codeContextField = value;
        }
    }
}
public partial class ChangeAAARQTPA_Extensions
{

    private ChangeAAARQTPA_ExtensionsMessagingDetails messagingDetailsField;

    /// <remarks/>
    public ChangeAAARQTPA_ExtensionsMessagingDetails MessagingDetails
    {
        get
        {
            return this.messagingDetailsField;
        }
        set
        {
            this.messagingDetailsField = value;
        }
    }
}
public partial class ChangeAAARQTPA_ExtensionsMessagingDetails
{

    private ChangeAAARQTPA_ExtensionsMessagingDetailsMDRSubset mDRSubsetField;

    /// <remarks/>
    public ChangeAAARQTPA_ExtensionsMessagingDetailsMDRSubset MDRSubset
    {
        get
        {
            return this.mDRSubsetField;
        }
        set
        {
            this.mDRSubsetField = value;
        }
    }
}
public partial class ChangeAAARQTPA_ExtensionsMessagingDetailsMDRSubset
{

    private string codeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }
}
public partial class ChangeAAARQAAA
{

    private string pseudoCityCodeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string PseudoCityCode
    {
        get
        {
            return this.pseudoCityCodeField;
        }
        set
        {
            this.pseudoCityCodeField = value;
        }
    }
}

[DataContract(Namespace = "http://webservices.sabre.com/sabreXML/2003/07")]

public partial class ChangeAAARS
{

    private string successField;

    private ChangeAAARSWarnings warningsField;

    private ChangeAAARSSource sourceField;

    private string dateField;

    private string textField;

    private ChangeAAARSTPA_Extensions tPA_ExtensionsField;

    private ChangeAAARSErrors errorsField;

    private string echoTokenField;

    private string timeStampField;

    private string targetField;

    private string versionField;

    private string sequenceNmbrField;

    private string primaryLangIDField;

    private string altLangIDField;

    public ChangeAAARS()
    {
        this.targetField = "Production";
    }

    /// <remarks/>
    public string Success
    {
        get
        {
            return this.successField;
        }
        set
        {
            this.successField = value;
        }
    }

    /// <remarks/>
    public ChangeAAARSWarnings Warnings
    {
        get
        {
            return this.warningsField;
        }
        set
        {
            this.warningsField = value;
        }
    }

    /// <remarks/>
    public ChangeAAARSSource Source
    {
        get
        {
            return this.sourceField;
        }
        set
        {
            this.sourceField = value;
        }
    }

    /// <remarks/>
    public string Date
    {
        get
        {
            return this.dateField;
        }
        set
        {
            this.dateField = value;
        }
    }

    /// <remarks/>
    public string Text
    {
        get
        {
            return this.textField;
        }
        set
        {
            this.textField = value;
        }
    }

    /// <remarks/>
    public ChangeAAARSTPA_Extensions TPA_Extensions
    {
        get
        {
            return this.tPA_ExtensionsField;
        }
        set
        {
            this.tPA_ExtensionsField = value;
        }
    }

    /// <remarks/>
    public ChangeAAARSErrors Errors
    {
        get
        {
            return this.errorsField;
        }
        set
        {
            this.errorsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string EchoToken
    {
        get
        {
            return this.echoTokenField;
        }
        set
        {
            this.echoTokenField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string TimeStamp
    {
        get
        {
            return this.timeStampField;
        }
        set
        {
            this.timeStampField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute("Production")]
    public string Target
    {
        get
        {
            return this.targetField;
        }
        set
        {
            this.targetField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Version
    {
        get
        {
            return this.versionField;
        }
        set
        {
            this.versionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "nonNegativeInteger")]
    public string SequenceNmbr
    {
        get
        {
            return this.sequenceNmbrField;
        }
        set
        {
            this.sequenceNmbrField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "language")]
    public string PrimaryLangID
    {
        get
        {
            return this.primaryLangIDField;
        }
        set
        {
            this.primaryLangIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "language")]
    public string AltLangID
    {
        get
        {
            return this.altLangIDField;
        }
        set
        {
            this.altLangIDField = value;
        }
    }
}
public partial class ChangeAAARSWarnings
{

    private ChangeAAARSWarningsWarning warningField;

    /// <remarks/>
    public ChangeAAARSWarningsWarning Warning
    {
        get
        {
            return this.warningField;
        }
        set
        {
            this.warningField = value;
        }
    }
}
public partial class ChangeAAARSWarningsWarning
{

    private string languageField;

    private string shortTextField;

    private string typeField;

    private string codeField;

    private string docURLField;

    private string statusField;

    private string tagField;

    private string recordIdField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Language
    {
        get
        {
            return this.languageField;
        }
        set
        {
            this.languageField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ShortText
    {
        get
        {
            return this.shortTextField;
        }
        set
        {
            this.shortTextField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
    public string DocURL
    {
        get
        {
            return this.docURLField;
        }
        set
        {
            this.docURLField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Status
    {
        get
        {
            return this.statusField;
        }
        set
        {
            this.statusField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Tag
    {
        get
        {
            return this.tagField;
        }
        set
        {
            this.tagField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string RecordId
    {
        get
        {
            return this.recordIdField;
        }
        set
        {
            this.recordIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}
public partial class ChangeAAARSSource
{

    private string agentSineField;

    private string pseudoCityCodeField;

    private string homePseudoCityCodeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string AgentSine
    {
        get
        {
            return this.agentSineField;
        }
        set
        {
            this.agentSineField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string PseudoCityCode
    {
        get
        {
            return this.pseudoCityCodeField;
        }
        set
        {
            this.pseudoCityCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string HomePseudoCityCode
    {
        get
        {
            return this.homePseudoCityCodeField;
        }
        set
        {
            this.homePseudoCityCodeField = value;
        }
    }
}
public partial class ChangeAAARSTPA_Extensions
{

    private string hostCommandField;

    /// <remarks/>
    public string HostCommand
    {
        get
        {
            return this.hostCommandField;
        }
        set
        {
            this.hostCommandField = value;
        }
    }
}
public partial class ChangeAAARSErrors
{

    private ChangeAAARSErrorsError errorField;

    /// <remarks/>
    public ChangeAAARSErrorsError Error
    {
        get
        {
            return this.errorField;
        }
        set
        {
            this.errorField = value;
        }
    }
}
public partial class ChangeAAARSErrorsError
{

    private ChangeAAARSErrorsErrorErrorInfo errorInfoField;

    private string errorCodeField;

    private string severityField;

    private string errorMessageField;

    /// <remarks/>
    public ChangeAAARSErrorsErrorErrorInfo ErrorInfo
    {
        get
        {
            return this.errorInfoField;
        }
        set
        {
            this.errorInfoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ErrorCode
    {
        get
        {
            return this.errorCodeField;
        }
        set
        {
            this.errorCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Severity
    {
        get
        {
            return this.severityField;
        }
        set
        {
            this.severityField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ErrorMessage
    {
        get
        {
            return this.errorMessageField;
        }
        set
        {
            this.errorMessageField = value;
        }
    }
}
public partial class ChangeAAARSErrorsErrorErrorInfo
{

    private string messageField;

    /// <remarks/>
    public string Message
    {
        get
        {
            return this.messageField;
        }
        set
        {
            this.messageField = value;
        }
    }
}
