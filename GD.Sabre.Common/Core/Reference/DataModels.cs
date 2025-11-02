
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GD.Sabre.Common.Core.Reference;



public enum YesNoType
{
    Y,
    N,
    U,
}

public enum ProfileTypeInfo
{

    TVL,
    AGT,
    AGY,
    CRP,
    OPX,
    ALC,
    GRP,
}

public enum StatusType
{
    AC,
    DL,
    IN,
    DE,
    NA,
    MP,
    MG,
    DM,
}

public enum SubjectAreaNamesType
{

    Association,
    PersonName,
    Telephone,
    Email,
    Address,
    Document,
    CustLoyalty,
    EmergencyContactPerson,
    EmploymentInfo,
    PaymentForm,
    RelatedIndividual,
    AirlinePref,
    HotelPref,
    VehicleRentalPref,
    RailPref,
    GroundTransportationPref,
    NotificationPref,
    Consent,
    PsychographicCategory,
    PriorityRemarks,
    Remark,
    SSR,
    OSI,
    CustomerReferenceInfo,
    BusinessSystemIdentityInfo,
    AnalyticalInfoGroup,
    AssociatedProfiles,
    AssociatedFilters,
    DirectlyAssociatedFilters,
    TemplateAssociatedFilters,
    AssociatedTemplates,
    AssociatedFormats,
    Discounts,
    CustomDefinedData,
    CustomDefinedValues,
    TaxInfo,
    CustomProfileRoles,
    StandardProfileRoles,
    SabreTravelPolicyEngine,
    SabreCorporateTravelPolicy,
    TransactionalData,
    STARData,
    CustomerValueScore,
    EnrollmentInfo,
    MergedProfiles,
    AgencyContactName,
    AgencyInfo,
    GDS,
    Branding,
    QueueAssignments,
    Commissions,
    AgentName,
    AgentInfo,
    AgentRelatedIndividuals,
    AgentGDSIdentity,
    SabreSecurityEntityAttribute,
    Incentives,
    BusinessTravelerSetting,
    ContactName,
    CorporateInfo,
    GroupInfo,
    Login,
    [System.Xml.Serialization.XmlEnumAttribute("Login/@PasswordHash")]
    LoginPasswordHash,
    NumberOfAssocProfiles,
    SabreTravelPolicy,
}

public enum VIT_StarLineType
{
    Item,
    S,
    P,
    A,
    O,
    N,
    R,
    F,
}

public enum ConsentValueType
{
    Y,
    N,
    U,
}

public enum PaymentFormCheckCodeEnumType
{
    CK,
    CHECK,
    CHEQUE,
}

public enum AnalyticalInfoGroupTypeNameCode
{
    SeasonalTraveler,
}

public enum AnalyticalInfoGroupTypeTypeCode
{
    MarketingCampaign,
}

public enum AnalyticalInfoGroupTypeCategoryCode
{
    CustomerSegmentation,
}

public enum CriteriaGroupTypeConnective
{
    AND,
    OR,
}

public enum AttributeGroupTypeNameCode
{
    FirstLevelSegmentation,
    SecondLevelSegmentation,
}

public enum PaymentFormGovernmentWarrantTypeEnumType
{
    GR,
    GGR,
    FGR,
}

public enum AttributeTypeNameCode
{
    Segmentation,
    Confidence,
}

public enum CriteriaTypeNameCode
{
    TravelingMonth,
    TripType,
}

public enum CriteriaTypeOperator
{
    Equals,
    IN,
    //[System.Xml.Serialization.XmlEnumAttribute("NOT IN")]
    NOTIN,
}


public abstract class BaseNameType
{
    public string? NamePrefix { get; set; }
    public string? GivenName { get; set; }
    public string? MiddleName { get; set; }
    public string? SurName { get; set; }
    public string? NameSuffix { get; set; }
}

public abstract class BaseDataSource
{
    public DataSourceInfoType? DataSource { get; set; }
    public TransactionalDataType? TransactionalData { get; set; }
}

public abstract class BaseSequence
{
    public string? DisplaySequenceNo { get; set; }
    public string? OrderSequenceNo { get; set; }
}

public abstract class BaseTransactionalSequence : BaseSequence
{
    public TransactionalDataType? TransactionalData { get; set; }
}

public abstract class BaseDatasourceSequence : BaseTransactionalSequence
{
    public DataSourceInfoType? DataSource { get; set; }
}

public partial class BasePrefTransactionalSequence : BaseTransactionalSequence
{
    public string? PreferLevelCode { get; set; }
    public string? OrderPreferenceNo { get; set; }
    public string? InformationText { get; set; }
}

public partial class SecurityInfoType
{
    public string? SecurityQuestionCode { get; set; }

    public string? SecurityAnswerHash { get; set; }

}

public partial class LoginType
{


    public LoginType()
    {
        this.IsHashed = YesNoType.Y;
        PasswordExpiredSpecified = false;
    }
    public SecurityInfoType[] SecurityInfo { get; set; }

    public string? LoginID { get; set; }

    public string? PasswordHash { get; set; }

    public YesNoType PasswordExpired { get; set; }

    [System.ComponentModel.DefaultValueAttribute(false)]
    public bool PasswordExpiredSpecified { get; set; }

    public string? SiteName { get; set; }

    public string? SubSiteName { get; set; }

    public YesNoType IsHashed { get; set; }


}

public partial class ProfileSubTypeType
{
    public string? SubTypeCode { get; set; }

}

public partial class AuxiliaryIDType
{
    public string? IDTypeCode { get; set; }

    public string? Identifier { get; set; }

}

public abstract class TPAIdentityTypeBase
{

    public TPAIdentityTypeBase()
    {
        this.ProfileNameModifyIndicator = YesNoType.Y;
        this.ProfileTypeCode = ProfileTypeInfo.TVL;
        this.ProfileTypeCodeSpecified = false;
    }

    public LoginType? Login { get; set; }

    public ProfileSubTypeType[]? ProfileSubType { get; set; }

