using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Exceptions;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Batch;
using IdokladSdk.Requests.Extensions;
using IdokladSdk.Response;
using IdokladSdk.Serialization;
using IdokladSdk.Validation;
using Newtonsoft.Json;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Base client.
    /// </summary>
    public abstract class BaseClient
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
            HttpClient = _apiContext.HttpClient;
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
        /// Gets HttpClient.
        /// </summary>
        protected HttpClient HttpClient { get; }

        internal async Task<ApiResult<T>> ExecuteAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (HttpClient.BaseAddress != null)
            {
                throw new IdokladSdkException("HttpClient cannot have BaseAddress set.");
            }

            var response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

            var data = await ApiResultValidator.ValidateAndDeserializeResponse(response, GetDataAsync<ApiResult<T>>, _apiContext.ApiResultHandler);

            return data;
        }

        internal async Task<ApiBatchResult<T>> ExecuteBatchAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken)
            where T : new()
        {
            var response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

            var data = await ApiResultValidator.ValidateAndDeserializeResponse(response, GetDataAsync<ApiBatchResult<T>>, _apiContext.ApiBatchResultHandler);

            return data;
        }

        /// <summary>
        /// DeleteAsync.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <typeparam name="T">Return type.</typeparam>
        /// <returns>Api result.</returns>
        protected internal Task<ApiResult<T>> DeleteAsync<T>(int id, CancellationToken cancellationToken)
            where T : new()
        {
            var deleteUrl = $"{ResourceUrl}/{id}";
            return DeleteAsync<T>(deleteUrl, cancellationToken);
        }

        /// <summary>
        /// DeleteAsync.
        /// </summary>
        /// <param name="resource">Resource.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <typeparam name="T">Return type.</typeparam>
        /// <returns>Api result.</returns>
        protected internal async Task<ApiResult<T>> DeleteAsync<T>(string resource, CancellationToken cancellationToken)
            where T : new()
        {
            var request = await CreateRequestAsync(resource, HttpMethod.Delete, cancellationToken).ConfigureAwait(false);

            return await ExecuteAsync<T>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// GetAsync.
        /// </summary>
        /// <param name="resource">Resource url.</param>
        /// <param name="queryParams">Query params.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <typeparam name="T">Return type.</typeparam>
        /// <returns>Api result.</returns>
        protected internal async Task<ApiResult<T>> GetAsync<T>(
            string resource,
            Dictionary<string, string> queryParams,
            CancellationToken cancellationToken)
        {
            var resourceUri = await GetQueryStringAsync(resource, queryParams).ConfigureAwait(false);
            var request = await CreateRequestAsync(resourceUri, HttpMethod.Get, cancellationToken).ConfigureAwait(false);

            return await ExecuteAsync<T>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// PatchAsync.
        /// </summary>
        /// <typeparam name="TPatchModel">Patch type.</typeparam>
        /// <typeparam name="TGetModel">Return model.</typeparam>
        /// <param name="resource">Resource url.</param>
        /// <param name="model">Model.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Api result.</returns>
        protected internal async Task<ApiResult<TGetModel>> PatchAsync<TPatchModel, TGetModel>(
            string resource,
            TPatchModel model,
            CancellationToken cancellationToken)
            where TGetModel : new()
        {
            ValidateModel(model);
            var request = await CreateRequestAsync(resource, new HttpMethod("PATCH"), cancellationToken).ConfigureAwait(false);
            request.AddJsonBody(model, new PatchRequestJsonSerializerSettings());

            return await ExecuteAsync<TGetModel>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// PatchAsync.
        /// </summary>
        /// <typeparam name="TPatchModel">Patch type.</typeparam>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <param name="model">Model.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Api result.</returns>
        protected internal Task<ApiResult<TGetModel>> PatchAsync<TPatchModel, TGetModel>(
            TPatchModel model,
            CancellationToken cancellationToken)
            where TGetModel : new()
        {
            return PatchAsync<TPatchModel, TGetModel>(ResourceUrl, model, cancellationToken);
        }

        /// <summary>
        /// PatchAsync.
        /// </summary>
        /// <typeparam name="TPatchModel">Patch type.</typeparam>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <param name="resource">Resource url.</param>
        /// <param name="models">Models.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Api result.</returns>
        protected internal async Task<ApiBatchResult<TGetModel>> PatchAsync<TPatchModel, TGetModel>(
            string resource,
            IList<TPatchModel> models,
            CancellationToken cancellationToken)
            where TPatchModel : new()
            where TGetModel : new()
        {
            var batch = new BatchModel<TPatchModel>(models);

            ValidateModel(batch);
            var request = await CreateRequestAsync(resource, new HttpMethod("PATCH"), cancellationToken);
            request.AddJsonBody(batch, new PatchRequestJsonSerializerSettings());

            return await ExecuteBatchAsync<TGetModel>(request, cancellationToken);
        }

        /// <summary>
        /// PatchAsync.
        /// </summary>
        /// <typeparam name="TPatchModel">Patch type.</typeparam>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <param name="models">Models.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Api result.</returns>
        protected internal Task<ApiBatchResult<TGetModel>> PatchAsync<TPatchModel, TGetModel>(
            IList<TPatchModel> models,
            CancellationToken cancellationToken)
            where TPatchModel : new()
            where TGetModel : new()
        {
            return PatchAsync<TPatchModel, TGetModel>(BatchUrl, models, cancellationToken);
        }

        /// <summary>
        /// PostAsync.
        /// </summary>
        /// <typeparam name="TPostModel">Post type.</typeparam>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <param name="resource">Resource url.</param>
        /// <param name="model">Model.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Api result.</returns>
        protected internal async Task<ApiResult<TGetModel>> PostAsync<TPostModel, TGetModel>(
            string resource,
            TPostModel model,
            CancellationToken cancellationToken)
            where TGetModel : new()
        {
            ValidateModel(model);
            var request = await CreateRequestAsync(resource, HttpMethod.Post, cancellationToken).ConfigureAwait(false);
            request.AddJsonBody(model, new CommonJsonSerializerSettings());

            return await ExecuteAsync<TGetModel>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// PostAsync.
        /// </summary>
        /// <typeparam name="TPostModel">Post type.</typeparam>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <param name="model">Model.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Api result.</returns>
        protected internal Task<ApiResult<TGetModel>> PostAsync<TPostModel, TGetModel>(
            TPostModel model,
            CancellationToken cancellationToken)
            where TGetModel : new()
        {
            return PostAsync<TPostModel, TGetModel>(ResourceUrl, model, cancellationToken);
        }

        /// <summary>
        /// PostAsync.
        /// </summary>
        /// <typeparam name="TPostModel">Post type.</typeparam>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <param name="resource">Resource url.</param>
        /// <param name="models">Models.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Api result.</returns>
        protected internal async Task<ApiBatchResult<TGetModel>> PostAsync<TPostModel, TGetModel>(
            string resource,
            IList<TPostModel> models,
            CancellationToken cancellationToken)
            where TPostModel : new()
            where TGetModel : new()
        {
            var batch = new BatchModel<TPostModel>(models);
            ValidateModel(batch);
            var request = await CreateRequestAsync(resource, HttpMethod.Post, cancellationToken).ConfigureAwait(false);
            request.AddJsonBody(batch);

            return await ExecuteBatchAsync<TGetModel>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// PostAsync.
        /// </summary>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <param name="resource">Resource url.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Api result.</returns>
        protected internal async Task<ApiResult<TGetModel>> PostAsync<TGetModel>(
            string resource,
            CancellationToken cancellationToken)
        {
            var request = await CreateRequestAsync(resource, HttpMethod.Post, cancellationToken).ConfigureAwait(false);

            return await ExecuteAsync<TGetModel>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// PostAsync.
        /// </summary>
        /// <typeparam name="TPostModel">Post type.</typeparam>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <param name="models">Models.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Api batch result.</returns>
        protected internal Task<ApiBatchResult<TGetModel>> PostAsync<TPostModel, TGetModel>(
            IList<TPostModel> models,
            CancellationToken cancellationToken)
            where TPostModel : new()
            where TGetModel : new()
        {
            return PostAsync<TPostModel, TGetModel>(BatchUrl, models, cancellationToken);
        }

        /// <summary>
        /// PutAsync.
        /// </summary>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <param name="resource">Resource url.</param>
        /// <param name="queryParams">Query params.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Api result.</returns>
        protected internal async Task<ApiResult<TGetModel>> PutAsync<TGetModel>(
            string resource,
            Dictionary<string, string> queryParams,
            CancellationToken cancellationToken)
        {
            var resourceUri = await GetQueryStringAsync(resource, queryParams).ConfigureAwait(false);
            var request = await CreateRequestAsync(resourceUri, HttpMethod.Put, cancellationToken).ConfigureAwait(false);

            return await ExecuteAsync<TGetModel>(request, cancellationToken);
        }

        /// <summary>
        /// PutAsync.
        /// </summary>
        /// <typeparam name="TPutModel">Put type.</typeparam>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <param name="resource">resource url.</param>
        /// <param name="model">Model.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Api result.</returns>
        protected internal async Task<ApiResult<TGetModel>> PutAsync<TPutModel, TGetModel>(
            string resource,
            TPutModel model,
            CancellationToken cancellationToken)
            where TGetModel : new()
        {
            ValidateModel(model);
            var request = await CreateRequestAsync(resource, HttpMethod.Put, cancellationToken).ConfigureAwait(false);
            request.AddJsonBody(model);

            return await ExecuteAsync<TGetModel>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// PutAsync.
        /// </summary>
        /// <typeparam name="TPutModel">Put type.</typeparam>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <param name="resource">Resource url.</param>
        /// <param name="models">Models.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Api batch result.</returns>
        protected internal async Task<ApiBatchResult<TGetModel>> PutAsync<TPutModel, TGetModel>(
            string resource,
            IList<TPutModel> models,
            CancellationToken cancellationToken)
            where TGetModel : new()
        {
            var batch = new BatchModel<TPutModel>(models);
            ValidateModel(batch);
            var request = await CreateRequestAsync(resource, HttpMethod.Put, cancellationToken).ConfigureAwait(false);
            request.AddJsonBody(batch);

            return await ExecuteBatchAsync<TGetModel>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// PutFileAsync.
        /// </summary>
        /// <typeparam name="TGetModel">Return type.</typeparam>
        /// <param name="resource">Resource url.</param>
        /// <param name="file">File.</param>
        /// <param name="queryParams">Query params.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Api result.</returns>
        protected internal async Task<ApiResult<TGetModel>> PutFileAsync<TGetModel>(string resource, IFile file, Dictionary<string, string> queryParams, CancellationToken cancellationToken)
        {
            const string contentTypeHeader = "Content-Type";
            string boundary = "--" + DateTime.Now.Ticks.ToString("x");
            var resourceUri = await GetQueryStringAsync(resource, queryParams).ConfigureAwait(false);
            var request = await CreateRequestAsync(resourceUri, HttpMethod.Put, cancellationToken).ConfigureAwait(false);

            using (var content = new MultipartFormDataContent(boundary))
            using (var byteContent = new ByteArrayContent(file.FileBytes))
            {
                byteContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"file\"",
                    FileName = $"\"{file.FileName}\""
                };
                content.Add(byteContent, file.FileName);
                content.Headers.Remove(contentTypeHeader);
                content.Headers.TryAddWithoutValidation(contentTypeHeader, $"multipart/form-data; boundary={boundary}");
                request.Content = content;

                return await ExecuteAsync<TGetModel>(request, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Create request.
        /// </summary>
        /// <param name="resource">Resource URL.</param>
        /// <param name="method">HTTP method.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>New <see cref="HttpRequestMessage"/> instance.</returns>
        protected internal async Task<HttpRequestMessage> CreateRequestAsync(string resource, HttpMethod method, CancellationToken cancellationToken)
        {
            var requestUri = _apiContext.Configuration.ApiUrl + resource;
            var request = new HttpRequestMessage(method, requestUri);
            var token = await _apiContext.GetTokenAsync(cancellationToken).ConfigureAwait(false);

            request.Headers.Add(Constants.Header.Authorization, "Bearer " + token.AccessToken);
            request.Headers.Add(Constants.Header.App, _apiContext.AppName);
            request.Headers.Add(Constants.Header.AppVersion, _apiContext.AppVersion);
            request.Headers.Add(Constants.Header.SdkVersion, GetSdkVersion());

            foreach (var header in _apiContext.Headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            return request;
        }

        /// <summary>
        /// Returns new default entity suitable for editing and storing.
        /// </summary>
        /// <typeparam name="T">POST data type.</typeparam>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/>ApiResult with data instance.</returns>
        protected Task<ApiResult<T>> DefaultAsync<T>(CancellationToken cancellationToken)
            where T : new()
        {
            return GetAsync<T>(ResourceUrl + "/Default", null, cancellationToken);
        }

        /// <summary>
        /// Returns new default entity suitable for editing and storing for specified document.
        /// </summary>
        /// <typeparam name="T">POST data type.</typeparam>
        /// <param name="id">Id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ApiResult{TData}"/>ApiResult with data instance.</returns>
        protected Task<ApiResult<T>> DefaultAsync<T>(int id, CancellationToken cancellationToken)
            where T : new()
        {
            return GetAsync<T>($"{ResourceUrl}/Default/{id}", null, cancellationToken);
        }

        private static bool IsValidObject(object obj, out List<ValidationMessage> results)
        {
            return ApiValidator.ValidateObject(obj, out results);
        }

        private async Task<string> GetQueryStringAsync(string resource, Dictionary<string, string> queryParams)
        {
            if (queryParams is null || !queryParams.Any())
            {
                return resource;
            }

            var queryContent = new FormUrlEncodedContent(queryParams);
            var queryString = await queryContent.ReadAsStringAsync();

            var delimeter = resource.Contains("?") ? "&" : "?";

            return $"{resource}{delimeter}{queryString}";
        }

        private async Task<T> GetDataAsync<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(content, new CommonJsonSerializerSettings());

            return data;
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
