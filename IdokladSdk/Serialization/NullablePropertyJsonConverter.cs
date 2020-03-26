using System;
using IdokladSdk.Models.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Converter for Nullable property <see cref="NullableProperty{T}"/>.
    /// </summary>
    public class NullablePropertyJsonConverter : JsonConverter
    {
        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var nullablePropertyType = value.GetType();
            var nullablePropertyValue = nullablePropertyType.GetProperty(nameof(NullableProperty<int>.Value)).GetValue(value);

            if (nullablePropertyValue != null)
            {
                JToken.FromObject(nullablePropertyValue).WriteTo(writer);
            }
            else
            {
                JValue.CreateNull().WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            if (objectType is null)
            {
                throw new ArgumentNullException(nameof(objectType));
            }

            return objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(NullableProperty<>);
        }
    }
}