    public AuxiliaryIDType[]? AuxiliaryID { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ClientCode { get; set; }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ClientContextCode { get; set; }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? UniqueID { get; set; }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ProfileTypeInfo ProfileTypeCode { get; set; }


    [System.Xml.Serialization.XmlIgnore()]
    public bool ProfileTypeCodeSpecified { get; set; }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ProfileName { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public YesNoType ProfileNameModifyIndicator { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? DomainID { get; set; }

}

public partial class TPAIdentityType : TPAIdentityTypeBase
{

    public TPAIdentityType() : base()
    {
        this.ProfileStatusCode = StatusType.AC;
    }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ProfileDescription { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public StatusType ProfileStatusCode { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ProfilePurgeNoDays { get; set; }
}

public partial class ProfileTypeTPA_Identity : TPAIdentityType { }

public partial class IgnoreSubjectAreaType
{
    public SubjectAreaNamesType[]? SubjectAreaName { get; set; }

}

public partial class AssociationIDType
{
    public string? AssociationID { get; set; }

    public string? DomainID { get; set; }

    public string? ClientCode { get; set; }


}

public partial class CriteriaType
{
    //[System.Xml.Serialization.XmlArrayItemAttribute("Value", IsNullable = false)]
    public ValueType[]? Value { get; set; }

    public CriteriaTypeNameCode? NameCode { get; set; }

    public CriteriaTypeOperator? Operator { get; set; }

}


public partial class ProfileAssociationType : AssociationIDType
{
    public string? AssociationDescription { get; set; }


    public string? AssociationName { get; set; }


    public string? ClientContextCode { get; set; }


    public ProfileTypeInfo? ProfileTypeCode { get; set; }


    public bool? ProfileTypeCodeSpecified { get; set; }


    public System.DateTime CreateDateTime { get; set; }

    public bool? CreateDateTimeSpecified { get; set; }

    public System.DateTime UpdateDateTime { get; set; }

    public bool? UpdateDateTimeSpecified { get; set; }


    public YesNoType? Shared { get; set; }


}

public partial class CriteriaGroupType
{
    public CriteriaType[]? Criteria { get; set; }

    public CriteriaGroupTypeConnective? Connective { get; set; }

    public bool? ConnectiveSpecified { get; set; }

}

public partial class AttributeType
{
    public AttributeTypeNameCode? NameCode { get; set; }

    public string? Value { get; set; }

}


public partial class AttributeGroupType
{
    public AttributeType[]? Attribute { get; set; }

    public AttributeGroupTypeNameCode? NameCode { get; set; }

    public string? OrderSequenceNo { get; set; }

}


public partial class AnalyticalInfoType
{
    public CriteriaGroupType? CriteriaGroup { get; set; }

    public AttributeGroupType[]? CustomerAttributes { get; set; }

    public string? OrderSequenceNo { get; set; }

}


public partial class AnalyticalInfoGroupType
{
    public AnalyticalInfoType[]? AnalyticalInfo { get; set; }

    public AnalyticalInfoGroupTypeNameCode? NameCode { get; set; }

    public string? SourceCode { get; set; }

    public AnalyticalInfoGroupTypeTypeCode? TypeCode { get; set; }

    public bool? TypeCodeSpecified { get; set; }

    public AnalyticalInfoGroupTypeCategoryCode? CategoryCode { get; set; }

    public bool? CategoryCodeSpecified { get; set; }

    public System.DateTime LastUpdateTimestamps { get; set; }
    public bool? LastUpdateTimestampsSpecified { get; set; }

    public System.DateTime PurgeDate { get; set; }
    public bool? PurgeDateSpecified { get; set; }

    public string? OrderSequenceNo { get; set; }

}

public partial class AllianceProfileTypeTravelerPersonName : BaseNameType
{


}

public partial class AllianceMembershipLevelType
{
    public string? VendorCode { get; set; }

    public string? VendorTypeCode { get; set; }

    public string? TierLevelValue { get; set; }

}


public partial class AllianceProfileTypeTraveler
{
    public AllianceProfileTypeTravelerPersonName? PersonName { get; set; }

    public AllianceMembershipLevelType[]? AllianceMembershipLevel { get; set; }

}

public partial class DataSourceInfoType
{
    public string? PrimaryDS { get; set; }

}

public partial class TemplateGroupNameType
{
    public string? OrderSequenceNo { get; set; }

    public string? Value { get; set; }

}


public partial class TransactionalDataType
{
    public TemplateGroupNameType[]? TemplateGroupName { get; set; }

    public string? LanguageId { get; set; }

    public string? TemplateSubjectAreaCount { get; set; }

}


public partial class TaxInfoType : BaseDatasourceSequence
{
    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? TaxID { get; set; }


    public string? TaxTypeCode { get; set; }


    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

}


public partial class CorporateInfoType
{
    public TaxInfoType[]? TaxInfo { get; set; }


    public TransactionalDataType? TransactionalData { get; set; }

    public string? CompanyURL { get; set; }

    public string? NumberOfEmployees { get; set; }

    public string? CorporationName { get; set; }

    public string? CorporationTypeCode { get; set; }

    public string? CorporationIdentifier { get; set; }

    public string? NatureOfBusinessCode { get; set; }

    public YesNoType? CreditBankInd { get; set; }

    public bool? CreditBankIndSpecified { get; set; }

    public string? CharterNumber { get; set; }

    public string? InformationText { get; set; }

}

public partial class ContactNameType : BaseNameType
{
    public TransactionalDataType? TransactionalData { get; set; }

    public string? PreferredFirstName { get; set; }

    public string? PreferredLastName { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? LanguageIDCode { get; set; }

    public string? VendorLocationCode { get; set; }

    public string? VendorCode { get; set; }

    public string? ServiceTypeCode { get; set; }

    public string? DepartmentName { get; set; }

    public string? CompanyID { get; set; }

    public string? Comment { get; set; }

    public string? Title { get; set; }

    public string? CompanyName { get; set; }

    public string? ContactTypeCode { get; set; }

    public string? GenderCode { get; set; }

}

public partial class BldgRoomType
{
    public string? FloorWing { get; set; }

    public string? Room { get; set; }

    public string? Value { get; set; }

}

public partial class AddressType : BaseDatasourceSequence
{

    public string[]? AddressLine { get; set; }

    public string? MailStop { get; set; }

    public string? POBox { get; set; }

    public string? CityName { get; set; }

    public string? PostalCd { get; set; }

    public string? StateCode { get; set; }

    public string? CountryCode { get; set; }

    public string? StreetNmbr { get; set; }

    public BldgRoomType? BldgRoom { get; set; }

    public string? InformationText { get; set; }

    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? ContactRemark { get; set; }

    public string? LocationTypeCode { get; set; }

    public string? AddressUsageTypeCode { get; set; }

    public string? Attention { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? LanguageIDCode { get; set; }

    public VIT_StarLineType? VIT_LineType { get; set; }

    public bool? VIT_LineTypeSpecified { get; set; }

    public string? VIT_SecondaryQualifier { get; set; }

    public string? VIT_OrderNmbr { get; set; }

    public YesNoType? NewAddress { get; set; }

    public bool? NewAddressSpecified { get; set; }

}


public partial class ParsedPhoneNumberType
{
    public string? CountryCd { get; set; }

    public string? AreaCd { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Extension { get; set; }

}

public class PhoneNumberItemType
{
    public string? StringValue { get; set; }

    public ParsedPhoneNumberType? ParsedPhoneNumberValue { get; set; }


    public bool IsString => StringValue != null;
    public bool IsParsedPhoneNumber => ParsedPhoneNumberValue != null;

    public PhoneNumberItemType()
    {

    }

    public PhoneNumberItemType(string stringValue)
    {
        StringValue = stringValue;
    }

    public PhoneNumberItemType(ParsedPhoneNumberType parsedPhoneNumberValue)
    {
        ParsedPhoneNumberValue = parsedPhoneNumberValue;
    }
}

public partial class TelephoneType : BaseDatasourceSequence
{
    public PhoneNumberItemType? Item { get; set; }

    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? ContactRemark { get; set; }

    public string? LocationTypeCode { get; set; }

    public string? DeviceTypeCode { get; set; }

    public string? LanguageIDCode { get; set; }

    public string? ServiceProvider { get; set; }

    public string? DeviceVendor { get; set; }

    public string? DeviceBrand { get; set; }

    public string? DeviceModel { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? PurposeCode { get; set; }

    public string? PhoneCityCode { get; set; }

    public string? InformationText { get; set; }

    public VIT_StarLineType? VIT_LineType { get; set; }

    public bool? VIT_LineTypeSpecified { get; set; }

    public string? VIT_SecondaryQualifier { get; set; }

    public string? VIT_OrderNmbr { get; set; }

    public YesNoType? FaxDevice { get; set; }

    public bool? FaxDeviceSpecified { get; set; }

    public YesNoType? PNRTelephoneTagIndicator { get; set; }

    public bool? PNRTelephoneTagIndicatorSpecified { get; set; }

}

public partial class EmailType : BaseDatasourceSequence
{
    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? ContactRemark { get; set; }

    public string? EmailTypeCode { get; set; }

    public string? EmailUsageCode { get; set; }

    public string? FormatTypeCode { get; set; }

    public string? EmailAddress { get; set; }

    public string? PurposeCode { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? LanguageIDCode { get; set; }

    public string? EmailRemark { get; set; }

    public VIT_StarLineType? VIT_LineType { get; set; }

    public bool? VIT_LineTypeSpecified { get; set; }

    public string? VIT_SecondaryQualifier { get; set; }

    public string? VIT_OrderNmbr { get; set; }

}

public abstract class PaymentFormItemType { }

public partial class PaymentFormTypeAccountsReceivable : PaymentFormItemType
{
    public PaymentFormTypeAccountsReceivable()
    {
        this.Indicator = true;
    }

    public bool? Indicator { get; set; }

}

public partial class PaymentFormTypeCash : PaymentFormItemType
{
    public PaymentFormTypeCash()
    {
        this.Indicator = true;
    }
    public bool? Indicator { get; set; }

    public YesNoType? FirstRemark { get; set; }

    public bool? FirstRemarkSpecified { get; set; }

}

public partial class PaymentFormTypeCheck : PaymentFormItemType
{
    public PaymentFormTypeCheck()
    {
        this.PNRCheckCode = PaymentFormCheckCodeEnumType.CK;
    }
    public string? BankRoutingNumber { get; set; }

    public PaymentFormCheckCodeEnumType? PNRCheckCode { get; set; }

    public YesNoType? FirstRemark { get; set; }

    public bool? FirstRemarkSpecified { get; set; }

}

public partial class GovernmentWarrantType : PaymentFormItemType
{
    public YesNoType? FirstRemark { get; set; }

    public bool? FirstRemarkSpecified { get; set; }

    public PaymentFormGovernmentWarrantTypeEnumType? WarrantType { get; set; }

    public string? WarrantSubtype { get; set; }

    public string? WarrantNumber { get; set; }

    public string? DebtorCd { get; set; }

    public string? ObjectCd { get; set; }

}

public partial class CardHolderNameType : BaseNameType
{
    public string? CardHolderFullName { get; set; }

}

public partial class PaymentCardTypeCardIssuerName
{
    public string? IssueNumberText { get; set; }

    public string? IssuerName { get; set; }

}


public partial class PaymentCardType : PaymentFormItemType
{
    public PaymentCardType()
    {
        this.CCViewAccess = YesNoType.N;
    }
    public CardHolderNameType? CardHolderName { get; set; }

    public PaymentCardTypeCardIssuerName? CardIssuerName { get; set; }

    public AddressType[]? Address { get; set; }

    public string? CardTypeCode { get; set; }

    public string? BankCardVendorCode { get; set; }

    public string? CardNumber { get; set; }

    public string? MaskedCardNumber { get; set; }

    public string? CardToken { get; set; }

    public YesNoType? CCViewAccess { get; set; }

    public string? EffectiveDate { get; set; }

    public string? ExpireDate { get; set; }

    public YesNoType? FirstRemark { get; set; }

    public bool? FirstRemarkSpecified { get; set; }

    public string? ExtendedPaymentNumMonths { get; set; }

}


public partial class PaymentFormType : BaseDatasourceSequence
{
    public PaymentFormItemType? Item { get; set; }

    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? TripTypeCode { get; set; }

    public string? ServiceUsageTypeCode { get; set; }

    public string? InformationText { get; set; }

    public VIT_StarLineType? VIT_LineType { get; set; }

    public bool? VIT_LineTypeSpecified { get; set; }

    public string? VIT_SecondaryQualifier { get; set; }

    public string? VIT_OrderNmbr { get; set; }

    public string? PaymentFormNickName { get; set; }

}

public abstract class ContactType : BaseNameType
{
    public string? EmergencyContactEmail { get; set; }

    public TelephoneType[]? Telephone { get; set; }

    public EmailType[]? Email { get; set; }

    public AddressType[]? Address { get; set; }

    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? RelationTypeCode { get; set; }

    public string? RelationType { get; set; }

    public System.DateTime BirthDate { get; set; }
    public bool? BirthDateSpecified { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? InformationText { get; set; }

}


public partial class EmergencyContactPersonType : ContactType
{
}

public partial class PriorityRemarksType : BaseDatasourceSequence
{
    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? Text { get; set; }

    public string? CategoryCode { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

}

public partial class RemarkType : BaseDatasourceSequence
{
    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? Text { get; set; }

    public string? TypeCode { get; set; }

    public string? CategoryCode { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public VIT_StarLineType? VIT_LineType { get; set; }

    public bool? VIT_LineTypeSpecified { get; set; }

    public string? VIT_SecondaryQualifier { get; set; }

    public string? VIT_OrderNmbr { get; set; }

}

public partial class GDSType : BaseTransactionalSequence
{
    public TransactionalDataType? TransactionalData { get; set; }

    public string? GDSCode { get; set; }

    public string? HostPartitionCd { get; set; }

    public string? GDS_ProfileID { get; set; }

    public string? PrimaryMultiHostID { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

}

public partial class CustomerReferenceInfoType : BaseDatasourceSequence
{
    public DataSourceInfoType? DataSource { get; set; }

    /// <remarks/>
    public TransactionalDataType? TransactionalData { get; set; }

    public string? TripTypeCode { get; set; }

    public string? Type { get; set; }

    public string? BranchID { get; set; }

    public string? ReferenceID { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? InformationText { get; set; }

}

public partial class SSRType : BaseDatasourceSequence
{
    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? ServiceTypeCode { get; set; }

    public string? SSRCode { get; set; }

    public string? TypeCode { get; set; }

    public string? Text { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public VIT_StarLineType? VIT_LineType { get; set; }

    public bool? VIT_LineTypeSpecified { get; set; }

    public string? VIT_SecondaryQualifier { get; set; }

    public string? VIT_OrderNmbr { get; set; }

    public string? InformationText { get; set; }

}

public partial class OSIType : BaseDatasourceSequence
{
    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? ServiceTypeCode { get; set; }

    public string? TypeCode { get; set; }

    public string? Text { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public VIT_StarLineType? VIT_LineType { get; set; }

    public bool? VIT_LineTypeSpecified { get; set; }

    public string? VIT_SecondaryQualifier { get; set; }

    public string? VIT_OrderNmbr { get; set; }

    public string? InformationText { get; set; }

}

public partial class BusinessSystemIdentityInfoType : BaseDatasourceSequence
{
    public DataSourceInfoType? DataSource { get; set; }


    public TransactionalDataType? TransactionalData { get; set; }

    public string? SystemName { get; set; }

    public string? IdentifierType { get; set; }

    public string? ID { get; set; }

    public string? Description { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? InformationText { get; set; }

}

public partial class PNRMoveInfoType
{
    public TransactionalDataType? TransactionalData { get; set; }

    public string? AssocProfileFilterID { get; set; }

    public string? AssocProfileFilterName { get; set; }

}


public partial class AssociatedProfilesType : BaseTransactionalSequence
{
    public AssociatedProfilesType()
    {
        this.TemplateInheritInd = YesNoType.N;
    }
    public PNRMoveInfoType? PNRMoveInfo { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? AssocUniqueID { get; set; }

    public ProfileTypeInfo? AssocProfileTypeCode { get; set; }

    public string? AssocProfileName { get; set; }

    public string? AssocProfileDescription { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? DomainID { get; set; }

    public string? ClientCode { get; set; }

    public string? ClientContextCode { get; set; }

    public YesNoType? TemplateInheritInd { get; set; }

    public string? ProfileRelationTypeCode { get; set; }

    public string? ProfileRelationStatusCode { get; set; }

    public YesNoType? CreditBankIndicator { get; set; }

    public bool? CreditBankIndicatorSpecified { get; set; }

    public YesNoType? AssocFiltersInd { get; set; }

    public bool? AssocFiltersIndSpecified { get; set; }

}

public partial class AssociatedFiltersType : BaseTransactionalSequence
{
    public AssociatedFiltersType()
    {
        this.TemplateInheritInd = YesNoType.N;
    }

    public TransactionalDataType? TransactionalData { get; set; }


    public string? FilterID { get; set; }

    public string? FilterName { get; set; }

    public string? ClientCode { get; set; }

    public string? ClientContextCode { get; set; }

    public string? DomainID { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public System.DateTime CreateDateTime { get; set; }
    public bool? CreateDateTimeSpecified { get; set; }

    public System.DateTime UpdateDateTime { get; set; }
    public bool? UpdateDateTimeSpecified { get; set; }

    public YesNoType? TemplateInheritInd { get; set; }

}

public partial class AssociatedTemplateType : BaseTransactionalSequence
{
    public TransactionalDataType? TransactionalData { get; set; }

    public string? TemplateID { get; set; }

    public string? TemplateName { get; set; }

    public string? ClientCode { get; set; }

    public string? ClientContextCode { get; set; }

    public string? DomainID { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

}

public partial class TemplateAssociatedFormatsType
{
    public string? DomainID { get; set; }

    public string? FormatID { get; set; }

    public string? FormatName { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? SequenceNo { get; set; }

    public System.DateTime CreateDateTime { get; set; }
    public bool? CreateDateTimeSpecified { get; set; }

    public System.DateTime UpdateDateTime { get; set; }
    public bool? UpdateDateTimeSpecified { get; set; }

}


public partial class AssociatedFormatsType : TemplateAssociatedFormatsType
{
    public AssociatedFormatsType()
    {
        this.TemplateInheritInd = YesNoType.N;
    }
    public YesNoType? TemplateInheritInd { get; set; }

}

public partial class DiscountsType : BaseDatasourceSequence
{
    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? VendorTypeCode { get; set; }

    public string? VendorCode { get; set; }

    public string? TypeCode { get; set; }

    public string? ID { get; set; }

    public string? Description { get; set; }

    public System.DateTime EffectiveDate { get; set; }
    public bool? EffectiveDateSpecified { get; set; }

    public System.DateTime ExpiryDate { get; set; }
    public bool? ExpiryDateSpecified { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? Percentage { get; set; }

    public string? Rate { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "time")]
    public System.DateTime ExpireTime { get; set; }
    public bool? ExpireTimeSpecified { get; set; }

    public string? InformationText { get; set; }

    public string? StatusCode { get; set; }

}

public partial class CustomDefinedDataType : BaseDatasourceSequence
{
    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? CustomFieldCode { get; set; }

    public string? Value { get; set; }

    public string? DomainID { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? InformationText { get; set; }

}

public partial class AirportInfoType
{
    public string? AirportCode { get; set; }

    public string? LocationTypeCode { get; set; }

}


public partial class AirportPrefType : BasePrefTransactionalSequence
{
    public AirportInfoType? AirportInfo { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public bool? Exclude { get; set; }

    public bool? ExcludeSpecified { get; set; }

    public string? PreferLevelCode { get; set; }

    public string? OrderPreferenceNo { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? InformationText { get; set; }

}

public partial class AirlineSeatInfoType
{
    public string? SeatNumber { get; set; }

    public string? SeatPreferenceCode { get; set; }

    public string? VendorCode { get; set; }

}


public partial class AirlineSeatPrefType : BaseTransactionalSequence
{
    public AirlineSeatInfoType? SeatInfo { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? PreferLevelCode { get; set; }

    public bool? Exclude { get; set; }

    public bool? ExcludeSpecified { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? InformationText { get; set; }

}

public partial class AirCabinInfoType
{
    public string? VendorCode { get; set; }

    public string? CabinNameCode { get; set; }

}


public partial class AirlineCabinPrefType : BasePrefTransactionalSequence
{
    public AirCabinInfoType? CabinInfo { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? PreferLevelCode { get; set; }

    public bool? Exclude { get; set; }

    public bool? ExcludeSpecified { get; set; }

    public string? OrderPreferenceNo { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? InformationText { get; set; }

}

public partial class AirMealInfoType
{
    public string? MealTypeCode { get; set; }

    public string? MealServiceCode { get; set; }

    public string? VendorCode { get; set; }

}

public partial class AirlineMealPrefType : BasePrefTransactionalSequence
{
    public AirMealInfoType? MealInfo { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? PreferLevelCode { get; set; }

    public bool? Exclude { get; set; }

    public bool? ExcludeSpecified { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? OrderPreferenceNo { get; set; }

    public string? InformationText { get; set; }

}

public partial class AirlineUpgradePrefType : BasePrefTransactionalSequence
{
    public TransactionalDataType? TransactionalData { get; set; }

    public string? PreferLevelCode { get; set; }

    public string? VendorCode { get; set; }

    public string? InformationText { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? OrderPreferenceNo { get; set; }

}

public partial class PreferredAirlinesType : BasePrefTransactionalSequence
{
    public TransactionalDataType? TransactionalData { get; set; }

    public string? VendorCode { get; set; }

    public bool? Exclude { get; set; }

    public bool? ExcludeSpecified { get; set; }

    public string? PreferLevelCode { get; set; }

    public string? OrderPreferenceNo { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? InformationText { get; set; }

}

public partial class PreferredAggregatorType : BaseTransactionalSequence
{
    public TransactionalDataType? TransactionalData { get; set; }

    public string? AggregatorCode { get; set; }

    public bool? Exclude { get; set; }

    public bool? ExcludeSpecified { get; set; }

    public string? InformationText { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? OrderPreferenceNo { get; set; }

}


public partial class AirlinePrefType : BaseDatasourceSequence
{
    public AirportPrefType[]? AirportPref { get; set; }

    public AirlineSeatPrefType[]? AirlineSeatPref { get; set; }

    public AirlineCabinPrefType[]? AirlineCabinPref { get; set; }

    public AirlineMealPrefType[]? AirlineMealPref { get; set; }

    public AirlineUpgradePrefType[]? AirlineUpgradePref { get; set; }

    public PreferredAirlinesType[]? PreferredAirlines { get; set; }

    public PreferredAggregatorType[]? PreferredAggregator { get; set; }

    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? TripTypeCode { get; set; }

    public string? GeoOriginCode { get; set; }

    public string? GeoDestinationCode { get; set; }

    public string? GeoRegionCode { get; set; }

    public string? InformationText { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? DisplaySequenceNo { get; set; }

}

public partial class HotelRateInfoType
{
    public string? MaxRoomRate { get; set; }

    public string? CurrencyCode { get; set; }

}


public partial class PreferredHotelType : BasePrefTransactionalSequence
{
    public HotelRateInfoType? HotelRate { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? HotelName { get; set; }

    public string? HotelChainCode { get; set; }

    public string? HotelVendorCode { get; set; }

    public string? RoomTypeCode { get; set; }

    public string? InformationText { get; set; }

    public string? GDSCode { get; set; }

    public bool? Exclude { get; set; }

    public bool? ExcludeSpecified { get; set; }

    public string? HotelVicinityCode { get; set; }

    public string? PreferLevelCode { get; set; }

    public string? OrderPreferenceNo { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

}


public partial class HotelPrefType : BaseDatasourceSequence
{
    public PreferredHotelType[]? PreferredHotel { get; set; }

    public PreferredAggregatorType[]? PreferredAggregator { get; set; }

    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? TripTypeCode { get; set; }

    public string? GeoOriginCode { get; set; }

    public string? GeoDestinationCode { get; set; }

    public string? GeoRegionCode { get; set; }

    public string? InformationText { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? DisplaySequenceNo { get; set; }

}

public partial class VehicleRateInfoType
{
    public string? MaxRateAmount { get; set; }

    public string? CurrencyCode { get; set; }

}

public abstract class VehicleTypeInfoItemType { }


public partial class VehicleMatrixTypeInfoType : VehicleTypeInfoItemType
{
    public string? VehicleCategoryCode { get; set; }

    public string? VehicleBodyTypeCode { get; set; }

    public string? VehicleFuelTypeCode { get; set; }

    public string? VehicleTransmissionTypeCode { get; set; }

}

public partial class VehiclePseudoTypeInfoType : VehicleTypeInfoItemType
{
    public string? VehiclePseudoTypeCode { get; set; }

}


public partial class VehicleTypeInfoType
{
    //[System.Xml.Serialization.XmlElementAttribute("MatrixType", typeof(VehicleMatrixTypeInfoType))]
    //[System.Xml.Serialization.XmlElementAttribute("PseudoType", typeof(VehiclePseudoTypeInfoType))]
    public VehicleTypeInfoItemType? Item { get; set; }

}


public partial class PreferredVehicleVendorsType : BasePrefTransactionalSequence
{

    public VehicleRateInfoType? VehicleRate { get; set; }

    public VehicleTypeInfoType? VehicleType { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? VendorCode { get; set; }

    public string? VehicleTypeCode { get; set; }

    public bool? Exclude { get; set; }

    public bool? ExcludeSpecified { get; set; }

    public string? PreferLevelCode { get; set; }

    public string? OrderPreferenceNo { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? InformationText { get; set; }

}

public partial class VehicleEquipmentType : BaseSequence
{
    public string? EquipmentCode { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

}


public partial class VehicleRentalPrefType : BaseDatasourceSequence
{

    public PreferredVehicleVendorsType[]? PreferredVehicleVendors { get; set; }


    public PreferredAggregatorType[]? PreferredAggregator { get; set; }


    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }


    public VehicleEquipmentType[]? VehicleEquipment { get; set; }


    public string? TripTypeCode { get; set; }


    public string? GeoOriginCode { get; set; }


    public string? GeoDestinationCode { get; set; }


    public string? GeoRegionCode { get; set; }


    public string? InformationText { get; set; }


    public string? OrderSequenceNo { get; set; }


    public string? DisplaySequenceNo { get; set; }


}

public partial class RailStationInfoType
{
    public RailStationInfoType()
    {
        this.ContextCode = "IATA";
    }
    public string? RailStationCode { get; set; }

    public string? LocationTypeCode { get; set; }

    public string? ContextCode { get; set; }


}


public partial class RailStationPrefType : BasePrefTransactionalSequence
{
    public RailStationInfoType? RailStationInfo { get; set; }


    public TransactionalDataType? TransactionalData { get; set; }


    public bool? Exclude { get; set; }


    public bool? ExcludeSpecified { get; set; }


    public string? PreferLevelCode { get; set; }


    public string? OrderPreferenceNo { get; set; }


    public string? DisplaySequenceNo { get; set; }


    public string? OrderSequenceNo { get; set; }


    public string? InformationText { get; set; }


}

public partial class RailSeatInfoType
{

    public string? SeatNumber { get; set; }

    public string? SeatPreferenceCode { get; set; }

    public string? VendorCode { get; set; }

}

public partial class RailSeatPrefType : BaseTransactionalSequence
{
    public RailSeatInfoType? SeatInfo { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? PreferLevelCode { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? InformationText { get; set; }

}

public partial class RailCabinInfoType
{
    public string? VendorCode { get; set; }

    public string? CabinNameCode { get; set; }

}


public partial class RailCabinPrefType : BasePrefTransactionalSequence
{
    public RailCabinInfoType? CabinInfo { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? PreferLevelCode { get; set; }

    public string? OrderPreferenceNo { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? InformationText { get; set; }

}

public partial class RailMealInfoType
{
    public string? MealTypeCode { get; set; }

    public string? MealServiceCode { get; set; }

    public string? VendorCode { get; set; }

}


public partial class RailMealPrefType : BasePrefTransactionalSequence
{
    public RailMealInfoType? MealInfo { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? PreferLevelCode { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? OrderPreferenceNo { get; set; }

    public string? InformationText { get; set; }

}

public partial class RailUpgradePrefType : BasePrefTransactionalSequence
{
    public TransactionalDataType? TransactionalData { get; set; }

    public string? PreferLevelCode { get; set; }

    public string? VendorCode { get; set; }

    public string? InformationText { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? OrderPreferenceNo { get; set; }

}

public partial class PreferredRailVendorsType : BasePrefTransactionalSequence
{
    public TransactionalDataType? TransactionalData { get; set; }

    public string? VendorCode { get; set; }

    public bool? Exclude { get; set; }

    public bool? ExcludeSpecified { get; set; }

    public string? PreferLevelCode { get; set; }

    public string? OrderPreferenceNo { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? InformationText { get; set; }

}

public partial class RailPrefType : BaseDatasourceSequence
{
    public RailStationPrefType[]? RailStationPref { get; set; }

    public RailSeatPrefType[]? RailSeatPref { get; set; }

    public RailCabinPrefType[]? RailCabinPref { get; set; }

    public RailMealPrefType[]? RailMealPref { get; set; }

    public RailUpgradePrefType[]? RailUpgradePref { get; set; }

    public PreferredRailVendorsType[]? PreferredRailVendors { get; set; }

    public PreferredAggregatorType[]? PreferredAggregator { get; set; }

    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? TripTypeCode { get; set; }

    public string? GeoOriginCode { get; set; }

    public string? GeoDestinationCode { get; set; }

    public string? GeoRegionCode { get; set; }

    public string? InformationText { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? DisplaySequenceNo { get; set; }

}

public partial class PreferredGroundTransportationVendorsType : BasePrefTransactionalSequence
{
    public TransactionalDataType? TransactionalData { get; set; }

    public string? VendorCode { get; set; }

    public bool? Exclude { get; set; }

    public bool? ExcludeSpecified { get; set; }

    public string? PreferLevelCode { get; set; }

    public string? OrderPreferenceNo { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? InformationText { get; set; }

}


public partial class GroundTransportationPrefType : BaseDatasourceSequence
{
    public PreferredGroundTransportationVendorsType[]? PreferredGroundTransportationVendors { get; set; }

    public PreferredAggregatorType[]? PreferredAggregator { get; set; }

    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? TripTypeCode { get; set; }

    public string? GeoOriginCode { get; set; }

    public string? GeoDestinationCode { get; set; }

    public string? GeoRegionCode { get; set; }

    public string? InformationText { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? DisplaySequenceNo { get; set; }

}

public partial class NotificationPreferenceType : BaseDatasourceSequence
{
    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? LanguageID { get; set; }

    public string? PreferenceStartTime { get; set; }

    public string? PreferenceEndTime { get; set; }

    //[System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
    public string? DaysPriorToStartNotification { get; set; }

    public string? PreferredDeviceDeliveryCapabilityCode { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

}

public partial class ConsentType : BaseDatasourceSequence
{

    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? TypeCode { get; set; }

    public ConsentValueType? Value { get; set; }

    public System.DateTime AcceptedDateTime { get; set; }
    public bool? AcceptedDateTimeSpecified { get; set; }

    public string? ApplicationCode { get; set; }

    public string? CampaignTypeCode { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

}

public partial class PsychographicDataType : BaseSequence
{
    public string? ValueCode { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

}


public partial class PsychographicCategoryType : BaseDatasourceSequence
{
    public PsychographicDataType[]? PsychographicData { get; set; }

    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? CategoryCode { get; set; }

    public string? ClientCode { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

}

public partial class DeclaredTravelHistoryPreferenceType
{
    public string? TripTypeCode { get; set; }

    public string? Value { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

}


public partial class TPA_MarketingPreferenceType
{
    public NotificationPreferenceType[]? NotificationPreference { get; set; }

    public ConsentType[]? Consent { get; set; }

    public PsychographicCategoryType[]? PsychographicCategory { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public DeclaredTravelHistoryPreferenceType[]? DeclaredTravelHistoryPreference { get; set; }

}

public abstract class LoungePrefItemType { }

public partial class PreferredDrinkType : LoungePrefItemType
{
    public string? DrinkName { get; set; }

    public string? LanguageIDCode { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

}

public partial class PreferredNewspaperType : LoungePrefItemType
{
    public string? NewspaperName { get; set; }

    public string? LanguageIDCode { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

}

public partial class LoungePrefType
{

    //[System.Xml.Serialization.XmlElementAttribute("PreferredDrink", typeof(PreferredDrinkType))]
    //[System.Xml.Serialization.XmlElementAttribute("PreferredNewspaper", typeof(PreferredNewspaperType))]
    public LoungePrefItemType[]? Items { get; set; }

    public string? TripTypeCode { get; set; }

    public string? VendorTypeCode { get; set; }

    public string? VendorCode { get; set; }

    public string? DisplaySequenceNo { get; set; }

}


public partial class PrefCollectionsType
{
    public AirlinePrefType[]? AirlinePref { get; set; }

    public HotelPrefType[]? HotelPref { get; set; }

    public VehicleRentalPrefType[]? VehicleRentalPref { get; set; }

    public RailPrefType[]? RailPref { get; set; }

    public GroundTransportationPrefType[]? GroundTransportationPref { get; set; }

    public TPA_MarketingPreferenceType? TPA_MarketingPreference { get; set; }

    public LoungePrefType[]? LoungePref { get; set; }

}

public partial class SabreTravelPolicyEngineType : BaseTransactionalSequence
{
    public TransactionalDataType? TransactionalData { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? PolicyID { get; set; }

    public string? PolicyName { get; set; }

}

public partial class SabreCorporateTravelPolicyType
{
    public TransactionalDataType? TransactionalData { get; set; }

    public string? CTPName { get; set; }

}

public partial class STPPolicyType
{
    public string? ID { get; set; }

    public string? OrderSequenceNo { get; set; }

}

public partial class STPPreferenceType
{
    public string? ID { get; set; }

    public string? OrderSequenceNo { get; set; }

}


public partial class SabreTravelPolicyType
{
    public STPPolicyType[]? Policy { get; set; }

    public STPPreferenceType[]? Preference { get; set; }

    public string? EntityID { get; set; }

}


public partial class TravelPolicyType
{
    public SabreTravelPolicyEngineType[]? SabreTravelPolicyEngine { get; set; }

    public SabreCorporateTravelPolicyType? SabreCorporateTravelPolicy { get; set; }

    public SabreTravelPolicyType? SabreTravelPolicy { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

}

public partial class BrandingType : BaseDataSource
{
    public AddressType[]? Address { get; set; }

    public TelephoneType[]? Telephone { get; set; }

    public EmailType[]? Email { get; set; }

    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? BrandingDisplayName { get; set; }

    public string? BrandingUsageTypeCd { get; set; }

    public string? BrandingURL { get; set; }

    public string? BrandingURLLogoLocationText { get; set; }

    public string? BrandingMarketingMessageDesc { get; set; }

    public string? LanguageIDCode { get; set; }

}

public partial class STARDataType
{
    public string? STARName { get; set; }

    public string? OriginatingPCC { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? Value { get; set; }

}

public partial class BusinessTravelerSettingType
{
    public string? DefaultBusTvlTypeCode { get; set; }

    public StatusType? DefaultBusTvlStatusCode { get; set; }

    public bool? DefaultBusTvlStatusCodeSpecified { get; set; }

}

public partial class EmployeeInfoType
{

    public TransactionalDataType? TransactionalData { get; set; }

    public string? EmployeeId { get; set; }

    public string? EmployeeTitle { get; set; }

    public string? EmployeeCostCenter { get; set; }

    public string? IndustryTypeCode { get; set; }

    public string? Division { get; set; }

    public string? Department { get; set; }

    public string? EmployeeName { get; set; }

    public string? Company { get; set; }

    public string? Subsidiary { get; set; }

    public string? BusinessUnit { get; set; }

    public string? OperatingUnit { get; set; }

    public string? ProjectID { get; set; }

    public string? AccountingCd { get; set; }

    public string? LocationCd { get; set; }

    public string? RegionCd { get; set; }

    public string? BranchID { get; set; }

    public string? GeneralLedgerCd { get; set; }

    public System.DateTime HireDate { get; set; }
    public bool? HireDateSpecified { get; set; }

}

public partial class EmploymentInfoType : BaseDatasourceSequence
{
    public EmployeeInfoType? EmployeeInfo { get; set; }

    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? LanguageIDCode { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? InformationText { get; set; }

}

public partial class NumberOfAssocProfilesType
{
    public string? Traveler { get; set; }

    public string? TravelAgent { get; set; }

    public string? TravelAgency { get; set; }

    public string? Corporation { get; set; }

    public string? Operational { get; set; }

    public string? GroupProfile { get; set; }

}

public partial class CustomDefinedValuesType
{
    public string? Name { get; set; }

    public string? Value { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

}

public partial class GroupInfoType
{
    public TaxInfoType[]? TaxInfo { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? GroupName { get; set; }

    public string? GroupIdentifier { get; set; }

    public string? InformationText { get; set; }

}

public partial class ContactNameOperationalType : BaseNameType
{

    public string? PreferredFirstName { get; set; }

    public string? PreferredSurname { get; set; }

    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? LanguageIDCode { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? DisplaySequenceNo { get; set; }

}

public partial class AgencyContactNameType : BaseDatasourceSequence
{
    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? NamePrefix { get; set; }

    public string? GivenName { get; set; }

    public string? MiddleName { get; set; }

    public string? Surname { get; set; }

    public string? NameSuffix { get; set; }

    public string? PreferredFirstName { get; set; }

    public string? PreferredLastName { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? DisplaySequenceNo { get; set; }

}

public partial class FeeInfoType : BaseDataSource
{
    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? FeeTypeCode { get; set; }

    public decimal? FeeAmount { get; set; }

    public bool? FeeAmountSpecified { get; set; }

    public string? FeeCurrencyCode { get; set; }

}


public partial class AgencyInfoType : BaseDataSource
{

    public TaxInfoType[]? TaxInfo { get; set; }

    public FeeInfoType[]? Fee { get; set; }

    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? TravelAgencyName { get; set; }

    public string? TravelAgencyDescription { get; set; }

    public string? TravelAgencyTypeCode { get; set; }

    public string? LanguageIDCode { get; set; }

    public string? AgencyBusinessUnitID { get; set; }

    public string? TravelAgencyIdentifier { get; set; }

    public string? URL { get; set; }

    public string? URLLogoLocationText { get; set; }

    public string? AgencyTradeName { get; set; }

    public string? BillableTravelArrangerCd { get; set; }

    public string? DefaultInactiveProfilesPurgeNoDays { get; set; }

    public string? EditPNRDesc { get; set; }

    public string? WebLoginRestrictID { get; set; }

    public YesNoType? AgyCreditCardAllowInd { get; set; }

    public bool? AgyCreditCardAllowIndSpecified { get; set; }

    public YesNoType? AgyCreditLimitAllowedInd { get; set; }

    public bool? AgyCreditLimitAllowedIndSpecified { get; set; }

    public string? AgyCreditLimit { get; set; }

}

public partial class QueueAssignmentsType : BaseDatasourceSequence
{
    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? QueueNo { get; set; }

    public string? DomainID { get; set; }

    public string? PrefatoryInstruction { get; set; }

    public string? GDSCode { get; set; }

    public string? QueueDesc { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

}

public partial class CommissionsType : BaseDatasourceSequence
{
    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? CommissionMeasureTypeCode { get; set; }

    public string? CommissionValue { get; set; }

    public string? ServiceTypeCode { get; set; }

    public string? TripTypeCode { get; set; }

    public string? SupplierCode { get; set; }

    public string? CommissionDescription { get; set; }

    public System.DateTime EffectiveDate { get; set; }
    public bool? EffectiveDateSpecified { get; set; }

    public System.DateTime DiscontinueDate { get; set; }
    public bool? DiscontinueDateSpecified { get; set; }

    public string? InformationText { get; set; }

    public string? GeoOriginCode { get; set; }

    public string? GeoDestinationCode { get; set; }

    public string? GeoRegionCode { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

}

public partial class AgentNameType : BaseNameType
{
    public TransactionalDataType? TransactionalData { get; set; }


    public string? PreferredFirstName { get; set; }

    public string? PreferredLastName { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? LanguageIDCode { get; set; }

}

public partial class AgentInfoType
{
    public TaxInfoType[]? TaxInfo { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public System.DateTime BirthDate { get; set; }
    public bool? BirthDateSpecified { get; set; }

    public string? MaritalStatusCode { get; set; }

    public string? GenderCode { get; set; }

    public string? AgeRange { get; set; }

    public string? RedressNumber { get; set; }

    public string? KnownTravelerNumber { get; set; }

    public YesNoType? SeniorIndicator { get; set; }

    public bool? SeniorIndicatorSpecified { get; set; }

    public YesNoType? SuperUser { get; set; }

    public bool? SuperUserSpecified { get; set; }

}
public partial class ReferenceType
{
    public string? TypeCode { get; set; }

    public string? Number { get; set; }

}


public partial class RelatedIndividualType : ContactType
{
    public ReferenceType? Reference { get; set; }

}

public partial class AgentGDSIdentityType : BaseTransactionalSequence
{
    public TransactionalDataType? TransactionalData { get; set; }

    public string? AgentSine { get; set; }

    public string? AgentID { get; set; }

    public string? GDSCode { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

}

public partial class DocHolderNameType : BaseNameType
{
}


public partial class DocumentType : BaseDatasourceSequence
{

    public DocumentType()
    {
        this.IsUsedForSecureFlightRules = YesNoType.N;
    }
    public string? DocHolderName { get; set; }

    public DocHolderNameType? DocHolder { get; set; }

    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? DocIssueLocation { get; set; }

    public string? DocID { get; set; }

    public string? DocTypeCode { get; set; }

    public System.DateTime BirthDate { get; set; }
    public bool? BirthDateSpecified { get; set; }

    public System.DateTime EffectiveDate { get; set; }
    public bool? EffectiveDateSpecified { get; set; }

    public System.DateTime ExpireDate { get; set; }

    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool? ExpireDateSpecified { get; set; }

    public string? DocIssueCountryCode { get; set; }

    public string? BirthPlace { get; set; }

    public string? BirthCountryCode { get; set; }

    public string? DocHolderNationalityCode { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public VIT_StarLineType? VIT_LineType { get; set; }

    public bool? VIT_LineTypeSpecified { get; set; }

    public string? VIT_SecondaryQualifier { get; set; }

    public string? VIT_OrderNmbr { get; set; }

    public string? GenderCode { get; set; }

    public string? InformationText { get; set; }

    public YesNoType? IsUsedForSecureFlightRules { get; set; }

}

public partial class MembershipLevelType
{
    public string? MembershipLevelTypeCode { get; set; }

    public string? MembershipLevelValue { get; set; }

    public string? AllianceCode { get; set; }

    public string? AllianceLevelValue { get; set; }

}

public partial class AssociatedVendorsType
{
    public string? VendorTypeCode { get; set; }


    public string? VendorCode { get; set; }

}

public partial class CustLoyaltyTotalsTypeAdditionalInfo
{
    public string? TypeCode { get; set; }

    public string? Value { get; set; }

}

public partial class CustLoyaltyTotalsTypeMilesToExpireOnDate
{
    public string? MilesTypeCode { get; set; }

    public System.DateTime MilesExpireDate { get; set; }
    public string? MilesToExpire { get; set; }

}

public partial class CustLoyaltyTotalsType
{

    public CustLoyaltyTotalsTypeMilesToExpireOnDate[]? MilesToExpireOnDate { get; set; }

    public CustLoyaltyTotalsTypeAdditionalInfo[]? AdditionalInfo { get; set; }

    public string? AccountBalance { get; set; }

    public System.DateTime MembershipStartDate { get; set; }
    public bool? MembershipStartDateSpecified { get; set; }

    public string? MilesToExpire { get; set; }

    public System.DateTime MilesExpireDate { get; set; }
    public bool? MilesExpireDateSpecified { get; set; }

    public string? LatestAwardAmount { get; set; }

    public System.DateTime LatestAwardDate { get; set; }
    public bool? LatestAwardDateSpecified { get; set; }

    public string? PrizeEligibleAmount { get; set; }

    public string? PreferenceRank { get; set; }

    public System.DateTime StatusDate { get; set; }
    public bool? StatusDateSpecified { get; set; }

    public string? YearToDateAmount { get; set; }

    public string? PreviousYearAmount { get; set; }

    public string? LifetimeAmount { get; set; }

    public string? RewardSubscriptionLevelText { get; set; }

}

public partial class CustLoyaltyType : BaseDatasourceSequence
{
    public string? GivenName { get; set; }

    public string? MiddleName { get; set; }

    public string? SurName { get; set; }

    public MembershipLevelType? MembershipLevel { get; set; }

    public AssociatedVendorsType[]? AssociatedVendors { get; set; }

    public CustLoyaltyTotalsType? CustLoyaltyTotals { get; set; }

    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? VendorTypeCode { get; set; }

    public string? VendorCode { get; set; }

    public string? ProgramTypeCode { get; set; }

    public string? MembershipID { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public VIT_StarLineType? VIT_LineType { get; set; }

    public bool? VIT_LineTypeSpecified { get; set; }

    public string? VIT_SecondaryQualifier { get; set; }

    public string? VIT_OrderNmbr { get; set; }

    public string? InformationText { get; set; }

}

public partial class CustomProfileRolesType
{
    public TransactionalDataType? TransactionalData { get; set; }

    public string? CustomRoleName { get; set; }

    public string? DisplaySequenceNo { get; set; }

}

public partial class StandardProfileRolesType
{
    public TransactionalDataType? TransactionalData { get; set; }

    public string? StandardRoleName { get; set; }

    public string? DisplaySequenceNo { get; set; }

}


public partial class RolesType
{
    public CustomProfileRolesType[]? CustomProfileRoles { get; set; }

    public StandardProfileRolesType[]? StandardProfileRoles { get; set; }

}

public partial class SabreSecurityEntityAttributeType : BaseTransactionalSequence
{
    public TransactionalDataType? TransactionalData { get; set; }

    public string? AttributeName { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

}

public partial class IncentivesType : BaseTransactionalSequence
{
    public TransactionalDataType? TransactionalData { get; set; }

    public string? SupplierCode { get; set; }

    public string? SupplierServiceTypeCode { get; set; }

    public string? SupplierIncentiveID { get; set; }

    public string? IncentiveValue { get; set; }

    public string? InformationText { get; set; }

    public System.DateTime EffectiveDate { get; set; }
    public bool? EffectiveDateSpecified { get; set; }

    public System.DateTime ExpiryDate { get; set; }
    public bool? ExpiryDateSpecified { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

}

public partial class PersonNameType : BaseNameType
{
    public string? PreferredFirstName { get; set; }

    public string? PreferredSurname { get; set; }

    public string? MothersMaidenName { get; set; }

    public DataSourceInfoType? DataSource { get; set; }

    public TransactionalDataType? TransactionalData { get; set; }

    public string? LanguageIDCode { get; set; }

    public VIT_StarLineType? VIT_LineType { get; set; }

    public bool? VIT_LineTypeSpecified { get; set; }

    public string? VIT_SecondaryQualifier { get; set; }

    public string? VIT_OrderNmbr { get; set; }

    public string? DisplaySequenceNo { get; set; }

    public string? OrderSequenceNo { get; set; }

    public string? InformationText { get; set; }

}

public partial class CustomerType
{
    public CustomerType()
    {
        this.LapInfantIndicator = YesNoType.N;
        this.IsSubjectToSecureFlightRule = YesNoType.N;
    }

    public PersonNameType[]? PersonName { get; set; }

    public TelephoneType[]? Telephone { get; set; }

    public EmailType[]? Email { get; set; }

    public AddressType[]? Address { get; set; }

    public PaymentFormType[]? PaymentForm { get; set; }

    public RelatedIndividualType[]? RelatedIndividual { get; set; }

    public EmergencyContactPersonType[]? EmergencyContactPerson { get; set; }

    public DocumentType[]? Document { get; set; }

    public CustLoyaltyType[]? CustLoyalty { get; set; }

    public EmploymentInfoType[]? EmploymentInfo { get; set; }

    public string? CountryOfResidence { get; set; }

    public System.DateTime BirthDate { get; set; }
    public bool? BirthDateSpecified { get; set; }

    public string? MaritalStatusCode { get; set; }

    public string? GenderCode { get; set; }

    public string? AgeRange { get; set; }

    public string? RedressNumber { get; set; }

    public string? KnownTravelerNumber { get; set; }

    public YesNoType? ChildIndicator { get; set; }

    public bool? ChildIndicatorSpecified { get; set; }

    public YesNoType? SeniorIndicator { get; set; }

    public bool? SeniorIndicatorSpecified { get; set; }

    public string? CitizenCountryCode { get; set; }

    public string? CurrencyCode { get; set; }

    public YesNoType? LapInfantIndicator { get; set; }

    public YesNoType? IsSubjectToSecureFlightRule { get; set; }

    public string? NationalityCode { get; set; }

    public string? ServiceSegmentationCode { get; set; }

}


public partial class ValueScoreUpdateInfoType
{
    public string? AccessUserID { get; set; }

    public string? DomainID { get; set; }

    public string? LNIATA { get; set; }

    public string? Group { get; set; }

}


public partial class CustomerValueScoreType
{
    public ValueScoreUpdateInfoType? ValueScoreUpdateInfo { get; set; }

    public string? Score { get; set; }

    public System.DateTime EffectiveDate { get; set; }
    public System.DateTime DiscontinueDate { get; set; }
    public string? ScoreTypeCode { get; set; }

    public string? Comment { get; set; }

    public System.DateTime LoadDateTime { get; set; }
    public bool? LoadDateTimeSpecified { get; set; }

    public string? VendorTypeCode { get; set; }

    public string? VendorCode { get; set; }

    public string? CustomerUserID { get; set; }

    public string? CustomerDomainID { get; set; }

}

public partial class EnrollmentInfoType
{
    public string? EnrollmentChannel { get; set; }

    public string? EnrollmentCd { get; set; }

    public System.DateTime EnrolledStartDateTime { get; set; }
    public bool? EnrolledStartDateTimeSpecified { get; set; }

    public System.DateTime EnrolledExpireDateTime { get; set; }
    public bool? EnrolledExpireDateTimeSpecified { get; set; }

    public string? TimeZoneCode { get; set; }

    public bool? EnrolledStatus { get; set; }

    public bool? EnrolledStatusSpecified { get; set; }

}

public partial class MergedProfilesType
{
    public string? MergedProfileUniqueID { get; set; }

    public ProfileTypeInfo? MergedProfileTypeCode { get; set; }

    public string? DomainID { get; set; }

    public string? MergeComment { get; set; }

}


public partial class TPA_Extensions_Type
{

    public PriorityRemarksType[]? PriorityRemarks { get; set; }

    public RemarkType[]? Remark { get; set; }

    public SSRType[]? SSR { get; set; }

    public OSIType[]? OSI { get; set; }

    public CustomerReferenceInfoType[]? CustomerReferenceInfo { get; set; }

    public BusinessSystemIdentityInfoType[]? BusinessSystemIdentityInfo { get; set; }

    public AssociatedProfilesType[]? AssociatedProfiles { get; set; }

    public AssociatedFiltersType[]? AssociatedFilters { get; set; }

    public AssociatedTemplateType[]? AssociatedTemplate { get; set; }

    public AssociatedFormatsType[]? AssociatedFormats { get; set; }

    public DiscountsType[]? Discounts { get; set; }

    public CustomDefinedDataType[]? CustomDefinedData { get; set; }

    public TaxInfoType[]? TaxInfo { get; set; }

    public TravelPolicyType? TravelPolicy { get; set; }

    public STARDataType[]? STARData { get; set; }

    public CustomerValueScoreType[]? CustomerValueScore { get; set; }

    public EnrollmentInfoType? EnrollmentInfo { get; set; }

    public MergedProfilesType[]? MergedProfiles { get; set; }

    public NumberOfAssocProfilesType? NumberOfAssocProfiles { get; set; }

    public CustomDefinedValuesType[]? CustomDefinedValues { get; set; }

}

[DataContract(IsReference = true)]
[KnownType(typeof(SabreServiceAllianceProfileType))]
[KnownType(typeof(SabreServiceCorporateProfileType))]
[KnownType(typeof(SabreServiceGroupProfileType))]
[KnownType(typeof(SabreServiceOperationalProfileType))]
[KnownType(typeof(SabreServiceTravelAgencyProfileType))]
[KnownType(typeof(SabreServiceTravelAgentProfileType))]
[KnownType(typeof(SabreServiceTravelerProfileType))]
public class @SabreServiceProfileItemType { }

public partial class SabreServiceAllianceProfileType : @SabreServiceProfileItemType
{
    public AllianceProfileTypeTraveler? Traveler { get; set; }

}

public partial class SabreServiceCorporateProfileType : @SabreServiceProfileItemType
{
    public CorporateInfoType? CorporateInfo { get; set; }

    public ContactNameType[]? ContactName { get; set; }

    public AddressType[]? Address { get; set; }

    public TelephoneType[]? Telephone { get; set; }

    public EmailType[]? Email { get; set; }

    public PaymentFormType[]? PaymentForm { get; set; }

    public EmergencyContactPersonType[]? EmergencyContactPerson { get; set; }

    public PriorityRemarksType[]? PriorityRemarks { get; set; }

    public RemarkType[]? Remark { get; set; }

    public GDSType[]? GDS { get; set; }

    public CustomerReferenceInfoType[]? CustomerReferenceInfo { get; set; }

    public SSRType[]? SSR { get; set; }

    public OSIType[]? OSI { get; set; }

    public BusinessSystemIdentityInfoType[]? BusinessSystemIdentityInfo { get; set; }

    public AssociatedProfilesType[]? AssociatedProfiles { get; set; }

    public AssociatedFiltersType[]? AssociatedFilters { get; set; }

    public AssociatedTemplateType[]? AssociatedTemplate { get; set; }

    public AssociatedFormatsType[]? AssociatedFormats { get; set; }

    public DiscountsType[]? Discounts { get; set; }

    public CustomDefinedDataType[]? CustomDefinedData { get; set; }

    public PrefCollectionsType? PrefCollections { get; set; }

    public TravelPolicyType? TravelPolicy { get; set; }

    public BrandingType[]? Branding { get; set; }

    public STARDataType[]? STARData { get; set; }

    public BusinessTravelerSettingType[]? BusinessTravelerSetting { get; set; }

    public EmploymentInfoType[]? EmploymentInfo { get; set; }

    public NumberOfAssocProfilesType? NumberOfAssocProfiles { get; set; }

    public CustomDefinedValuesType[]? CustomDefinedValues { get; set; }

}

public partial class SabreServiceGroupProfileType : @SabreServiceProfileItemType
{
    public GroupInfoType? GroupInfo { get; set; }

    public ContactNameType[]? ContactName { get; set; }

    public AddressType[]? Address { get; set; }

    public TelephoneType[]? Telephone { get; set; }

    public EmailType[]? Email { get; set; }

    public PaymentFormType[]? PaymentForm { get; set; }

    public EmergencyContactPersonType[]? EmergencyContactPerson { get; set; }

    public PriorityRemarksType[]? PriorityRemarks { get; set; }

    public RemarkType[]? Remark { get; set; }

    public GDSType[]? GDS { get; set; }

    public CustomerReferenceInfoType[]? CustomerReferenceInfo { get; set; }

    public SSRType[]? SSR { get; set; }

    public OSIType[]? OSI { get; set; }

    public BusinessSystemIdentityInfoType[]? BusinessSystemIdentityInfo { get; set; }

    public AssociatedProfilesType[]? AssociatedProfiles { get; set; }

    public AssociatedFiltersType[]? AssociatedFilters { get; set; }

    public AssociatedTemplateType[]? AssociatedTemplate { get; set; }

    public AssociatedFormatsType[]? AssociatedFormats { get; set; }

    public DiscountsType[]? Discounts { get; set; }

    public CustomDefinedDataType[]? CustomDefinedData { get; set; }

    public PrefCollectionsType? PrefCollections { get; set; }

    public TravelPolicyType? TravelPolicy { get; set; }

    public BrandingType[]? Branding { get; set; }

    public STARDataType[]? STARData { get; set; }

    public BusinessTravelerSettingType[]? BusinessTravelerSetting { get; set; }

    public EmploymentInfoType[]? EmploymentInfo { get; set; }

    public NumberOfAssocProfilesType? NumberOfAssocProfiles { get; set; }

    public CustomDefinedValuesType[]? CustomDefinedValues { get; set; }

}

public partial class SabreServiceOperationalProfileType : @SabreServiceProfileItemType
{
    public ContactNameOperationalType[]? ContactName { get; set; }

    public TelephoneType[]? Telephone { get; set; }

    public EmailType[]? Email { get; set; }

    public AddressType[]? Address { get; set; }

    public PaymentFormType[]? PaymentForm { get; set; }

    public PriorityRemarksType[]? PriorityRemarks { get; set; }

    public RemarkType[]? Remark { get; set; }

    public CustomerReferenceInfoType[]? CustomerReferenceInfo { get; set; }

    public SSRType[]? SSR { get; set; }

    public OSIType[]? OSI { get; set; }

    public AssociatedProfilesType[]? AssociatedProfiles { get; set; }

    public AssociatedFiltersType[]? AssociatedFilters { get; set; }

    public AssociatedTemplateType[]? AssociatedTemplate { get; set; }

    public AssociatedFormatsType[]? AssociatedFormats { get; set; }

    public DiscountsType[]? Discounts { get; set; }

    public CustomDefinedDataType[]? CustomDefinedData { get; set; }

    public PrefCollectionsType? PrefCollections { get; set; }

    public TravelPolicyType? TravelPolicy { get; set; }

    public STARDataType[]? STARData { get; set; }

    public EmploymentInfoType[]? EmploymentInfo { get; set; }

    public NumberOfAssocProfilesType? NumberOfAssocProfiles { get; set; }

    public CustomDefinedValuesType[]? CustomDefinedValues { get; set; }

}

public partial class SabreServiceTravelAgencyProfileType : @SabreServiceProfileItemType
{
    public AgencyContactNameType[]? AgencyContactName { get; set; }

    public AgencyInfoType? AgencyInfo { get; set; }

    public AddressType[]? Address { get; set; }

    public TelephoneType[]? Telephone { get; set; }

    public EmailType[]? Email { get; set; }

    public PaymentFormType[]? PaymentForm { get; set; }

    public EmergencyContactPersonType[]? EmergencyContactPerson { get; set; }

    public GDSType[]? GDS { get; set; }

    public BrandingType[]? Branding { get; set; }

    public PriorityRemarksType[]? PriorityRemarks { get; set; }

    public RemarkType[]? Remark { get; set; }

    public CustomerReferenceInfoType[]? CustomerReferenceInfo { get; set; }

    public BusinessSystemIdentityInfoType[]? BusinessSystemIdentityInfo { get; set; }

    public AssociatedProfilesType[]? AssociatedProfiles { get; set; }

    public AssociatedFiltersType[]? AssociatedFilters { get; set; }

    public AssociatedTemplateType[]? AssociatedTemplate { get; set; }

    public AssociatedFormatsType[]? AssociatedFormats { get; set; }

    public DiscountsType[]? Discounts { get; set; }

    public CustomDefinedDataType[]? CustomDefinedData { get; set; }

    public PrefCollectionsType? PrefCollections { get; set; }

    public TravelPolicyType? TravelPolicy { get; set; }

    public STARDataType[]? STARData { get; set; }

    public QueueAssignmentsType[]? QueueAssignments { get; set; }

    public CommissionsType[]? Commissions { get; set; }

    public EmploymentInfoType[]? EmploymentInfo { get; set; }

    public NumberOfAssocProfilesType? NumberOfAssocProfiles { get; set; }

    public CustomDefinedValuesType[]? CustomDefinedValues { get; set; }

}

public partial class SabreServiceTravelAgentProfileType : @SabreServiceProfileItemType
{
    public AgentNameType[]? AgentName { get; set; }

    public AgentInfoType? AgentInfo { get; set; }

    public RelatedIndividualType[]? AgentRelatedIndividuals { get; set; }

    public AgentGDSIdentityType[]? AgentGDSIdentity { get; set; }

    public AddressType[]? Address { get; set; }

    public TelephoneType[]? Telephone { get; set; }

    public EmailType[]? Email { get; set; }

    public PaymentFormType[]? PaymentForm { get; set; }

    public EmergencyContactPersonType[]? EmergencyContactPerson { get; set; }

    public DocumentType[]? Document { get; set; }

    public CustLoyaltyType[]? CustLoyalty { get; set; }

    public EmploymentInfoType[]? EmploymentInfo { get; set; }

    public GDSType[]? GDS { get; set; }

    public PriorityRemarksType[]? PriorityRemarks { get; set; }

    public RemarkType[]? Remark { get; set; }

    public CustomerReferenceInfoType[]? CustomerReferenceInfo { get; set; }

    public BusinessSystemIdentityInfoType[]? BusinessSystemIdentityInfo { get; set; }

    public AssociatedProfilesType[]? AssociatedProfiles { get; set; }

    public AssociatedFiltersType[]? AssociatedFilters { get; set; }

    public AssociatedTemplateType[]? AssociatedTemplate { get; set; }

    public AssociatedFormatsType[]? AssociatedFormats { get; set; }

    public DiscountsType[]? Discounts { get; set; }

    public CustomDefinedDataType[]? CustomDefinedData { get; set; }

    public PrefCollectionsType? PrefCollections { get; set; }

    public QueueAssignmentsType[]? QueueAssignments { get; set; }

    public CommissionsType[]? Commissions { get; set; }

    public RolesType? Roles { get; set; }

    public STARDataType[]? STARData { get; set; }

    public SabreSecurityEntityAttributeType[]? SabreSecurityEntityAttribute { get; set; }

    public IncentivesType[]? Incentives { get; set; }

    public NumberOfAssocProfilesType? NumberOfAssocProfiles { get; set; }

    public CustomDefinedValuesType[]? CustomDefinedValues { get; set; }

}

public class SabreServiceTravelerProfileType : @SabreServiceProfileItemType
{
    public CustomerType? Customer { get; set; }

    public PrefCollectionsType? PrefCollections { get; set; }

    public TPA_Extensions_Type? TPA_Extensions { get; set; }

}

// FilterProfileType
// ProfileType
public class SabreServiceProfileType
{

    public ProfileTypeTPA_Identity? TPA_Identity { get; set; }


    //AllianceProfileType
    //CorporateProfileType
    //GroupProfileType
    //OperationalProfileType
    //TravelAgencyProfileType
    //TravelAgentProfileType
    //TravelerProfileType
    public @SabreServiceProfileItemType? Item { get; set; }


    public IgnoreSubjectAreaType? IgnoreSubjectArea { get; set; }


    public ProfileAssociationType? Association { get; set; }


    public AnalyticalInfoGroupType[]? AnalyticalInfoGroup { get; set; }


    public System.DateTime CreateDateTime { get; set; }

    public System.DateTime UpdateDateTime { get; set; }

    public string? PrimaryLanguageIDCode { get; set; }

}

// FilterType
public partial class SabreServiceFilterType
{
    public SabreServiceFilterType()
    {
        UsedByShared = YesNoType.N;
    }

    public SabreServiceProfileType Profile { get; set; }

    public AssociatedProfilesType[] AssociatedProfiles { get; set; }

    public AssociatedFormatsType[] AssociatedFormats { get; set; }

    public string FilterID { get; set; }
    public string DomainID { get; set; }
    public string ClientCode { get; set; }
    public string ClientContextCode { get; set; }
    public string FilterName { get; set; }
    public string FilterDescription { get; set; }
    public string MainProfileOrderSeqNo { get; set; }
    public System.DateTime CreateDateTime { get; set; }
    public System.DateTime UpdateDateTime { get; set; }
    public StatusType FilterStatusCode { get; set; }
    public bool FilterStatusCodeSpecified { get; set; }
    public string FilterPurgeNoOfDays { get; set; }
    public ProfileTypeInfo FilterTypeCode { get; set; }
    public YesNoType UsedByShared { get; set; }
}


public partial class DeleteTPAIdentityType : TPAIdentityTypeBase
{
}


public partial class DeleteLoginType
{
    public string LoginID { get; set; }
}

[DataContract(IsReference = true)]
[KnownType(typeof(SabreServiceDeleteProfileType))]
[KnownType(typeof(SabreServiceDeleteFilterType))]
public class @SabreServiceDeleteItemType { }

public partial class SabreServiceDeleteProfileType : @SabreServiceDeleteItemType
{
    public SabreServiceDeleteProfileType()
    {
        this.StatusCode = StatusType.DL;
    }
    public DeleteTPAIdentityType? TPA_Identity { get; set; }
    public string? PurgeDays { get; set; }

    [System.ComponentModel.DefaultValueAttribute(StatusType.DL)]
    public StatusType StatusCode { get; set; }
}

public partial class SabreServiceDeleteFilterType : @SabreServiceDeleteItemType
{
    public SabreServiceDeleteFilterType()
    {
        this.StatusCode = StatusType.DL;
    }

    public string? FilterID { get; set; }
    public string? DomainID { get; set; }
    public string? PurgeDays { get; set; }
    public string? ClientCode { get; set; }
    public string? ClientContextCode { get; set; }
    [System.ComponentModel.DefaultValueAttribute(StatusType.DL)]
    public StatusType StatusCode { get; set; }
}

// DeleteType
public partial class SabreServiceDeleteType
{

    // DeleteAssociationType
    // DeleteDomainType
    // DeleteDomainFiltersType
    // DeleteDomainFormatsType
    // DeleteDomainProfilesType
    // DeleteDomainTemplatesType
    // DeleteFilterType
    // DeleteFormatType
    // DeleteMetadataType
    // DeleteProfileType
    // DeleteTemplateType
    // DeleteValidatorType
    public @SabreServiceDeleteItemType? Item { get; set; }
}


