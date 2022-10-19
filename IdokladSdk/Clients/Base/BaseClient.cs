using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using IdokladSdk.Models.Batch;
using IdokladSdk.Response;
using IdokladSdk.Validation;
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
                          throw new ArgumentNullException("API context cannot be null.", nameof(apiContext));
            Client = new RestClient(_apiContext.Configuration.ApiUrl);
            Client.AddHandler("application/json", () => new CommonJsonSerializer());
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

        internal ApiResult<T> Execute<T>(RestRequest request)
        {
            var response = Client.Execute<ApiResult<T>>(request);

            ApiResultValidator.ValidateResponse(response, _apiContext.ApiResultHandler);

            return response.Data;
        }

        internal ApiBatchResult<T> ExecuteBatch<T>(RestRequest request)
            where T : new()
        {
            var response = Client.Execute<ApiBatchResult<T>>(request);

            ApiResultValidator.ValidateResponse(response, _apiContext.ApiBatchResultHandler);

            return response.Data;
        }

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <typeparam name="T">Return type.</typeparam>
        /// <returns>Api result.</returns>
        protected internal ApiResult<T> Delete<T>(int id)
            where T : new()
        {
            var deleteUrl = $"{ResourceUrl}/{id}";
            return Delete<T>(deleteUrl);
        }

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="resource">Resource url.</param>
        /// <typeparam name="T">Return type.</typeparam>
        /// <returns>Api result.</returns>
        protected internal ApiResult<T> Delete<T>(string resource)
            where T : new()
        {
            var request = CreateRequest(resource, Method.DELETE);

            return Execute<T>(request);
        }

        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="resource">Resource url.</param>
        /// <param name="queryParams">Query params.</param>
        /// <typeparam name="T">Return type.</typeparam>
        /// <returns>Api result.</returns>
        protected internal ApiResult<T> Get<T>(string resource, Dictionary<string, string> queryParams = null)
        {
            var request = CreateRequest(resource, Method.GET);
            ProcessQueryParameters(request, queryParams);

            return Execute<T>(request);
        }

        /// <summary>
        /// Patch.
        /// </summary>
        /// <param name="resource">Resource url.</param>
        /// <param name="model">Model.</param>
        /// <typeparam name="TPatchModel">Patch type.</typeparam>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <returns>Api result.</returns>
        protected internal ApiResult<TGetModel> Patch<TPatchModel, TGetModel>(string resource, TPatchModel model)
            where TGetModel : new()
        {
            ValidateModel(model);
            var request = CreateRequest(resource, Method.PATCH);
            request.JsonSerializer = new PatchRequestJsonSerializer();
            request.AddJsonBody(model);

            return Execute<TGetModel>(request);
        }

        /// <summary>
        /// Patch.
        /// </summary>
        /// <param name="model">Model.</param>
        /// <typeparam name="TPatchModel">Patch type.</typeparam>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <returns>Api result.</returns>
        protected internal ApiResult<TGetModel> Patch<TPatchModel, TGetModel>(TPatchModel model)
            where TGetModel : new()
        {
            return Patch<TPatchModel, TGetModel>(ResourceUrl, model);
        }

        /// <summary>
        /// Patch.
        /// </summary>
        /// <param name="resource">Resource url.</param>
        /// <param name="models">Models.</param>
        /// <typeparam name="TPatchModel">Patch type.</typeparam>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <returns>Api batch result.</returns>
        protected internal ApiBatchResult<TGetModel> Patch<TPatchModel, TGetModel>(
            string resource,
            IList<TPatchModel> models)
            where TPatchModel : new()
            where TGetModel : new()
        {
            var batch = new BatchModel<TPatchModel>(models);

            ValidateModel(batch);
            var request = CreateRequest(resource, Method.PATCH);
            request.JsonSerializer = new PatchRequestJsonSerializer();
            request.AddJsonBody(batch);

            return ExecuteBatch<TGetModel>(request);
        }

        /// <summary>
        /// Patch.
        /// </summary>
        /// <param name="models">Models.</param>
        /// <typeparam name="TPatchModel">Patch type.</typeparam>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <returns>Api batch result.</returns>
        protected internal ApiBatchResult<TGetModel> Patch<TPatchModel, TGetModel>(IList<TPatchModel> models)
            where TPatchModel : new()
            where TGetModel : new()
        {
            return Patch<TPatchModel, TGetModel>(BatchUrl, models);
        }

        /// <summary>
        /// Post.
        /// </summary>
        /// <param name="resource">Resource url.</param>
        /// <param name="model">Model.</param>
        /// <typeparam name="TPostModel">Post type.</typeparam>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <returns>Api result.</returns>
        protected internal ApiResult<TGetModel> Post<TPostModel, TGetModel>(string resource, TPostModel model)
            where TGetModel : new()
        {
            ValidateModel(model);
            var request = CreateRequest(resource, Method.POST);
            request.JsonSerializer = new CommonJsonSerializer();
            request.AddJsonBody(model);

            return Execute<TGetModel>(request);
        }

        /// <summary>
        /// Post.
        /// </summary>
        /// <param name="resource">Resource url.</param>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <returns>Api result.</returns>
        protected internal ApiResult<TGetModel> Post<TGetModel>(string resource)
        {
            var request = CreateRequest(resource, Method.POST);

            return Execute<TGetModel>(request);
        }

        /// <summary>
        /// Post.
        /// </summary>
        /// <param name="resource">Resource url.</param>
        /// <param name="models">Models.</param>
        /// <typeparam name="TPostModel">Post type.</typeparam>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <returns>Api result.</returns>
        protected internal ApiBatchResult<TGetModel> Post<TPostModel, TGetModel>(
            string resource,
            IList<TPostModel> models)
            where TPostModel : new()
            where TGetModel : new()
        {
            var batch = new BatchModel<TPostModel>(models);
            ValidateModel(batch);
            var request = CreateRequest(resource, Method.POST);
            request.AddJsonBody(batch);

            return ExecuteBatch<TGetModel>(request);
        }

        /// <summary>
        /// Post.
        /// </summary>
        /// <param name="models">Models.</param>
        /// <typeparam name="TPostModel">Post type.</typeparam>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <returns>Api result.</returns>
        protected internal ApiBatchResult<TGetModel> Post<TPostModel, TGetModel>(IList<TPostModel> models)
            where TPostModel : new()
            where TGetModel : new()
        {
            return Post<TPostModel, TGetModel>(BatchUrl, models);
        }

        /// <summary>
        /// Post.
        /// </summary>
        /// <param name="model">Model.</param>
        /// <typeparam name="TPostModel">PostModel.</typeparam>
        /// <typeparam name="TGetModel">GetModel.</typeparam>
        /// <returns>Api result.</returns>
        protected internal ApiResult<TGetModel> Post<TPostModel, TGetModel>(TPostModel model)
            where TGetModel : new()
        {
            return Post<TPostModel, TGetModel>(ResourceUrl, model);
        }

        /// <summary>
        /// Put.
        /// </summary>
        /// <param name="resource">Result url.</param>
        /// <param name="queryParams">Query params.</param>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <returns>Api result.</returns>
        protected internal ApiResult<TGetModel> Put<TGetModel>(
            string resource,
            Dictionary<string, string> queryParams = null)
            where TGetModel : new()
        {
            var request = CreateRequest(resource, Method.PUT);
            ProcessQueryParameters(request, queryParams);

            return Execute<TGetModel>(request);
        }

        /// <summary>
        /// Put.
        /// </summary>
        /// <param name="resource">Resource url.</param>
        /// <param name="model">Model.</param>
        /// <typeparam name="TPutModel">Put type.</typeparam>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <returns>Api result.</returns>
        protected internal ApiResult<TGetModel> Put<TPutModel, TGetModel>(string resource, TPutModel model)
            where TGetModel : new()
        {
            ValidateModel(model);
            var request = CreateRequest(resource, Method.PUT);
            request.AddJsonBody(model);

            return Execute<TGetModel>(request);
        }

        /// <summary>
        /// Put.
        /// </summary>
        /// <param name="resource">Resource url.</param>
        /// <param name="models">Models.</param>
        /// <typeparam name="TPutModel">Put type.</typeparam>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <returns>Api batch result.</returns>
        protected internal ApiBatchResult<TGetModel> Put<TPutModel, TGetModel>(string resource, IList<TPutModel> models)
            where TGetModel : new()
        {
            var batch = new BatchModel<TPutModel>(models);
            ValidateModel(batch);
            var request = CreateRequest(resource, Method.PUT);
            request.AddJsonBody(batch);

            return ExecuteBatch<TGetModel>(request);
        }

        /// <summary>
        /// Create request.
        /// </summary>
        /// <param name="resource">Resource URL.</param>
        /// <param name="method">HTTP method.</param>
        /// <returns>New RestRequest instance.</returns>
        protected internal RestRequest CreateRequest(string resource, Method method)
        {
            if (string.IsNullOrWhiteSpace(resource))
            {
                throw new ArgumentNullException("Resource URL cannot be null or empty.");
            }

            var request = new RestRequest(resource, method);
            var token = _apiContext.GetToken();

            request.AddHeader(Constants.Header.Authorization, "Bearer " + token.AccessToken);
            request.AddHeader(Constants.Header.App, _apiContext.AppName);
            request.AddHeader(Constants.Header.AppVersion, _apiContext.AppVersion);
            request.AddHeader(Constants.Header.SdkVersion, GetSdkVersion());
            request.AddHeaders(_apiContext.Headers);

            return request;
        }

        /// <summary>
        /// Returns new default entity suitable for editing and storing.
        /// </summary>
        /// <typeparam name="T">POST data type.</typeparam>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        protected ApiResult<T> Default<T>()
            where T : new()
        {
            return Get<T>(ResourceUrl + "/Default");
        }

        /// <summary>
        /// Returns new default entity suitable for editing and storing for specified document.
        /// </summary>
        /// <typeparam name="T">POST data type.</typeparam>
        /// <param name="id">Id.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance.</returns>
        protected ApiResult<T> Default<T>(int id)
            where T : new()
        {
            return Get<T>($"{ResourceUrl}/Default/{id}");
        }

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
