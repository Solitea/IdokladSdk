using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.StockMovement;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.StockMovement
{
    /// <summary>
    /// StockMovementTests.
    /// </summary>
    public partial class StockMovementTests
    {
        private StockMovementGetModel _newStockMovementAsync;

        [Test]
        [Order(6)]
        public async Task DefaultAsync_SuccessfullyGetDefault()
        {
            var data = (await _stockMovementClient.DefaultAsync(PriceListItemId)).AssertResult();

            Assert.AreEqual(PriceListItemId, data.PriceListItemId);
        }

        [Test]
        [Order(7)]
        public async Task PostAsync_SuccessfullyCreated()
        {
            // Arrange
            var defaultModel = (await _stockMovementClient.DefaultAsync(PriceListItemId)).AssertResult();
            defaultModel.Amount = 1;

            // Act
            _newStockMovementAsync = (await _stockMovementClient.PostAsync(defaultModel)).AssertResult();

            // Assert
            Assert.AreEqual(PriceListItemId, _newStockMovementAsync.PriceListItemId);
            Assert.AreEqual(1, _newStockMovementAsync.Amount);
        }

        [Test]
        [Order(8)]
        public async Task UpdateAsync_SuccessfullyUpdated()
        {
            // Arrange
            var patch = new StockMovementPatchModel
            {
                Note = "Note",
                Id = _newStockMovementAsync.Id
            };

            // Act
            var data = (await _stockMovementClient.UpdateAsync(patch)).AssertResult();

            // Assert
            Assert.AreEqual(patch.Note, data.Note);
        }

        [Test]
        [Order(9)]
        public async Task DetailAsync_SuccessfullyGetDetail()
        {
            // Act
            var data = (await _stockMovementClient.Detail(_newStockMovementAsync.Id).GetAsync()).AssertResult();

            // Assert
            Assert.AreEqual(PriceListItemId, data.PriceListItemId);
        }

        [Test]
        [Order(10)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = (await _stockMovementClient.DeleteAsync(_newStockMovementAsync.Id)).AssertResult();

            // Assert
            Assert.IsTrue(data);
        }

        [Test]
        public async Task BatchAsync_SuccessfullyCreated()
        {
            // Arrange
            var defaultStockMovement = (await _stockMovementClient.DefaultAsync(PriceListItemId)).AssertResult();
            defaultStockMovement.Amount = 100;

            // Act
            var data = await _stockMovementClient.PostAsync(new List<StockMovementPostModel> { defaultStockMovement });

            // Assert
            Assert.AreEqual(BatchResultType.Success, data.Status);
            var id = data.Results.First().Data.Id;
            Assert.Greater(id, 0);
            await _stockMovementClient.DeleteAsync(id);
        }

        [Test]
        public async Task GetListAsync_SuccessfullyGetList()
        {
            // Act
            var data = (await _stockMovementClient.List()
                .Filter(f => f.PriceListItemId.IsEqual(PriceListItemId))
                .GetAsync()).AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
        }
    }
}
