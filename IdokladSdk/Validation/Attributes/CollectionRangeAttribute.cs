using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Validation.Attributes
{
    public class CollectionRangeAttribute : ValidationAttribute
    {
        public CollectionRangeAttribute()
        {
            MinLength = 0;
            MaxLength = int.MaxValue;
            AllowNull = false;
        }

        public CollectionRangeAttribute(int minLength, int maxLength)
        {
            MinLength = minLength;
            MaxLength = maxLength;
            AllowNull = false;
        }

        public CollectionRangeAttribute(int minLength, int maxLength, bool allowNull)
        {
            MinLength = minLength;
            MaxLength = maxLength;
            AllowNull = allowNull;
        }

        protected int MaxLength { get; set; }

        protected int MinLength { get; set; }

        protected bool AllowNull { get; set; }

        protected virtual void EnsureLegalLengths()
        {
            if (MinLength < 0)
            {
                throw new InvalidOperationException($"{nameof(CollectionRangeAttribute)} invalid MinimumLength value. Must be greater than 0.");
            }

            if (MinLength > MaxLength)
            {
                throw new InvalidOperationException($"{nameof(CollectionRangeAttribute)} invalid range values. MaximumLength must be greater or equal MinimumLength. MaximumLength: {MaxLength} MinimumLength:{MinLength}");
            }
        }

        protected virtual string InvalidCollectionLengthValidationMessage(ValidationContext validationContext, int length)
        {
            _ = validationContext ?? throw new ArgumentNullException(nameof(validationContext));
            return $"{validationContext.DisplayName} count is not within required range <{MinLength}, {MaxLength}>. Actual length is {length}";
        }

        protected virtual bool IsCollectionLengthValid(int length)
        {
            return (length >= MinLength) && (length <= MaxLength);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            EnsureLegalLengths();
            var collection = value as ICollection;

            if (collection == null && AllowNull)
            {
                return ValidationResult.Success;
            }

            if (collection == null)
            {
                return new ValidationResult(NullCollectionValidationMessage(validationContext));
            }

            var length = collection.Count;
            var isValid = IsCollectionLengthValid(length);
            return isValid ?
                ValidationResult.Success :
                new ValidationResult(InvalidCollectionLengthValidationMessage(validationContext, length));
        }

        protected virtual string NullCollectionValidationMessage(ValidationContext validationContext)
        {
            _ = validationContext ?? throw new ArgumentNullException(nameof(validationContext));
            return $"{validationContext.DisplayName} must be a collection with length within required range <{MinLength}, {MaxLength}>.";
        }
    }
}
