using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.Tag;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Tag
{
    [TestFixture]
    public partial class TagTests : TestBase
    {
        private const string Tag1Color = "#123456";
        private const string Tag2Color = "#654321";
        private const string Tag1Name = "Tag 1";
        private const string Tag2Name = "Tag 2";

        private readonly List<int> _tagIdsToDelete = new List<int>();

        public TagClient TagClient { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            TagClient = DokladApi.TagClient;
        }

        [SetUp]
        public void SetUp()
        {
            _tagIdsToDelete.Clear();
        }

        [TearDown]
        public void TearDown()
        {
            foreach (var id in _tagIdsToDelete)
            {
                TagClient.Delete(id);
            }
        }

        [Test]
        public void AddTag_DuplicitName_Fails()
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
            var result = TagClient.Post(tagPostModel);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Test]
        public void AddTag_SuccessfullyAdded()
        {
            // Arrange
            var tagPostModel = new TagPostModel
            {
                Name = Tag1Name,
                Color = Tag1Color
            };

            // Act
            var tagGetModel = TagClient.Post(tagPostModel).AssertResult();
            MarkForDelete(tagGetModel.Id);

            // Assert
            Assert.NotZero(tagGetModel.Id);
            Assert.AreEqual(Lowercase(tagPostModel.Color), tagGetModel.Color);
            Assert.AreEqual(tagPostModel.Name, tagGetModel.Name);
        }

        [Test]
        public void DeleteTag_NonExistingId_Fails()
        {
            // Arrange
            var tagId = 0;

            // Act
            var result = TagClient.Delete(tagId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Test]
        public void DeleteTag_SuccessfullyDeleted()
        {
            // Arrange
            var tagPostModel = new TagPostModel
            {
                Name = Tag1Name,
                Color = Tag1Color
            };
            var id = PostAndMarkForDelete(tagPostModel);

            // Act
            var result = TagClient.Delete(id).AssertResult();

            // Assert
            Assert.True(result);
        }

        [Test]
        public void Get_ReturnsList()
        {
            // Arrange
            var tagPostModel = new TagPostModel
            {
                Name = Tag1Name,
                Color = Tag1Color
            };
            var id = PostAndMarkForDelete(tagPostModel);

            // Act
            var data = TagClient.List().Get().AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.TotalPages, 0);
            Assert.NotNull(data.Items);
            Assert.NotZero(data.Items.Count());
            var tag = data.Items.First(t => t.Id == id);
            Assert.AreEqual(id, tag.Id);
            Assert.AreEqual(tagPostModel.Color, tag.Color);
            Assert.AreEqual(tagPostModel.Name, tag.Name);
        }

        [Test]
        public void Get_WithFilter_ReturnsFilteredList()
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
                Name = Tag2Name,
                Color = Tag2Color
            };
            var id = PostAndMarkForDelete(tagPostModel);

            // Act
            var data = TagClient.List()
                .Filter(t => t.Name.IsEqual(Tag2Name))
                .Get().AssertResult();

            // Assert
            Assert.AreEqual(1, data.TotalItems);
            Assert.AreEqual(1, data.TotalPages);
            Assert.NotNull(data.Items);
            Assert.NotZero(data.Items.Count());
            var tag = data.Items.First(t => t.Id == id);
            Assert.AreEqual(id, tag.Id);
            Assert.AreEqual(tagPostModel.Color, tag.Color);
            Assert.AreEqual(tagPostModel.Name, tag.Name);
        }

        [Test]
        public void UpdateTag_ColorOnlyUpdate_SuccessfullyUpdated()
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
            var tagGetModel = TagClient.Update(tagPatchModel).AssertResult();

            // Assert
            Assert.NotZero(tagGetModel.Id);
            Assert.AreEqual(Lowercase(tagPatchModel.Color), tagGetModel.Color);
            Assert.AreEqual(tagPostModel.Name, tagGetModel.Name);
        }

        [Test]
        public void UpdateTag_DuplicitName_ThrowsException()
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
            var result = TagClient.Update(tagPatchModel);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Test]
        public void UpdateTag_FullUpdate_SuccessfullyUpdated()
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
            var tagGetModel = TagClient.Update(tagPatchModel).AssertResult();

            // Assert
            Assert.NotZero(tagGetModel.Id);
            Assert.AreEqual(Lowercase(tagPatchModel.Color), tagGetModel.Color);
            Assert.AreEqual(tagPatchModel.Name, tagGetModel.Name);
        }

        [Test]
        public void UpdateTag_NameOnlyUpdate_Name_SuccessfullyUpdated()
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
            var tagGetModel = TagClient.Update(tagPatchModel).AssertResult();

            // Assert
            Assert.NotZero(tagGetModel.Id);
            Assert.AreEqual(Lowercase(tagPostModel.Color), tagGetModel.Color);
            Assert.AreEqual(tagPatchModel.Name, tagGetModel.Name);
        }

        [Test]
        public void UpdateTag_NonExistingId_ThrowsException()
        {
            // Arrange
            var tagId = 0;
            var tagPatchModel = new TagPatchModel
            {
                Id = tagId
            };

            // Act
            var result = TagClient.Update(tagPatchModel);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        private int PostAndMarkForDelete(TagPostModel tagPostModel)
        {
            var tagGetModel = TagClient.Post(tagPostModel).AssertResult();
            MarkForDelete(tagGetModel.Id);
            return tagGetModel.Id;
        }

        private void MarkForDelete(int id)
        {
            _tagIdsToDelete.Add(id);
        }

        private string Lowercase(string str)
        {
            var cultureInfo = CultureInfo.InvariantCulture;
            return str.ToLower(cultureInfo);
        }
    }
}
