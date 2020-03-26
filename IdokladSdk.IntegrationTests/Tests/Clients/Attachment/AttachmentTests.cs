using System.IO;
using System.Linq;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.Attachment;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Attachment
{
    [TestFixture]
    public class AttachmentTests : TestBase
    {
        private const string FileName = "reportnew.pdf";
        private const int DocumentId = 913242;
        private const string AttachmentPath = "Tests/Clients/Attachment/File/report.pdf";
        private AttachmentClient _attachmentClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _attachmentClient = DokladApi.AttachmentClient;
        }

        [Test]
        [Order(1)]
        public void Upload_SuccessfullyUpdated()
        {
            // Arrange
            var model = new AttachmentUploadModel
            {
                FileBytes = File.ReadAllBytes($"{TestContext.CurrentContext.TestDirectory}/{AttachmentPath}"),
                FileName = FileName,
                DocumentType = AttachmentDocumentType.IssuedInvoice,
                DocumentId = DocumentId
            };

            // Act
            var data = _attachmentClient.Upload(model).AssertResult();

            // Assert
            Assert.IsTrue(data);
        }

        [Test]
        [Order(2)]
        public void Get_SuccessfullyGetAttachment()
        {
            // Act
            var data = _attachmentClient.Get(DocumentId, AttachmentDocumentType.IssuedInvoice).AssertResult();

            // Assert
            var first = data.FirstOrDefault();
            Assert.NotNull(first);
            Assert.NotNull(first.FileBytes);
            Assert.AreEqual(FileName, first.FileName);
        }

        [Test]
        [Order(3)]
        public void Delete_SuccessfullyDeleted()
        {
            // Act
            var data = _attachmentClient.Delete(DocumentId, AttachmentDocumentType.IssuedInvoice).AssertResult();

            // Assert
            Assert.IsTrue(data);
        }
    }
}
