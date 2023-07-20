namespace IdokladSdk.Validation.PasswordStrengthValidator
{
    public interface IPasswordStrengthValidator
    {
        PasswordStrengthValidationResult Validate(string password);
    }
}
