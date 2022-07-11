using System;
using Newtonsoft.Json;

namespace IdokladSdk.Serialization
{
    public class DateTimeConverter : JsonConverter
    {
        private const string DefaultDateTime = "1753-01-01";

        public override bool CanConvert(Type objectType) => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value.ToString().Equals(DefaultDateTime))
            {
                return null;
            }

            return serializer?.Deserialize(reader, objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
