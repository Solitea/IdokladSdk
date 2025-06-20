using System.ComponentModel.DataAnnotations;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Enums
{
    /// <summary>
    /// All possible validations used in iDoklad API.
    /// </summary>
    public enum ValidationType
    {
        /// <summary>
        /// Property value is required. <see cref="RequiredAttribute"/>
        /// </summary>
        Required = 1,

        /// <summary>
        /// Specifies property data type. Validation always returns <c>true</c>. <see cref="DataTypeAttribute"/>
        /// </summary>
        DataType = 2,

        /// <summary>
        /// Length of string value is limited. <see cref="StringLengthAttribute"/>
        /// </summary>
        StringLength = 3,

        /// <summary>
        /// Property value has to match specified range. <see cref="RangeAttribute"/>
        /// </summary>
        Range = 4,

        /// <summary>
        /// Property value has to match specified regular expression. <see cref="RegularExpressionAttribute"/>
        /// </summary>
        RegularExpression = 5,

        /// <summary>
        /// Property value cannot equal to given value. <see cref="CannotEqualAttribute"/>
        /// </summary>
        CannotEqual = 6,

        /// <summary>
        /// Property contains collection of entities and their count has to match given range. <see cref="CollectionRangeAttribute"/>
        /// </summary>
        CollectionRange = 7,

        /// <summary>
        /// Property specifies color value. <see cref="ColorAttribute"/>
        /// </summary>
        Color = 8,

        /// <summary>
        /// Property has to contain date newer than given data. <see cref="DateGreaterOrEqualThanAttribute"/>
        /// </summary>
        DateGreaterOrEqualThan = 9,

        /// <summary>
        /// Property has to contain DateTime value in given range. <see cref="DateTimeAttribute"/>
        /// </summary>
        DateTime = 10,

        /// <summary>
        /// Property has to contan decimal value greater than zero. <see cref="DecimalGreaterThanZeroAttribute"/>
        /// </summary>
        DecimalGreaterThanZero = 11,

        /// <summary>
        /// Property has to contain email address. <see cref="EmailAddressAttribute"/>
        /// </summary>
        EmailAddress = 12,

        /// <summary>
        /// Property has to contain collection of email addresses. <see cref="EmailCollectionAttribute"/>
        /// </summary>
        EmailCollection = 13,

        /// <summary>
        /// Property contains collection of entities with specified minimum number of items. <see cref="CollectionRangeAttribute"/>
        /// </summary>
        MinCollectionLength = 14,

        /// <summary>
        /// Property has to contain non empty string. <see cref="NotEmptyStringAttribute"/>
        /// </summary>
        NotEmptyString = 15,

        /// <summary>
        /// Property has to contain foreign key. It has to be either null or non-zero. <see cref="NullableForeignKeyAttribute"/>
        /// </summary>
        NullableForeignKey = 16,

        /// <summary>
        /// Property value is required when dependent property has certain value. <see cref="RequiredIfAttribute"/>
        /// </summary>
        RequiredIf = 17,

        /// <summary>
        /// Property value is required when dependent property has non-null value. <see cref="RequiredIfHasValueAttribute"/>
        /// </summary>
        RequiredIfHasValue = 18,

        /// <summary>
        /// Property value has to be non-zero. <see cref="RequiredNonDefaultAttribute"/>
        /// </summary>
        RequiredNonDefault = 19,

        /// <summary>
        /// Property value has to contain valid identification number. <see cref="IdentificationNumberPatchAttribute"/>
        /// </summary>
        IdentificationNumber = 20,

        /// <summary>
        /// Property has to contain valid numeric sequence number format. <see cref="NumericSequenceNumberFormatAttribute"/>
        /// </summary>
        NumericSequenceNumberFormat = 21,

        /// <summary>
        /// Property has to contain valid bank account number format. <see cref="BankAccountNumberAttribute"/>
        /// </summary>
        BankAccountNumber = 22,

        /// <summary>
        /// Property has to contain valid IBAN number format or empty/null value. <see cref="IbanAttribute"/>
        /// </summary>
        Iban = 23,

        /// <summary>
        /// Property has to contain at least one number, one lower and one upper case letter. <see cref="MinPasswordStrengthAttribute"/>
        /// </summary>
        MinPasswordStrength = 24,

        /// <summary>
        /// Property has to contain date earlier than given dependent date. <see cref="DateGreaterThanOrEqualThanAnotherDateAttribute"/>
        /// </summary>
        DateGreaterOrEqualThanAnotherDate = 25,

        /// <summary>
        /// Property has to be greater or equal to certain value. <see cref="MinValueAttribute"/>
        /// </summary>
        MinValue = 26,

        /// <summary>
        /// Property is required when recurrence type of end is after number created. <see cref="CopyCountEndOnRecurringInvoiceAttribute"/>
        /// </summary>
        CopyCountEndOnRecurringInvoice = 27,

        /// <summary>
        /// Property is required when recurrence type of end is on specific day. <see cref="DateOfEndOnRecurringInvoiceAttribute"/>
        /// </summary>
        DateOfEndOnRecurringInvoice = 28,

        /// <summary>
        /// Property must be greater or equal than today. <see cref="DateGreaterOrEqualThanTodayAttribute"/>
        /// </summary>
        DateGreaterOrEqualThanToday = 29,

        /// <summary>
        /// Property is valid only when RecurrenceType is Months and RecurrenceCount is 1. <see cref="IssueLastDayOfMonthOnRecurringInvoiceAttribute"/>
        /// </summary>
        IssueLastDayOfMonthOnRecurringInvoice = 30,

        /// <summary>
        /// Property is valid only for supported file extensions. <see cref="LogoAndSignatureExtensionAttribute"/>
        /// </summary>
        LogoAndSignatureExtension = 31,

        /// <summary>
        /// Property cannot equal to given value if dependent property is target value. <see cref="CannotEqualIf"/>
        /// </summary>
        CannotEqualIf = 32,

        /// <summary>
        /// Property must be null or empty if dependent property is target value. <see cref="NullOrEmptyStringIfAttribute"/>
        /// </summary>
        NullOrEmptyStringIf = 33,

        /// <summary>
        /// Property must be null if dependent property is target value. <see cref="NullIfAttribute"/>
        /// </summary>
        NullIf = 34,

        /// <summary>
        /// Property must be default or zero if dependent property is target value. <see cref="DecimalZeroOrDefaultIfAttribute"/>
        /// </summary>
        DecimalZeroOrDefaultIf = 35,

        /// <summary>
        /// Property must have a value indicating that the date and time are in Coordinated Universal Time (UTC).
        /// </summary>
        DateTimeInUtc = 36
    }
}
