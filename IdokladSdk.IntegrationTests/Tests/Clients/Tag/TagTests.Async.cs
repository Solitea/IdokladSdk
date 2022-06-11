using System.Net;
using System.Threading.Tasks;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.Tag;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Tag
{
    public partial class TagTests
    {
        [Test]
        public async Task AddTagAsync_DuplicitName_Fails()
        {
            // Arrange
            var tagPostModel = new TagPostModel
            {
                Name = Tag1Name,
            };
            PostAndMarkForDelete(tagPostModel);
            tagPostModel = new TagPostModel
            {
                Name = Tag1Name,
            };

            // Act
            var result = await TagClient.PostAsync(tagPostModel);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Test]
        public async Task AddTagAsync_SuccessfullyAdded()
        {
            // Arrange
            var tagPostModel = new TagPostModel
            {
                Name = Tag1Name,
            };

            // Act
            var tagGetModel = (await TagClient.PostAsync(tagPostModel)).AssertResult();
            MarkForDelete(tagGetModel.Id);

            // Assert
            Assert.NotZero(tagGetModel.Id);
            Assert.AreEqual(tagPostModel.Name, tagGetModel.Name);
        }

        [Test]
        public async Task DeleteTagAsync_NonExistingId_Fails()
        {
            // Arrange
            var tagId = 0;

            // Act
            var result = await TagClient.DeleteAsync(tagId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Test]
        public async Task DeleteTagAsync_SuccessfullyDeleted()
        {
            // Arrange
            var tagPostModel = new TagPostModel
            {
                Name = Tag1Name
            };
            var id = PostAndMarkForDelete(tagPostModel);

            // Act
            var result = (await TagClient.DeleteAsync(id)).AssertResult();

            // Assert
            Assert.True(result);
        }

        [Test]
        public async Task UpdateTagAsync_DuplicitName_ThrowsException()
        {
            // Arrange
            var tagPostModel = new TagPostModel
            {
                Name = Tag1Name
            };
            PostAndMarkForDelete(tagPostModel);
            tagPostModel = new TagPostModel
            {
                Name = Tag2Name,
            };
            var id = PostAndMarkForDelete(tagPostModel);
            var tagPatchModel = new TagPatchModel
            {
                Id = id,
                Name = Tag1Name
            };

            // Act
            var result = await TagClient.UpdateAsync(tagPatchModel);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Test]
        public async Task UpdateTagAsync_FullUpdate_SuccessfullyUpdated()
        {
            // Arrange
            var tagPostModel = new TagPostModel
            {
                Name = Tag1Name
            };
            var id = PostAndMarkForDelete(tagPostModel);
            var tagPatchModel = new TagPatchModel
            {
                Id = id,
                Name = Tag2Name
            };

            // Act
            var tagGetModel = (await TagClient.UpdateAsync(tagPatchModel)).AssertResult();

            // Assert
            Assert.NotZero(tagGetModel.Id);
            Assert.AreEqual(tagPatchModel.Name, tagGetModel.Name);
        }

        [Test]
        public async Task UpdateTagAsync_NameOnlyUpdate_Name_SuccessfullyUpdated()
        {
            // Arrange
            var tagPostModel = new TagPostModel
            {
                Name = Tag1Name,
            };
            var id = PostAndMarkForDelete(tagPostModel);
            var tagPatchModel = new TagPatchModel
            {
                Id = id,
                Name = Tag2Name
            };

            // Act
            var tagGetModel = (await TagClient.UpdateAsync(tagPatchModel)).AssertResult();

            // Assert
            Assert.NotZero(tagGetModel.Id);
            Assert.AreEqual(tagPatchModel.Name, tagGetModel.Name);
        }

        [Test]
        public async Task UpdateTagAsync_NonExistingId_ThrowsException()
        {
            // Arrange
            var tagId = 0;
            var tagPatchModel = new TagPatchModel
            {
                Id = tagId
            };

            // Act
            var result = await TagClient.UpdateAsync(tagPatchModel);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}
