using System.Text.RegularExpressions;

namespace IdokladSdk.Validation.PasswordStrengthValidator
{
    public class PasswordStrengthValidator : IPasswordStrengthValidator
    {
        private const string HasLowerCaseLetter = @"(?=.*[a-z])";
        private const string HasNumber = @"(?=.*\d)";
        private const string HasUpperCaseLetter = @"(?=.*[A-Z])";
        private const int RequiredLength = 8;

        public PasswordStrengthValidationResult Validate(string password)
        {
            password = password ?? string.Empty;
            return new PasswordStrengthValidationResult
            {
                HasLowerCaseLetter = new Regex(HasLowerCaseLetter).IsMatch(password),
                HasNumber = new Regex(HasNumber).IsMatch(password),
                HasUpperCaseLetter = new Regex(HasUpperCaseLetter).IsMatch(password),
                HasRequiredLength = password.Length >= RequiredLength,
            };
        }
    }
}
