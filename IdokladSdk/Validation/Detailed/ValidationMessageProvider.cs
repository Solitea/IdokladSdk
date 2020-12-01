using System;
using System.Collections.Generic;
using System.Linq;
using IdokladSdk.Validation.Detailed.Model;

namespace IdokladSdk.Validation
{
    /// <summary>
    /// Class for obtaining validation messages.
    /// </summary>
    public class ValidationMessageProvider
    {
        /// <summary>
        /// Returns validation message for given property and validation attribute.
        /// Can be overriden to return custom messages based on <see cref="AttributeValidationResult.ValidationType"/> property.
        /// </summary>
        /// <param name="propertyValidationResult">Result of validation of property value against all its validation attributes.</param>
        /// <param name="attributeValidationResult">Result of validation of property value against single validation attribute.</param>
        /// <returns>Validation message.</returns>
        public virtual string GetValidationMessage(PropertyValidationResult propertyValidationResult, AttributeValidationResult attributeValidationResult)
        {
            _ = attributeValidationResult ?? throw new ArgumentNullException(nameof(attributeValidationResult));
            return attributeValidationResult.ValidationResult.ErrorMessage;
        }

        /// <summary>
        /// Returns validation messages for given property.
        /// </summary>
        /// <param name="propertyValidationResult">Result of validation property value against all its validation attributes.</param>
        /// <returns>Validation message.</returns>
        public virtual IEnumerable<string> GetValidationMessages(PropertyValidationResult propertyValidationResult)
        {
            _ = propertyValidationResult ?? throw new ArgumentNullException(nameof(propertyValidationResult));
            return propertyValidationResult.InvalidAttributes.Select(a => GetValidationMessage(propertyValidationResult, a));
        }
    }
}
