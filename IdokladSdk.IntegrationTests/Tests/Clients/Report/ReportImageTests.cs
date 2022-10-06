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
    public partial class ReportImageTests : TestBase
    {
        private ReportClient _reportClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _reportClient = DokladApi.ReportClient;
        }

        [Test]
        public void GetImage_IssuedInvoiceDetail_SuccessfullyGetReport()
        {
            // Act
            var data = _reportClient.IssuedInvoice.Detail(913255).GetImage(new ExtendedReportImageOption
            {
                Language = Language.En,
                PaymentOption = PaymentOption.WithPayment,
            }).AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImage_IssuedInvoiceDetail_WithoutSpecificLanguage_SuccessfullyGetReport()
        {
            // Act
            var data = _reportClient.IssuedInvoice.Detail(913255).GetImage(new ExtendedReportImageOption
            {
                PaymentOption = PaymentOption.WithPayment,
            }).AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImage_ProformaInvoiceDetail_SuccessfullyGetReport()
        {
            // Act
            var data = _reportClient.ProformaInvoice.Detail(913250).GetImage().AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImage_CreditNoteDetail_SuccessfullyGetReport()
        {
            // Act
            var data = _reportClient.CreditNote.Detail(913257).GetImage().AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImage_SalesReceiptDetail_SuccessfullyGetReport()
        {
            // Act
            var data = _reportClient.SalesReceipt.Detail(224356).GetImage(new ReportImageOption
            {
                Language = Language.Cz
            }).AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImage_ReceivedInvoiceDetail_SuccessfullyGetReport()
        {
            // Act
            var data = _reportClient.ReceivedInvoice.Detail(165292).GetImage(new ReportImageOption
            {
                Language = Language.Cz
            }).AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImage_CashVoucherDetail_SuccessfullyGetReport()
        {
            // Act
            var data = _reportClient.CashVoucher.Detail(587154).GetImage(new ReportImageOption
            {
                Language = Language.Cz
            }).AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImage_CashVoucherDetail_ForInvoice_SuccessfullyGetReport()
        {
            // Act
            var data = _reportClient.CashVoucher.DetailForInvoice(913318, InvoiceReportDocumentType.IssuedInvoice).GetImage(new ReportImageOption
            {
                Language = Language.Cz
            }).AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void Get_IssuedInvoiceList_SuccessfullyGetReport()
        {
            // Act
            var data = _reportClient.IssuedInvoice.List().Sort(s => s.DocumentNumber.Asc()).GetImage(new ReportImageOption { Language = Language.En }).AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetImage_IssuedTaxDocumentDetail_SuccessfullyGetReport()
        {
            // Act
            var data = _reportClient.IssuedTaxDocument.Detail(1542).GetImage(new ReportImageOption { Language = Language.Cz }).AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void Get_ProformaInvoiceList_SuccessfullyGetReport()
        {
            // Act
            var data = _reportClient.ProformaInvoice.List().GetImage(new ReportImageOption { Language = Language.En })
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void Get_CreditNoteList_SuccessfullyGetReport()
        {
            // Act
            var data = _reportClient.CreditNote.List().GetImage(new ReportImageOption { Language = Language.Cz }).AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void Get_CashVoucherList_SuccessfullyGetReport()
        {
            // Act
            var data = _reportClient.CashVoucher.List().GetImage(new ReportImageOption { Language = Language.Cz }).AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void Get_SalesOrderDetail_SuccessfullyGetReport()
        {
            // Act
            var data = _reportClient.SalesOrder.Detail(1009).GetImage(new ReportImageOption { Language = Language.Sk }).AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void Get_SalesReceiptList_SuccessfullyGetReport()
        {
            // Act
            var data = _reportClient.SalesReceipt.List().GetImage(new ReportImageOption { Language = Language.Cz }).AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void Get_ReceivedInvoiceList_SuccessfullyGetReport()
        {
            // Act
            var data = _reportClient.ReceivedInvoice.List().GetImage(new ReportImageOption { Language = Language.Cz }).AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.IsNotEmpty(data);
        }
    }
}
