using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models;
using IdokladSdk.Models.Common;
using IdokladSdk.Requests.Core.Interfaces;
using IdokladSdk.Response;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Core.Tags
{
    public abstract class TaggableDocumentTestsBase<TClient, TDetail, TList, TGetModel, TGetListModel, TPostModel, TPatchModel, TExpandModel, TFilterModel>
        : TaggableDocumentGetTestsBase<TClient, TDetail, TList, TGetModel, TGetListModel, TExpandModel, TFilterModel>
        where TClient : BaseClient, IEntityDetail<TDetail>, IEntityList<TList>
        where TDetail : class, IGetDetailRequest<TGetModel>, IExpandable<TDetail, TExpandModel>
        where TList : class, IGetListRequest<TGetListModel>, IFilterable<TList, TFilterModel>
        where TGetModel : IEntityId, new()
        where TGetListModel : IEntityId, new()
        where TPostModel : class, new()
        where TPatchModel : IEntityId, new()
    {
        protected const int PartnerId = 323824;

        private readonly List<int> _entityIdsToDelete = new ();

        [SetUp]
        public void SetUp()
        {
            _entityIdsToDelete.Clear();
        }

        [TearDown]
        public async Task TearDown()
        {
            var tasks = _entityIdsToDelete.Select(DeleteAsync);

            await Task.WhenAll(tasks);
        }

        [Test]
        public async Task Default_ReturnsEmptyTagsAsync()
        {
            // Act
            var result = await DefaultAsync().AssertResult();

            // Assert
            AssertHasEmptyTagIds(GetTags(result));
        }

        [Test]
        public async Task Patch_DuplicateTagIds_FailsAsync()
        {
            // Arrange
            var patchModel = new TPatchModel { Id = EntityWithTags1Id };
            SetTags(patchModel, new List<int> { Tag1Id, Tag1Id });

            // Act
            var result = await UpdateAsync(patchModel);

            // Assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task Patch_EmptyTags_RemovesTagsAsync()
        {
            // Arrange
            var postModel = await DefaultAsync().AssertResult();
            SetRequiredProperties(postModel);
            var id = await PostAndMarkForDeleteAsync(postModel);
            var patchModel = new TPatchModel { Id = id };
            SetTags(patchModel, new List<int>());

            // Act
            var result = await UpdateAsync(patchModel).AssertResult();

            // Assert
            AssertHasEmptyTags(GetTags(result));
        }

        [Test]
        public async Task Patch_NullTags_DoesNotModifyTagsAsync()
        {
            // Arrange
            var postModel = await DefaultAsync().AssertResult();
            SetRequiredProperties(postModel);
            GetTags(postModel).Add(Tag1Id);
            GetTags(postModel).Add(Tag2Id);
            var id = await PostAndMarkForDeleteAsync(postModel);
            var patchModel = new TPatchModel { Id = id };

            // Act
            var result = await UpdateAsync(patchModel).AssertResult();

            // Assert
            AssertHasTags(GetTags(result), new List<int> { Tag1Id, Tag2Id });
        }

        [Test]
        public async Task Patch_SomeTags_AssignsTagsAsync()
        {
            // Arrange
            var postModel = await DefaultAsync().AssertResult();
            SetRequiredProperties(postModel);
            var id = await PostAndMarkForDeleteAsync(postModel);
            var patchModel = new TPatchModel { Id = id };
            SetTags(patchModel, new List<int> { Tag1Id, Tag3Id });

            // Act
            var result = await UpdateAsync(patchModel).AssertResult();

            // Assert
            AssertHasTags(GetTags(result), new List<int> { Tag1Id, Tag3Id });
        }

        [Test]
        public async Task Post_EmptyTags_DoesNotAssignTagsAsync()
        {
            // Arrange
            var postModel = await DefaultAsync().AssertResult();
            SetRequiredProperties(postModel);

            // Act
            var result = await PostAsync(postModel).AssertResult();
            MarkForDelete(result.Id);

            // Assert
            AssertHasEmptyTags(GetTags(result));
        }

        [Test]
        public async Task Post_MultipleTags_AssignsTagsAsync()
        {
            // Arrange
            var postModel = await DefaultAsync().AssertResult();
            SetRequiredProperties(postModel);
            GetTags(postModel).Add(Tag1Id);
            GetTags(postModel).Add(Tag2Id);

            // Act
            var result = await PostAsync(postModel).AssertResult();
            MarkForDelete(result.Id);

            // Assert
            AssertHasTags(GetTags(result), new List<int> { Tag1Id, Tag2Id });
        }

        [Test]
        public async Task Post_NonExistingTagId_FailsAsync()
        {
            // Arrange
            var postModel = await DefaultAsync().AssertResult();
            SetRequiredProperties(postModel);
            GetTags(postModel).Add(1);

            // Act
            var result = await PostAsync(postModel);

            // Assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task Post_NullTags_DoesNotAssignTagsAsync()
        {
            // Arrange
            var postModel = await DefaultAsync().AssertResult();
            SetRequiredProperties(postModel);
            SetTags(postModel, null);

            // Act
            var result = await PostAsync(postModel).AssertResult();
            MarkForDelete(result.Id);

            // Assert
            AssertHasEmptyTags(GetTags(result));
        }

        [Test]
        public async Task Post_SingleTag_AssignsTagAsync()
        {
            // Arrange
            var postModel = await DefaultAsync().AssertResult();
            SetRequiredProperties(postModel);
            GetTags(postModel).Add(Tag1Id);

            // Act
            var result = await PostAsync(postModel).AssertResult();
            MarkForDelete(result.Id);

            // Assert
            AssertHasTags(GetTags(result), new List<int> { Tag1Id });
        }

        protected virtual Task<ApiResult<TPostModel>> DefaultAsync() => ((IDefaultRequest<TPostModel>)Client).DefaultAsync();

        protected virtual Task<ApiResult<bool>> DeleteAsync(int id) => ((IDeleteRequest)Client).DeleteAsync(id);

        protected List<TagDocumentGetModel> GetTags(TGetModel getModel)
        {
            var tagsProperty = typeof(TGetModel).GetProperties().First(p => p.Name == TagsPropertyName && p.DeclaringType == typeof(TGetModel));
            return (List<TagDocumentGetModel>)tagsProperty.GetValue(getModel);
        }

        protected List<int> GetTags(TPostModel postModel)
        {
            var tagsProperty = typeof(TPostModel).GetProperty(TagsPropertyName);
            return (List<int>)tagsProperty.GetValue(postModel);
        }

        protected virtual Task<ApiResult<TGetModel>> PostAsync(TPostModel postModel) => ((IPostRequest<TPostModel, TGetModel>)Client).PostAsync(postModel);

        protected abstract void SetRequiredProperties(TPostModel postModel);

        protected void SetTags(TPatchModel patchModel, List<int> tagIds)
        {
            var tagsProperty = typeof(TPatchModel).GetProperty(TagsPropertyName);
            tagsProperty.SetValue(patchModel, tagIds);
        }

        protected void SetTags(TPostModel postModel, List<int> tagIds)
        {
            var tagsProperty = typeof(TPostModel).GetProperty(TagsPropertyName);
            tagsProperty.SetValue(postModel, tagIds);
        }

        protected virtual Task<ApiResult<TGetModel>> UpdateAsync(TPatchModel patchModel) => ((IPatchRequest<TPatchModel, TGetModel>)Client).UpdateAsync(patchModel);

        private void MarkForDelete(int id)
        {
            _entityIdsToDelete.Add(id);
        }

        private async Task<int> PostAndMarkForDeleteAsync(TPostModel postModel)
        {
            var tagGetModel = await PostAsync(postModel).AssertResult();
            MarkForDelete(tagGetModel.Id);
            return tagGetModel.Id;
        }
    }
}
