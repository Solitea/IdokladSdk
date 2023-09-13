using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace IdokladSdk.Validation.Attributes
{
    public class LogoAndSignatureExtensionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _ = validationContext ?? throw new ArgumentNullException(nameof(validationContext));
            var fileName = (string)value;

            var extension = "." + fileName.Split('.').Last().ToLower();
            var allowed = new List<string> { ".png", ".jpeg", ".jpg", ".gif" };
            if (!allowed.Contains(extension))
            {
                return new ValidationResult(
                    $"The extension {extension} is not allowed. Allowed extensions: {string.Join(", ", allowed)}");
            }

            return ValidationResult.Success;
        }
    }
}
