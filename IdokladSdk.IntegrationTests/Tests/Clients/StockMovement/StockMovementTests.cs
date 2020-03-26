using System.Collections.Generic;
using System.Linq;
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
    public partial class StockMovementTests : TestBase
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
        public void Default_SuccessfullyGetDefault()
        {
            var data = _stockMovementClient.Default(PriceListItemId).AssertResult();

            Assert.AreEqual(PriceListItemId, data.PriceListItemId);
        }

        [Test]
        [Order(2)]
        public void Post_SuccessfullyCreated()
        {
            // Arrange
            var defaultModel = _stockMovementClient.Default(PriceListItemId).AssertResult();
            defaultModel.Amount = 1;

            // Act
            _newStockMovement = _stockMovementClient.Post(defaultModel).AssertResult();

            // Assert
            Assert.AreEqual(PriceListItemId, _newStockMovement.PriceListItemId);
            Assert.AreEqual(1, _newStockMovement.Amount);
        }

        [Test]
        [Order(3)]
        public void Update_SuccessfullyUpdated()
        {
            // Arrange
            var patch = new StockMovementPatchModel
            {
                Note = "Note",
                Id = _newStockMovement.Id
            };

            // Act
            var data = _stockMovementClient.Update(patch).AssertResult();

            // Assert
            Assert.AreEqual(patch.Note, data.Note);
        }

        [Test]
        [Order(4)]
        public void Detail_SuccessfullyGetDetail()
        {
            // Act
            var data = _stockMovementClient.Detail(_newStockMovement.Id).Get().AssertResult();

            // Assert
            Assert.AreEqual(PriceListItemId, data.PriceListItemId);
        }

        [Test]
        [Order(5)]
        public void Delete_SuccessfullyDeleted()
        {
            // Act
            var data = _stockMovementClient.Delete(_newStockMovement.Id).AssertResult();

            // Assert
            Assert.IsTrue(data);
        }

        [Test]
        public void Batch_SuccessfullyCreated()
        {
            // Arrange
            var defaultStockMovement = _stockMovementClient.Default(PriceListItemId).AssertResult();
            defaultStockMovement.Amount = 100;

            // Act
            var data = _stockMovementClient.Post(new List<StockMovementPostModel> { defaultStockMovement });

            // Assert
            Assert.AreEqual(BatchResultType.Success, data.Status);
            var id = data.Results.First().Data.Id;
            Assert.Greater(id, 0);
            _stockMovementClient.Delete(id).AssertResult();
        }

        [Test]
        public void GetList_SuccessfullyGetList()
        {
            // Act
            var data = _stockMovementClient.List()
                .Filter(f => f.PriceListItemId.IsEqual(PriceListItemId))
                .Get()
                .AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
        }
    }
}
