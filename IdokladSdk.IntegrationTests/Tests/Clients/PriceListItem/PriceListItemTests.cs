using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.PriceListItem;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.PriceListItem
{
    [TestFixture]
    public class PriceListItemTests : TestBase
    {
        private readonly List<int> _newPriceListItems = new List<int>();
        private int _newPriceListItemId = 0;
        private PriceListItemPostModel _priceListItemPostModel;
        private DateTime _dateLastChange;

        public PriceListItemClient PriceListItemClient { get; set; }

        public StockMovementClient StockMovementClient { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            PriceListItemClient = DokladApi.PriceListItemClient;
            StockMovementClient = DokladApi.StockMovementClient;
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            foreach (var id in _newPriceListItems)
            {
                await PriceListItemClient.DeleteAsync(id);
            }
        }

        [Test]
        [Order(1)]
        public async Task PostAsync_SuccessfullyPosted()
        {
            // Arrange
            _priceListItemPostModel = await PriceListItemClient.DefaultAsync().AssertResult();
            SetPostModel();

            // Act
            var data = await PriceListItemClient.PostAsync(_priceListItemPostModel).AssertResult();
            _newPriceListItemId = data.Id;

            // Assert
            Assert.That(data.Id, Is.GreaterThan(0));
            AssertModelsAreEqueal(data, _priceListItemPostModel);
        }

        [Test]
        [Order(2)]
        public async Task GetDetailAsync_SuccessfullyGet()
        {
            // Act
            var data = await PriceListItemClient.Detail(_newPriceListItemId).GetAsync().AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(_newPriceListItemId));
            AssertModelsAreEqueal(data, _priceListItemPostModel);
        }

        [Test]
        [Order(3)]
        public async Task UpdateAsync_SuccessfullyUpdated()
        {
            // Arrange
            var priceListItemPatchModel = CreatePatchModel();

            // Act
            var data = await PriceListItemClient.UpdateAsync(priceListItemPatchModel).AssertResult();
            _dateLastChange = data.Metadata.DateLastChange;

            // Assert
            AssertModelsAreEqueal(data, priceListItemPatchModel);
        }

        [Test]
        [Order(4)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = await PriceListItemClient.DeleteAsync(_newPriceListItemId, true).AssertResult();

            // Assert
            Assert.That(data, Is.True);
        }

        [Test]
        [Order(5)]
        public async Task BatchPostAsync_SuccessfullyPosted()
        {
            // Arrange
            _priceListItemPostModel = await PriceListItemClient.DefaultAsync().AssertResult();
            SetPostModel();
            var batch = new List<PriceListItemPostModel> { _priceListItemPostModel };

            // Act
            var data = await PriceListItemClient.PostAsync(batch).AssertResult();
            var priceListItemGetModel = data.First();
            _newPriceListItemId = priceListItemGetModel.Id;

            // Assert
            Assert.That(priceListItemGetModel.Id, Is.GreaterThan(0));
            AssertModelsAreEqueal(priceListItemGetModel, _priceListItemPostModel);
        }

        [Test]
        [Order(6)]
        public async Task GetListWithFilterAsync_ReturnsList()
        {
            // Act
            var data = await PriceListItemClient
                .List()
                .Filter(f => f.DateLastChange.IsGreaterThanOrEqual(_dateLastChange))
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
            Assert.That(data.Items.Count(), Is.GreaterThan(0));
            Assert.That(data.Items.Any(i => i.Id == _newPriceListItemId), Is.True);
        }

        [Test]
        [Order(7)]
        public async Task BatchUpdateAsync_SuccessfullyUpdated()
        {
            // Arrange
            var priceListItemPatchModel = CreatePatchModel();
            var batch = new List<PriceListItemPatchModel> { priceListItemPatchModel };

            // Act
            var data = await PriceListItemClient.UpdateAsync(batch).AssertResult();
            var priceListItemGetModel = data.First();

            // Assert
            AssertModelsAreEqueal(priceListItemGetModel, priceListItemPatchModel);
        }

        [Test]
        [Order(8)]
        public async Task BatchDeleteAsync_SuccessfullyDeleted()
        {
            // Arrange
            var idBatch = new List<int> { _newPriceListItemId };

            // Act
            var data = await PriceListItemClient.DeleteAsync(idBatch, true).AssertResult();

            // Assert
            var result = data.First();
            Assert.That(result.Id, Is.EqualTo(_newPriceListItemId));
            Assert.That(result.IsSuccess, Is.True);
        }

        [Test]
        public async Task GetListWithSortAsync_ReturnsList()
        {
            // Act
            var data = await PriceListItemClient
                .List()
                .Sort(x => x.Name.Desc())
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
            Assert.That(data.Items.Count(), Is.GreaterThan(0));
            Assert.That(data.Items, Is.Ordered.By(nameof(PriceListItemListGetModel.Name)).Descending);
        }

        [Test]
        public async Task Post_AsStockItemWithInitialData_SuccessfullyPostedAsync()
        {
            // Arrange
            _priceListItemPostModel = await PriceListItemClient.DefaultAsync().AssertResult();
            SetPostModel();
            _priceListItemPostModel.InitialDateStockBalance = new DateTime(2020, 01, 01).SetKindUtc();
            _priceListItemPostModel.InitialStockBalance = 100;

            // Act
            var data = await PriceListItemClient.PostAsync(_priceListItemPostModel).AssertResult();
            _newPriceListItems.Add(data.Id);

            // Assert
            Assert.That(data.Id, Is.GreaterThan(0));
            var stockMovements = await StockMovementClient.List()
                .Filter(f => f.PriceListItemId.IsEqual(data.Id)).GetAsync()
                .AssertResult();
            var initialStockMovement = stockMovements.Items.FirstOrDefault();
            Assert.That(initialStockMovement, Is.Not.Null);
            Assert.That(initialStockMovement.Amount, Is.EqualTo(_priceListItemPostModel.InitialStockBalance));
            Assert.That(initialStockMovement.DateOfMovement, Is.EqualTo(_priceListItemPostModel.InitialDateStockBalance));
        }

        private void SetPostModel()
        {
            _priceListItemPostModel.Amount = 2;
            _priceListItemPostModel.BarCode = "0123456789";
            _priceListItemPostModel.Code = "ABCDEFG";
            _priceListItemPostModel.CurrencyId = 2;
            _priceListItemPostModel.IsStockItem = true;
            _priceListItemPostModel.Name = "Price list item";
            _priceListItemPostModel.Price = 100;
            _priceListItemPostModel.PriceType = PriceType.OnlyBase;
            _priceListItemPostModel.Unit = "ks";
            _priceListItemPostModel.VatRateType = VatRateType.Basic;
            _priceListItemPostModel.VatCodeId = 1;
        }

        private PriceListItemPatchModel CreatePatchModel()
        {
            return new PriceListItemPatchModel
            {
                Amount = 3,
                BarCode = "9876543210",
                Code = "XYZ",
                CurrencyId = 1,
                Id = _newPriceListItemId,
                IsStockItem = false,
                Name = "New name",
                Price = 200,
                PriceType = PriceType.WithVat,
                Unit = "kg",
                VatRateType = VatRateType.Reduced1,
                VatCodeId = 2
            };
        }

        private void AssertModelsAreEqueal(PriceListItemGetModel getModel, PriceListItemPostModel postModel)
        {
            Assert.That(getModel.Amount, Is.EqualTo(postModel.Amount));
            Assert.That(getModel.BarCode, Is.EqualTo(postModel.BarCode));
            Assert.That(getModel.Code, Is.EqualTo(postModel.Code));
            Assert.That(getModel.CurrencyId, Is.EqualTo(postModel.CurrencyId));
            Assert.That(getModel.IsStockItem, Is.EqualTo(postModel.IsStockItem));
            Assert.That(getModel.Name, Is.EqualTo(postModel.Name));
            Assert.That(getModel.Price, Is.EqualTo(postModel.Price));
            Assert.That(getModel.PriceType, Is.EqualTo(postModel.PriceType));
            Assert.That(getModel.Unit, Is.EqualTo(postModel.Unit));
            Assert.That(getModel.VatRateType, Is.EqualTo(postModel.VatRateType));
            Assert.That(getModel.VatCodeId, Is.EqualTo(postModel.VatCodeId));
        }

        private void AssertModelsAreEqueal(PriceListItemGetModel data, PriceListItemPatchModel patchModel)
        {
            Assert.That(data.Amount, Is.EqualTo(patchModel.Amount));
            Assert.That(data.BarCode, Is.EqualTo(patchModel.BarCode));
            Assert.That(data.Code, Is.EqualTo(patchModel.Code));
            Assert.That(data.CurrencyId, Is.EqualTo(patchModel.CurrencyId));
            Assert.That(data.IsStockItem, Is.EqualTo(patchModel.IsStockItem));
            Assert.That(data.Name, Is.EqualTo(patchModel.Name));
            Assert.That(data.Price, Is.EqualTo(patchModel.Price));
            Assert.That(data.PriceType, Is.EqualTo(patchModel.PriceType));
            Assert.That(data.Unit, Is.EqualTo(patchModel.Unit));
            Assert.That(data.VatRateType, Is.EqualTo(patchModel.VatRateType));
            Assert.That(data.VatCodeId, Is.EqualTo(patchModel.VatCodeId));
        }
    }
}
