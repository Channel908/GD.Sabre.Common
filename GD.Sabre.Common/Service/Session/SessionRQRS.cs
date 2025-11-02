using GD.Sabre.Common.Core.Reference;
using System.Runtime.Serialization;

namespace GD.Sabre.Common.Service.Session;

[DataContract(Namespace = "http://www.sabre.com/eps/schemas")]
public partial class SessionCreateRQ
{
    public SessionCreateRQPOS? POS { get; set; }
}



public partial class SessionCreateRQPOS
{
    public SessionCreateRQPOSSource? Source { get; set; }
}


public partial class SessionCreateRQPOSSource
{
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? PseudoCityCode { get; set; }
}

[DataContract(Namespace = "http://www.sabre.com/eps/schemas")]
public partial class SessionCloseRQ
{
    public SessionCloseRQPOS? POS { get; set; }
}
public partial class SessionCloseRQPOS
{
    public SessionCloseRQPOSSource? Source { get; set; }
}

public partial class SessionCloseRQPOSSource
{
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? PseudoCityCode { get; set; }
}



[DataContract(Namespace = "http://www.opentravel.org/OTA/2002/11")]
public partial class SessionCreateRS
{
    public SessionCreateRS()
    {
        this.Target = Sabre_OTA_ProfileRQTarget.Production;
    }

    public SessionCreateRSSuccess? Success { get; set; }
    public SessionCreateRSWarnings? Warnings { get; set; }
    public string? ConversationId { get; set; }
    public SessionCreateRSErrors? Errors { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? EchoToken { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? TimeStamp { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(Sabre_OTA_ProfileRQTarget.Production)]
    public Sabre_OTA_ProfileRQTarget Target { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? version { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "nonNegativeInteger")]
    public string? SequenceNmbr { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "language")]
    public string? PrimaryLangID { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "language")]
    public string? AltLangID { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? status { get; set; }
}

public partial class SessionCreateRSSuccess { }

public partial class SessionCreateRSWarnings
{
    public SessionCreateRSWarningsWarning? Warning { get; set; }
}

public partial class SessionCreateRSWarningsWarning
{

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Language { get; set; }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ShortText { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Type { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Code { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
    public string? DocURL { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Status { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Tag { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? RecordId { get; set; }
}

public partial class SessionCreateRSErrors
{
    public SessionCreateRSErrorsError? Error { get; set; }
}

public partial class SessionCreateRSErrorsError
{
    public SessionCreateRSErrorsErrorErrorInfo ErrorInfo { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ErrorCode { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Severity { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ErrorMessage { get; set; }
}

public partial class SessionCreateRSErrorsErrorErrorInfo
{
    public string? Message { get; set; }
}

[DataContract(Namespace = "http://www.opentravel.org/OTA/2002/11")]
public partial class SessionCloseRS
{
    public SessionCloseRS()
    {
        this.Target = SessionCloseRSTarget.Production;
    }

    public SessionCloseRSSuccess Success { get; set; }
    public SessionCloseRSWarnings Warnings { get; set; }
    public string ConversationId { get; set; }

    public SessionCloseRSErrors Errors { get; set; }

    [System.Xml.Serialization.XmlAttribute()]
    public string EchoToken { get; set; }

    [System.Xml.Serialization.XmlAttribute()]
    public string TimeStamp { get; set; }

    [System.Xml.Serialization.XmlAttribute()]
    [System.ComponentModel.DefaultValue(SessionCloseRSTarget.Production)]
    public SessionCloseRSTarget Target { get; set; }

    [System.Xml.Serialization.XmlAttribute()]
    public string Version { get; set; }

    [System.Xml.Serialization.XmlAttribute(DataType = "nonNegativeInteger")]
    public string SequenceNmbr { get; set; }

    [System.Xml.Serialization.XmlAttribute(DataType = "language")]
    public string PrimaryLangID { get; set; }

    [System.Xml.Serialization.XmlAttribute(DataType = "language")]
    public string AltLangID { get; set; }
    [System.Xml.Serialization.XmlAttribute()]
    public string status { get; set; }

}

public partial class SessionCloseRSSuccess
{
}

public partial class SessionCloseRSWarnings
{

    public SessionCloseRSWarningsWarning Warning { get; set; }

}

public partial class SessionCloseRSErrors
{

    public SessionCloseRSErrorsError Error { get; set; }
}


public partial class SessionCloseRSWarningsWarning
{
    [System.Xml.Serialization.XmlAttribute()]
    public string Language { get; set; }

    [System.Xml.Serialization.XmlAttribute()]
    public string ShortText { get; set; }

    [System.Xml.Serialization.XmlAttribute()]
    public string Type { get; set; }

    [System.Xml.Serialization.XmlAttribute()]
    public string Code { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
    public string DocURL { get; set; }

    [System.Xml.Serialization.XmlAttribute()]
    public string Status { get; set; }

    [System.Xml.Serialization.XmlAttribute()]
    public string Tag { get; set; }

    [System.Xml.Serialization.XmlAttribute()]
    public string RecordId { get; set; }


}

public partial class SessionCloseRSErrorsError
{
    public SessionCloseRSErrorsErrorErrorInfo ErrorInfo { get; set; }

    [System.Xml.Serialization.XmlAttribute()]
    public string ErrorCode { get; set; }

    [System.Xml.Serialization.XmlAttribute()]
    public string Severity { get; set; }

    [System.Xml.Serialization.XmlAttribute()]
    public string ErrorMessage { get; set; }
}

public partial class SessionCloseRSErrorsErrorErrorInfo
{


    /// <remarks/>
    public string Message { get; set; }

}

public enum SessionCloseRSTarget
{

    /// <remarks/>
    Test,

    /// <remarks/>
    Production,
}

