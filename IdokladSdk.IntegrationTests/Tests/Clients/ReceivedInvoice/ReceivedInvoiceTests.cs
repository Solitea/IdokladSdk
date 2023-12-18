using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.ReceivedInvoice;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReceivedInvoice
{
    /// <summary>
    /// ReceivedInvoiceTests.
    /// </summary>
    public class ReceivedInvoiceTests : TestBase
    {
        private const int PartnerId = 323823;
        private ReceivedInvoiceClient _receivedInvoiceClient;
        private ReceivedInvoicePostModel _receivedInvoicePostModel;
        private int _receivedInvoiceId;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _receivedInvoiceClient = DokladApi.ReceivedInvoiceClient;
        }

        [Test]
        [Order(1)]
        public async Task PostAsync_SuccessfullyCreated()
        {
            var vatCodeId = 24;

            // Arrange
            _receivedInvoicePostModel = await _receivedInvoiceClient.DefaultAsync().AssertResult();
            _receivedInvoicePostModel.PartnerId = PartnerId;
            _receivedInvoicePostModel.Description = "Invoice";
            _receivedInvoicePostModel.Items.Clear();
            _receivedInvoicePostModel.Items.Add(new ReceivedInvoiceItemPostModel
            {
                Name = "Test",
                UnitPrice = 100,
                Amount = 1,
                VatCodeId = vatCodeId
            });

            // Act
            var data = await _receivedInvoiceClient.PostAsync(_receivedInvoicePostModel).AssertResult();
            _receivedInvoiceId = data.Id;

            // Assert
            Assert.That(data.Id, Is.GreaterThan(0));
            Assert.That(data.DateOfIssue, Is.EqualTo(_receivedInvoicePostModel.DateOfIssue));
            Assert.That(data.PartnerId, Is.EqualTo(PartnerId));
            Assert.That(data.Items.Count, Is.GreaterThan(0));
            Assert.That(data.Items.First(i => i.ItemType == IssuedInvoiceItemType.ItemTypeNormal).VatCodeId, Is.EqualTo(vatCodeId));
        }

        [Test]
        [Order(1)]
        public async Task Post_NotValidModel_ReceivedDocumentNumberTooLong_ThrowExceptionAsync()
        {
            // Arrange
            var receivedInvoicePostModel = await _receivedInvoiceClient.DefaultAsync().AssertResult();
            receivedInvoicePostModel.PartnerId = PartnerId;
            receivedInvoicePostModel.Description = "Invoice";
            receivedInvoicePostModel.ReceivedDocumentNumber = new string('A', 31);
            receivedInvoicePostModel.Items.Clear();
            receivedInvoicePostModel.Items.Add(new ReceivedInvoiceItemPostModel
            {
                Name = "Test",
                UnitPrice = 100,
            });

            // Act
            var exception = Assert.ThrowsAsync<ValidationException>(async () => await _receivedInvoiceClient.PostAsync(receivedInvoicePostModel));

            // Assert
            Assert.That(exception.Message, Is.Not.Null.Or.Empty);
        }

        [Test]
        [Order(4)]
        public void Update_NotValidModel_ReceivedDocumentNumberTooLong_ThrowException()
        {
            var model = new ReceivedInvoicePatchModel
            {
                Id = _receivedInvoiceId,
                ReceivedDocumentNumber = new string('A', 31)
            };

            // Act
            var exception = Assert.ThrowsAsync<ValidationException>(async () => await _receivedInvoiceClient.UpdateAsync(model));

            // Assert
            Assert.That(exception.Message, Is.Not.Null.Or.Empty);
        }

        [Test]
        [Order(2)]
        public async Task GetAsync_SuccessfullyGet()
        {
            // Act
            var data = (await _receivedInvoiceClient.Detail(_receivedInvoiceId).GetAsync()).AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(_receivedInvoiceId));
        }

        [Test]
        [Order(3)]
        public async Task GetAsync_Expand_SuccessfullyGet()
        {
            // Act
            var data = (await _receivedInvoiceClient.Detail(_receivedInvoiceId)
                .Include(s => s.Partner).GetAsync()).AssertResult();

            Assert.That(data.Id, Is.EqualTo(_receivedInvoiceId));
            Assert.That(data.Partner, Is.Not.Null);
        }

        [Test]
        [Order(4)]
        public async Task UpdateAsync_SuccessfullyUpdated()
        {
            var model = new ReceivedInvoicePatchModel
            {
                Id = _receivedInvoiceId,
                Description = "DescriptionUpdated"
            };

            // Act
            var data = (await _receivedInvoiceClient.UpdateAsync(model)).AssertResult();

            // Assert
            Assert.That(data.Description, Is.EqualTo(model.Description));
        }

        [Test]
        [Order(5)]
        public async Task Update_SetCustomVatRateToNull_CustomVatRateIsNullAsync()
        {
            var invoiceToUpdate = await _receivedInvoiceClient.Detail(_receivedInvoiceId).GetAsync().AssertResult();
            var model = CreatePatchModelWithCustomVatRate(invoiceToUpdate, 13);
            var data = await _receivedInvoiceClient.UpdateAsync(model).AssertResult();
            Assert.That(data.Items.First().CustomVatRate, Is.Not.Null);
            model = CreatePatchModelWithCustomVatRate(invoiceToUpdate, null);

            // Act
            data = await _receivedInvoiceClient.UpdateAsync(model).AssertResult();

            // Assert
            Assert.That(data.Items.First().CustomVatRate, Is.Null);
        }

        [Test]
        [Order(6)]
        public async Task CopyAsync_SuccessfullyGetPostModel()
        {
            // Arrange
            var invoiceToCopy = await _receivedInvoiceClient.Detail(_receivedInvoiceId).GetAsync().AssertResult();

            // Act
            var data = await _receivedInvoiceClient.CopyAsync(_receivedInvoiceId).AssertResult();

            // Assert
            Assert.That(data.Description, Is.EqualTo(invoiceToCopy.Description));
            Assert.That(data.PartnerId, Is.EqualTo(invoiceToCopy.PartnerId));
            Assert.That(data.CurrencyId, Is.EqualTo(invoiceToCopy.CurrencyId));
        }

        [Test]
        [Order(7)]
        public async Task UpdateAsync_AddNewItems_SucessfullyUpdated()
        {
            // Arrange
            var invoiceToUpdate = (await _receivedInvoiceClient.Detail(_receivedInvoiceId).GetAsync()).AssertResult();
            var itemName2 = "Test2Test";
            var itemName3 = "Test3Test";
            var model = new ReceivedInvoicePatchModel
            {
                Id = invoiceToUpdate.Id,
                Items = new List<ReceivedInvoiceItemPatchModel>
            {
                new ReceivedInvoiceItemPatchModel
                {
                    Id = 1,
                    Name = itemName2,
                    UnitPrice = 100
                },
                new ReceivedInvoiceItemPatchModel
                {
                    Name = itemName3,
                    UnitPrice = 100
                }
            }
            };

            // Act
            var data = (await _receivedInvoiceClient.UpdateAsync(model)).AssertResult();

            // Assert
            Assert.That(data.Items.Count, Is.GreaterThanOrEqualTo(2));
            Assert.That(data.Items.Any(x => x.Name == itemName2));
            Assert.That(data.Items.Any(x => x.Name == itemName3));
        }

        [Test]
        [Order(8)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = (await _receivedInvoiceClient.DeleteAsync(_receivedInvoiceId)).AssertResult();

            // Assert
            Assert.That(data, Is.True);
        }

        [Test]
        public async Task RecountAsync_SuccessfullyRecounted()
        {
            // Arrange
            var item = new ReceivedInvoiceItemRecountPostModel
            {
                UnitPrice = 100,
                Amount = 2,
                Name = "Test",
                Id = 1,
                PriceType = PriceType.WithoutVat,
                VatRateType = VatRateType.Basic
            };
            var model = new ReceivedInvoiceRecountPostModel
            {
                CurrencyId = 1,
                DateOfTaxing = DateTime.Today.SetKindUtc(),
                Items = new List<ReceivedInvoiceItemRecountPostModel> { item }
            };

            // Act
            var data = (await _receivedInvoiceClient.RecountAsync(model)).AssertResult();

            // Assert
            var recountedItem = data.Items.First(x => x.ItemType == IssuedInvoiceItemType.ItemTypeNormal);
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
            var item = new ReceivedInvoiceItemRecountPostModel
            {
                UnitPrice = 100,
                Amount = 1,
                Name = "Test",
                Id = 1,
                PriceType = PriceType.WithoutVat,
                VatRateType = VatRateType.Basic
            };
            var model = new ReceivedInvoiceRecountPostModel
            {
                CurrencyId = 2,
                ExchangeRate = 20,
                ExchangeRateAmount = 1,
                DateOfTaxing = DateTime.Today.SetKindUtc(),
                Items = new List<ReceivedInvoiceItemRecountPostModel> { item }
            };

            // Act
            var result = await _receivedInvoiceClient.RecountAsync(model).AssertResult();

            // Assert
            var recountedItem = result.Items.First(x => x.ItemType == IssuedInvoiceItemType.ItemTypeNormal);
            Assert.That(result.ExchangeRateAmount, Is.EqualTo(1));
            Assert.That(result.ExchangeRate, Is.EqualTo(20));
            Assert.That(result.CurrencyId, Is.EqualTo(2));
            Assert.That(recountedItem.Prices.TotalWithVat, Is.EqualTo(121));
            Assert.That(recountedItem.Prices.TotalWithVatHc, Is.EqualTo(2420));
        }

        [Test]
        public async Task GetListAsync_SuccessfullyReturned()
        {
            // Act
            var data = await _receivedInvoiceClient.List().GetAsync().AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
        }

        private ReceivedInvoicePatchModel CreatePatchModelWithCustomVatRate(ReceivedInvoiceGetModel invoiceToUpdate, decimal? customVatRate)
        {
            return new ReceivedInvoicePatchModel
            {
                Id = invoiceToUpdate.Id,
                Items = new List<ReceivedInvoiceItemPatchModel>
            {
                new ReceivedInvoiceItemPatchModel
                {
                    Id = invoiceToUpdate.Items.First().Id,
                    CustomVatRate = customVatRate,
                    Name = invoiceToUpdate.Items.First().Name
                }
            }
            };
        }
    }
}
