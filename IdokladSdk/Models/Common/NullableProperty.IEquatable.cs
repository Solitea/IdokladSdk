using System;

namespace IdokladSdk.Models.Common
{
    public partial struct NullableProperty<T> : IEquatable<NullableProperty<T>>
    {
        /// <inheritdoc />
        public bool Equals(NullableProperty<T> other)
        {
            return other.IsSet == IsSet && other.Value.Equals(Value);
        }
    }
}
