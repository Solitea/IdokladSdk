namespace IdokladSdk.Enums
{
    /// <summary>
    /// ExportedState.
    /// </summary>
    public enum ExportedState
    {
        /// <summary>
        /// Doklad nebyl exportován.
        /// </summary>
        /// <summary xml:lang="en">
        /// The document was not exported.
        /// </summary>
        NotExported = 0,

        /// <summary>
        /// Doklad byl exportován do externího účetního software. Změnou dokladu s nastaveným Exported = 1 se exported automaticky nastaví na Changed.
        /// </summary>
        /// <summary xml:lang="en">
        /// The document was exported to an external accounting system. Changing a document with Exported = 1 will change the exported value to Changed.
        /// </summary>
        Exported = 1,

        /// <summary>
        /// Doklad byl exportován a následně v iDokladu změněn.
        /// </summary>
        /// <summary xml:lang="en">
        /// The document was exported and later changed in ItsMyBill.
        /// </summary>
        Changed = 2,

        /// <summary>
        /// Doklad byl exportován a následně v iDokladu smazán.
        /// </summary>
        /// <summary xml:lang="en">
        /// The document was exported and later deleted in ItsMyBill.
        /// </summary>
        Deleted = 3
    }
}
