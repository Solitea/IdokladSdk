using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReceivedDocument
{
    [TestFixture]
    public class ReceivedDocumentTests : TestBase
    {
        private ReceivedDocumentsClient _receivedDocumentsClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _receivedDocumentsClient = DokladApi.ReceivedDocumentsClient;
        }

        [Test]
        public async Task List_GetAsync_SuccessfullyReturned()
        {
            // Act
            var result = await _receivedDocumentsClient.List().GetAsync();

            // Assert
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Data, Is.Not.Null);
        }

        [Test]
        public async Task List_GetAsync_WithFilterAndSort_SuccessfullyReturned()
        {
            // Act
            var result = await _receivedDocumentsClient
                .List()
                .Filter(f => f.DocumentType.IsEqual(InboxAttachmentDocumentType.ReceivedInvoice))
                .Sort(s => s.DateOfReceiving.Desc())
                .GetAsync();

            // Assert
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data.Items.All(i => i.DocumentType == InboxAttachmentDocumentType.ReceivedInvoice), Is.True);
        }
    }
}
