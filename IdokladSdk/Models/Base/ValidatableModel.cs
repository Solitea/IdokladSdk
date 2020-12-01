using IdokladSdk.Validation;
using IdokladSdk.Validation.Detailed.Model;

namespace IdokladSdk.Models.Base
{
    /// <summary>
    /// Validatable model.
    /// </summary>
    public abstract class ValidatableModel
    {
        /// <summary>
        /// Validates model on client based on validation attributes.
        /// </summary>
        /// <returns><see cref="ModelValidationResult"/>.</returns>
        public virtual ModelValidationResult Validate()
        {
            var validator = new ModelValidator();
            return validator.Validate(this);
        }
    }
}
