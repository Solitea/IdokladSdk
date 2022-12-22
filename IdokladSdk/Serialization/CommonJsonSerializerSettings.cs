using Newtonsoft.Json;

namespace IdokladSdk.Serialization
{
    /// <summary>
    /// Common serializer settings for iDoklad API requests.
    /// </summary>
    public class CommonJsonSerializerSettings : JsonSerializerSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonJsonSerializerSettings" /> class.
        /// </summary>
        public CommonJsonSerializerSettings()
        {
            DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff";
            DateTimeZoneHandling = DateTimeZoneHandling.Utc;
        }
    }
}
