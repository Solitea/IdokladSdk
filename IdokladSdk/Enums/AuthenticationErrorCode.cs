namespace IdokladSdk.Enums
{
    /// <summary>
    /// AuthenticationErrorCode.
    /// </summary>
    public enum AuthenticationErrorCode
    {
        /// <summary>
        /// Agenda has free subscription.
        /// </summary>
        FreeSubscription = 0,

        /// <summary>
        /// Need to downgrade.
        /// A manual downgrade using the web interface is needed.
        /// </summary>
        NeedToDowngrade = 1,

        /// <summary>
        /// Subscription has expired.
        /// </summary>
        Expired = 2
    }
}
