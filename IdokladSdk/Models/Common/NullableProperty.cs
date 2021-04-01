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
    public struct NullableProperty<T> : IEquatable<NullableProperty<T>>, IConvertible
        where T : struct, IConvertible
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

        private IConvertible OriginalValue => (IConvertible)Value.Value;

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

        /// <inheritdoc />
        public TypeCode GetTypeCode() => OriginalValue.GetTypeCode();

        /// <inheritdoc />
        public bool ToBoolean(IFormatProvider provider) => OriginalValue.ToBoolean(provider);

        /// <inheritdoc />
        public byte ToByte(IFormatProvider provider) => OriginalValue.ToByte(provider);

        /// <inheritdoc />
        public char ToChar(IFormatProvider provider) => OriginalValue.ToChar(provider);

        /// <inheritdoc />
        public DateTime ToDateTime(IFormatProvider provider) => OriginalValue.ToDateTime(provider);

        /// <inheritdoc />
        public decimal ToDecimal(IFormatProvider provider) => OriginalValue.ToDecimal(provider);

        /// <inheritdoc />
        public double ToDouble(IFormatProvider provider) => OriginalValue.ToDouble(provider);

        /// <inheritdoc />
        public short ToInt16(IFormatProvider provider) => OriginalValue.ToInt16(provider);

        /// <inheritdoc />
        public int ToInt32(IFormatProvider provider) => OriginalValue.ToInt32(provider);

        /// <inheritdoc />
        public long ToInt64(IFormatProvider provider) => OriginalValue.ToInt64(provider);

        /// <inheritdoc />
        public sbyte ToSByte(IFormatProvider provider) => OriginalValue.ToSByte(provider);

        /// <inheritdoc />
        public float ToSingle(IFormatProvider provider) => OriginalValue.ToSingle(provider);

        /// <inheritdoc />
        public string ToString(IFormatProvider provider) => OriginalValue.ToString(provider);

        /// <inheritdoc />
        public object ToType(Type conversionType, IFormatProvider provider) => OriginalValue.ToType(conversionType, provider);

        /// <inheritdoc />
        public ushort ToUInt16(IFormatProvider provider) => OriginalValue.ToUInt16(provider);

        /// <inheritdoc />
        public uint ToUInt32(IFormatProvider provider) => OriginalValue.ToUInt32(provider);

        /// <inheritdoc />
        public ulong ToUInt64(IFormatProvider provider) => OriginalValue.ToUInt64(provider);
    }
}
