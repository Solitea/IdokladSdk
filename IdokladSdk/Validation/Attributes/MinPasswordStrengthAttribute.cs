using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace IdokladSdk.Validation.Attributes
{
    /// <summary>
    /// Attribute to validate password strength.
    /// </summary>
    public class MinPasswordStrengthAttribute : ValidationAttribute
    {
        private const string HasNumber = @"(?=.*\d)";
        private const string HasLowerCaseLetter = @"(?=.*[a-z])";
        private const string HasUpperCaseLetter = @"(?=.*[A-Z])";
        private const string AtLeastOneTimes = @"{1,}";
        private const string PasswordStrength = HasNumber + HasLowerCaseLetter + HasUpperCaseLetter + "." + AtLeastOneTimes;

        /// <summary>
        /// Initializes a new instance of the <see cref="MinPasswordStrengthAttribute"/> class.
        /// </summary>
        public MinPasswordStrengthAttribute()
            : base(PasswordStrength)
        {
        }

        /// <inheritdoc/>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var password = value.ToString();
                if (Regex.IsMatch(password, PasswordStrength))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("The password must contain at least one lower case letter, one upper case letter and one number.");
                }
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
