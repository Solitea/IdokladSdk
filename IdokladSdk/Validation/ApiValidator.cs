using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

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
            var isValid = ValidateEntity(entity, innerResults);

            errors =
                innerResults.Select(x => new ValidationMessage { Message = x.ErrorMessage, MemberNames = x.MemberNames })
                    .ToList();
            return isValid;
        }

        private static IEnumerable<object> GetNestedObjects(object entity)
        {
            return entity.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(x => x.CanRead
                        && x.GetIndexParameters().Length == 0
                        && x.PropertyType != typeof(string)
                        && !x.PropertyType.IsValueType)
                .Select(x => x.GetValue(entity, null))
                .Where(x => x != null);
        }

        private static bool CheckIfDateTimePropertiesAreUtc(object entity, IList<ValidationResult> validationResults)
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

        private static bool ValidateCollectionOfEntities(object collection, IList<ValidationResult> validationResults)
        {
            var isValid = true;
            var collectionOfEntities = collection as IEnumerable;

            foreach (var entityFromCollection in collectionOfEntities)
            {
                isValid &= ValidateEntity(entityFromCollection, validationResults);
            }

            return isValid;
        }

        private static bool ValidateEntities(IEnumerable<object> entities, IList<ValidationResult> validationResults)
        {
            var isValid = true;

            foreach (var entity in entities)
            {
                var entityType = entity.GetType();

                if (entityType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(entityType))
                {
                    isValid &= ValidateCollectionOfEntities(entity, validationResults);
                }
                else
                {
                    isValid &= ValidateEntity(entity, validationResults);
                }
            }

            return isValid;
        }

        private static bool ValidateEntity(object entity, IList<ValidationResult> validationResults)
        {
            var datesAreUtc = CheckIfDateTimePropertiesAreUtc(entity, validationResults);
            var validationContext = new ValidationContext(entity);

            var isValid = Validator.TryValidateObject(entity, validationContext, validationResults, true);
            var nestedEntities = GetNestedObjects(entity);

            if (nestedEntities.Any())
            {
                isValid &= ValidateEntities(nestedEntities, validationResults);
            }

            return datesAreUtc && isValid;
        }
    }
}
