namespace IdokladSdk.Validation.PasswordStrengthValidator
{
    public class PasswordStrengthValidationResult
    {
        public bool HasRequiredLength { get; set; }

        public bool HasNumber { get; set; }

        public bool HasLowerCaseLetter { get; set; }

        public bool HasUpperCaseLetter { get; set; }
    }
}
