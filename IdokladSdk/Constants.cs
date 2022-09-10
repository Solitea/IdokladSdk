namespace IdokladSdk
{
    /// <summary>
    /// Set of constants.
    /// </summary>
    public static partial class Constants
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

        /// <summary>
        /// Constants for header.
        /// </summary>
        public partial struct Header
        {
            public const string SecureToken = "SecureToken";

            public const string Authorization = "Authorization";

            public const string App = "X-App";

            public const string AppVersion = "X-App-Version";

            public const string ApiVersion = "X-Api-Version";

            public const string SdkVersion = "X-Sdk-Version";
        }
    }
}
