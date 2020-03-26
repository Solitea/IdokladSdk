namespace IdokladSdk.Enums
{
    /// <summary>
    /// EetResponsibility.
    /// </summary>
    public enum EetResponsibility
    {
        /// <summary>
        /// Zaevidovaní dokladu do EET za vás provede iDoklad.
        /// </summary>
        /// <summary xml:lang="en">
        /// ItsMyBill will register the document into EET for you.
        /// </summary>
        Idoklad = 0,

        /// <summary>
        /// Nechcete, aby za vás iDoklad provedl registraci do EET.
        /// </summary>
        /// <summary xml:lang="en">
        /// Use if you don't want ItsMyBill to register the document into EET.
        /// </summary>
        ExternalApplication = 1
    }
}
