namespace IdokladSdk
{
    /// <summary>
    /// Set of constants.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// SDK's API version.
        /// </summary>
        public const string ApiVersion = "v3";

        /// <summary>
        /// Default page number.
        /// </summary>
        public const int DefaultPage = 1;

        /// <summary>
        /// Default page size.
        /// </summary>
        public const int DefaultPageSize = 20;

        /// <summary>
        /// Default date time.
        /// </summary>
        public const string DefaultDateTimeString = "1753-1-1";

        /// <summary>
        /// DateTime format.
        /// </summary>
        public const string DateFormat = "yyyy-MM-dd HH:mm";

        /// <summary>
        /// Maximum length of document number.
        /// </summary>
        public const int MaxDocumentNumberLength = 10;

        internal struct Header
        {
            internal const string SecureToken = "SecureToken";

            internal const string Authorization = "Authorization";

            internal const string App = "X-App";

            internal const string AppVersion = "X-App-Version";

            internal const string ApiVersion = "X-Api-Version";

            internal const string SdkVersion = "X-Sdk-Version";
        }
    }
}
