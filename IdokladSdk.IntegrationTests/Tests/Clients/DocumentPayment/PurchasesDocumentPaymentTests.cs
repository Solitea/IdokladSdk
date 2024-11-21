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
    [TestFixture]
    [Ignore("Remove ignore after candidate creation")]
    public class PurchasesDocumentPaymentTests : TestBase
    {
        private const string CurrencySymbol = "Kč";
        private const string PartnerName = "Alza.cz a.s.";
        private const int PaymentOptionId = 2;
        private const int ReceivedInvoicePaymentId = 683183;

        public DocumentPaymentClient DocumentPaymentClient { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            DocumentPaymentClient = DokladApi.DocumentPaymentClient;
        }

        [Test]
        public async Task GetReceivedInvoicePayment_ReturnsPayment()
        {
            // Act
            var data = await DocumentPaymentClient.Purchases
                .GetReceivedInvoicePayment(ReceivedInvoicePaymentId).GetAsync().AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(ReceivedInvoicePaymentId));
            Assert.That(data.CurrencySymbol, Is.EqualTo(CurrencySymbol));
            Assert.That(data.DateOfMaturity, Is.EqualTo(new DateTime(2020, 4, 29)));
            Assert.That(data.DateOfPayment, Is.EqualTo(new DateTime(2020, 4, 29)));
            Assert.That(data.IsIncomeTax, Is.EqualTo(true));
            Assert.That(data.PartnerName, Is.EqualTo(PartnerName));
            Assert.That(data.ReceivedInvoice, Is.Null);
            Assert.That(data.PaymentOptionId, Is.EqualTo(PaymentOptionId));
        }

        [Test]
        public async Task GetReceivedInvoicePayment_WithExpand_ReturnsPayment()
        {
            // Arrange
            var page = await DocumentPaymentClient.Purchases.List().PageSize(1)
                .GetAsync(c => new { c.Id }, DocumentPaymentPurchaseType.ReceivedInvoice)
                .AssertResult();
            var id = page.Items.First().Id;

            // Act
            var data = await DocumentPaymentClient.Purchases
                .GetReceivedInvoicePayment(id)
                .Include(x => x.ReceivedInvoice)
                .Include(x => x.Currency)
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(id));
            Assert.That(data.ReceivedInvoice, Is.Not.Null);
            Assert.That(data.Currency, Is.Not.Null);
        }

        [Test]
        public async Task GetListAsync_ApplyDateOfPaymentAscSort_ReturnsSortedPurchasesDocumentPayments()
        {
            // Act
            var data = await DocumentPaymentClient.Purchases
                .List().Sort(s => s.DateOfPayment.Asc())
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.Items, Is.Not.Null);
            var dates = data.Items.Select(o => o.DateOfPayment).ToList();
            Assert.That(dates, Is.Ordered.Ascending);
        }

        [Test]
        public async Task GetListAsync_ApplyDateOfPaymentDescSort_ReturnsSortedPurchasesDocumentPayments()
        {
            // Act
            var data = await DocumentPaymentClient.Purchases
                .List().Sort(s => s.DateOfPayment.Desc())
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.Items, Is.Not.Null);
            var dates = data.Items.Select(o => o.DateOfPayment).ToList();
            Assert.That(dates, Is.Ordered.Descending);
        }

        [Test]
        public async Task GetListAsync_ApplyDocumentIdAscSort_ReturnsSortedPurchasesDocumentPayments()
        {
            // Act
            var data = await DocumentPaymentClient.Purchases
                .List().Sort(s => s.DocumentId.Asc())
                .GetAsync()
                .AssertResult();

            //Assert
            Assert.That(data.Items, Is.Not.Null);
            var documentIds = data.Items.Select(s => s.PaidDocument.Id);
            Assert.That(documentIds, Is.Ordered.Ascending);
        }

        [Test]
        public async Task GetListAsync_ApplyDocumentIdDescSort_ReturnsSortedPurchasesDocumentPayments()
        {
            // Act
            var data = await DocumentPaymentClient.Purchases
                .List().Sort(s => s.DocumentId.Desc())
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.Items, Is.Not.Null);
            var documentIds = data.Items.Select(s => s.PaidDocument.Id);
            Assert.That(documentIds, Is.Ordered.Descending);
        }

        [Test]
        public async Task GetListAsync_ApplyFilter_ReturnsPurchasesDocumentPayments()
        {
            // Arrange
            var partnerId = 323823;
            var dateOfPayment = new DateTime(2024, 11, 20);
            var documentNumber = "UC20240001";
            var documentId = 4393;

            // Act
            var data = await DocumentPaymentClient.Purchases
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
        public async Task GetListAsync_OnlyReceivedReceipt_ReturnsPurchasesDocumentPayments()
        {
            // Act
            var data = await DocumentPaymentClient.Purchases
                .List()
                .GetAsync(DocumentPaymentPurchaseType.ReceivedReceipt)
                .AssertResult();

            // Assert
            Assert.That(data.Items, Is.Not.Null);
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
            Assert.That(data.Items.All(f =>
                f.PaidDocument.DocumentType == PurchasePaymentForDocumentType.ReceivedReceipt));
        }

        [Test]
        public async Task GetListAsync_ReturnsPurchasesDocumentPayments()
        {
            // Act
            var data = await DocumentPaymentClient.Purchases
                .List()
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.Items, Is.Not.Null);
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
        }
    }
}
