using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using IdokladSdk.Enums;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Validation;
using IdokladSdk.Validation.Detailed.Model;

namespace IdokladSdk.NetCore.TestApp.Examples.Providers
{
    public class CustomValidationMessageProvider : ValidationMessageProvider
    {
        /// <inheritdoc />
        public override string GetValidationMessage(PropertyValidationResult propertyValidationResult, AttributeValidationResult attributeValidationResult)
        {
            _ = attributeValidationResult ?? throw new ArgumentNullException(nameof(attributeValidationResult));
            _ = propertyValidationResult ?? throw new ArgumentNullException(nameof(propertyValidationResult));

            var propertyDisplayName = GetPropertyDisplayName(propertyValidationResult);

            switch (attributeValidationResult.ValidationType)
            {
                case ValidationType.Required:
                case ValidationType.RequiredNonDefault:
                    return string.Format(CultureInfo.CurrentCulture, ValidationMessages.Required, propertyDisplayName);

                case ValidationType.StringLength:
                    var stringLengthAttribute = (StringLengthAttribute)attributeValidationResult.ValidationAttribute;
                    return string.Format(CultureInfo.CurrentCulture, ValidationMessages.StringLength, propertyDisplayName, stringLengthAttribute.MinimumLength, stringLengthAttribute.MaximumLength);

                default:
                    return base.GetValidationMessage(propertyValidationResult, attributeValidationResult);
            }
        }

        private string GetPropertyDisplayName(PropertyValidationResult propertyValidationResult)
        {
            // If you want "user readable" property names to be used in validation messages, you have to write your own logic to get them.
            // Otherwise, display name will be used (but it's the same as property name).
            switch (propertyValidationResult.ValidationContext.ObjectInstance)
            {
                case IssuedInvoicePostModel invoice:
                    return GetInvoicePropertyName(propertyValidationResult);
                default:
                    return propertyValidationResult.ValidationContext.DisplayName;
            }
        }

        private string GetInvoicePropertyName(PropertyValidationResult propertyValidationResult)
        {
            switch (propertyValidationResult.Name)
            {
                case nameof(IssuedInvoicePostModel.Description):
                    return ApplicationStrings.Label_Description;
                case nameof(IssuedInvoicePostModel.VariableSymbol):
                    return ApplicationStrings.Label_VariableSymbol;
                default:
                    return propertyValidationResult.ValidationContext.DisplayName;
            }
        }
    }
}
