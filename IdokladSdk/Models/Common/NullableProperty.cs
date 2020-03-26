using System;
using System.Diagnostics;
using IdokladSdk.Clients;
using Newtonsoft.Json;

namespace IdokladSdk.Models.Common
{
    /// <summary>
    /// Struct for detecting whether a value of a property of nullable type was set.
    /// </summary>
    /// <typeparam name="T">Original property type.</typeparam>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    [JsonConverter(typeof(NullablePropertyJsonConverter))]
    public struct NullableProperty<T> : IEquatable<NullableProperty<T>>
        where T : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableProperty{T}"/> struct.
        /// </summary>
        /// <param name="value">Value.</param>
        public NullableProperty(T? value)
        {
            Value = value;
            IsSet = true;
        }

        /// <summary>
        /// Gets a value indicating whether a property was set.
        /// </summary>
        public bool IsSet { get; }

        /// <summary>
        /// Gets a value of a property.
        /// </summary>
        public T? Value { get; }

        private string DebuggerDisplay
        {
            get
            {
                if (IsSet)
                {
                    return Value.HasValue ? Value.ToString() : "null";
                }

                return "not set";
            }
        }

        /// <summary>
        /// Operator for casting of a value of original type to NullableProperty type.
        /// </summary>
        /// <param name="value">Property value (of original type).</param>
        public static implicit operator NullableProperty<T>(T? value)
        {
            return new NullableProperty<T>(value);
        }

        /// <summary>
        /// Operator for casting of a value of NullableProperty type to original type.
        /// </summary>
        /// <param name="value">Property value (of NullableProperty type).</param>
        public static implicit operator T?(NullableProperty<T> value)
        {
            return value.Value;
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns><c>true</c> if both operands are equal, <c>false</c> otherwise.</returns>
        public static bool operator ==(NullableProperty<T> left, NullableProperty<T> right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns><c>true</c> if both operands are not equal, <c>false</c> otherwise.</returns>
        public static bool operator !=(NullableProperty<T> left, NullableProperty<T> right)
        {
            return !(left == right);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is NullableProperty<T> nullable && Equals(nullable);
        }

        /// <inheritdoc />
        public bool Equals(NullableProperty<T> other)
        {
            return other.IsSet == IsSet && other.Value.Equals(Value);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            var hash = 17;
            hash = (hash * 23) + IsSet.GetHashCode();
            hash = (hash * 23) + Value.GetHashCode();
            return hash;
        }
    }
}
