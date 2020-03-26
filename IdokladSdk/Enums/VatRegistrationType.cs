using System.Runtime.Serialization;

namespace IdokladSdk.Enums
{
    /// <summary>
    /// VatRegistrationType.
    /// </summary>
    public enum VatRegistrationType
    {
        /// <summary>
        /// VAT non-payer
        /// </summary>
        [EnumMember(Value = "0")]
        NotVatPayer = 0,

        /// <summary>
        /// VAT payer
        /// </summary>
        [EnumMember(Value = "1")]
        VatPayer = 1,

        /// <summary>
        /// Identified person
        /// </summary>
        [EnumMember(Value = "2")]
        IdentifiedPersonVat = 2
    }
}
