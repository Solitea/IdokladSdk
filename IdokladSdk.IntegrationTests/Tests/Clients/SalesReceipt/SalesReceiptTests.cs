using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Tests.Clients.SalesReceipt.SelectModels;
using IdokladSdk.Models.DocumentAddress;
using IdokladSdk.Models.RegisteredSale;
using IdokladSdk.Models.SalesReceipt;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.SalesReceipt
{
    public class SalesReceiptTests : TestBase
    {
        private const int PartnerId = 323823;
        private const int SalesPosEquipmentId = 12902;

        private readonly List<int> _salesReceiptIds = new List<int>();
        private int _salesReceiptId;
        private SalesReceiptClient _client;
        private SalesReceiptPostModel _postModel;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _client = DokladApi.SalesReceiptClient;
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            foreach (var id in _salesReceiptIds)
            {
                await _client.DeleteAsync(id);
            }
        }

        [Test]
        [Order(1)]
        public async Task Post_SuccessfullyCreatedAsync()
        {
            // Arrange
            _postModel = await _client.DefaultAsync().AssertResult();
            SetPostModel();

            // Act
            var data = await _client.PostAsync(_postModel).AssertResult();
            _salesReceiptId = data.Id;
            _salesReceiptIds.Add(_salesReceiptId);

            // Assert
            Assert.That(data.Id, Is.GreaterThan(0));
            Assert.That(data.DateOfIssue, Is.EqualTo(_postModel.DateOfIssue));
            Assert.That(data.PartnerId, Is.EqualTo(PartnerId));
            Assert.That(data.Note, Is.EqualTo(_postModel.Note));
            Assert.That(data.Items.Count, Is.GreaterThan(0));
            Assert.That(data.Payments.Count, Is.GreaterThan(0));
        }

        [Test]
        [Order(2)]
        public async Task Get_SuccessfullyGetAsync()
        {
            // Act
            var data = await _client.Detail(_salesReceiptId).GetAsync().AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(_salesReceiptId));
            Assert.That(data.Note, Is.EqualTo(_postModel.Note));
            Assert.That(data.Items.Any(i => i.ItemType == SalesReceiptItemType.ItemTypeNormal), Is.True);
        }

        [Test]
        [Order(3)]
        public async Task Get_WithInclude_SuccessfullyGetAsync()
        {
            // Act
            var data = await _client.Detail(_salesReceiptId)
                .Include(s => s.Partner)
                .Include(s => s.Payments.PaymentOption)
                .GetAsync()
                .AssertResult();

            Assert.That(data.Id, Is.EqualTo(_salesReceiptId));
            Assert.That(data.Partner, Is.Not.Null);
            Assert.That(data.Payments.Count, Is.GreaterThan(0));
            Assert.That(data.Payments.Any(i => i.PaymentOption == null), Is.False);
        }

        [Test]
        [Order(4)]
        public async Task Get_WithSelect_SuccessfullyGetAsync()
        {
            // Act
            var data = await _client.Detail(_salesReceiptId)
                .GetAsync<SalesReceiptSelectModel>()
                .AssertResult();

            Assert.That(data.Id, Is.EqualTo(_salesReceiptId));
            Assert.That(data.DocumentNumber, Is.Not.EqualTo(default(string)));
            Assert.That(data.DocumentNumber, Is.Not.EqualTo(string.Empty));
        }

        [Test]
        [Order(5)]
        public async Task Update_SuccessfullyUpdatedAsync()
        {
            var model = new SalesReceiptPatchModel
            {
                Id = _salesReceiptId,
                Name = "updated name",
                Note = "updated note",
                PartnerAddress = new DocumentAddressPatchModel
                {
                    CompanyName = "CompanyUpdate"
                }
            };

            // Act
            await _client.UpdateAsync(model).AssertResult();
            var data = await _client.Detail(_salesReceiptId).Include(s => s.Partner).GetAsync().AssertResult();

            // Assert
            Assert.That(data.Name, Is.EqualTo(model.Name));
            Assert.That(data.Note, Is.EqualTo(model.Note));
            Assert.That(data.PartnerId, Is.EqualTo(PartnerId));
            Assert.That(data.PartnerAddress.NickName, Is.EqualTo(model.PartnerAddress.CompanyName));
        }

        [Test]
        [Order(6)]
        public async Task CopyAsync_SuccessfullyGetPostModel()
        {
            // Arrange
            var salesReceiptToCopy = await _client.Detail(_salesReceiptId).GetAsync().AssertResult();

            // Act
            var data = await _client.CopyAsync(_salesReceiptId).AssertResult();

            // Assert
            Assert.That(data.PartnerId, Is.EqualTo(salesReceiptToCopy.PartnerId));
            Assert.That(data.CurrencyId, Is.EqualTo(salesReceiptToCopy.CurrencyId));
            Assert.That(data.Items.Count(c => c.ItemType == SalesReceiptItemType.ItemTypeRound), Is.EqualTo(1));
        }

        [Test]
        [Order(8)]
        public async Task Delete_SuccessfullyDeletedAsync()
        {
            // Act
            var data = await _client.DeleteAsync(_salesReceiptId).AssertResult();

            // Assert
            Assert.That(data, Is.True);
            _salesReceiptIds.Remove(_salesReceiptId);
        }

        [Test]
        public async Task GetList_SuccessfullyReturnedAsync()
        {
            // Act
            var data = await _client.List().GetAsync().AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
        }

        [Test]
        public async Task GetList_WithPage_SuccessfullyReturnedAsync()
        {
            // Arrange
            var pageSize = 1;

            // Act
            var data = await _client.List()
                .Page(1)
                .PageSize(1)
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThanOrEqualTo(3));
            Assert.That(data.TotalItems / pageSize, Is.EqualTo(data.TotalPages));
        }

        [Test]
        public async Task GetList_WithFilter_SuccessfullyReturnedAsync()
        {
            // Arrange
            var id = 224356;

            // Act
            var data = await _client.List()
                .Filter(f => f.Id.IsEqual(id))
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.Items.Count(), Is.EqualTo(1));
            Assert.That(data.Items.First().Id, Is.EqualTo(id));
        }

        [Test]
        public async Task GetList_WithSelect_SuccessfullyReturnedAsync()
        {
            // Act
            var data = await _client.List()
                .GetAsync<SalesReceiptSelectPaymentModel>()
                .AssertResult();

            // Assert
            var salesReceipt = data.Items.First();

            var payment = salesReceipt.Payments.First();
            Assert.That(payment, Is.Not.Null);
            Assert.That(payment.Prices.PaymentAmount, Is.EqualTo(100));
        }

        [Test]
        public async Task RecountAsync_SuccessfullyRecounted()
        {
            // Arrange
            var model = CreateRecountPostModel();

            // Act
            var data = await _client.RecountAsync(model).AssertResult();

            // Assert
            AssertRecountModel(data, model);
        }

        [Test]
        public async Task Recount_WithRoundingItem_SuccessfullyRecountedAsync()
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
                Name = "Zaokrouhlení",
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
            var data = await _client.RecountAsync(model).AssertResult();

            // Assert
            var recountedItem = data.Items.First();
            var roundingItem = data.Items.Single(i => i.ItemType == SalesReceiptItemType.ItemTypeRound);
            Assert.That(recountedItem.Id, Is.EqualTo(item.Id));
            Assert.That(recountedItem.Name, Is.EqualTo(item.Name));
            Assert.That(roundingItem.Name, Is.EqualTo(rounding.Name));
            Assert.That(recountedItem.Prices.TotalWithVat, Is.EqualTo(240.06M));
            Assert.That(recountedItem.Prices.TotalWithVatHc, Is.EqualTo(240.06M));
            Assert.That(recountedItem.Prices.TotalVat, Is.EqualTo(41.66M));
            Assert.That(recountedItem.Prices.TotalVatHc, Is.EqualTo(41.66M));
            Assert.That(recountedItem.Prices.TotalWithoutVat, Is.EqualTo(198.4M));
            Assert.That(recountedItem.Prices.TotalWithoutVatHc, Is.EqualTo(198.4M));
            Assert.That(roundingItem.Prices.TotalWithVat, Is.EqualTo(-0.06M));
            Assert.That(roundingItem.Prices.TotalWithVatHc, Is.EqualTo(-0.06M));
            Assert.That(roundingItem.Prices.TotalVat, Is.EqualTo(-0.00M));
            Assert.That(roundingItem.Prices.TotalVatHc, Is.EqualTo(-0.00M));
            Assert.That(roundingItem.Prices.TotalWithoutVat, Is.EqualTo(-0.06M));
            Assert.That(roundingItem.Prices.TotalWithoutVatHc, Is.EqualTo(-0.06M));
        }

        [Test]
        public async Task Recount_ForeignCurrency_SuccessfullyRecountedAsync()
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
            var result = await _client.RecountAsync(model).AssertResult();

            // Assert
            var recountedItem = result.Items.First(x => x.ItemType == SalesReceiptItemType.ItemTypeNormal);
            Assert.That(result.ExchangeRateAmount, Is.EqualTo(1));
            Assert.That(result.ExchangeRate, Is.EqualTo(20));
            Assert.That(result.CurrencyId, Is.EqualTo(2));
            Assert.That(recountedItem.Prices.TotalWithVat, Is.EqualTo(121));
            Assert.That(recountedItem.Prices.TotalWithVatHc, Is.EqualTo(2420));
        }

        [Test]
        public async Task BatchPost_SuccessfullyCreatedAsync()
        {
            // Arrange
            var defaultSalesReceipt = await _client.DefaultAsync().AssertResult();
            defaultSalesReceipt.SalesPosEquipmentId = SalesPosEquipmentId;
            defaultSalesReceipt.Name = "Test";
            defaultSalesReceipt.Items.First().Name = "Test";

            // Act
            var data = await _client.PostAsync(new List<SalesReceiptPostModel> { defaultSalesReceipt });

            // Assert
            Assert.That(data.Status, Is.EqualTo(BatchResultType.Success));
            var id = data.Results.First().Data.Id;
            Assert.That(id, Is.GreaterThan(0));
            _salesReceiptIds.Add(id);
        }

        [Test]
        public async Task Patch_ChangeCurrency_SucessfullyUpdatedAsync()
        {
            // Arrange
            var defaultSalesReceipt = await _client.DefaultAsync().AssertResult();
            defaultSalesReceipt.SalesPosEquipmentId = SalesPosEquipmentId;
            defaultSalesReceipt.Name = "Test";
            defaultSalesReceipt.Items.First().Name = "Test";

            var postResult = await _client.PostAsync(defaultSalesReceipt).AssertResult();
            _salesReceiptIds.Add(postResult.Id);
            var updateModel = new SalesReceiptPatchModel
            {
                Id = postResult.Id,
                CurrencyId = 2,
                SalesPosEquipmentId = null
            };

            // Assert
            await _client.UpdateAsync(updateModel).AssertResult();
        }

        [Test]
        public async Task Patch_ChangeCurrencyWithoutSalesPosEquipment_UnsucessfulAsync()
        {
            // Arrange
            var defaultSalesReceipt = await _client.DefaultAsync().AssertResult();
            defaultSalesReceipt.SalesPosEquipmentId = SalesPosEquipmentId;
            defaultSalesReceipt.Name = "Test";
            defaultSalesReceipt.Items.First().Name = "Test";

            var postResult = await _client.PostAsync(defaultSalesReceipt).AssertResult();
            _salesReceiptIds.Add(postResult.Id);
            var updateModel = new SalesReceiptPatchModel
            {
                Id = postResult.Id,
                CurrencyId = 2
            };

            // Act
            var patchResult = await _client.UpdateAsync(updateModel);

            // Assert
            Assert.That(patchResult.IsSuccess, Is.False);
            Assert.That(patchResult.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        private void AssertRecountModel(SalesReceiptRecountGetModel recountGetModel, SalesReceiptRecountPostModel recountPostModel)
        {
            var itemToRecount = recountPostModel.Items.First();
            var recountedItem = recountGetModel.Items.First();
            Assert.That(recountedItem.Id, Is.EqualTo(itemToRecount.Id));
            Assert.That(recountedItem.Name, Is.EqualTo(itemToRecount.Name));
            Assert.That(recountedItem.Prices.TotalWithVat, Is.EqualTo(242));
            Assert.That(recountedItem.Prices.TotalWithVatHc, Is.EqualTo(242));
            Assert.That(recountedItem.Prices.TotalVat, Is.EqualTo(42));
            Assert.That(recountedItem.Prices.TotalVatHc, Is.EqualTo(42));
            Assert.That(recountedItem.Prices.TotalWithoutVat, Is.EqualTo(200));
            Assert.That(recountedItem.Prices.TotalWithoutVatHc, Is.EqualTo(200));
        }

        private SalesReceiptRecountPostModel CreateRecountPostModel()
        {
            var item = new SalesReceiptItemRecountPostModel
            {
                UnitPrice = 100,
                Amount = 2,
                Name = "Test",
                PriceType = PriceTypeWithoutOnlyBase.WithoutVat,
                VatRateType = VatRateType.Basic
            };

            return new SalesReceiptRecountPostModel
            {
                CurrencyId = 1,
                DateOfIssue = DateTime.Today.SetKindUtc(),
                Items = new List<SalesReceiptItemRecountPostModel> { item },
                Payments = new List<SalesReceiptPaymentRecountPostModel> { new SalesReceiptPaymentRecountPostModel { PaymentOptionId = 1 } }
            };
        }

        private void SetPostModel()
        {
            _postModel.PartnerId = PartnerId;
            _postModel.Name = "Name";
            _postModel.Note = "Note";
            _postModel.ElectronicRecordsOfSales = new ElectronicRecordsOfSalesPostModel { IsEet = false };
            _postModel.Items.Clear();
            _postModel.Items.Add(new SalesReceiptItemPostModel
            {
                Name = "Test",
                UnitPrice = 100.45m,
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
        }
    }
}
