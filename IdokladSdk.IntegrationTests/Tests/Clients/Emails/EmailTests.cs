using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.Email;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Emails
{
    [TestFixture]
    public class EmailTests : TestBase
    {
        private const string MyEmail = "qquc@furusato.tokyo";
        private const string OtherEmail = "qquc@furusato.tok";
        private const string PartnerEmail = "qquc_test@furusato.tokyo";

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            InitDokladApi();
        }

        [Test]
        public void Send_CreditNoteEmail_Successfully()
        {
            // Arrange
            var settings = new CreditNoteEmailSettings
            {
                DocumentId = 913257,
                ReportLanguage = Language.Cz,
                EmailBody = "Test CreditNote email.",
                EmailSubject = "CreditNote",
                InvoiceSendType = InvoiceSendType.AsLink,
                SendToSelf = true,
                SendToPartner = true,
                OtherRecipients = new List<string> { OtherEmail }
            };

            // Act
            var result = DokladApi.MailClient.CreditNoteEmail.Send(settings).AssertResult();

            // Assert
            AssertEmailResult(result);
        }

        [Test]
        public async Task Send_IssuedInvoiceEmail_Successfully()
        {
            // Arrange
            var settings = new IssuedInvoiceEmailSettings
            {
                DocumentId = 913242,
                ReportLanguage = Language.En,
                EmailBody = "Test IssuedInvoice email.",
                EmailSubject = "IssuedInvoice",
                InvoiceSendType = InvoiceSendType.AsPdf,
                SendToSelf = true,
                SendToPartner = true,
                OtherRecipients = new List<string> { OtherEmail }
            };

            // Act
            var response = await DokladApi.MailClient.IssuedInvoiceEmail.SendAsync(settings);
            var result = response.AssertResult();

            // Assert
            AssertEmailResult(result);
        }

        [Test]
        public void Send_ProformaInvoiceEmail_Successfully()
        {
            // Arrange
            var settings = new ProformaInvoiceEmailSettings
            {
                DocumentId = 913250,
                ReportLanguage = Language.Sk,
                EmailBody = "Test ProformaInvoice email.",
                EmailSubject = "ProformaInvoice",
                InvoiceSendType = InvoiceSendType.AsLink,
                SendToSelf = true,
                SendToPartner = true,
                OtherRecipients = new List<string> { OtherEmail }
            };

            // Act
            var result = DokladApi.MailClient.ProformaInvoiceEmail.Send(settings).AssertResult();

            // Assert
            AssertEmailResult(result);
        }

        [Test]
        public async Task Send_ReceivedInvoiceEmail_Successfully()
        {
            // Arrange
            var settings = new ReceivedInvoiceEmailSettings
            {
                DocumentId = 165292,
                ReportLanguage = Language.De,
                EmailBody = "Test ReceivedInvoice email.",
                EmailSubject = "ReceivedInvoice",
                SendToSelf = true,
                OtherRecipients = new List<string> { OtherEmail }
            };

            // Act
            var response = await DokladApi.MailClient.ReceivedInvoiceEmail.SendAsync(settings);
            var result = response.AssertResult();

            // Assert
            Assert.IsTrue(result.Sent.Contains(MyEmail));
            Assert.IsTrue(!result.NotSent.Any());
        }

        [Test]
        public void Send_SalesOrderEmail_Successfully()
        {
            // Arrange
            var settings = new SalesOrderEmailSettings
            {
                DocumentId = 822,
                ReportLanguage = Language.Sk,
                EmailBody = "Test SalesOrder email.",
                EmailSubject = "SalesOrder",
                SendToPartner = true,
                OtherRecipients = new List<string> { OtherEmail }
            };

            // Act
            var result = DokladApi.MailClient.SalesOrderEmail.Send(settings).AssertResult();

            // Assert
            Assert.IsTrue(result.Sent.Contains(PartnerEmail));
            Assert.IsTrue(!result.NotSent.Any());
        }

        [Test]
        [TestCaseSource(nameof(GetCreditNoteEmailSettings))]
        public void Send_CreditNoteEmailWithoutRecipient_ThrowsValidationException(CreditNoteEmailSettings setting)
        {
            var exception = Assert.Throws<ValidationException>(() => DokladApi.MailClient.CreditNoteEmail.Send(setting));

            AssertExceptionMessage(exception);
        }

        [Test]
        [TestCaseSource(nameof(GetIssuedInvoiceEmailSettings))]
        public void Send_IssuedInvoiceEmailWithoutRecipient_ThrowsValidationException(IssuedInvoiceEmailSettings setting)
        {
            var exception = Assert.Throws<ValidationException>(() => DokladApi.MailClient.IssuedInvoiceEmail.Send(setting));

            AssertExceptionMessage(exception);
        }

        [Test]
        [TestCaseSource(nameof(GetProformaInvoiceEmailSettings))]
        public void Send_ProformaInvoiceEmailWithoutRecipient_ThrowsValidationException(ProformaInvoiceEmailSettings setting)
        {
            var exception = Assert.ThrowsAsync<ValidationException>(() => DokladApi.MailClient.ProformaInvoiceEmail.SendAsync(setting));

            AssertExceptionMessage(exception);
        }

        [Test]
        [TestCaseSource(nameof(GetReceivedInvoiceEmailSettings))]
        public void Send_ReceivedInvoiceEmailWithoutRecipient_ThrowsValidationException(ReceivedInvoiceEmailSettings setting)
        {
            var exception = Assert.ThrowsAsync<ValidationException>(() => DokladApi.MailClient.ReceivedInvoiceEmail.SendAsync(setting));

            AssertExceptionMessage(exception);
        }

        [Test]
        [TestCaseSource(nameof(GetSalesOrderEmailSettings))]
        public void Send_SalesOrderEmailWithoutRecipient_ThrowsValidationException(SalesOrderEmailSettings setting)
        {
            var exception = Assert.Throws<ValidationException>(() => DokladApi.MailClient.SalesOrderEmail.Send(setting));

            AssertExceptionMessage(exception);
        }

        private static IList<CreditNoteEmailSettings> GetCreditNoteEmailSettings()
        {
            return GetEmailSettings<CreditNoteEmailSettings>();
        }

        private static IList<IssuedInvoiceEmailSettings> GetIssuedInvoiceEmailSettings()
        {
            return GetEmailSettings<IssuedInvoiceEmailSettings>();
        }

        private static IList<ProformaInvoiceEmailSettings> GetProformaInvoiceEmailSettings()
        {
            return GetEmailSettings<ProformaInvoiceEmailSettings>();
        }

        private static IList<ReceivedInvoiceEmailSettings> GetReceivedInvoiceEmailSettings()
        {
            return GetEmailSettings<ReceivedInvoiceEmailSettings>();
        }

        private static IList<SalesOrderEmailSettings> GetSalesOrderEmailSettings()
        {
            return GetEmailSettings<SalesOrderEmailSettings>();
        }

        private static IList<TSettings> GetEmailSettings<TSettings>()
            where TSettings : EmailSettings, new()
        {
            return new List<TSettings>
            {
                new TSettings(),
                new TSettings { OtherRecipients = new List<string> { "qquc@furusato" } }
            };
        }

        private void AssertEmailResult(EmailSendResult result)
        {
            Assert.IsTrue(result.Sent.Contains(PartnerEmail));
            Assert.IsTrue(result.Sent.Contains(MyEmail));
            Assert.IsTrue(!result.NotSent.Any());
        }

        private void AssertExceptionMessage(ValidationException exception)
        {
            Assert.IsNotNull(exception.Message);
            Assert.IsNotEmpty(exception.Message);
        }
    }
}
