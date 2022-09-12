using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Reflection;
using RestSharp;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Base client.
    /// </summary>
    public abstract partial class BaseClient
    {
        private readonly ApiContext _apiContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseClient"/> class.
        /// </summary>
        /// <param name="apiContext">Instance of ApiContext.</param>
        protected BaseClient(ApiContext apiContext)
        {
            _apiContext = apiContext ??
                          throw new ArgumentNullException(nameof(apiContext), "API context cannot be null.");
            //Client = new RestClient(_apiContext.Configuration.ApiUrl);
            Client = _apiContext.ApiRestClient;
            //Client.AddHandler("application/json", () => new CommonJsonSerializer());
            Client.UseSerializer<CommonJsonSerializer>();
        }

        /// <summary>
        /// Gets resource URL.
        /// </summary>
        public abstract string ResourceUrl { get; }

        /// <summary>
        /// Gets resource URL for batch operations.
        /// </summary>
        protected virtual string BatchUrl => $"{ResourceUrl}/Batch";

        /// <summary>
        /// Gets RestClient.
        /// </summary>
        protected RestClient Client { get; }

        /// <summary>
        /// Gets HttpClient.
        /// </summary>
        protected HttpClient HttpClient { get; }

        private static bool IsValidObject(object obj, out List<ValidationMessage> results)
        {
            return ApiValidator.ValidateObject(obj, out results);
        }

        private static void ProcessQueryParameters(RestRequest request, Dictionary<string, string> queryParams)
        {
            if (queryParams != null)
            {
                foreach (var item in queryParams)
                {
                    request.AddQueryParameter(item.Key, item.Value);
                }
            }
        }

        private string GetSdkVersion() => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        private void ValidateModel<T>(T model)
        {
            if (!IsValidObject(model, out List<ValidationMessage> errors))
            {
                throw new ValidationException("Model is not valid.\n" + string.Join("\n", errors));
            }
        }
    }
}
