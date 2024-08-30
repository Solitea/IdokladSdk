using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.CashVoucher;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.CashVoucher
{
    [TestFixture]
    public class CashVoucherTests : TestBase
    {
        private const int CashVoucherId = 587154;
        private const int UnpaidIssuedInvoice = 914456;
        private const int UnpaidReceivedInvoice = 165460;

        private CashVoucherClient _client;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            InitDokladApi();
            _client = DokladApi.CashVoucherClient;
        }

        [Test]
        public async Task Default_SuccessfullyGetAsync()
        {
            // Act
            var cashVoucherIssue = await _client.DefaultAsync(MovementType.Issue).AssertResult();
            var cashVoucherEntry = await _client.DefaultAsync(MovementType.Entry).AssertResult();

            // Assert
            Assert.That(cashVoucherIssue.MovementType, Is.Not.EqualTo(cashVoucherEntry.MovementType));
            Assert.That(cashVoucherIssue.MovementType, Is.EqualTo(MovementType.Issue));
            Assert.That(cashVoucherEntry.MovementType, Is.EqualTo(MovementType.Entry));
        }

        [Test]
        [TestCaseSource(nameof(GetDefaultVouchers))]
        public async Task Default_SuccessfullyGetAsync(PairedDocumentType documentType, int documentId)
        {
            // Act
            var cashVoucher = await _client.DefaultAsync(documentType, documentId).AssertResult();

            // Assert
            Assert.That(cashVoucher.PairedDocument.DocumentType, Is.EqualTo(documentType));
            Assert.That(cashVoucher.PairedDocument.DocumentId, Is.EqualTo(documentId));
        }

        [Test]
        public async Task Detail_SuccessfullyGetAsync()
        {
            // Act
            var cashVoucher = await _client.Detail(CashVoucherId).GetAsync().AssertResult();

            // Assert
            Assert.That(cashVoucher.Id, Is.EqualTo(CashVoucherId));
            Assert.That(cashVoucher.Items.First().Price, Is.EqualTo(500m));
        }

        [Test]
        public async Task List_SucessfullyGetAsync()
        {
            // Act
            var cashVouchers = await _client.List().GetAsync().AssertResult();

            // Assert
            Assert.That(cashVouchers.TotalItems, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public async Task Post_SuccessfullyAsync()
        {
            // Arrange
            var cashVoucherName = $"Issued invoice for test: {UnpaidIssuedInvoice}";

            // Act
            var cashVoucher = await _client.DefaultAsync(PairedDocumentType.IssuedInvoice, UnpaidIssuedInvoice).AssertResult();
            cashVoucher.Name = cashVoucherName;
            var postedCashVoucher = await _client.PostAsync(cashVoucher).AssertResult();
            var pairModel = new CashVoucherPairPostModel { CashVoucherId = postedCashVoucher.Id, DocumentId = UnpaidIssuedInvoice, DocumentType = PairedDocumentType.IssuedInvoice };
            var paired = await _client.PairAsync(pairModel).AssertResult();
            var deleted = await _client.DeleteAsync(postedCashVoucher.Id).AssertResult();

            // Assert
            Assert.That(cashVoucher.PairedDocument.DocumentId, Is.EqualTo(UnpaidIssuedInvoice));
            Assert.That(postedCashVoucher.InvoiceId, Is.EqualTo(UnpaidIssuedInvoice));
            Assert.That(postedCashVoucher.Name, Is.EqualTo(cashVoucherName));
            Assert.That(paired, Is.True);
            Assert.That(deleted, Is.True);
        }

        private static IList<object> GetDefaultVouchers()
        {
            return new List<object> { new object[] { PairedDocumentType.IssuedInvoice, UnpaidIssuedInvoice }, new object[] { PairedDocumentType.ReceivedInvoice, UnpaidReceivedInvoice } };
        }
    }
}
