using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Common.Extensions;

namespace IdokladSdk.Models.Common.Helpers
{
    internal static class NullablePropertyHelper
    {
        internal static object GetDependentPropertyValue(ValidationContext context, string dependentProperty)
        {
            var containerType = context.ObjectInstance.GetType();
            var dependentPropertyInfo = containerType.GetProperty(dependentProperty);
            if (dependentPropertyInfo != null)
            {
                var type = dependentPropertyInfo.PropertyType;
                if (type.IsNullablePropertyType())
                {
                    var nullableProperty = dependentPropertyInfo.GetValue(context.ObjectInstance, null);

                    return type.GetValueOfNullableProperty(nullableProperty);
                }

                return dependentPropertyInfo.GetValue(context.ObjectInstance, null);
            }

            return null;
        }

        internal static object GetValue(object value)
        {
            if (value.IsTypeOfNullableProperty(out var type))
            {
                return type.GetValueOfNullableProperty(value);
            }

            return value;
        }

        internal static bool IsNotSetNullableProperty(object value)
        {
            return value?.GetType().IsNullablePropertyType() == true && !IsNullablePropertySet(value);
        }

        private static bool IsNullablePropertySet(object value)
        {
            var genericDefinition = value.GetType().GetGenericTypeDefinition();
            var genericArgs = value.GetType().GetGenericArguments();
            var typedVariant = genericDefinition.MakeGenericType(genericArgs);
            var iSet = typedVariant?.GetProperty("IsSet")?.GetValue(value, null);
            return iSet == null || (bool)iSet;
        }
    }
}
