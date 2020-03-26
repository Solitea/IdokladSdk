using System;
using System.IO;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Common serializer for iDoklad API requests.
    /// </summary>
    public class CommonJsonSerializer : ISerializer, IDeserializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonJsonSerializer" /> class.
        /// </summary>
        public CommonJsonSerializer()
        {
            ContentType = "application/json";
            Serializer = new JsonSerializer
            {
                DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff",
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
        }

        /// <summary>
        /// Gets or sets content type for serialized content.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets instance of Newtonsoft JSON serializer used for actual serialization.
        /// </summary>
        protected JsonSerializer Serializer { get; }

        /// <summary>
        /// Serialize the object as JSON.
        /// </summary>
        /// <param name="obj">Object to serialize.</param>
        /// <returns>JSON as String.</returns>
        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    Serializer.Serialize(jsonTextWriter, obj);

                    var result = stringWriter.ToString();
                    return result;
                }
            }
        }

        /// <summary>
        /// Deserialize response as JSON.
        /// </summary>
        /// <typeparam name="T">Expected response type.</typeparam>
        /// <param name="response">Response in JSON format.</param>
        /// <returns>Deserialized object of <typeparamref name="T"/> type.</returns>
        public T Deserialize<T>(IRestResponse response)
        {
            var content = response?.Content ?? throw new ArgumentException();

            using (var stringReader = new StringReader(content))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                {
                    return Serializer.Deserialize<T>(jsonTextReader);
                }
            }
        }
    }
}
