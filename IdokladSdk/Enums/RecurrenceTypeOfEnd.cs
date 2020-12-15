namespace IdokladSdk.Enums
{
    /// <summary>
    /// Type of recurrence end.
    /// </summary>
    public enum RecurrenceTypeOfEnd
    {
        /// <summary>
        /// Never
        /// </summary>
        Never = 0,

        /// <summary>
        /// After a specific date
        /// </summary>
        OnSpecificDate = 1,

        /// <summary>
        /// After a specific number of issues
        /// </summary>
        AfterNumberCreated = 2
    }
}
