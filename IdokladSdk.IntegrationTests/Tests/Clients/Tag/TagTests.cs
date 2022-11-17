using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.Tag;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Tag;

[TestFixture]
public class TagTests : TestBase
{
    private const string Tag1Color = "#123456";
    private const string Tag2Color = "#654321";

    private readonly List<int> _tagIdsToDelete = new List<int>();

    public TagClient TagClient { get; set; }

    private string Tag1Name { get; set; }

    private string Tag2Name { get; set; }

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
        var suffixToAvoidDuplicates = (long)DateTime.Now.TimeOfDay.TotalMilliseconds;
        Tag1Name = $"Tag 1 ({suffixToAvoidDuplicates})";
        Tag2Name = $"Tag 2 ({suffixToAvoidDuplicates})";
    }

    [TearDown]
    public async Task TearDownAsync()
    {
        foreach (var id in _tagIdsToDelete)
        {
            await TagClient.DeleteAsync(id);
        }
    }

    [Test]
    public async Task AddTagAsync_DuplicitName_Fails()
    {
        // Arrange
        var tagPostModel = new TagPostModel
        {
            Name = Tag1Name,
            Color = Tag1Color
        };
        await PostAndMarkForDeleteAsync(tagPostModel);
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
        var id = await PostAndMarkForDeleteAsync(tagPostModel);

        // Act
        var result = (await TagClient.DeleteAsync(id)).AssertResult();

        // Assert
        Assert.True(result);
    }

    [Test]
    public async Task Get_ReturnsListAsync()
    {
        // Arrange
        var tagPostModel = new TagPostModel
        {
            Name = Tag1Name,
            Color = Tag1Color
        };
        var id = await PostAndMarkForDeleteAsync(tagPostModel);

        // Act
        var data = await TagClient.List().GetAsync().AssertResult();

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
    public async Task Get_WithFilter_ReturnsFilteredListAsync()
    {
        // Arrange
        var tagPostModel = new TagPostModel
        {
            Name = Tag1Name,
            Color = Tag1Color
        };
        await PostAndMarkForDeleteAsync(tagPostModel);
        tagPostModel = new TagPostModel
        {
            Name = Tag2Name,
            Color = Tag2Color
        };
        var id = await PostAndMarkForDeleteAsync(tagPostModel);

        // Act
        var data = await TagClient.List()
            .Filter(t => t.Name.IsEqual(Tag2Name))
            .GetAsync().AssertResult();

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
    public async Task UpdateTagAsync_ColorOnlyUpdate_SuccessfullyUpdated()
    {
        // Arrange
        var tagPostModel = new TagPostModel
        {
            Name = Tag1Name,
            Color = Tag1Color
        };
        var id = await PostAndMarkForDeleteAsync(tagPostModel);
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
        await PostAndMarkForDeleteAsync(tagPostModel);
        tagPostModel = new TagPostModel
        {
            Name = Tag2Color,
            Color = Tag2Color
        };
        var id = await PostAndMarkForDeleteAsync(tagPostModel);
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
        var id = await PostAndMarkForDeleteAsync(tagPostModel);
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
        var id = await PostAndMarkForDeleteAsync(tagPostModel);
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

    private string Lowercase(string str)
    {
        var cultureInfo = CultureInfo.InvariantCulture;
        return str.ToLower(cultureInfo);
    }

    private void MarkForDelete(int id)
    {
        _tagIdsToDelete.Add(id);
    }

    private async Task<int> PostAndMarkForDeleteAsync(TagPostModel tagPostModel)
    {
        var tagGetModel = await TagClient.PostAsync(tagPostModel).AssertResult();
        MarkForDelete(tagGetModel.Id);
        return tagGetModel.Id;
    }
}
