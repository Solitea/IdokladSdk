namespace IdokladSdk.Enums
{
    /// <summary>
    /// Filter type according to partner's country.
    /// </summary>
    public enum VatCodeFilterPartner
    {
        /// <summary>
        /// Without restrictions.
        /// </summary>
        WithoutRestriction = 0,

        /// <summary>
        /// Domestic.
        /// </summary>
        Domestic = 1,

        /// <summary>
        /// EU member.
        /// </summary>
        EuMember = 2,

        /// <summary>
        /// Third country.
        /// </summary>
        ThirdCountry = 3
    }
}
