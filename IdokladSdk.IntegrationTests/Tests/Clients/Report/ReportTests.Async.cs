using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.Report;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Report
{
    /// <summary>
    /// ReportTests.
    /// </summary>
    public partial class ReportTests
    {
        [Test]
        public void GetAsync_IssuedInvoiceDetail_SuccessfullyGetAsyncAsyncReport()
        {
            var data = _reportClient.IssuedInvoice.Detail(913255).GetAsync(new ExtendedReportOption
            {
                Language = Language.En,
                PaymentOption = PaymentOption.WithPayment,
            }).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetAsync_IssuedInvoiceDetail_WithoutSpecificLanguage_SuccessfullyGetAsyncAsyncReport()
        {
            var data = _reportClient.IssuedInvoice.Detail(913255).GetAsync(new ExtendedReportOption
            {
                PaymentOption = PaymentOption.WithPayment,
            }).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetAsyncAsync_ProformaInvoiceDetail_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.ProformaInvoice.Detail(913250).GetAsync().Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetAsyncAsync_CreditNoteDetail_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.CreditNote.Detail(913257).GetAsync().Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetAsync_SalesReceiptDetail_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.SalesReceipt.Detail(224356).GetAsync(new ReportOption
            {
                Language = Language.Cz
            }).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetAsync_ReceivedInvoiceDetail_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.ReceivedInvoice.Detail(165292).GetAsync(new ReportOption
            {
                Language = Language.Cz
            }).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetAsync_CashVoucherDetail_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.CashVoucher.Detail(587154).GetAsync(new ReportOption
            {
                Language = Language.Cz
            }).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetAsync_CashVoucherDetail_ForInvoice_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.CashVoucher.DetailForInvoice(913318, InvoiceReportDocumentType.IssuedInvoice).GetAsync(new ReportOption
            {
                Language = Language.Cz
            }).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetAsync_IssuedInvoiceList_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.IssuedInvoice.List().Sort(s => s.DocumentNumber.Asc()).GetAsync(Language.En).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetAsync_ProformaInvoiceList_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.ProformaInvoice.List().GetAsync(Language.En).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetAsync_CreditNoteList_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.CreditNote.List().GetAsync(Language.Cz).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetAsync_CashVoucherList_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.CashVoucher.List().GetAsync(Language.Cz).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetAsync_SalesReceiptList_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.SalesReceipt.List().GetAsync(Language.Cz).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetAsync_ReceivedInvoiceList_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.ReceivedInvoice.List().GetAsync(Language.Cz).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }
    }
}
