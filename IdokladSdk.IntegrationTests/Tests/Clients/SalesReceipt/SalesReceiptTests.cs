using System;
using System.Collections.Generic;
using System.Linq;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Tests.Clients.SalesReceipt.SelectModels;
using IdokladSdk.Models.RegisteredSale;
using IdokladSdk.Models.SalesReceipt;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.SalesReceipt
{
    public class SalesReceiptTests : TestBase
    {
        private const int PartnerId = 323823;
        private int _salesReceiptId;
        private SalesReceiptClient _client;
        private SalesReceiptPostModel _postModel;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _client = DokladApi.SalesReceiptClient;
        }

        [Test]
        [Order(1)]
        public void Post_SuccessfullyCreated()
        {
            // Arrange
            _postModel = _client.Default().AssertResult();
            _postModel.PartnerId = PartnerId;
            _postModel.Name = "Name";
            _postModel.ElectronicRecordsOfSales = new ElectronicRecordsOfSalesPostModel
            {
                IsEet = false
            };
            _postModel.Items.Clear();
            _postModel.Items.Add(new SalesReceiptItemPostModel
            {
                Name = "Test",
                UnitPrice = 100,
                PriceType = PriceTypeWithoutOnlyBase.WithVat,
                VatRateType = VatRateType.Basic,
                Amount = 1,
                Unit = string.Empty
            });
            _postModel.Payments.Clear();
            _postModel.Payments.Add(new SalesReceiptPaymentPostModel
            {
                PaymentAmount = 100,
                PaymentOptionId = 3,
                PaymentTransactionCode = string.Empty
            });

            // Act
            var data = _client.Post(_postModel).AssertResult();
            _salesReceiptId = data.Id;

            // Assert
            Assert.Greater(data.Id, 0);
            Assert.AreEqual(_postModel.DateOfIssue, data.DateOfIssue);
            Assert.AreEqual(PartnerId, data.PartnerId);
            Assert.Greater(data.Items.Count, 0);
            Assert.Greater(data.Payments.Count, 0);
        }

        [Test]
        [Order(2)]
        public void Get_SuccessfullyGet()
        {
            // Act
            var data = _client.Detail(_salesReceiptId).Get().AssertResult();

            // Assert
            Assert.AreEqual(_salesReceiptId, data.Id);
        }

        [Test]
        [Order(3)]
        public void Get_WithInclude_SuccessfullyGet()
        {
            // Act
            var data = _client.Detail(_salesReceiptId)
                .Include(s => s.Partner)
                .Include(s => s.Payments.PaymentOption)
                .Get()
                .AssertResult();

            Assert.AreEqual(_salesReceiptId, data.Id);
            Assert.IsNotNull(data.Partner);
            Assert.Greater(data.Payments.Count, 0);
            Assert.IsFalse(data.Payments.Any(i => i.PaymentOption == null));
        }

        [Test]
        [Order(4)]
        public void Get_WithSelect_SuccessfullyGet()
        {
            // Act
            var data = _client.Detail(_salesReceiptId)
                .Get<SalesReceiptSelectModel>()
                .AssertResult();

            Assert.AreEqual(_salesReceiptId, data.Id);
            Assert.AreNotEqual(default(string), data.DocumentNumber);
            Assert.AreNotEqual(string.Empty, data.DocumentNumber);
        }

        [Test]
        [Order(5)]
        public void Update_SuccessfullyUpdated()
        {
            var model = new SalesReceiptPatchModel
            {
                Id = _salesReceiptId,
                Name = "updated name"
            };

            // Act
            var data = _client.Update(model).AssertResult();

            // Assert
            Assert.AreEqual(model.Name, data.Name);
            Assert.AreEqual(PartnerId, data.PartnerId);
        }

        [Test]
        [Order(6)]
        public void Delete_SuccessfullyDeleted()
        {
            // Act
            var data = _client.Delete(_salesReceiptId).AssertResult();

            // Assert
            Assert.IsTrue(data);
        }

        [Test]
        public void GetList_SuccessfullyReturned()
        {
            // Act
            var data = _client.List().Get().AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.TotalPages, 0);
        }

        [Test]
        public void GetList_WithPage_SuccessfullyReturned()
        {
            // Arrange
            var pageSize = 1;

            // Act
            var data = _client.List()
                .Page(1)
                .PageSize(1)
                .Get()
                .AssertResult();

            // Assert
            Assert.GreaterOrEqual(data.TotalItems, 3);
            Assert.AreEqual(data.TotalItems / pageSize, data.TotalPages);
        }

        [Test]
        public void GetList_WithFilter_SuccessfullyReturned()
        {
            // Arrange
            var id = 224356;

            // Act
            var data = _client.List()
                .Filter(f => f.Id.IsEqual(id))
                .Get()
                .AssertResult();

            // Assert
            Assert.AreEqual(1, data.Items.Count());
            Assert.AreEqual(id, data.Items.First().Id);
        }

        [Test]
        public void GetList_WithSelect_SuccessfullyReturned()
        {
            // Act
            var data = _client.List()
                .Get<SalesReceiptSelectPaymentModel>()
                .AssertResult();

            // Assert
            var salesReceipt = data.Items.First();

            var payment = salesReceipt.Payments.First();
            Assert.IsNotNull(payment);
            Assert.AreEqual(100, payment.Prices.PaymentAmount);
        }

        [Test]
        public void Recount_SuccessfullyRecounted()
        {
            // Arrange
            var item = new SalesReceiptItemRecountPostModel
            {
                UnitPrice = 100,
                Amount = 2,
                Name = "Test",
                PriceType = PriceTypeWithoutOnlyBase.WithoutVat,
                VatRateType = VatRateType.Basic
            };
            var model = new SalesReceiptRecountPostModel
            {
                CurrencyId = 1,
                DateOfIssue = DateTime.Today.SetKindUtc(),
                Items = new List<SalesReceiptItemRecountPostModel> { item },
                Payments = new List<SalesReceiptPaymentRecountPostModel> { new SalesReceiptPaymentRecountPostModel { PaymentOptionId = 1 } }
            };

            // Act
            var data = _client.Recount(model).AssertResult();

            // Assert
            var recountedItem = data.Items.First();
            Assert.AreEqual(item.Id, recountedItem.Id);
            Assert.AreEqual(item.Name, recountedItem.Name);
            Assert.AreEqual(242, recountedItem.Prices.TotalWithVat);
            Assert.AreEqual(242, recountedItem.Prices.TotalWithVatHc);
            Assert.AreEqual(42, recountedItem.Prices.TotalVat);
            Assert.AreEqual(42, recountedItem.Prices.TotalVatHc);
            Assert.AreEqual(200, recountedItem.Prices.TotalWithoutVat);
            Assert.AreEqual(200, recountedItem.Prices.TotalWithoutVatHc);
        }

        [Test]
        public void Recount_WithRoundingItem_SuccessfullyRecounted()
        {
            // Arrange
            var item = new SalesReceiptItemRecountPostModel
            {
                UnitPrice = 99.2M,
                Amount = 2,
                Name = "Test",
                PriceType = PriceTypeWithoutOnlyBase.WithoutVat,
                VatRateType = VatRateType.Basic,
                ItemType = SalesReceiptItemType.ItemTypeNormal
            };
            var rounding = new SalesReceiptItemRecountPostModel
            {
                UnitPrice = 0.1M,
                Amount = 1,
                Name = "Rounding",
                PriceType = PriceTypeWithoutOnlyBase.WithVat,
                VatRateType = VatRateType.Basic,
                ItemType = SalesReceiptItemType.ItemTypeRound
            };
            var model = new SalesReceiptRecountPostModel
            {
                CurrencyId = 1,
                DateOfIssue = DateTime.Today.SetKindUtc(),
                Items = new List<SalesReceiptItemRecountPostModel> { item, rounding },
                Payments = new List<SalesReceiptPaymentRecountPostModel> { new SalesReceiptPaymentRecountPostModel { PaymentOptionId = 1 } }
            };

            // Act
            var data = _client.Recount(model).AssertResult();

            // Assert
            var recountedItem = data.Items.First();
            var roundingItem = data.Items.Single(i => i.ItemType == SalesReceiptItemType.ItemTypeRound);
            Assert.AreEqual(item.Id, recountedItem.Id);
            Assert.AreEqual(item.Name, recountedItem.Name);
            Assert.AreEqual(rounding.Name, roundingItem.Name);
            Assert.AreEqual(240.06M, recountedItem.Prices.TotalWithVat);
            Assert.AreEqual(240.06M, recountedItem.Prices.TotalWithVatHc);
            Assert.AreEqual(41.66M, recountedItem.Prices.TotalVat);
            Assert.AreEqual(41.66M, recountedItem.Prices.TotalVatHc);
            Assert.AreEqual(198.4M, recountedItem.Prices.TotalWithoutVat);
            Assert.AreEqual(198.4M, recountedItem.Prices.TotalWithoutVatHc);
            Assert.AreEqual(-0.06M, roundingItem.Prices.TotalWithVat);
            Assert.AreEqual(-0.06M, roundingItem.Prices.TotalWithVatHc);
            Assert.AreEqual(-0.01M, roundingItem.Prices.TotalVat);
            Assert.AreEqual(-0.01M, roundingItem.Prices.TotalVatHc);
            Assert.AreEqual(-0.05M, roundingItem.Prices.TotalWithoutVat);
            Assert.AreEqual(-0.05M, roundingItem.Prices.TotalWithoutVatHc);
        }

        [Test]
        public void Recount_ForeignCurrency_SuccessfullyRecounted()
        {
            // Arrange
            var item = new SalesReceiptItemRecountPostModel
            {
                UnitPrice = 100,
                Amount = 1,
                Name = "Test",
                Id = 1,
                PriceType = PriceTypeWithoutOnlyBase.WithoutVat,
                VatRateType = VatRateType.Basic
            };
            var model = new SalesReceiptRecountPostModel
            {
                CurrencyId = 2,
                ExchangeRate = 20,
                ExchangeRateAmount = 1,
                DateOfIssue = DateTime.Today.SetKindUtc(),
                Items = new List<SalesReceiptItemRecountPostModel> { item },
                Payments = new List<SalesReceiptPaymentRecountPostModel> { new SalesReceiptPaymentRecountPostModel { PaymentOptionId = 1 } }
            };

            // Act
            var result = _client.Recount(model).AssertResult();

            // Assert
            var recountedItem = result.Items.First(x => x.ItemType == SalesReceiptItemType.ItemTypeNormal);
            Assert.AreEqual(1, result.ExchangeRateAmount);
            Assert.AreEqual(20, result.ExchangeRate);
            Assert.AreEqual(2, result.CurrencyId);
            Assert.AreEqual(121, recountedItem.Prices.TotalWithVat);
            Assert.AreEqual(2420, recountedItem.Prices.TotalWithVatHc);
        }

        [Test]
        public void BatchPost_SuccessfullyCreated()
        {
            // Arrange
            var defaultSalesReceipt = _client.Default().AssertResult();
            defaultSalesReceipt.Items.First().Name = "Test";

            // Act
            var data = _client.Post(new List<SalesReceiptPostModel> { defaultSalesReceipt });

            // Assert
            Assert.AreEqual(BatchResultType.Success, data.Status);
            var id = data.Results.First().Data.Id;
            Assert.Greater(id, 0);
            _client.Delete(id).AssertResult();
        }
    }
}
