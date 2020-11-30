namespace IdokladSdk.Enums
{
    /// <summary>
    /// IdentificationValidationResult.
    /// </summary>
    public enum IdentificationValidationResult
    {
        /// <summary>
        /// Validation OK
        /// </summary>
        Ok = 0,

        /// <summary>
        /// No value to validate
        /// </summary>
        NoValue = 1,

        /// <summary>
        /// Bad format of value
        /// </summary>
        BadFormat = 2,

        /// <summary>
        /// Check validation error
        /// </summary>
        CheckFailed = 3,

        /// <summary>
        /// Other validation error
        /// </summary>
        OtherError = 4
    }
}
