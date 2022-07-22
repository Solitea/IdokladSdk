using System;

namespace IdokladSdk.Models.Common.Extensions
{
    internal static class NullableExtensions
    {
        public static bool IsAnyNullableType(this Type type, out Type underlyingType)
        {
            return type.IsNullableType(out underlyingType) || type.IsNullablePropertyType(out underlyingType);
        }

        public static bool IsNullablePropertyType(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(NullableProperty<>);
        }

        public static bool IsNullablePropertyType(this Type type, out Type underlyingType)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(NullableProperty<>))
            {
                underlyingType = type.GetGenericArguments()[0];
            }
            else
            {
                underlyingType = null;
            }

            return underlyingType != null;
        }

        public static bool IsNullableType(this Type type)
        {
            return Nullable.GetUnderlyingType(type) != null;
        }

        public static bool IsNullableType(this Type type, out Type underlyingType)
        {
            underlyingType = Nullable.GetUnderlyingType(type);
            return underlyingType != null;
        }
    }
}
