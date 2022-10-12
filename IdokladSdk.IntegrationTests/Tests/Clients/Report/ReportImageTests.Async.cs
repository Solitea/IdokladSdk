using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.Report;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Report
{
    /// <summary>
    /// ReportTests.
    /// </summary>
    public partial class ReportImageTests
    {
        [Test]
        public void GetImageAsync_IssuedInvoiceDetail_SuccessfullyGetAsyncAsyncReport()
        {
            var data = _reportClient.IssuedInvoice.Detail(913255).GetImageAsync(new ExtendedReportImageOption
            {
                Language = Language.En,
                PaymentOption = PaymentOption.WithPayment,
            }).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImageAsync_IssuedInvoiceDetail_WithoutSpecificLanguage_SuccessfullyGetAsyncAsyncReport()
        {
            var data = _reportClient.IssuedInvoice.Detail(913255).GetImageAsync(new ExtendedReportImageOption
            {
                PaymentOption = PaymentOption.WithPayment,
            }).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImageAsync_ProformaInvoiceDetail_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.ProformaInvoice.Detail(913250).GetImageAsync().Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImageAsync_CreditNoteDetail_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.CreditNote.Detail(913257).GetImageAsync().Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImageAsync_SalesReceiptDetail_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.SalesReceipt.Detail(224356).GetImageAsync(new ReportImageOption
            {
                Language = Language.Cz
            }).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImageAsync_ReceivedInvoiceDetail_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.ReceivedInvoice.Detail(165292).GetImageAsync(new ReportImageOption
            {
                Language = Language.Cz
            }).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImageAsync_CashVoucherDetail_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.CashVoucher.Detail(587154).GetImageAsync(new ReportImageOption
            {
                Language = Language.Cz
            }).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImageAsync_CashVoucherDetail_ForInvoice_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.CashVoucher.DetailForInvoice(913318, InvoiceReportDocumentType.IssuedInvoice).GetImageAsync(new ReportImageOption
            {
                Language = Language.Cz
            }).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImageAsync_IssuedInvoiceList_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.IssuedInvoice.List().Sort(s => s.DocumentNumber.Asc()).GetImageAsync(new ReportImageOption { Language = Language.En }).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImageAsync_ProformaInvoiceList_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.ProformaInvoice.List().GetImageAsync(new ReportImageOption { Language = Language.En }).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImageAsync_CreditNoteList_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.CreditNote.List().GetImageAsync(new ReportImageOption { Language = Language.Cz }).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImageAsync_CashVoucherList_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.CashVoucher.List().GetImageAsync(new ReportImageOption { Language = Language.Cz }).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImageAsync_SalesReceiptList_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.SalesReceipt.List().GetImageAsync(new ReportImageOption { Language = Language.Cz }).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImageAsync_ReceivedInvoiceList_SuccessfullyGetAsyncReport()
        {
            var data = _reportClient.ReceivedInvoice.List().GetImageAsync(new ReportImageOption { Language = Language.Cz }).Result.AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }
    }
}
