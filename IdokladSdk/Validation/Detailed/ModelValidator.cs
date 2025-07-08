using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;
using IdokladSdk.Validation.Detailed.Model;

namespace IdokladSdk.Validation
{
    /// <summary>
    /// Model validator allows client side model validation based on validation attributes.
    /// </summary>
    public class ModelValidator
    {
        private string IdokladModelNamespacePrefix { get; } = GetIdokladModelNamespacePrefix();

        private Dictionary<string, PropertyValidationResult> InvalidProperties { get; set; }

        /// <summary>
        /// Validates object based on property validation attributes. It validates all properties (does not stop after
        /// first validation error). It validates also nested models (single instances or list of model instances).
        /// Returned value provides access to ValidationAttribute instances to get their constraints and to ValidationResult
        /// instances to get validation messages.
        /// </summary>
        /// <param name="model">Object to be validated.</param>
        /// <returns><see cref="ModelValidationResult"/>.</returns>
        public ModelValidationResult Validate(object model)
        {
            InvalidProperties = new Dictionary<string, PropertyValidationResult>();
            ValidateProperties(model, string.Empty);
            return CreateValidationResult();
        }

        private static bool IsCollectionOfDatetimes(Type type) => type.IsAssignableFrom(typeof(IEnumerable<DateTime>)) || type.IsAssignableFrom(typeof(IEnumerable<DateTime?>));

        private static void CheckIfPropertyIsUtcKindDateTime(PropertyInfo propertyInfo, object propertyValue, ref List<AttributeValidationResult> validationAttributes)
        {
            if (propertyInfo.PropertyType == typeof(DateTime) || Nullable.GetUnderlyingType(propertyInfo.PropertyType) == typeof(DateTime))
            {
                var dateTime = (DateTime?)propertyValue;

                if (dateTime.HasValue && dateTime.Value.Kind != DateTimeKind.Utc)
                {
                    validationAttributes.Add(new AttributeValidationResult()
                    {
                        ValidationAttribute = new UtcDateTimeAttribute(),
                        ValidationResult = new ValidationResult("DateTime must be in UTC.", new[] { propertyInfo.Name })
                    });
                }
            }
        }

        private static string GetIdokladModelNamespacePrefix()
        {
            return typeof(ValidatableModel).Namespace?.Split('.')[0];
        }

        private ValidationContext CreatePropertyValidationContext(object instance, PropertyInfo propertyInfo, ValidationContext validationContext)
        {
            return new ValidationContext(instance, validationContext, validationContext.Items)
            {
                MemberName = propertyInfo.Name
            };
        }

        private ModelValidationResult CreateValidationResult()
        {
            return new ModelValidationResult
            {
                InvalidProperties = InvalidProperties
            };
        }

        private List<PropertyInfo> GetInstanceProperties(object instance)
        {
            return instance.GetType().GetRuntimeProperties()
                .Where(IsPublicProperty)
                .ToList();
        }

        private List<ValidationAttribute> GetOtherAttributes(List<ValidationAttribute> validationAttributes, RequiredAttribute requiredAttribute)
        {
            if (requiredAttribute != null)
            {
                return validationAttributes.Except(new ValidationAttribute[] { requiredAttribute }).ToList();
            }

            return validationAttributes;
        }

        private List<ValidationAttribute> GetPropertyAttributes(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttributes(true)
                .OfType<ValidationAttribute>()
                .ToList();
        }

        private string GetPropertyName(PropertyInfo propertyInfo, string propertyNamePrefix, int? index = null)
        {
            if (string.IsNullOrEmpty(propertyNamePrefix))
            {
                return index.HasValue
                    ? $"{propertyInfo.Name}[{index}]"
                    : propertyInfo.Name;
            }

            return index.HasValue
                ? $"{propertyNamePrefix}.{propertyInfo.Name}[{index}]"
                : $"{propertyNamePrefix}.{propertyInfo.Name}";
        }

        private RequiredAttribute GetRequiredAttribute(IEnumerable<ValidationAttribute> validationAttributes)
        {
            return validationAttributes.OfType<RequiredAttribute>().FirstOrDefault();
        }

        private bool IsCollectionOfIdokladModels(Type type)
        {
            if (type.IsGenericType && typeof(IEnumerable).IsAssignableFrom(type.GetGenericTypeDefinition()))
            {
                return IsIdokladModel(type.GetGenericArguments()[0]);
            }

            return false;
        }

        private bool IsIdokladModel(Type type)
        {
            _ = type ?? throw new ArgumentNullException(nameof(type));

            if (!type.Namespace.StartsWith(IdokladModelNamespacePrefix, StringComparison.Ordinal))
            {
                return false;
            }

            if (type.IsEnum)
            {
                return false;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(NullableProperty<>))
            {
                return false;
            }

            return true;
        }

        private bool IsPublicProperty(PropertyInfo p) => (p.GetMethod != null && p.GetMethod.IsPublic) || (p.SetMethod != null && p.SetMethod.IsPublic);

        private void ProcessPropertyValidationResult(
            PropertyInfo propertyInfo,
            string propertyNamePrefix,
            ValidationContext validationContext,
            List<AttributeValidationResult> invalidAttributes)
        {
            if (invalidAttributes.Any())
            {
                var propertyValidationResult = new PropertyValidationResult
                {
                    Name = GetPropertyName(propertyInfo, propertyNamePrefix),
                    ValidationContext = validationContext,
                    InvalidAttributes = invalidAttributes
                };
                InvalidProperties.Add(propertyValidationResult.Name, propertyValidationResult);
            }
        }

