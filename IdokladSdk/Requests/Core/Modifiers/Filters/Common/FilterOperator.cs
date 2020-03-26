namespace IdokladSdk.Requests.Core.Modifiers.Filters.Common
{
    /// <summary>
    /// Operator types for filters.
    /// </summary>
    public enum FilterOperator
    {
        /// <summary>
        /// Lower than
        /// </summary>
        Lt,

        /// <summary>
        /// Lower than or equal
        /// </summary>
        Lte,

        /// <summary>
        /// Greater than
        /// </summary>
        Gt,

        /// <summary>
        /// Greater than or equal
        /// </summary>
        Gte,

        /// <summary>
        /// Equal
        /// </summary>
        Eq,

        /// <summary>
        /// Not equal
        /// </summary>
        Neq,

        /// <summary>
        /// Contains
        /// </summary>
        Ct,

        /// <summary>
        /// Not contains
        /// </summary>
        Nct
    }
}
