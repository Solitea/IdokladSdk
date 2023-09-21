using System;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.DocumentPayment
{
    /// <summary>
    /// SalesDocumentPaymentTests.
    /// </summary>
    [TestFixture]
    public class SalesDocumentPaymentTests : TestBase
    {
        public DocumentPaymentClient DocumentPaymentClient { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            DocumentPaymentClient = DokladApi.DocumentPaymentClient;
        }

        [Test]
        public async Task GetGetCreditNotePayment_ReturnsPayment()
        {
            // Arrange
            var page = await DocumentPaymentClient.Sales.List().PageSize(1)
                .GetAsync(c => new { c.Id }, DocumentPaymentSalesType.CreditNote).AssertResult();
            var id = page.Items.First().Id;

            // Act
            var data = await DocumentPaymentClient.Sales
                .GetCreditNotePayment(id).GetAsync().AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(id));
            Assert.That(data.CreditNote, Is.Null);
            Assert.That(data.Prices, Is.Not.Null);
        }

        [Test]
        public async Task GetIssuedInvoicePayment_ReturnsPayment()
        {
            // Arrange
            var page = await DocumentPaymentClient.Sales.List().PageSize(1)
                .GetAsync(c => new { c.Id }, DocumentPaymentSalesType.IssuedInvoice).AssertResult();
            var id = page.Items.First().Id;

            // Act
            var data = await DocumentPaymentClient.Sales
                .GetIssuedInvoicePayment(id).GetAsync().AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(id));
            Assert.That(data.IssuedInvoice, Is.Null);
        }

        [Test]
        public async Task GetIssuedInvoicePayment_WithExpand_ReturnsPayment()
        {
            // Arrange
            var page = await DocumentPaymentClient.Sales.List().PageSize(1)
                .GetAsync(c => new { c.Id }, DocumentPaymentSalesType.IssuedInvoice)
                .AssertResult();
            var id = page.Items.First().Id;

            // Act
            var data = await DocumentPaymentClient.Sales
                .GetIssuedInvoicePayment(id)
                .Include(x => x.IssuedInvoice)
                .Include(x => x.Currency)
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(id));
            Assert.That(data.IssuedInvoice, Is.Not.Null);
            Assert.That(data.Currency, Is.Not.Null);
        }

        [Test]
        public async Task GetListAsync_ApplyFilter_ReturnsSalesDocumentPayments()
        {
            // Arrange
            var partnerId = 323823;
            var partnerName = "Alza.cz a.s.";
            var paymentOptionId = 3;
            var dateOfPayment = new DateTime(2020, 01, 22);
            var documentNumber = "PR2020001";

            // Act
            var data = await DocumentPaymentClient.Sales
                .List()
                .Filter(f => f.PartnerId.IsEqual(partnerId))
                .Filter(f => f.PartnerName.IsEqual(partnerName))
                .Filter(f => f.PaymentOptionId.IsEqual(paymentOptionId))
                .Filter(f => f.DateOfPayment.IsEqual(dateOfPayment))
                .Filter(f => f.DocumentNumber.IsEqual(documentNumber))
                .FilterType(FilterType.And)
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.Items, Is.Not.Null);
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
            var item = data.Items.First();
            Assert.That(item.PaidDocument.PartnerId, Is.EqualTo(partnerId));
            Assert.That(item.PaidDocument.PartnerName, Is.EqualTo(partnerName));
            Assert.That(item.PaymentOptionId, Is.EqualTo(paymentOptionId));
            Assert.That(item.DateOfPayment, Is.EqualTo(dateOfPayment));
            Assert.That(item.PaidDocument.DocumentNumber, Is.EqualTo(documentNumber));
        }

        [Test]
        public async Task GetListAsync_OnlyCreditNotes_ReturnsSalesDocumentPayments()
        {
            // Act
            var data = await DocumentPaymentClient.Sales
                .List()
                .GetAsync(DocumentPaymentSalesType.CreditNote)
                .AssertResult();

            // Assert
            Assert.That(data.Items, Is.Not.Null);
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
            Assert.That(data.Items.All(f => f.PaidDocument.DocumentType == ApiSalesPaymentForDocumentType.CreditNote));
        }

        [Test]
        public async Task GetListAsync_ReturnsSalesDocumentPayments()
        {
            // Act
            var data = await DocumentPaymentClient.Sales
                .List()
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.Items, Is.Not.Null);
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
        }

        [Test]
        public async Task GetProformaInvoicePayment_ReturnsPayment()
        {
            // Arrange
            var page = await DocumentPaymentClient.Sales.List().PageSize(1)
                .GetAsync(c => new { c.Id }, DocumentPaymentSalesType.ProformaInvoice).AssertResult();
            var id = page.Items.First().Id;

            // Act
            var data = await DocumentPaymentClient.Sales
                .GetProformaInvoicePayment(id).GetAsync().AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(id));
            Assert.That(data.ProformaInvoice, Is.Null);
            Assert.That(data.Prices, Is.Not.Null);
        }

        [Test]
        public async Task GetSalesReceiptPayment_ReturnsPayment()
        {
            // Arrange
            var page = await DocumentPaymentClient.Sales.List().PageSize(1)
                .GetAsync(c => new { c.Id }, DocumentPaymentSalesType.SalesReceipt).AssertResult();
            var id = page.Items.First().Id;

            // Act
            var data = await DocumentPaymentClient.Sales
                .GetSalesReceiptPayment(id).GetAsync().AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(id));
            Assert.That(data.SalesReceipt, Is.Null);
            Assert.That(data.Prices, Is.Not.Null);
        }
    }
}
