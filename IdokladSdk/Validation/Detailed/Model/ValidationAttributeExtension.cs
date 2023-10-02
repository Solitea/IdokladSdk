using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Validation.Detailed.Model
{
    public static class ValidationAttributeExtension
    {
        public static ValidationType GetValidationType(this ValidationAttribute attribute)
        {
            _ = attribute ?? throw new ArgumentNullException(nameof(attribute));

            switch (attribute.GetType().Name)
            {
                case nameof(RequiredAttribute): return ValidationType.Required;

                case nameof(DataTypeAttribute): return ValidationType.DataType;

                case nameof(StringLengthAttribute): return ValidationType.StringLength;

                case nameof(RangeAttribute): return ValidationType.Range;

                case nameof(NullableRangeAttribute): return ValidationType.Range;

                case nameof(RegularExpressionAttribute): return ValidationType.RegularExpression;

                case nameof(CannotEqualAttribute): return ValidationType.CannotEqual;

                case nameof(CollectionRangeAttribute): return ValidationType.CollectionRange;

                case nameof(ColorAttribute): return ValidationType.Color;

                case nameof(DateGreaterOrEqualThanAttribute): return ValidationType.DateGreaterOrEqualThan;

                case nameof(DateTimeAttribute): return ValidationType.DateTime;

                case nameof(DecimalGreaterThanZeroAttribute): return ValidationType.DecimalGreaterThanZero;

                case nameof(EmailAttribute): return ValidationType.EmailAddress;

                case nameof(EmailCollectionAttribute): return ValidationType.EmailCollection;

                case nameof(MinCollectionLengthAttribute): return ValidationType.MinCollectionLength;

                case nameof(NotEmptyStringAttribute): return ValidationType.NotEmptyString;

                case nameof(NullableForeignKeyAttribute): return ValidationType.NullableForeignKey;

                case nameof(RequiredIfAttribute): return ValidationType.RequiredIf;

                case nameof(RequiredIfHasValueAttribute): return ValidationType.RequiredIfHasValue;

                case nameof(RequiredNonDefaultAttribute): return ValidationType.RequiredNonDefault;

                case nameof(IdentificationNumberPostAttribute): return ValidationType.IdentificationNumber;

                case nameof(IdentificationNumberPatchAttribute): return ValidationType.IdentificationNumber;

                case nameof(NumericSequenceNumberFormatAttribute): return ValidationType.NumericSequenceNumberFormat;

                case nameof(BankAccountNumberAttribute): return ValidationType.BankAccountNumber;

                case nameof(IbanAttribute): return ValidationType.Iban;

                case nameof(MinPasswordStrengthAttribute): return ValidationType.MinPasswordStrength;

                case nameof(DateGreaterThanOrEqualThanAnotherDateAttribute): return ValidationType.DateGreaterOrEqualThanAnotherDate;

                case nameof(MinValueAttribute): return ValidationType.MinValue;

                case nameof(DecimalRangeAttribute): return ValidationType.Range;

                case nameof(CopyCountEndOnRecurringInvoiceAttribute): return ValidationType.CopyCountEndOnRecurringInvoice;

                case nameof(DateOfEndOnRecurringInvoiceAttribute): return ValidationType.DateOfEndOnRecurringInvoice;

                case nameof(DateGreaterOrEqualThanTodayAttribute): return ValidationType.DateGreaterOrEqualThanToday;

                case nameof(IssueLastDayOfMonthOnRecurringInvoiceAttribute): return ValidationType.IssueLastDayOfMonthOnRecurringInvoice;

                case nameof(LogoAndSignatureExtensionAttribute): return ValidationType.LogoAndSignatureExtension;

                default:
                    throw new NotImplementedException($"{nameof(ValidationType)} doesn't contain value for {attribute.GetType().Name}.");
            }
        }
    }
}
