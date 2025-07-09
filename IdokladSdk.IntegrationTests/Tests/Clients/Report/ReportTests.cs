using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.Report;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Report
{
    /// <summary>
    /// ReportTests.
    /// </summary>
    public class ReportTests : TestBase
    {
        private ReportClient _reportClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _reportClient = DokladApi.ReportClient;
        }

        [Test]
        public async Task GetAsync_IssuedInvoiceDetail_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.IssuedInvoice.Detail(913255).GetAsync(new ExtendedReportOption
            {
                Language = Language.En,
                PaymentOption = PaymentOption.WithPayment,
            }).AssertResult();

            Assert.That(data, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task GetAsync_IssuedInvoiceDetail_WithoutSpecificLanguage_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.IssuedInvoice.Detail(913255).GetAsync(new ExtendedReportOption
            {
                PaymentOption = PaymentOption.WithPayment,
            }).AssertResult();

            Assert.That(data, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task GetAsync_ProformaInvoiceDetail_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.ProformaInvoice.Detail(913250).GetAsync().AssertResult();

            Assert.That(data, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task GetAsync_CreditNoteDetail_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.CreditNote.Detail(913257).GetAsync().AssertResult();

            Assert.That(data, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task GetAsync_SalesReceiptDetail_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.SalesReceipt.Detail(224356).GetAsync(new ReportOption
            {
                Language = Language.Cz
            }).AssertResult();

            Assert.That(data, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task GetAsync_ReceivedInvoiceDetail_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.ReceivedInvoice.Detail(165292).GetAsync(new ReportOption
            {
                Language = Language.Cz
            }).AssertResult();

            Assert.That(data, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task GetAsync_CashVoucherDetail_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.CashVoucher.Detail(643249).GetAsync(new ReportOption
            {
                Language = Language.Cz
            }).AssertResult();

            Assert.That(data, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task GetAsync_CashVoucherDetail_ForInvoice_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.CashVoucher.DetailForInvoice(913318, InvoiceReportDocumentType.IssuedInvoice).GetAsync(new ReportOption
            {
                Language = Language.Cz
            }).AssertResult();

            Assert.That(data, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task GetAsync_BankStatementDetail_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.BankStatement.Detail(990771).GetAsync(new ReportOption
            {
                Language = Language.Cz
            }).AssertResult();

            Assert.That(data, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task GetAsync_IssuedInvoiceList_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.IssuedInvoice.List().Sort(s => s.DocumentNumber.Asc()).GetAsync(Language.En).AssertResult();

            Assert.That(data, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task Get_IssuedTaxDocumentDetail_SuccessfullyGetReport()
        {
            // Act
            var data = await _reportClient.IssuedTaxDocument.Detail(8222).GetAsync(new ReportOption { Language = Language.Cz }).AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task GetAsync_ProformaInvoiceList_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.ProformaInvoice.List().Filter(f => f.Id.IsGreaterThan(1138604)).GetAsync(Language.En).AssertResult();

            Assert.That(data, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task GetAsync_CreditNoteList_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.CreditNote.List().GetAsync(Language.Cz).AssertResult();

            Assert.That(data, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task GetAsync_CashVoucherList_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.CashVoucher.List().GetAsync(Language.Cz).AssertResult();

            Assert.That(data, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task GetAsync_BankStatementList_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.BankStatement.List().GetAsync(Language.Cz).AssertResult();

            Assert.That(data, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task Get_SalesOrderDetail_SuccessfullyGetReport()
        {
            // Act
            var data = await _reportClient.SalesOrder.Detail(1009).GetAsync(new ReportOption { Language = Language.Sk }).AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task GetAsync_SalesReceiptList_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.SalesReceipt.List().GetAsync(Language.Cz).AssertResult();

            Assert.That(data, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task GetAsync_ReceivedInvoiceList_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.ReceivedInvoice.List().GetAsync(Language.Cz).AssertResult();

            Assert.That(data, Is.Not.Null.Or.Empty);
        }
    }
}
