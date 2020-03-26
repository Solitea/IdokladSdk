using System;
using System.Globalization;
using Newtonsoft.Json;

namespace IdokladSdk.Serialization
{
    /// <summary>
    /// JSON converter for API result.
    /// </summary>
    public class ApiResultDataJsonConverter : JsonConverter
    {
        /// <inheritdoc/>
        public override bool CanConvert(Type objectType) => true;

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(bool))
            {
                return Convert.ToBoolean(reader?.Value, CultureInfo.InvariantCulture);
            }

            return serializer?.Deserialize(reader, objectType);
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer?.WriteValue(value);
        }
    }
}
