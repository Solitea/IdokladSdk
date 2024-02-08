using System;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.DocumentPayment
{
    /// <summary>
    /// SalesDocumentPaymentTests.
    /// </summary>
    [TestFixture]
    public class SalesDocumentPaymentTests : TestBase
    {
        private const int CreditNotePaymentId = 1981587;
        private const int IssuedInvoicePaymentId = 1931356;
        private const int ProformaInvoicePaymentId = 1931330;
        private const int SalesReceiptPaymentId = 224120;
        private const string PartnerName = "Alza.cz a.s.";
        private const int PaymentOptionId = 3;
        private const string CurrencySymbol = "Kč";

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
            // Act
            var data = await DocumentPaymentClient.Sales
                .GetCreditNotePayment(CreditNotePaymentId).GetAsync().AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(CreditNotePaymentId));
            Assert.That(data.CurrencySymbol, Is.EqualTo(CurrencySymbol));
            Assert.That(data.DateOfMaturity, Is.EqualTo(new DateTime(2021, 3, 22)));
            Assert.That(data.DateOfPayment.Date, Is.EqualTo(new DateTime(2021, 3, 8)));
            Assert.That(data.IsIncomeTax, Is.EqualTo(true));
            Assert.That(data.PartnerName, Is.EqualTo(PartnerName));
            Assert.That(data.CreditNote, Is.Null);
            Assert.That(data.Prices, Is.Not.Null);
            Assert.That(data.PaymentOptionId, Is.EqualTo(5));
        }

        [Test]
        public async Task GetIssuedInvoicePayment_ReturnsPayment()
        {
            // Act
            var data = await DocumentPaymentClient.Sales
                .GetIssuedInvoicePayment(IssuedInvoicePaymentId).GetAsync().AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(IssuedInvoicePaymentId));
            Assert.That(data.CurrencySymbol, Is.EqualTo(CurrencySymbol));
            Assert.That(data.DateOfMaturity, Is.EqualTo(new DateTime(2020, 2, 5)));
            Assert.That(data.DateOfPayment, Is.EqualTo(new DateTime(2020, 1, 22)));
            Assert.That(data.IsIncomeTax, Is.EqualTo(true));
            Assert.That(data.PartnerName, Is.EqualTo(PartnerName));
            Assert.That(data.IssuedInvoice, Is.Null);
            Assert.That(data.PaymentOptionId, Is.EqualTo(PaymentOptionId));
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
            var dateOfPayment = new DateTime(2020, 01, 22);
            var documentNumber = "PR2020001";
            var documentId = 224356;

            // Act
            var data = await DocumentPaymentClient.Sales
                .List()
                .Filter(f => f.PartnerId.IsEqual(partnerId))
                .Filter(f => f.PartnerName.Contains(PartnerName))
                .Filter(f => f.PaymentOptionId.IsEqual(PaymentOptionId))
                .Filter(f => f.DateOfPayment.IsEqual(dateOfPayment))
                .Filter(f => f.DocumentNumber.IsEqual(documentNumber))
                .Filter(f => f.DocumentId.IsEqual(documentId))
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.Items, Is.Not.Null);
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
            var item = data.Items.First();
            Assert.That(item.PaidDocument.PartnerId, Is.EqualTo(partnerId));
            Assert.That(item.PaidDocument.PartnerName, Is.EqualTo(PartnerName));
            Assert.That(item.PaymentOptionId, Is.EqualTo(PaymentOptionId));
            Assert.That(item.DateOfPayment, Is.EqualTo(dateOfPayment));
            Assert.That(item.PaidDocument.DocumentNumber, Is.EqualTo(documentNumber));
            Assert.That(item.PaidDocument.Id, Is.EqualTo(documentId));
        }

        [Test]
        public async Task GetListAsync_ApplyDateOfPaymentDescSort_ReturnsSortedSalesDocumentPayments()
        {
            // Act
            var data = await DocumentPaymentClient.Sales
                .List().Sort(s => s.DateOfPayment.Desc())
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.Items, Is.Not.Null);
            var dates = data.Items.Select(o => o.DateOfPayment).ToList();
            Assert.That(dates, Is.Ordered.Descending);
        }

        [Test]
        public async Task GetListAsync_ApplyDateOfPaymentAscSort_ReturnsSortedSalesDocumentPayments()
        {
            // Act
            var data = await DocumentPaymentClient.Sales
                .List().Sort(s => s.DateOfPayment.Asc())
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.Items, Is.Not.Null);
            var dates = data.Items.Select(o => o.DateOfPayment).ToList();
            Assert.That(dates, Is.Ordered.Ascending);
        }

        [Test]
        public async Task GetListAsync_ApplyDocumentIdDescSort_ReturnsSortedSalesDocumentPayments()
        {
            // Act
            var data = await DocumentPaymentClient.Sales
                .List().Sort(s => s.DocumentId.Desc())
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.Items, Is.Not.Null);
            var documentIds = data.Items.Select(s => s.PaidDocument.Id);
            Assert.That(documentIds, Is.Ordered.Descending);
        }

        [Test]
        public async Task GetListAsync_ApplyDocumentIdAscSort_ReturnsSortedSalesDocumentPayments()
        {
            // Act
            var data = await DocumentPaymentClient.Sales
                .List().Sort(s => s.DocumentId.Asc())
                .GetAsync()
                .AssertResult();

            //Assert
            Assert.That(data.Items, Is.Not.Null);
            var documentIds = data.Items.Select(s => s.PaidDocument.Id);
            Assert.That(documentIds, Is.Ordered.Ascending);
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
            // Act
            var data = await DocumentPaymentClient.Sales
                .GetProformaInvoicePayment(ProformaInvoicePaymentId).GetAsync().AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(ProformaInvoicePaymentId));
            Assert.That(data.ProformaInvoice, Is.Null);
            Assert.That(data.Prices, Is.Not.Null);
            Assert.That(data.CurrencySymbol, Is.EqualTo(CurrencySymbol));
            Assert.That(data.DateOfMaturity, Is.EqualTo(new DateTime(2020, 2, 3)));
            Assert.That(data.DateOfPayment, Is.EqualTo(new DateTime(2020, 1, 20)));
            Assert.That(data.IsIncomeTax, Is.EqualTo(true));
            Assert.That(data.PartnerName, Is.EqualTo(PartnerName));
            Assert.That(data.PaymentOptionId, Is.EqualTo(1));
        }

        [Test]
        public async Task GetSalesReceiptPayment_ReturnsPayment()
        {
            // Act
            var data = await DocumentPaymentClient.Sales
                .GetSalesReceiptPayment(SalesReceiptPaymentId).GetAsync().AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(SalesReceiptPaymentId));
            Assert.That(data.SalesReceipt, Is.Null);
            Assert.That(data.Prices, Is.Not.Null);
            Assert.That(data.CurrencySymbol, Is.EqualTo(CurrencySymbol));
            Assert.That(data.DateOfMaturity, Is.EqualTo(new DateTime(2020, 1, 22)));
            Assert.That(data.DateOfPayment, Is.EqualTo(new DateTime(2020, 1, 22)));
            Assert.That(data.IsIncomeTax, Is.EqualTo(true));
            Assert.That(data.PartnerName, Is.EqualTo(PartnerName));
            Assert.That(data.PaymentOptionId, Is.EqualTo(PaymentOptionId));
        }
    }
}
