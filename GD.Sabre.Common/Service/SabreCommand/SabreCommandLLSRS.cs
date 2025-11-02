using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Runtime.Serialization;
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://webservices.sabre.com", ClrNamespace = "webservices.sabre.com")]
namespace GD.Sabre.Common.Service.SabreCommand;

[DataContract(Namespace = "http://webservices.sabre.com/sabreXML/2011/10")]
public partial class SabreCommandLLSRQ
{



    private SabreCommandLLSRQRequest requestField;

    private string echoTokenField;

    private string timeStampField;

    private SabreCommandLLSRQTarget targetField;

    private string versionField;

    private string sequenceNmbrField;

    private string primaryLangIDField;

    private string altLangIDField;

    public SabreCommandLLSRQ()
    {
        this.targetField = SabreCommandLLSRQTarget.Production;
    }

    /// <remarks/>
    public SabreCommandLLSRQRequest Request
    {
        get
        {
            return this.requestField;
        }
        set
        {
            this.requestField = value;
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
    [System.ComponentModel.DefaultValueAttribute(SabreCommandLLSRQTarget.Production)]
    public SabreCommandLLSRQTarget Target
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

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool ReturnHostCommand { get; set; }

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

public partial class SabreCommandLLSRQRequest
{

    private string hostCommandField;

    private SabreCommandLLSRQRequestOutput outputField;

    private string mDRSubsetField;

    private bool cDATAField;

    public SabreCommandLLSRQRequest()
    {
        this.cDATAField = false;
    }

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

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public SabreCommandLLSRQRequestOutput Output
    {
        get
        {
            return this.outputField;
        }
        set
        {
            this.outputField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string MDRSubset
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

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(false)]
    public bool CDATA
    {
        get
        {
            return this.cDATAField;
        }
        set
        {
            this.cDATAField = value;
        }
    }
}

public enum SabreCommandLLSRQRequestOutput
{

    /// <remarks/>
    SCREEN,

    /// <remarks/>
    SDS,

    /// <remarks/>
    SDSXML,

    /// <remarks/>
    DATABAHN,
}

public enum SabreCommandLLSRQTarget
{

    /// <remarks/>
    Test,

    /// <remarks/>
    Production,
}

[DataContract(Namespace = "http://webservices.sabre.com/sabreXML/2011/10")]
public partial class SabreCommandLLSRS
{
    private ApplicationResults applicationResultsField;
    private string responseField;

    private SabreCommandLLSRSXML_Content xML_ContentField;

    private SabreCommandLLSRSErrorRS errorRSField;

    private string echoTokenField;

    private string timeStampField;

    private SabreCommandLLSRSTarget targetField;

    private string versionField;

    private string sequenceNmbrField;

    private string primaryLangIDField;

    private string altLangIDField;

    public SabreCommandLLSRS()
    {
        this.targetField = SabreCommandLLSRSTarget.Production;
    }

    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://services.sabre.com/STL/v01")]
    public ApplicationResults ApplicationResults
    {
        get
        {
            return this.applicationResultsField;
        }
        set
        {
            this.applicationResultsField = value;
        }
    }

    /// <remarks/>
    public string Response
    {
        get
        {
            return this.responseField;
        }
        set
        {
            this.responseField = value;
        }
    }

    /// <remarks/>
    public SabreCommandLLSRSXML_Content XML_Content
    {
        get
        {
            return this.xML_ContentField;
        }
        set
        {
            this.xML_ContentField = value;
        }
    }

    /// <remarks/>
    public SabreCommandLLSRSErrorRS ErrorRS
    {
        get
        {
            return this.errorRSField;
        }
        set
        {
            this.errorRSField = value;
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
    [System.ComponentModel.DefaultValueAttribute(SabreCommandLLSRSTarget.Production)]
    public SabreCommandLLSRSTarget Target
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

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string HostCommand { get; set; }

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


public partial class ApplicationResults
{
    public Success Success { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string status { get; set; }
}

public partial class Success
{
    public SystemSpecificResults SystemSpecificResults { get; set; }
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string timeStamp { get; set; }
}

public partial class SystemSpecificResults
{
    public string HostCommand { get; set; }
}

public partial class SabreCommandLLSRSXML_Content
{

    private System.Xml.XmlElement[] anyField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAnyElementAttribute()]
    public System.Xml.XmlElement[] Any
    {
        get
        {
            return this.anyField;
        }
        set
        {
            this.anyField = value;
        }
    }
}

public partial class SabreCommandLLSRSErrorRS
{

    private SabreCommandLLSRSErrorRSErrors errorsField;

    /// <remarks/>
    public SabreCommandLLSRSErrorRSErrors Errors
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
}

public partial class SabreCommandLLSRSErrorRSErrors
{

    private SabreCommandLLSRSErrorRSErrorsError errorField;

    /// <remarks/>
    public SabreCommandLLSRSErrorRSErrorsError Error
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

public partial class SabreCommandLLSRSErrorRSErrorsError
{

    private SabreCommandLLSRSErrorRSErrorsErrorErrorInfo errorInfoField;

    private string errorCodeField;

    private string severityField;

    private string errorMessageField;

    /// <remarks/>
    public SabreCommandLLSRSErrorRSErrorsErrorErrorInfo ErrorInfo
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

public partial class SabreCommandLLSRSErrorRSErrorsErrorErrorInfo
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

public enum SabreCommandLLSRSTarget
{

    /// <remarks/>
    Test,

    /// <remarks/>
    Production,
}

