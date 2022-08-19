using IdokladSdk.Models.Common.Extensions;

namespace IdokladSdk.Models.Common.Helpers
{
    internal static class NullablePropertyHelper
    {
        internal static object GetValue(object value)
        {
            if (value.IsTypeOfNullableProperty(out var type))
            {
                return type.GetValueOfNullableProperty(value);
            }

            return value;
        }
    }
}
