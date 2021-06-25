using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.IssuedInvoice
{
    /// <summary>
    /// IssuedInvoiceTests.
    /// </summary>
    public partial class IssuedInvoiceTests
    {
        private IssuedInvoicePostModel _issuedInvoicePostModelAsync;
        private int _issuedInvoiceIdAsync;

        [Test]
        [Order(6)]
        public async Task PostAsync_SuccessfullyCreated()
        {
            // Arrange
            _issuedInvoicePostModelAsync = _issuedInvoiceClient.Default().AssertResult();
            _issuedInvoicePostModelAsync.PartnerId = PartnerId;
            _issuedInvoicePostModelAsync.Description = "Invoice";
            _issuedInvoicePostModelAsync.Items.Clear();
            _issuedInvoicePostModelAsync.Items.Add(new IssuedInvoiceItemPostModel
            {
                Name = "Test",
                UnitPrice = 100
            });

            // Act
            var data = (await _issuedInvoiceClient.PostAsync(_issuedInvoicePostModelAsync)).AssertResult();
            _issuedInvoiceIdAsync = data.Id;

            // Assert
            Assert.Greater(data.Id, 0);
            Assert.AreEqual(_issuedInvoicePostModelAsync.DateOfIssue, data.DateOfIssue);
            Assert.AreEqual(PartnerId, data.PartnerId);
            Assert.Greater(data.Items.Count, 0);
        }

        [Test]
        [Order(7)]
        public async Task UpdateAsync_SuccessfullyUpdated()
        {
            var model = new IssuedInvoicePatchModel
            {
                Id = _issuedInvoiceIdAsync,
                Description = "DescriptionUpdated"
            };

            // Act
            var data = (await _issuedInvoiceClient.UpdateAsync(model)).AssertResult();

            // Assert
            Assert.AreEqual(model.Description, data.Description);
        }

        [Test]
        [Order(8)]
        public async Task GetAsync_SuccessfullyGet()
        {
            // Act
            var data = (await _issuedInvoiceClient.Detail(_issuedInvoiceIdAsync).GetAsync()).AssertResult();

            // Assert
            Assert.AreEqual(_issuedInvoiceIdAsync, data.Id);
        }

        [Test]
        [Order(9)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = (await _issuedInvoiceClient.DeleteAsync(_issuedInvoiceIdAsync)).AssertResult();

            // Assert
            Assert.IsTrue(data);
        }

        [Test]
        public async Task GetRecurrenceFromInvoiceAsync_SuccessfullyReturned()
        {
            // Act
            var data = (await _issuedInvoiceClient.RecurrenceAsync(InvoiceId)).AssertResult();

            // Assert
            Assert.IsNotNull(data);
            Assert.IsNotNull(data.InvoiceTemplate);
            Assert.IsNotNull(data.RecurringSetting);
        }

        [Test]
        public async Task GetListAsync_SuccessfullyReturned()
        {
            // Act
            var data = (await _issuedInvoiceClient.List().GetAsync()).AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.TotalPages, 0);
        }

        [Test]
        public async Task PostWithOssRegimeAsync_SuccessfullyCreated()
        {
            // Arrange
            _issuedInvoicePostModel = _issuedInvoiceClient.Default().AssertResult();
            _issuedInvoicePostModel.PartnerId = GermanPartnerId;
            _issuedInvoicePostModel.Description = "MossTest";
            _issuedInvoicePostModel.HasVatRegimeOss = true;
            _issuedInvoicePostModel.Items.Clear();
            _issuedInvoicePostModel.Items.Add(new IssuedInvoiceItemPostModel
            {
                Name = "Test",
                UnitPrice = 100,
                VatRateType = VatRateType.Basic
            });

            // Act
            var data = (await _issuedInvoiceClient.PostAsync(_issuedInvoicePostModel)).AssertResult();

            // Assert
            Assert.That(data.HasVatRegimeOss, Is.True);
            Assert.Greater(data.Id, 0);
            Assert.Greater(data.Items.Count, 0);
            Assert.AreEqual(data.Items.First().VatRate, 19);

            // Teardown
            _issuedInvoiceClient.Delete(data.Id);
        }

        [Test]
        public async Task RecountAsync_SuccessfullyRecounted()
        {
            // Arrange
            var item = new IssuedInvoiceItemRecountPostModel
            {
                DiscountPercentage = 0,
                UnitPrice = 100,
                Amount = 2,
                Name = "Test",
                Id = 1,
                PriceType = PriceType.WithoutVat,
                VatRateType = VatRateType.Basic
            };
            var model = new IssuedInvoiceRecountPostModel
            {
                CurrencyId = 1,
                DateOfTaxing = DateTime.Today.SetKindUtc(),
                DiscountPercentage = 0,
                PaymentOptionId = 1,
                Items = new List<IssuedInvoiceItemRecountPostModel> { item }
            };

            // Act
            var data = (await _issuedInvoiceClient.RecountAsync(model)).AssertResult();

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
        public async Task CopyAsync_SuccessfullyGetPosModel()
        {
            // Arrange
            var invoiceToCopy = _issuedInvoiceClient.Detail(InvoiceId).Get().AssertResult();

            // Act
            var data = (await _issuedInvoiceClient.CopyAsync(InvoiceId)).AssertResult();

            // Assert
            Assert.AreEqual(invoiceToCopy.Description, data.Description);
            Assert.AreEqual(invoiceToCopy.PartnerId, data.PartnerId);
            Assert.AreEqual(invoiceToCopy.CurrencyId, data.CurrencyId);
        }
    }
}
