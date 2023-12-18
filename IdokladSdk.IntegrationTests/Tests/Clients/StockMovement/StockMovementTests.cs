using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.StockMovement;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.StockMovement
{
    /// <summary>
    /// StockMovementTests.
    /// </summary>
    public class StockMovementTests : TestBase
    {
        private const int PriceListItemId = 107444;
        private StockMovementClient _stockMovementClient;
        private StockMovementGetModel _newStockMovement;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _stockMovementClient = DokladApi.StockMovementClient;
        }

        [Test]
        [Order(1)]
        public async Task DefaultAsync_SuccessfullyGetDefault()
        {
            var data = await _stockMovementClient.DefaultAsync(PriceListItemId).AssertResult();

            Assert.That(data.PriceListItemId, Is.EqualTo(PriceListItemId));
        }

        [Test]
        [Order(2)]
        public async Task PostAsync_SuccessfullyCreated()
        {
            // Arrange
            var defaultModel = await _stockMovementClient.DefaultAsync(PriceListItemId).AssertResult();
            defaultModel.Amount = 1;

            // Act
            _newStockMovement = await _stockMovementClient.PostAsync(defaultModel).AssertResult();

            // Assert
            Assert.That(_newStockMovement.PriceListItemId, Is.EqualTo(PriceListItemId));
            Assert.That(_newStockMovement.Amount, Is.EqualTo(1));
        }

        [Test]
        [Order(3)]
        public async Task UpdateAsync_SuccessfullyUpdated()
        {
            // Arrange
            var patch = new StockMovementPatchModel
            {
                Note = "Note",
                Id = _newStockMovement.Id
            };

            // Act
            var data = await _stockMovementClient.UpdateAsync(patch).AssertResult();

            // Assert
            Assert.That(data.Note, Is.EqualTo(patch.Note));
        }

        [Test]
        [Order(4)]
        public async Task DetailAsync_SuccessfullyGetDetail()
        {
            // Act
            var data = (await _stockMovementClient.Detail(_newStockMovement.Id).GetAsync()).AssertResult();

            // Assert
            Assert.That(data.PriceListItemId, Is.EqualTo(PriceListItemId));
        }

        [Test]
        [Order(5)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = (await _stockMovementClient.DeleteAsync(_newStockMovement.Id)).AssertResult();

            // Assert
            Assert.That(data, Is.True);
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
            Assert.That(data.Status, Is.EqualTo(BatchResultType.Success));
            var id = data.Results.First().Data.Id;
            Assert.That(id, Is.EqualTo(0));
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
            Assert.That(data.TotalItems, Is.Zero);
        }
    }
}
