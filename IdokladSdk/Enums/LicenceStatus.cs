namespace IdokladSdk.Enums
{
    /// <summary>
    /// Licence status.
    /// </summary>
    public enum LicenceStatus : int
    {
        /// <summary>
        /// Ok.
        /// </summary>
        Ok = 1,

        /// <summary>
        /// Changed.
        /// </summary>
        Changed = 2,

        /// <summary>
        /// WillExpireSoon.
        /// </summary>
        WillExpireSoon = 3,

        /// <summary>
        /// NeedToDowngrade.
        /// </summary>
        NeedToDowngrade = 4,

        /// <summary>
        /// Expired.
        /// </summary>
        Expired = 5
    }
}
