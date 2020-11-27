using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Validation.Attributes
{
    public class RequiredIfHasValueAttribute : ValidationAttribute
    {
        public RequiredIfHasValueAttribute(string dependentProperty)
        {
            DependentProperty = dependentProperty;
        }

        public string DependentProperty { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var containerType = validationContext.ObjectInstance.GetType();
            var field = containerType.GetProperty(DependentProperty);

            if (field != null)
            {
                var dependentValue = field.GetValue(validationContext.ObjectInstance, null);
                if (dependentValue != null && value == null)
                {
                    return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
                }
            }

            return null;
        }
    }
}
