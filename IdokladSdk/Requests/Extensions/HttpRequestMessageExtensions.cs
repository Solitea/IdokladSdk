using System.Net.Http;
using System.Text;
using IdokladSdk.Serialization;
using Newtonsoft.Json;

namespace IdokladSdk.Requests.Extensions
{
    internal static class HttpRequestMessageExtensions
    {
        internal static void AddJsonBody(this HttpRequestMessage request, object model)
        {
            var json = JsonConvert.SerializeObject(model, new CommonJsonSerializerSettings());
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        internal static void AddJsonBody(this HttpRequestMessage request, object model, JsonSerializerSettings jsonSerializerSettings)
        {
            var json = JsonConvert.SerializeObject(model, jsonSerializerSettings);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
