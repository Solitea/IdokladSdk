using System;
using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Validation.Attributes
{
    internal class MinCollectionLengthAttribute : CollectionRangeAttribute
    {
        public MinCollectionLengthAttribute(int minLength)
            : base(minLength, int.MaxValue)
        {
        }

        public MinCollectionLengthAttribute(int minLength, bool allowNull)
            : base(minLength, int.MaxValue, allowNull)
        {
        }

        protected override string InvalidCollectionLengthValidationMessage(ValidationContext validationContext, int length)
        {
            return $"{validationContext.DisplayName} must have at least {MinLength} elements. Actual number of elements is {length}";
        }

        protected override bool IsCollectionLengthValid(int length)
        {
            return length >= MinLength;
        }

        protected override string NullCollectionValidationMessage(ValidationContext validationContext)
        {
            return $"{validationContext.DisplayName} can not be null. Must have at least {MinLength} elements.";
        }

        protected override void EnsureLegalLengths()
        {
            if (MinLength < 0)
            {
                throw new InvalidOperationException($"{nameof(CollectionRangeAttribute)} invalid MinimumLength value. Must be greater than 0.");
            }
        }
    }
}
