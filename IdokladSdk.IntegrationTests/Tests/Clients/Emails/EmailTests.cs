using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
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
        private const int PaymentId = 1937322;

        public MailClient MailClient { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            InitDokladApi();
            MailClient = DokladApi.MailClient;
        }

        [Test]
        public async Task SendAsync_CreditNoteEmail_Successfully()
        {
            // Arrange
            var settings = new CreditNoteEmailSettings
            {
                DocumentId = 913257,
                ReportLanguage = Language.Cz,
                EmailBody = "Test CreditNote email.",
                EmailSubject = "CreditNote",
                SendType = SendType.AsLink,
                SendToSelf = true,
                SendToPartner = true,
                OtherRecipients = new List<string> { OtherEmail }
            };

            // Act
            var result = await MailClient.CreditNoteEmail.SendAsync(settings).AssertResult();

            // Assert
            AssertEmailResult(result);
        }

        [Test]
        public async Task Send_IssuedDocumentPaymentEmail_SucessfullyAsync()
        {
            // Act
            var result = await MailClient.IssuedDocumentPaymentConfirmationEmail.SendAsync(PaymentId).AssertResult();

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task Send_ProformaInvoiceEmail_Successfully()
        {
            // Arrange
            var settings = new ProformaInvoiceEmailSettings
            {
                DocumentId = 913250,
                ReportLanguage = Language.Sk,
                EmailBody = "Test ProformaInvoice email.",
                EmailSubject = "ProformaInvoice",
                SendType = SendType.AsLink,
                SendToSelf = true,
                SendToPartner = true,
                OtherRecipients = new List<string> { OtherEmail }
            };

            // Act
            var result = await MailClient.ProformaInvoiceEmail.SendAsync(settings).AssertResult();

            // Assert
            AssertEmailResult(result);
        }

        [Test]
        public async Task Send_SalesOrderEmail_Successfully()
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
            var result = await MailClient.SalesOrderEmail.SendAsync(settings).AssertResult();

            // Assert
            Assert.That(result.Sent.Contains(PartnerEmail), Is.True);
            Assert.That(!result.NotSent.Any(), Is.True);
        }

        [TestCase(RemindersDocumentType.ProformaInvoice, 922399)]
        [TestCase(RemindersDocumentType.IssuedInvoice, 914456)]
        public async Task Send_Reminders_SuccessfullySentAsync(RemindersDocumentType documentType, int id)
        {
            // Arrange
            var settings = new RemindersEmailSettings
            {
                DocumentId = id,
                ReportLanguage = Language.En,
                EmailBody = "Test Reminders email.",
                EmailSubject = "Reminder",
                DocumentType = documentType,
                SendToSelf = true,
                SendToPartner = true,
                OtherRecipients = new List<string> { OtherEmail }
            };

            // Act
            var result = await MailClient.RemindersEmail.SendAsync(settings).AssertResult();

            // Assert
            Assert.That(result.Sent.Contains(PartnerEmail), Is.True);
            Assert.That(!result.NotSent.Any(), Is.True);
        }

        [Test]
        public async Task Send_SalesReceipt_SuccessfullySentAsync()
        {
            // Arrange
            var settings = new SalesReceiptEmailSettings
            {
                DocumentId = 224673,
                ReportLanguage = Language.En,
                EmailBody = "Test sales receipt email.",
                EmailSubject = "Sales receipt",
                SendType = SendType.AsLink,
                SendToSelf = true,
                SendToPartner = true,
                OtherRecipients = new List<string> { OtherEmail }
            };

            // Act
            var result = await MailClient.SalesReceiptEmail.SendAsync(settings).AssertResult();

            // Assert
            Assert.That(result.Sent.Contains(PartnerEmail), Is.True);
            Assert.That(!result.NotSent.Any(), Is.True);
        }

        [Test]
        public async Task Send_IssuedTaxDocument_SuccessfullySent()
        {
            // Arrange
            var issuedTaxDocumentId = 8222;
            var settings = new IssuedTaxDocumentEmailSettings
            {
                DocumentId = issuedTaxDocumentId,
                ReportLanguage = Language.En,
                EmailBody = "Test issued tax document email.",
                EmailSubject = "Issued tax document",
                SendToAccountant = true,
                SendToSelf = true,
                SendToPartner = true,
                OtherRecipients = new List<string> { OtherEmail }
            };

            // Act
            var result = await MailClient.IssuedTaxDocumentEmail.SendAsync(settings).AssertResult();

            // Assert
            Assert.That(result.Sent.Contains(PartnerEmail), Is.True);
            Assert.That(!result.NotSent.Any(), Is.True);
            var issuedTaxDocument = await DokladApi.IssuedTaxDocumentClient.Detail(issuedTaxDocumentId).GetAsync().AssertResult();
            Assert.That(issuedTaxDocument.IsSentToAccountant, Is.Not.EqualTo(MailSentType.NotSent));
            Assert.That(issuedTaxDocument.IsSentToPartner, Is.Not.EqualTo(MailSentType.NotSent));
        }

        [Test]
        public async Task Send_IssuedInvoiceEmail_SuccessfullyAsync()
        {
            // Arrange
            var settings = new IssuedInvoiceEmailSettings
            {
                DocumentId = 913242,
                ReportLanguage = Language.En,
                EmailBody = "Test IssuedInvoice email.",
                EmailSubject = "IssuedInvoice",
                SendType = SendType.AsPdf,
                SendToSelf = true,
                SendToPartner = true,
                OtherRecipients = new List<string> { OtherEmail }
            };

            // Act
            var result = await MailClient.IssuedInvoiceEmail.SendAsync(settings).AssertResult();

            // Assert
            AssertEmailResult(result);
        }

        [Test]
        public async Task Send_ReceivedInvoiceEmail_SuccessfullyAsync()
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
            var result = await MailClient.ReceivedInvoiceEmail.SendAsync(settings).AssertResult();

            // Assert
            Assert.That(result.Sent.Contains(MyEmail), Is.True);
            Assert.That(!result.NotSent.Any(), Is.True);
        }

        [TestCaseSource(nameof(GetCreditNoteEmailSettings))]
        public void Send_CreditNoteEmailWithoutRecipient_ThrowsValidationException(CreditNoteEmailSettings setting)
        {
            var exception = Assert.ThrowsAsync<ValidationException>(async () => await DokladApi.MailClient.CreditNoteEmail.SendAsync(setting));

            AssertExceptionMessage(exception);
        }

        [TestCaseSource(nameof(GetIssuedInvoiceEmailSettings))]
        public void Send_IssuedInvoiceEmailWithoutRecipient_ThrowsValidationException(IssuedInvoiceEmailSettings setting)
        {
            var exception = Assert.ThrowsAsync<ValidationException>(async () => await DokladApi.MailClient.IssuedInvoiceEmail.SendAsync(setting));

            AssertExceptionMessage(exception);
        }

        [TestCaseSource(nameof(GetProformaInvoiceEmailSettings))]
        public void Send_ProformaInvoiceEmailWithoutRecipient_ThrowsValidationException(ProformaInvoiceEmailSettings setting)
        {
            var exception = Assert.ThrowsAsync<ValidationException>(async () => await DokladApi.MailClient.ProformaInvoiceEmail.SendAsync(setting));

            AssertExceptionMessage(exception);
        }

        [TestCaseSource(nameof(GetReceivedInvoiceEmailSettings))]
        public void Send_ReceivedInvoiceEmailWithoutRecipient_ThrowsValidationException(ReceivedInvoiceEmailSettings setting)
        {
            var exception = Assert.ThrowsAsync<ValidationException>(async () => await DokladApi.MailClient.ReceivedInvoiceEmail.SendAsync(setting));

            AssertExceptionMessage(exception);
        }

        [TestCaseSource(nameof(GetSalesOrderEmailSettings))]
        public void Send_SalesOrderEmailWithoutRecipient_ThrowsValidationException(SalesOrderEmailSettings setting)
        {
            var exception = Assert.ThrowsAsync<ValidationException>(async () => await DokladApi.MailClient.SalesOrderEmail.SendAsync(setting));

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
            Assert.That(result.Sent.Contains(PartnerEmail), Is.True);
            Assert.That(result.Sent.Contains(MyEmail), Is.True);
            Assert.That(!result.NotSent.Any(), Is.True);
        }

        private void AssertExceptionMessage(ValidationException exception)
        {
            Assert.That(exception.Message, Is.Not.Null.Or.Empty);
        }
    }
}
