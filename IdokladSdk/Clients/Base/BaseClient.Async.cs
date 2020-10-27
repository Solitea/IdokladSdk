using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.Models.Batch;
using IdokladSdk.Response;
using IdokladSdk.Validation;
using RestSharp;

namespace IdokladSdk.Clients
{
    public abstract partial class BaseClient
    {
        internal Task<ApiResult<T>> DeleteAsync<T>(int id, CancellationToken cancellationToken)
            where T : new()
        {
            var deleteUrl = $"{ResourceUrl}/{id}";
            return DeleteAsync<T>(deleteUrl, cancellationToken);
        }

        internal async Task<ApiResult<T>> DeleteAsync<T>(string resource, CancellationToken cancellationToken)
            where T : new()
        {
            var request = await CreateRequestAsync(resource, Method.DELETE, cancellationToken).ConfigureAwait(false);

            return await ExecuteAsync<T>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="Execute{T}(RestRequest)"/>
        internal async Task<ApiResult<T>> ExecuteAsync<T>(RestRequest request, CancellationToken cancellationToken)
        {
            var response = await Client.ExecuteAsync<ApiResult<T>>(request, cancellationToken).ConfigureAwait(false);

            ApiResultValidator.ValidateResponse(response, _apiContext.ApiResultHandler);

            return response.Data;
        }

        /// <inheritdoc cref="ExecuteBatch{T}(RestRequest)"/>
        internal async Task<ApiBatchResult<T>> ExecuteBatchAsync<T>(RestRequest request, CancellationToken cancellationToken)
            where T : new()
        {
            var response = await Client.ExecuteAsync<ApiBatchResult<T>>(request, cancellationToken).ConfigureAwait(false);

            ApiResultValidator.ValidateResponse(response, _apiContext.ApiBatchResultHandler);

            return response.Data;
        }

        /// <inheritdoc cref="Get{T}(string, Dictionary{string,string})"/>
        internal async Task<ApiResult<T>> GetAsync<T>(string resource, Dictionary<string, string> queryParams, CancellationToken cancellationToken)
        {
            var request = await CreateRequestAsync(resource, Method.GET, cancellationToken).ConfigureAwait(false);
            ProcessQueryParameters(request, queryParams);

            return await ExecuteAsync<T>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="Patch{TPatchModel,TGetModel}(string,TPatchModel)"/>
        internal async Task<ApiResult<TGetModel>> PatchAsync<TPatchModel, TGetModel>(string resource, TPatchModel model, CancellationToken cancellationToken)
            where TGetModel : new()
        {
            ValidateModel(model);
            var request = await CreateRequestAsync(resource, Method.PATCH, cancellationToken).ConfigureAwait(false);
            request.JsonSerializer = new PatchRequestJsonSerializer();
            request.AddJsonBody(model);

            return await ExecuteAsync<TGetModel>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="Patch{TPatchModel,TGetModel}(TPatchModel)"/>
        internal Task<ApiResult<TGetModel>> PatchAsync<TPatchModel, TGetModel>(TPatchModel model, CancellationToken cancellationToken)
            where TGetModel : new()
        {
            return PatchAsync<TPatchModel, TGetModel>(ResourceUrl, model, cancellationToken);
        }

        internal Task<ApiBatchResult<TGetModel>> PatchAsync<TPatchModel, TGetModel>(string resource, IList<TPatchModel> models, CancellationToken cancellationToken)
            where TPatchModel : new()
            where TGetModel : new()
        {
            var batch = new BatchModel<TPatchModel>(models);

            ValidateModel(batch);
            var request = CreateRequest(resource, Method.PATCH);
            request.JsonSerializer = new PatchRequestJsonSerializer();
            request.AddJsonBody(batch);

            return ExecuteBatchAsync<TGetModel>(request, cancellationToken);
        }

        internal Task<ApiBatchResult<TGetModel>> PatchAsync<TPatchModel, TGetModel>(IList<TPatchModel> models, CancellationToken cancellationToken)
            where TPatchModel : new()
            where TGetModel : new()
        {
            return PatchAsync<TPatchModel, TGetModel>(BatchUrl, models, cancellationToken);
        }

        /// <inheritdoc cref="Post{TPostModel,TGetModel}(string,TPostModel)"/>
        internal async Task<ApiResult<TGetModel>> PostAsync<TPostModel, TGetModel>(string resource, TPostModel model, CancellationToken cancellationToken)
            where TGetModel : new()
        {
            ValidateModel(model);
            var request = await CreateRequestAsync(resource, Method.POST, cancellationToken).ConfigureAwait(false);
            request.JsonSerializer = new CommonJsonSerializer();
            request.AddJsonBody(model);

            return await ExecuteAsync<TGetModel>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="Post{TPostModel,TGetModel}(string,TPostModel)"/>
        internal Task<ApiResult<TGetModel>> PostAsync<TPostModel, TGetModel>(TPostModel model, CancellationToken cancellationToken)
            where TGetModel : new()
        {
            return PostAsync<TPostModel, TGetModel>(ResourceUrl, model, cancellationToken);
        }

        internal async Task<ApiBatchResult<TGetModel>> PostAsync<TPostModel, TGetModel>(string resource, IList<TPostModel> models, CancellationToken cancellationToken)
            where TPostModel : new()
            where TGetModel : new()
        {
            var batch = new BatchModel<TPostModel>(models);
            ValidateModel(batch);
            var request = await CreateRequestAsync(resource, Method.POST, cancellationToken).ConfigureAwait(false);
            request.AddJsonBody(batch);

            return await ExecuteBatchAsync<TGetModel>(request, cancellationToken).ConfigureAwait(false);
        }

        internal async Task<ApiResult<TGetModel>> PostAsync<TGetModel>(string resource, CancellationToken cancellationToken)
        {
            var request = await CreateRequestAsync(resource, Method.POST, cancellationToken).ConfigureAwait(false);

            return await ExecuteAsync<TGetModel>(request, cancellationToken).ConfigureAwait(false);
        }

        internal Task<ApiBatchResult<TGetModel>> PostAsync<TPostModel, TGetModel>(IList<TPostModel> models, CancellationToken cancellationToken)
            where TPostModel : new()
            where TGetModel : new()
        {
            return PostAsync<TPostModel, TGetModel>(BatchUrl, models, cancellationToken);
        }

        internal Task<ApiResult<TGetModel>> PutAsync<TGetModel>(string resource, Dictionary<string, string> queryParams, CancellationToken cancellationToken)
        {
            var request = CreateRequest(resource, Method.PUT);
            ProcessQueryParameters(request, queryParams);

            return ExecuteAsync<TGetModel>(request, cancellationToken);
        }

        internal async Task<ApiResult<TGetModel>> PutAsync<TPutModel, TGetModel>(string resource, TPutModel model, CancellationToken cancellationToken)
            where TGetModel : new()
        {
            ValidateModel(model);
            var request = await CreateRequestAsync(resource, Method.PUT, cancellationToken).ConfigureAwait(false);
            request.AddJsonBody(model);

            return await ExecuteAsync<TGetModel>(request, cancellationToken).ConfigureAwait(false);
        }

        internal async Task<ApiBatchResult<TGetModel>> PutAsync<TPutModel, TGetModel>(string resource, IList<TPutModel> models, CancellationToken cancellationToken)
            where TGetModel : new()
        {
            var batch = new BatchModel<TPutModel>(models);
            ValidateModel(batch);
            var request = await CreateRequestAsync(resource, Method.PUT, cancellationToken).ConfigureAwait(false);
            request.AddJsonBody(batch);

            return await ExecuteBatchAsync<TGetModel>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="CreateRequest"/>
        protected async Task<RestRequest> CreateRequestAsync(string resource, Method method, CancellationToken cancellationToken)
        {
            var request = new RestRequest(resource, method);
            var token = await _apiContext.GetTokenAsync(cancellationToken).ConfigureAwait(false);

            request.AddHeader(Constants.Header.Authorization, "Bearer " + token.AccessToken);
            request.AddHeader(Constants.Header.App, _apiContext.AppName);
            request.AddHeader(Constants.Header.AppVersion, _apiContext.AppVersion);
            request.AddHeader(Constants.Header.SdkVersion, Constants.Header.SdkVersionNumber);
            request.AddHeaders(_apiContext.Headers);

            return request;
        }

        /// <inheritdoc cref="Default{T}()"/>
        protected Task<ApiResult<T>> DefaultAsync<T>(CancellationToken cancellationToken)
            where T : new()
        {
            return GetAsync<T>(ResourceUrl + "/Default", null, cancellationToken);
        }

        /// <inheritdoc cref="Default{T}(int)"/>
        protected Task<ApiResult<T>> DefaultAsync<T>(int id, CancellationToken cancellationToken)
            where T : new()
        {
            return GetAsync<T>($"{ResourceUrl}/Default/{id}", null, cancellationToken);
        }
    }
}
