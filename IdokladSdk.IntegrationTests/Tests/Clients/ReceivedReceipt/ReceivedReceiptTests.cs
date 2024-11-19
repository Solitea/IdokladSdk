using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.ReceivedReceipt.Get;
using IdokladSdk.Models.ReceivedReceipt.Patch;
using IdokladSdk.Models.ReceivedReceipt.Post;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReceivedReceipt
{
    [TestFixture]
    [Ignore("Remove ignore after candidate creation")]
    public class ReceivedReceiptTests : TestBase
    {
        private const int PartnerId = 323823;
        private ReceivedReceiptClient _receivedReceiptClient;
        private ReceivedReceiptPostModel _receivedReceiptPostModel;
        private int _receivedReceiptId;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _receivedReceiptClient = DokladApi.ReceivedReceiptClient;
        }

        [Test]
        public async Task DefaultAsync_SuccessfullyReturned()
        {
            // Act
            var data = await _receivedReceiptClient.DefaultAsync().AssertResult();

            // Assert
            Assert.That(data.DateOfIssue, Is.EqualTo(DateTime.Now.Date));
        }

        [Test]
        [Order(1)]
        public async Task PostAsync_SuccessfullyCreated()
        {
            var vatCodeId = 24;

            // Arrange
            _receivedReceiptPostModel = await _receivedReceiptClient.DefaultAsync().AssertResult();
            _receivedReceiptPostModel.PartnerId = PartnerId;
            _receivedReceiptPostModel.Description = "Received receipt";
            _receivedReceiptPostModel.Items.Clear();
            _receivedReceiptPostModel.Items.Add(new ReceivedReceiptItemPostModel()
            {
                Name = "Test",
                UnitPrice = 100,
                Amount = 1,
                VatCodeId = vatCodeId
            });

            // Act
            var data = await _receivedReceiptClient.PostAsync(_receivedReceiptPostModel).AssertResult();
            _receivedReceiptId = data.Id;

            // Assert
            Assert.That(data.Id, Is.GreaterThan(0));
            Assert.That(data.DateOfIssue, Is.EqualTo(_receivedReceiptPostModel.DateOfIssue));
            Assert.That(data.Partner.Id, Is.EqualTo(PartnerId));
            Assert.That(data.Items.Count, Is.GreaterThan(0));
            Assert.That(data.Items.First().VatCodeId, Is.EqualTo(vatCodeId));
        }

        [Test]
        [Order(2)]
        public async Task GetAsync_Expand_SuccessfullyGet()
        {
            // Act
            var data = await _receivedReceiptClient.Detail(_receivedReceiptId)
                .Include(s => s.Partner.Country).GetAsync().AssertResult();

            Assert.That(data.Id, Is.EqualTo(_receivedReceiptId));
            Assert.That(data.Partner, Is.Not.Null);
            Assert.That(data.Partner.Country, Is.Not.Null);
        }

        [Test]
        [Order(3)]
        public async Task UpdateAsync_SuccessfullyUpdated()
        {
            var model = new ReceivedReceiptPatchModel
            {
                Id = _receivedReceiptId,
                Description = "DescriptionUpdated"
            };

            // Act
            var data = await _receivedReceiptClient.UpdateAsync(model).AssertResult();

            // Assert
            Assert.That(data.Description, Is.EqualTo(model.Description));
        }

        [Test]
        [Order(4)]
        public async Task Update_SetCustomVatRateToNull_CustomVatRateIsNullAsync()
        {
            var receiptToUpdate = await _receivedReceiptClient.Detail(_receivedReceiptId).GetAsync().AssertResult();
            var model = CreatePatchModelWithCustomVatRate(receiptToUpdate, 13);
            var data = await _receivedReceiptClient.UpdateAsync(model).AssertResult();
            Assert.That(data.Items.First().CustomVat, Is.Not.Null);
            model = CreatePatchModelWithCustomVatRate(receiptToUpdate, null);

            // Act
            data = await _receivedReceiptClient.UpdateAsync(model).AssertResult();

            // Assert
            Assert.That(data.Items.First().CustomVat, Is.Null);
        }

        [Test]
        [Order(5)]
        public async Task UpdateAsync_AddNewItems_SucessfullyUpdated()
        {
            // Arrange
            var receiptToUpdate = await _receivedReceiptClient.Detail(_receivedReceiptId).GetAsync().AssertResult();
            var itemName2 = "Test2Test";
            var itemName3 = "Test3Test";
            var model = new ReceivedReceiptPatchModel
            {
                Id = receiptToUpdate.Id,
                Items = new List<ReceivedReceiptItemPatchModel>
            {
                new ReceivedReceiptItemPatchModel
                {
                    Id = 1,
                    Name = itemName2,
                    UnitPrice = 100
                },
                new ReceivedReceiptItemPatchModel
                {
                    Name = itemName3,
                    UnitPrice = 100
                }
            }
            };

            // Act
            var data = await _receivedReceiptClient.UpdateAsync(model).AssertResult();

            // Assert
            Assert.That(data.Items.Count, Is.GreaterThanOrEqualTo(2));
            Assert.That(data.Items.Any(x => x.Name == itemName2));
            Assert.That(data.Items.Any(x => x.Name == itemName3));
        }

        [Test]
        [Order(6)]
        public async Task GetListAsync_SuccessfullyReturned()
        {
            // Act
            var data = await _receivedReceiptClient.List().GetAsync().AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
        }

        [Test]
        [Order(7)]
        public async Task GetListAsync_FilterByPartnerId_SuccessfullyReturned()
        {
            // Act
            var data = await _receivedReceiptClient.List().Filter(r => r.PartnerId.IsEqual(PartnerId)).GetAsync().AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
        }

        [Test]
        [Order(8)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = await _receivedReceiptClient.DeleteAsync(_receivedReceiptId).AssertResult();

            // Assert
            Assert.That(data, Is.True);
        }

        [Test]
        public async Task RecountAsync_SuccessfullyRecounted()
        {
            // Arrange
            var item = new ReceivedReceiptItemRecountPostModel
            {
                UnitPrice = 100,
                Amount = 2,
                Name = "Test",
                Id = 1,
                PriceType = PriceTypeWithoutOnlyBase.WithoutVat,
                VatRateType = VatRateType.Basic
            };
            var model = new ReceivedReceiptRecountPostModel
            {
                CurrencyId = 1,
                DateOfIssue = DateTime.Today.SetKindUtc(),
                Items = new List<ReceivedReceiptItemRecountPostModel> { item }
            };

            // Act
            var data = await _receivedReceiptClient.RecountAsync(model).AssertResult();

            // Assert
            var recountedItem = data.Items.First();
            Assert.That(recountedItem.Id, Is.EqualTo(item.Id));
            Assert.That(recountedItem.Name, Is.EqualTo(item.Name));
            Assert.That(recountedItem.Prices.TotalWithVat, Is.EqualTo(242));
            Assert.That(recountedItem.Prices.TotalWithVatHc, Is.EqualTo(242));
            Assert.That(recountedItem.Prices.TotalVat, Is.EqualTo(42));
            Assert.That(recountedItem.Prices.TotalVatHc, Is.EqualTo(42));
            Assert.That(recountedItem.Prices.TotalWithoutVat, Is.EqualTo(200));
            Assert.That(recountedItem.Prices.TotalWithoutVatHc, Is.EqualTo(200));
        }

        [Test]
        public async Task Recount_ForeignCurrency_SuccessfullyRecountedAsync()
        {
            // Arrange
            var item = new ReceivedReceiptItemRecountPostModel
            {
                UnitPrice = 100,
                Amount = 1,
                Name = "Test",
                Id = 1,
                PriceType = PriceTypeWithoutOnlyBase.WithoutVat,
                VatRateType = VatRateType.Basic
            };
            var model = new ReceivedReceiptRecountPostModel
            {
                CurrencyId = 2,
                ExchangeRate = 20,
                ExchangeRateAmount = 1,
                DateOfIssue = DateTime.Today.SetKindUtc(),
                Items = new List<ReceivedReceiptItemRecountPostModel> { item }
            };

            // Act
            var result = await _receivedReceiptClient.RecountAsync(model).AssertResult();

            // Assert
            var recountedItem = result.Items.First();
            Assert.That(result.ExchangeRateAmount, Is.EqualTo(1));
            Assert.That(result.ExchangeRate, Is.EqualTo(20));
            Assert.That(result.CurrencyId, Is.EqualTo(2));
            Assert.That(recountedItem.Prices.TotalWithVat, Is.EqualTo(121));
            Assert.That(recountedItem.Prices.TotalWithVatHc, Is.EqualTo(2420));
        }

        private ReceivedReceiptPatchModel CreatePatchModelWithCustomVatRate(ReceivedReceiptGetModel receiptToUpdate, decimal? customVat)
        {
            return new ReceivedReceiptPatchModel
            {
                Id = receiptToUpdate.Id,
                Items = new List<ReceivedReceiptItemPatchModel>
                {
                    new ReceivedReceiptItemPatchModel
                    {
                        Id = receiptToUpdate.Items.First().Id,
                        CustomVat = customVat,
                        Name = receiptToUpdate.Items.First().Name
                    }
                }
            };
        }
    }
}
