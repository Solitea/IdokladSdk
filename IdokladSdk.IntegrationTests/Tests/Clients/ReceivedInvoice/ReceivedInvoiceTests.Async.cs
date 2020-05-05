using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.ReceivedInvoice;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReceivedInvoice
{
    /// <summary>
    /// ReceivedInvoiceTests.
    /// </summary>
    public partial class ReceivedInvoiceTests
    {
        private ReceivedInvoicePostModel _receivedInvoicePostModelAsync;
        private int _receivedInvoiceIdAsync;

        [Test]
        [Order(8)]
        public async Task PostAsync_SuccessfullyCreated()
        {
            var vatCodeId = 24;

            // Arrange
            _receivedInvoicePostModelAsync = (await _receivedInvoiceClient.DefaultAsync()).AssertResult();
            _receivedInvoicePostModelAsync.PartnerId = PartnerId;
            _receivedInvoicePostModelAsync.Description = "Invoice";
            _receivedInvoicePostModelAsync.Items.Clear();
            _receivedInvoicePostModelAsync.Items.Add(new ReceivedInvoiceItemPostModel
            {
                Name = "Test",
                UnitPrice = 100,
                Amount = 1,
                VatCodeId = vatCodeId
            });

            // Act
            var data = (await _receivedInvoiceClient.PostAsync(_receivedInvoicePostModelAsync)).AssertResult();
            _receivedInvoiceIdAsync = data.Id;

            // Assert
            Assert.Greater(data.Id, 0);
            Assert.AreEqual(_receivedInvoicePostModelAsync.DateOfIssue, data.DateOfIssue);
            Assert.AreEqual(PartnerId, data.PartnerId);
            Assert.Greater(data.Items.Count, 0);
            Assert.AreEqual(vatCodeId, data.Items.First(i => i.ItemType == IssuedInvoiceItemType.ItemTypeNormal).VatCodeId);
        }

        [Test]
        [Order(9)]
        public async Task GetAsync_SuccessfullyGet()
        {
            // Act
            var data = (await _receivedInvoiceClient.Detail(_receivedInvoiceIdAsync).GetAsync()).AssertResult();

            // Assert
            Assert.AreEqual(_receivedInvoiceIdAsync, data.Id);
        }

        [Test]
        [Order(10)]
        public async Task GetAsync_Expand_SuccessfullyGet()
        {
            // Act
            var data = (await _receivedInvoiceClient.Detail(_receivedInvoiceIdAsync)
                .Include(s => s.Partner).GetAsync()).AssertResult();

            Assert.AreEqual(_receivedInvoiceIdAsync, data.Id);
            Assert.IsNotNull(data.Partner);
        }

        [Test]
        [Order(11)]
        public async Task UpdateAsync_SuccessfullyUpdated()
        {
            var model = new ReceivedInvoicePatchModel
            {
                Id = _receivedInvoiceIdAsync,
                Description = "DescriptionUpdated"
            };

            // Act
            var data = (await _receivedInvoiceClient.UpdateAsync(model)).AssertResult();

            // Assert
            Assert.AreEqual(model.Description, data.Description);
        }

        [Test]
        [Order(12)]
        public async Task CopyAsync_SuccessfullyGetPosModel()
        {
            // Arrange
            var invoiceToCopy = (await _receivedInvoiceClient.Detail(_receivedInvoiceIdAsync).GetAsync()).AssertResult();

            // Act
            var data = (await _receivedInvoiceClient.CopyAsync(_receivedInvoiceIdAsync)).AssertResult();

            // Assert
            Assert.AreEqual(invoiceToCopy.Description, data.Description);
            Assert.AreEqual(invoiceToCopy.PartnerId, data.PartnerId);
            Assert.AreEqual(invoiceToCopy.CurrencyId, data.CurrencyId);
        }

        [Test]
        [Order(13)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = (await _receivedInvoiceClient.DeleteAsync(_receivedInvoiceIdAsync)).AssertResult();

            // Assert
            Assert.IsTrue(data);
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
        public async Task GetListAsync_SuccessfullyReturned()
        {
            // Act
            var data = (await _receivedInvoiceClient.List().GetAsync()).AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.TotalPages, 0);
        }
    }
}
