using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        private readonly List<int> _entityIdsToDelete = new List<int>();

        [SetUp]
        public void SetUp()
        {
            _entityIdsToDelete.Clear();
        }

        [TearDown]
        public void TearDown()
        {
            foreach (var id in _entityIdsToDelete)
            {
                Delete(id);
            }
        }

        [Test]
        public void Default_ReturnsEmptyTags()
        {
            // Act
            var result = Default().AssertResult();

            // Assert
            AssertHasEmptyTagIds(GetTags(result));
        }

        [Test]
        public void Patch_DuplicateTagIds_Fails()
        {
            // Arrange
            var patchModel = new TPatchModel { Id = EntityWithTags1Id };
            SetTags(patchModel, new List<int> { Tag1Id, Tag1Id });

            // Act
            var result = Update(patchModel);

            // Assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void Patch_EmptyTags_RemovesTags()
        {
            // Arrange
            var postModel = Default().AssertResult();
            SetRequiredProperties(postModel);
            var id = PostAndMarkForDelete(postModel);
            var patchModel = new TPatchModel { Id = id };
            SetTags(patchModel, new List<int>());

            // Act
            var result = Update(patchModel).AssertResult();

            // Assert
            AssertHasEmptyTags(GetTags(result));
        }

        [Test]
        public void Patch_NullTags_DoesNotModifyTags()
        {
            // Arrange
            var postModel = Default().AssertResult();
            SetRequiredProperties(postModel);
            GetTags(postModel).Add(Tag1Id);
            GetTags(postModel).Add(Tag2Id);
            var id = PostAndMarkForDelete(postModel);
            var patchModel = new TPatchModel { Id = id };

            // Act
            var result = Update(patchModel).AssertResult();

            // Assert
            AssertHasTags(GetTags(result), new List<int> { Tag1Id, Tag2Id });
        }

        [Test]
        public void Patch_SomeTags_AssignsTags()
        {
            // Arrange
            var postModel = Default().AssertResult();
            SetRequiredProperties(postModel);
            var id = PostAndMarkForDelete(postModel);
            var patchModel = new TPatchModel { Id = id };
            SetTags(patchModel, new List<int> { Tag1Id, Tag3Id });

            // Act
            var result = Update(patchModel).AssertResult();

            // Assert
            AssertHasTags(GetTags(result), new List<int> { Tag1Id, Tag3Id });
        }

        [Test]
        public void Post_EmptyTags_DoesNotAssignTags()
        {
            // Arrange
            var postModel = Default().AssertResult();
            SetRequiredProperties(postModel);

            // Act
            var result = Post(postModel).AssertResult();
            MarkForDelete(result.Id);

            // Assert
            AssertHasEmptyTags(GetTags(result));
        }

        [Test]
        public void Post_MultipleTags_AssignsTags()
        {
            // Arrange
            var postModel = Default().AssertResult();
            SetRequiredProperties(postModel);
            GetTags(postModel).Add(Tag1Id);
            GetTags(postModel).Add(Tag2Id);

            // Act
            var result = Post(postModel).AssertResult();
            MarkForDelete(result.Id);

            // Assert
            AssertHasTags(GetTags(result), new List<int> { Tag1Id, Tag2Id });
        }

        [Test]
        public void Post_NonExistingTagId_Fails()
        {
            // Arrange
            var postModel = Default().AssertResult();
            SetRequiredProperties(postModel);
            GetTags(postModel).Add(1);

            // Act
            var result = Post(postModel);

            // Assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void Post_NullTags_DoesNotAssignTags()
        {
            // Arrange
            var postModel = Default().AssertResult();
            SetRequiredProperties(postModel);
            SetTags(postModel, null);

            // Act
            var result = Post(postModel).AssertResult();
            MarkForDelete(result.Id);

            // Assert
            AssertHasEmptyTags(GetTags(result));
        }

        [Test]
        public void Post_SingleTag_AssignsTag()
        {
            // Arrange
            var postModel = Default().AssertResult();
            SetRequiredProperties(postModel);
            GetTags(postModel).Add(Tag1Id);

            // Act
            var result = Post(postModel).AssertResult();
            MarkForDelete(result.Id);

            // Assert
            AssertHasTags(GetTags(result), new List<int> { Tag1Id });
        }

        protected virtual ApiResult<TPostModel> Default() => (ApiResult<TPostModel>)((IDefaultRequest<TPostModel>)Client).Default();

        protected virtual ApiResult<bool> Delete(int id) => (ApiResult<bool>)((IDeleteRequest)Client).Delete(id);

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

        protected virtual ApiResult<TGetModel> Post(TPostModel postModel) => (ApiResult<TGetModel>)((IPostRequest<TPostModel, TGetModel>)Client).Post(postModel);

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

        protected virtual ApiResult<TGetModel> Update(TPatchModel patchModel) => (ApiResult<TGetModel>)((IPatchRequest<TPatchModel, TGetModel>)Client).Update(patchModel);

        private void MarkForDelete(int id)
        {
            _entityIdsToDelete.Add(id);
        }

        private int PostAndMarkForDelete(TPostModel postModel)
        {
            var tagGetModel = Post(postModel).AssertResult();
            MarkForDelete(tagGetModel.Id);
            return tagGetModel.Id;
        }
    }
}
