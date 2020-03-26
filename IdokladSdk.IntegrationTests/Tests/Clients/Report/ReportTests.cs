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
    public partial class ReportTests : TestBase
    {
        private ReportClient _reportClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _reportClient = DokladApi.ReportClient;
        }

        [Test]
        public void Get_IssuedInvoiceDetail_SuccessfullyGetReport()
        {
            var data = _reportClient.IssuedInvoice.Detail(913255).Get(new ExtendedReportOption
            {
                Language = Language.En,
                PaymentOption = PaymentOption.WithPayment,
            }).AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void Get_ProformaInvoiceDetail_SuccessfullyGetReport()
        {
            var data = _reportClient.ProformaInvoice.Detail(913250).Get().AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void Get_CreditNoteDetail_SuccessfullyGetReport()
        {
            var data = _reportClient.CreditNote.Detail(913257).Get().AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void Get_SalesReceiptDetail_SuccessfullyGetReport()
        {
            var data = _reportClient.SalesReceipt.Detail(224356).Get(new ReportOption
            {
                Language = Language.Cz
            }).AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void Get_ReceivedInvoiceDetail_SuccessfullyGetReport()
        {
            var data = _reportClient.ReceivedInvoice.Detail(165292).Get(new ReportOption
            {
                Language = Language.Cz
            }).AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void Get_CashVoucherDetail_SuccessfullyGetReport()
        {
            var data = _reportClient.CashVoucher.Detail(587154).Get(new ReportOption
            {
                Language = Language.Cz
            }).AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void Get_CashVoucherDetail_ForInvoice_SuccessfullyGetReport()
        {
            var data = _reportClient.CashVoucher.DetailForInvoice(913318, InvoiceReportDocumentType.IssuedInvoice).Get(new ReportOption
            {
                Language = Language.Cz
            }).AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void Get_IssuedInvoiceList_SuccessfullyGetReport()
        {
            var data = _reportClient.IssuedInvoice.List().Sort(s => s.DocumentNumber.Asc()).Get(Language.En).AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void Get_ProformaInvoiceList_SuccessfullyGetReport()
        {
            var data = _reportClient.ProformaInvoice.List().Get(Language.En).AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void Get_CreditNoteList_SuccessfullyGetReport()
        {
            var data = _reportClient.CreditNote.List().Get(Language.Cz).AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void Get_CashVoucherList_SuccessfullyGetReport()
        {
            var data = _reportClient.CashVoucher.List().Get(Language.Cz).AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void Get_SalesReceiptList_SuccessfullyGetReport()
        {
            var data = _reportClient.SalesReceipt.List().Get(Language.Cz).AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void Get_ReceivedInvoiceList_SuccessfullyGetReport()
        {
            var data = _reportClient.ReceivedInvoice.List().Get(Language.Cz).AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }
    }
}
