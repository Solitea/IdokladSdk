using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.RecurringInvoice
{
    public partial class RecurringInvoiceTests
    {
        [Test]
        [Order(10)]
        public async Task PostAsync_SuccessfullyCreated()
        {
            // Arrange
            var model = CreatePostModel();

            // Act
            var data = (await RecurringInvoiceClient.PostAsync(model)).AssertResult();
            _recurringInvoiceId = data.Id;
            _recurringInvoiceItemId = data.InvoiceTemplate?.Items?.First()?.Id;
            _issuedInvoiceId = data.CreatedInvoice?.Id;

            // Assert
            AssertResultGetModel(data);
        }

        [Test]
        [Order(11)]
        public async Task GetDetailAsync_ReturnsRecurringInvoice()
        {
            // Act
            var data = (await RecurringInvoiceClient.Detail(_recurringInvoiceId).GetAsync()).AssertResult();

            // Assert
            AssertGetModel(data);
        }

        [Test]
        [Order(12)]
        public async Task GetDetailAsync_Expand_ReturnsRecurringInvoice()
        {
            // Act
            var data = (await RecurringInvoiceClient.Detail(_recurringInvoiceId)
                .Include(i => i.InvoiceTemplate.ConstantSymbol)
                .Include(i => i.InvoiceTemplate.Currency)
                .Include(i => i.InvoiceTemplate.Partner)
                .Include(i => i.InvoiceTemplate.PaymentOption)
                .Include(i => i.InvoiceTemplate.VatReverseChargeCode)
                .Include(i => i.InvoiceTemplate.Items.PriceListItem)
                .GetAsync()).AssertResult();

            // Assert
            AssertGetModel(data);
            AssertExpand(data);
        }

        [Test]
        [Order(13)]
        public async Task UpdateAsync_SuccessfullyUpdated()
        {
            // Arrange
            var model = CreatePatchModel();

            // Act
            var data = (await RecurringInvoiceClient.UpdateAsync(model)).AssertResult();

            // Assert
            AssertGetModel(data);
        }

        [Test]
        [Order(14)]
        public async Task GetListAsync_ReturnsList()
        {
            // Act
            var data = (await RecurringInvoiceClient.List().GetAsync()).AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
            Assert.That(data.Items, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        [Order(15)]
        public async Task GetListAsync_WithFilter_ReturnsList()
        {
            // Act
            var data = (await RecurringInvoiceClient.List()
                .Filter(i => i.PartnerId.IsEqual(PartnerId))
                .Filter(i => i.Id.IsEqual(_recurringInvoiceId))
                .GetAsync()).AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
            Assert.That(data.Items, Is.Not.Null.And.Not.Empty);
            AssertListGetModel(data.Items.FirstOrDefault());
        }

        [Test]
        [Order(16)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = (await RecurringInvoiceClient.DeleteAsync(_recurringInvoiceId)).AssertResult();

            // Assert
            Assert.That(data, Is.True);
        }

        [Test]
        [Order(17)]
        public async Task NextIssueDateAsync_ReturnsCorrectValue()
        {
            // Arrange
            var model = CreateNextIssueDatesPostModel();

            // Act
            var data = (await RecurringInvoiceClient.NextIssueDatesAsync(model)).AssertResult();

            // Assert
            AssertNextIssueData(data);
        }

        [Test]
        [Order(18)]
        public async Task RecountAsync_SuccessfullyRecounted()
        {
            // Arrange
            var model = CreateRecountPostModel();

            // Act
            var data = (await RecurringInvoiceClient.RecountAsync(model)).AssertResult();

            // Assert
            AssertRecountData(model, data);
        }
    }
}
