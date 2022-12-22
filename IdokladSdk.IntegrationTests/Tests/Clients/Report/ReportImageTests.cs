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
    public class ReportImageTests : TestBase
    {
        private ReportClient _reportClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _reportClient = DokladApi.ReportClient;
        }

        [Test]
        public async Task GetImageAsync_IssuedInvoiceDetail_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.IssuedInvoice.Detail(913255).GetImageAsync(new ExtendedReportImageOption
            {
                Language = Language.En,
                PaymentOption = PaymentOption.WithPayment,
            }).AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public async Task GetImageAsync_IssuedInvoiceDetail_WithoutSpecificLanguage_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.IssuedInvoice.Detail(913255).GetImageAsync(new ExtendedReportImageOption
            {
                PaymentOption = PaymentOption.WithPayment,
            }).AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public async Task GetImageAsync_ProformaInvoiceDetail_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.ProformaInvoice.Detail(913250).GetImageAsync().AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public async Task GetImageAsync_CreditNoteDetail_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.CreditNote
                .Detail(913257)
                .GetImageAsync()
                .AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public async Task GetImageAsync_SalesReceiptDetail_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.SalesReceipt
                .Detail(224356)
                .GetImageAsync(new ReportImageOption
                {
                    Language = Language.Cz
                }).AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public async Task GetImageAsync_ReceivedInvoiceDetail_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.ReceivedInvoice
                .Detail(165292)
                .GetImageAsync(new ReportImageOption
                {
                    Language = Language.Cz
                }).AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public async Task GetImageAsync_CashVoucherDetail_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.CashVoucher
                .Detail(587154)
                .GetImageAsync(new ReportImageOption
                {
                    Language = Language.Cz
                }).AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public async Task GetImageAsync_CashVoucherDetail_ForInvoice_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.CashVoucher
                .DetailForInvoice(913318, InvoiceReportDocumentType.IssuedInvoice)
                .GetImageAsync(new ReportImageOption
                {
                    Language = Language.Cz
                }).AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public async Task GetImageAsync_IssuedInvoiceList_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.IssuedInvoice
                .List()
                .Sort(s => s.DocumentNumber.Asc())
                .GetImageAsync(new ReportImageOption { Language = Language.En })
                .AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public async Task GetImage_IssuedTaxDocumentDetail_SuccessfullyGetReport()
        {
            // Act
            var data = await _reportClient.IssuedTaxDocument
                .Detail(1542)
                .GetImageAsync(new ReportImageOption { Language = Language.Cz })
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public async Task GetImageAsync_ProformaInvoiceList_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.ProformaInvoice
                .List()
                .GetImageAsync(new ReportImageOption { Language = Language.En })
                .AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public async Task GetImageAsync_CreditNoteList_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.CreditNote
                .List()
                .GetImageAsync(new ReportImageOption { Language = Language.Cz })
                .AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public async Task GetImageAsync_CashVoucherList_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.CashVoucher
                .List()
                .GetImageAsync(new ReportImageOption { Language = Language.Cz })
                .AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public async Task GetAsync_SalesOrderDetail_SuccessfullyGetReport()
        {
            // Act
            var data = await _reportClient.SalesOrder
                .Detail(1009)
                .GetImageAsync(new ReportImageOption { Language = Language.Sk })
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public async Task GetImageAsync_SalesReceiptList_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.SalesReceipt
                .List()
                .GetImageAsync(new ReportImageOption { Language = Language.Cz })
                .AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public async Task GetImageAsync_ReceivedInvoiceList_SuccessfullyGetAsyncReport()
        {
            var data = await _reportClient.ReceivedInvoice.List().GetImageAsync(new ReportImageOption { Language = Language.Cz }).AssertResult();

            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }
    }
}