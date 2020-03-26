using System.Runtime.Serialization;

namespace IdokladSdk.Enums
{
    /// <summary>
    /// Round.
    /// </summary>
    public enum Round
    {
        /// <summary>
        /// Rounding – never
        /// </summary>
        [EnumMember(Value = "0")]
        Never = 0,

        /// <summary>
        /// Rounding – always
        /// </summary>
        [EnumMember(Value = "1")]
        Always = 1,

        /// <summary>
        /// According to a method payment (round cash payment)
        /// </summary>
        [EnumMember(Value = "2")]
        ByPaymentOption = 2
    }
}
