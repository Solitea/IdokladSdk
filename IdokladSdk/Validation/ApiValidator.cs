using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace IdokladSdk
{
    /// <summary>
    /// API validator.
    /// </summary>
    public static class ApiValidator
    {
        /// <summary>
        /// Validates object based on object's data annotations.
        /// </summary>
        /// <param name="entity">Object.</param>
        /// <param name="errors">Validation errors.</param>
        /// <returns><c>true</c> if object is valid, otherwise <c>false</c>.</returns>
        public static bool ValidateObject(object entity, out List<ValidationMessage> errors)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var innerResults = new List<ValidationResult>();
            var datesAreUtc = CheckIfDateTimePropertiesAreUtc(entity, innerResults);
            var isValid = Validator.TryValidateObject(entity, new ValidationContext(entity), innerResults, true);

            errors =
                innerResults.Select(x => new ValidationMessage { Message = x.ErrorMessage, MemberNames = x.MemberNames })
                    .ToList();
            return datesAreUtc && isValid;
        }

        private static bool CheckIfDateTimePropertiesAreUtc(object entity, List<ValidationResult> validationResults)
        {
            var type = entity.GetType();
            var dateTimeProperties = type.GetProperties()
                .Where(p => p.PropertyType == typeof(DateTime) || Nullable.GetUnderlyingType(p.PropertyType) == typeof(DateTime));
            var result = true;

            foreach (var property in dateTimeProperties)
            {
                var dateTime = property.GetValue(entity) as DateTime?;

                if (dateTime.HasValue && dateTime.Value.Kind != DateTimeKind.Utc)
                {
                    validationResults.Add(new ValidationResult($"The field {property.Name} must be in UTC.", new List<string> { property.Name }));
                    result = false;
                }
            }

            return result;
        }
    }
}
