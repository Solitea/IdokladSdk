using System;

namespace IdokladSdk.Models.Common.Extensions
{
    internal static class NullableExtensions
    {
        internal static object GetValueOfNullableProperty(this Type type, object value)
        {
            return type.GetProperty("Value").GetValue(value, null);
        }

        internal static bool IsAnyNullableType(this Type type, out Type underlyingType)
        {
            return type.IsNullableType(out underlyingType) || type.IsNullablePropertyType(out underlyingType);
        }

        internal static bool IsNullablePropertyType(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(NullableProperty<>);
        }

        internal static bool IsNullablePropertyType(this Type type, out Type underlyingType)
        {
            if (type.IsNullablePropertyType())
            {
                underlyingType = type.GetGenericArguments()[0];
            }
            else
            {
                underlyingType = null;
            }

            return underlyingType != null;
        }

        internal static bool IsNullableType(this Type type)
        {
            return Nullable.GetUnderlyingType(type) != null;
        }

        internal static bool IsNullableType(this Type type, out Type underlyingType)
        {
            underlyingType = Nullable.GetUnderlyingType(type);
            return underlyingType != null;
        }

        internal static bool IsTypeOfNullableProperty(this object value, out Type type)
        {
            type = value?.GetType();
            return type != null && type.IsNullablePropertyType();
        }
    }
}
