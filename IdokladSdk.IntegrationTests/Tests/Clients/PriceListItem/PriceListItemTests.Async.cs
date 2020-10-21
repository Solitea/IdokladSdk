using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.PriceListItem;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.PriceListItem
{
    [TestFixture]
    public partial class PriceListItemTests : TestBase
    {
        [Test]
        [Order(9)]
        public async Task PostAsync_SuccessfullyPosted()
        {
            // Arrange
            _priceListItemPostModel = (await PriceListItemClient.DefaultAsync()).AssertResult();
            SetPostModel();

            // Act
            var data = (await PriceListItemClient.PostAsync(_priceListItemPostModel)).AssertResult();
            _newPriceListItemId = data.Id;

            // Assert
            Assert.Greater(data.Id, 0);
            AssertModelsAreEqueal(data, _priceListItemPostModel);
        }

        [Test]
        [Order(10)]
        public async Task GetDetailAsync_SuccessfullyGet()
        {
            // Act
            var data = (await PriceListItemClient.Detail(_newPriceListItemId).GetAsync()).AssertResult();

            // Assert
            Assert.AreEqual(_newPriceListItemId, data.Id);
            AssertModelsAreEqueal(data, _priceListItemPostModel);
        }

        [Test]
        [Order(11)]
        public async Task UpdateAsync_SuccessfullyUpdated()
        {
            // Arrange
            var priceListItemPatchModel = CreatePatchModel();

            // Act
            var data = (await PriceListItemClient.UpdateAsync(priceListItemPatchModel)).AssertResult();
            _dateLastChange = data.Metadata.DateLastChange;

            // Assert
            AssertModelsAreEqueal(data, priceListItemPatchModel);
        }

        [Test]
        [Order(12)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = (await PriceListItemClient.DeleteAsync(_newPriceListItemId, true)).AssertResult();

            // Assert
            Assert.True(data);
        }

        [Test]
        [Order(13)]
        public async Task BatchPostAsync_SuccessfullyPosted()
        {
            _priceListItemPostModel = (await PriceListItemClient.DefaultAsync()).AssertResult();
            SetPostModel();
            var batch = new List<PriceListItemPostModel> { _priceListItemPostModel };

            // Act
            var data = (await PriceListItemClient.PostAsync(batch)).AssertResult();
            var priceListItemGetModel = data.First();
            _newPriceListItemId = priceListItemGetModel.Id;

            // Assert
            Assert.Greater(priceListItemGetModel.Id, 0);
            AssertModelsAreEqueal(priceListItemGetModel, _priceListItemPostModel);
        }

        [Test]
        [Order(14)]
        public async Task GetListWithFilterAsync_ReturnsList()
        {
            // Act
            var data = (await PriceListItemClient
                .List()
                .Filter(f => f.DateLastChange.IsGreaterThanOrEqual(_dateLastChange))
                .GetAsync())
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.Greater(data.Items.Count(), 0);
            Assert.True(data.Items.Any(i => i.Id == _newPriceListItemId));
        }

        [Test]
        [Order(15)]
        public async Task BatchUpdateAsync_SuccessfullyUpdated()
        {
            // Arrange
            var priceListItemPatchModel = CreatePatchModel();
            var batch = new List<PriceListItemPatchModel> { priceListItemPatchModel };

            // Act
            var data = (await PriceListItemClient.UpdateAsync(batch)).AssertResult();
            var priceListItemGetModel = data.First();

            // Assert
            AssertModelsAreEqueal(priceListItemGetModel, priceListItemPatchModel);
        }

        [Test]
        [Order(16)]
        public async Task BatchDeleteAsync_SuccessfullyDeleted()
        {
            // Arrange
            var idBatch = new List<int> { _newPriceListItemId };

            // Act
            var data = (await PriceListItemClient.DeleteAsync(idBatch, true)).AssertResult();

            // Assert
            Assert.True(data.First());
        }

        [Test]
        public async Task GetListWithSortAsync_ReturnsList()
        {
            // Act
            var data = (await PriceListItemClient
                .List()
                .Sort(x => x.Name.Desc())
                .GetAsync())
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.Greater(data.Items.Count(), 0);
        }
    }
}
