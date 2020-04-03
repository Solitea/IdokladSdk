using System;
using System.Collections.Generic;
using System.Linq;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.PriceListItem;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.PriceListItem
{
    [TestFixture]
    public partial class PriceListItemTests : TestBase
    {
        private int _newPriceListItemId = 0;
        private PriceListItemPostModel _priceListItemPostModel;
        private DateTime _dateLastChange;

        public PriceListItemClient PriceListItemClient { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            PriceListItemClient = DokladApi.PriceListItemClient;
        }

        [Test]
        [Order(1)]
        public void Post_SuccessfullyPosted()
        {
            // Arrange
            _priceListItemPostModel = PriceListItemClient.Default().AssertResult();
            SetPostModel();

            // Act
            var data = PriceListItemClient.Post(_priceListItemPostModel).AssertResult();
            _newPriceListItemId = data.Id;

            // Assert
            Assert.Greater(data.Id, 0);
            AssertModelsAreEqueal(data, _priceListItemPostModel);
        }

        [Test]
        [Order(2)]
        public void GetDetail_SuccessfullyGet()
        {
            // Act
            var data = PriceListItemClient.Detail(_newPriceListItemId).Get().AssertResult();

            // Assert
            Assert.AreEqual(_newPriceListItemId, data.Id);
            AssertModelsAreEqueal(data, _priceListItemPostModel);
        }

        [Test]
        [Order(3)]
        public void Update_SuccessfullyUpdated()
        {
            // Arrange
            var priceListItemPatchModel = CreatePatchModel();

            // Act
            var data = PriceListItemClient.Update(priceListItemPatchModel).AssertResult();
            _dateLastChange = data.Metadata.DateLastChange;

            // Assert
            AssertModelsAreEqueal(data, priceListItemPatchModel);
        }

        [Test]
        [Order(4)]
        public void Delete_SuccessfullyDeleted()
        {
            // Act
            var data = PriceListItemClient.Delete(_newPriceListItemId, true).AssertResult();

            // Assert
            Assert.True(data);
        }

        [Test]
        [Order(5)]
        public void BatchPost_SuccessfullyPosted()
        {
            // Arrange
            _priceListItemPostModel = PriceListItemClient.Default().AssertResult();
            SetPostModel();
            var batch = new List<PriceListItemPostModel> { _priceListItemPostModel };

            // Act
            var data = PriceListItemClient.Post(batch).AssertResult();
            var priceListItemGetModel = data.First();
            _newPriceListItemId = priceListItemGetModel.Id;

            // Assert
            Assert.Greater(priceListItemGetModel.Id, 0);
            AssertModelsAreEqueal(priceListItemGetModel, _priceListItemPostModel);
        }

        [Test]
        [Order(6)]
        public void GetListWithFilter_ReturnsList()
        {
            // Act
            var data = PriceListItemClient
                .List()
                .Filter(f => f.DateLastChange.IsGreaterThanOrEqual(_dateLastChange))
                .Get()
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.Greater(data.Items.Count(), 0);
            Assert.True(data.Items.Any(i => i.Id == _newPriceListItemId));
        }

        [Test]
        [Order(7)]
        public void BatchUpdate_SuccessfullyUpdated()
        {
            // Arrange
            var priceListItemPatchModel = CreatePatchModel();
            var batch = new List<PriceListItemPatchModel> { priceListItemPatchModel };

            // Act
            var data = PriceListItemClient.Update(batch).AssertResult();
            var priceListItemGetModel = data.First();

            // Assert
            AssertModelsAreEqueal(priceListItemGetModel, priceListItemPatchModel);
        }

        [Test]
        [Order(8)]
        public void BatchDelete_SuccessfullyDeleted()
        {
            // Arrange
            var idBatch = new List<int> { _newPriceListItemId };

            // Act
            var data = PriceListItemClient.Delete(idBatch, true).AssertResult();

            // Assert
            Assert.True(data.First());
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
                VatRateType = VatRateType.Reduced2,
                VatCodeId = 2
            };
        }

        private void AssertModelsAreEqueal(PriceListItemGetModel getModel, PriceListItemPostModel postModel)
        {
            Assert.AreEqual(postModel.Amount, getModel.Amount);
            Assert.AreEqual(postModel.BarCode, getModel.BarCode);
            Assert.AreEqual(postModel.Code, getModel.Code);
            Assert.AreEqual(postModel.CurrencyId, getModel.CurrencyId);
            Assert.AreEqual(postModel.IsStockItem, getModel.IsStockItem);
            Assert.AreEqual(postModel.Name, getModel.Name);
            Assert.AreEqual(postModel.Price, getModel.Price);
            Assert.AreEqual(postModel.PriceType, getModel.PriceType);
            Assert.AreEqual(postModel.Unit, getModel.Unit);
            Assert.AreEqual(postModel.VatRateType, getModel.VatRateType);
            Assert.AreEqual(postModel.VatCodeId, getModel.VatCodeId);
        }

        private void AssertModelsAreEqueal(PriceListItemGetModel data, PriceListItemPatchModel patchModel)
        {
            Assert.AreEqual(patchModel.Amount, data.Amount);
            Assert.AreEqual(patchModel.BarCode, data.BarCode);
            Assert.AreEqual(patchModel.Code, data.Code);
            Assert.AreEqual(patchModel.CurrencyId, data.CurrencyId);
            Assert.AreEqual(patchModel.IsStockItem, data.IsStockItem);
            Assert.AreEqual(patchModel.Name, data.Name);
            Assert.AreEqual(patchModel.Price, data.Price);
            Assert.AreEqual(patchModel.PriceType, data.PriceType);
            Assert.AreEqual(patchModel.Unit, data.Unit);
            Assert.AreEqual(patchModel.VatRateType, data.VatRateType);
            Assert.AreEqual(patchModel.VatCodeId, data.VatCodeId);
        }
    }
}
