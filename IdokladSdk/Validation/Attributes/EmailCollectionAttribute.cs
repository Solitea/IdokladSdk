using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace IdokladSdk.Validation.Attributes
{
    /// <summary>
    /// Attribute for validation collection of strings.
    /// </summary>
    public class EmailCollectionAttribute : ValidationAttribute
    {
        /// <inheritdoc/>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var collection = value as ICollection<string>;

            if (collection.All(x => Regex.IsMatch(x, EmailAttribute.RegExpression)))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage, new List<string> { validationContext?.MemberName });
        }
    }
}
