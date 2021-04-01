using System;

namespace IdokladSdk.Models.Common
{
    public partial struct NullableProperty<T> : IConvertible
    {
        private IConvertible OriginalValue => (IConvertible)Value.Value;

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
