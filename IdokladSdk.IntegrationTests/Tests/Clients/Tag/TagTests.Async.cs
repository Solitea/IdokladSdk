using System.Net;
using System.Threading.Tasks;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.Tag;
using NUnit.Framework;

namespace Doklad.Tests.Integration.Doklad.Web.Api.ControllerTests.Version3
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
                Color = Tag1Color
            };
            PostAndMarkForDelete(tagPostModel);
            tagPostModel = new TagPostModel
            {
                Name = Tag1Name,
                Color = Tag2Color
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
                Color = Tag1Color
            };

            // Act
            var tagGetModel = (await TagClient.PostAsync(tagPostModel)).AssertResult();
            MarkForDelete(tagGetModel.Id);

            // Assert
            Assert.NotZero(tagGetModel.Id);
            Assert.AreEqual(Lowercase(tagPostModel.Color), tagGetModel.Color);
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
                Name = Tag1Name,
                Color = Tag1Color
            };
            var id = PostAndMarkForDelete(tagPostModel);

            // Act
            var result = (await TagClient.DeleteAsync(id)).AssertResult();

            // Assert
            Assert.True(result);
        }

        public async Task UpdateTagAsync_ColorOnlyUpdate_SuccessfullyUpdated()
        {
            // Arrange
            var tagPostModel = new TagPostModel
            {
                Name = Tag1Name,
                Color = Tag1Color
            };
            var id = PostAndMarkForDelete(tagPostModel);
            var tagPatchModel = new TagPatchModel
            {
                Id = id,
                Color = Tag2Color
            };

            // Act
            var tagGetModel = (await TagClient.UpdateAsync(tagPatchModel)).AssertResult();

            // Assert
            Assert.NotZero(tagGetModel.Id);
            Assert.AreEqual(Lowercase(tagPatchModel.Color), tagGetModel.Color);
            Assert.AreEqual(tagPostModel.Name, tagGetModel.Name);
        }

        [Test]
        public async Task UpdateTagAsync_DuplicitName_ThrowsException()
        {
            // Arrange
            var tagPostModel = new TagPostModel
            {
                Name = Tag1Name,
                Color = Tag1Color
            };
            PostAndMarkForDelete(tagPostModel);
            tagPostModel = new TagPostModel
            {
                Name = Tag2Color,
                Color = Tag2Color
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
                Name = Tag1Name,
                Color = Tag1Color
            };
            var id = PostAndMarkForDelete(tagPostModel);
            var tagPatchModel = new TagPatchModel
            {
                Id = id,
                Name = Tag2Name,
                Color = Tag2Color
            };

            // Act
            var tagGetModel = (await TagClient.UpdateAsync(tagPatchModel)).AssertResult();

            // Assert
            Assert.NotZero(tagGetModel.Id);
            Assert.AreEqual(Lowercase(tagPatchModel.Color), tagGetModel.Color);
            Assert.AreEqual(tagPatchModel.Name, tagGetModel.Name);
        }

        [Test]
        public async Task UpdateTagAsync_NameOnlyUpdate_Name_SuccessfullyUpdated()
        {
            // Arrange
            var tagPostModel = new TagPostModel
            {
                Name = Tag1Name,
                Color = Tag1Color
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
            Assert.AreEqual(Lowercase(tagPostModel.Color), tagGetModel.Color);
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
