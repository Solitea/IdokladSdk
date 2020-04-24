using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.Email;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Emails
{
    public partial class EmailTests
    {
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
            var response = await MailClient.IssuedInvoiceEmail.SendAsync(settings);
            var result = response.AssertResult();

            // Assert
            AssertEmailResult(result);
        }

        [Test]
        public async Task Send_IssuedDocumentPaymentEmail_SucessfullyAsync()
        {
            // Act
            var response = await MailClient.IssuedDocumentPaymentConfirmationEmail.SendAsync(PaymentId);
            var result = response.AssertResult();

            // Assert
            Assert.IsTrue(result);
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
            var response = await MailClient.ReceivedInvoiceEmail.SendAsync(settings);
            var result = response.AssertResult();

            // Assert
            Assert.IsTrue(result.Sent.Contains(MyEmail));
            Assert.IsTrue(!result.NotSent.Any());
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
            var response = await MailClient.RemindersEmail.SendAsync(settings);
            var result = response.AssertResult();

            // Assert
            Assert.IsTrue(result.Sent.Contains(PartnerEmail));
            Assert.IsTrue(!result.NotSent.Any());
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
            var response = await MailClient.SalesReceiptEmail.SendAsync(settings);
            var result = response.AssertResult();

            // Assert
            Assert.IsTrue(result.Sent.Contains(PartnerEmail));
            Assert.IsTrue(!result.NotSent.Any());
        }
    }
}