        /// <summary>
        /// Checks if property is collection of DateTime and validates each DateTime in the collection.
        /// If any DateTime is not in UTC, it marks the property as invalid.
        /// </summary>
        private void ValidateNestedDateTimeCollection(object instance, PropertyInfo propertyInfo, ref ValidationContext context, string propertyNamePrefix)
        {
            var dtCollection = Enumerable.Empty<DateTime?>();
            var propertyName = GetPropertyName(propertyInfo, propertyNamePrefix);

            if (instance is IEnumerable<DateTime> dts)
            {
                dtCollection = dts.Cast<DateTime?>();
            }
            else if (instance is IEnumerable<DateTime?> nullableDts)
            {
                dtCollection = nullableDts;
            }
            else
            {
                throw new ApplicationException($"Property {propertyName} should be cast as IEnumerable<DateTime> or IEnumerable<DateTime?>");
            }

            foreach (var dt in dtCollection)
            {
                if (dt.HasValue && dt.Value.Kind != DateTimeKind.Utc)
                {
                    var validationResult = new ValidationResult("DateTime must be in UTC.", new[] { propertyName });
                    var invalidAttributes = new List<AttributeValidationResult>
                    {
                        new AttributeValidationResult
                        {
                            ValidationAttribute = new UtcDateTimeAttribute(),
                            ValidationResult = validationResult
                        }
                    };

                    ProcessPropertyValidationResult(propertyInfo, propertyNamePrefix, context, invalidAttributes);
                    break; // No need to continue checking the rest of the collection if one invalid date is found.
                }
            }
        }

        private void ValidateNestedModelCollection(object instance, PropertyInfo propertyInfo, string propertyNamePrefix)
        {
            var modelCollection = instance as IEnumerable<object> ?? throw new ApplicationException("Property should be cast as IEnumerable");
            foreach (var item in modelCollection.Select((model, index) => (model, index)))
            {
                ValidateNestedModel(item.model, propertyInfo, propertyNamePrefix, item.index);
            }
        }

        private void ValidateNestedModel(object instance, PropertyInfo propertyInfo, string propertyNamePrefix, int? index = null)
        {
            var newPropertyNamePrefix = GetPropertyName(propertyInfo, propertyNamePrefix, index);
            ValidateProperties(instance, newPropertyNamePrefix);
        }

        private void ValidateProperties(object instance,  string propertyNamePrefix)
        {
            var instanceValidationContext = new ValidationContext(instance);
            var propertyInfos = GetInstanceProperties(instance);

            foreach (var propertyInfo in propertyInfos)
            {
                var propertyValue = propertyInfo.GetValue(instance);
                var propertyValidationContext = CreatePropertyValidationContext(instance, propertyInfo, instanceValidationContext);
                var invalidAttributes = ValidateProperty(propertyInfo, propertyValue, propertyValidationContext);
                ProcessPropertyValidationResult(propertyInfo, propertyNamePrefix, propertyValidationContext, invalidAttributes);

                if (propertyValue != null)
                {
                    if (IsIdokladModel(propertyInfo.PropertyType))
                    {
                        ValidateNestedModel(propertyValue, propertyInfo, propertyNamePrefix);
                    }
                    else if (IsCollectionOfIdokladModels(propertyInfo.PropertyType))
                    {
                        ValidateNestedModelCollection(propertyValue, propertyInfo, propertyNamePrefix);
                    }
                    else if (IsCollectionOfDatetimes(propertyInfo.PropertyType))
                    {
                        ValidateNestedDateTimeCollection(propertyValue, propertyInfo, ref propertyValidationContext, propertyNamePrefix);
                    }
                }
            }
        }

        private List<AttributeValidationResult> ValidateProperty(PropertyInfo propertyInfo, object propertyValue, ValidationContext validationContext)
        {
            var validationAttributes = GetPropertyAttributes(propertyInfo);
            var invalidAttributes = new List<AttributeValidationResult>();

            CheckIfPropertyIsUtcKindDateTime(propertyInfo, propertyValue, ref invalidAttributes);

            var requiredAttribute = GetRequiredAttribute(validationAttributes);
            if (requiredAttribute != null)
            {
                var validationResult = requiredAttribute.GetValidationResult(propertyValue, validationContext);

                if (validationResult != ValidationResult.Success)
                {
                    invalidAttributes.Add(new AttributeValidationResult
                    {
                        ValidationAttribute = requiredAttribute,
                        ValidationResult = validationResult
                    });
                    return invalidAttributes;
                }
            }

            var otherAttributes = GetOtherAttributes(validationAttributes, requiredAttribute);
            foreach (var validationAttribute in otherAttributes)
            {
                var validationResult = validationAttribute.GetValidationResult(propertyValue, validationContext);

                if (validationResult != ValidationResult.Success)
                {
                    invalidAttributes.Add(new AttributeValidationResult
                    {
                        ValidationAttribute = validationAttribute,
                        ValidationResult = validationResult
                    });
                }
            }

            return invalidAttributes;
        }
    }
}
