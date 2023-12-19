using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Core.Helpers;
using IdokladSdk.Models.Attachment;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Attachment
{
    [TestFixture]
    public partial class AttachmentTests : TestBase
    {
        private const string FileName = "reportnew.pdf";
        private const string AttachmentPath = "Tests/Clients/Attachment/File/report.pdf";
        private int _documentId = 0;
        private int _attachmentId = 0;
        private string _attachmentName = string.Empty;
        private AttachmentClient _attachmentClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _attachmentClient = DokladApi.AttachmentClient;
            _documentId = DokladSdkTestsHelper.CreateDefaultIssuedInvoiceAsync(DokladApi).GetAwaiter().GetResult().Id;
        }

        [OneTimeTearDown]
        public async Task OneTimeTeardown()
        {
            await DokladApi.IssuedInvoiceClient.DeleteAsync(_documentId);
        }

        [Test]
        [Order(1)]
        public async Task UploadAsync_SuccessfullyUpdated()
        {
            // Arrange
            var model1 = GetAttachmentUploadModel(1);
            var model2 = GetAttachmentUploadModel(2);
            var model3 = GetAttachmentUploadModel(3);

            // Act
            var data1 = await _attachmentClient.UploadAsync(model1).AssertResult();
            var data2 = await _attachmentClient.UploadAsync(model2).AssertResult();
            var data3 = await _attachmentClient.UploadAsync(model3).AssertResult();

            // Assert
            Assert.That(data1, Is.True);
            Assert.That(data2, Is.True);
            Assert.That(data3, Is.True);
        }

        [Test]
        [Order(2)]
        public async Task GetAsync_SuccessfullyGetAllAttachment()
        {
            // Act
            var data = await _attachmentClient.GetAsync(_documentId, AttachmentDocumentType.IssuedInvoice).AssertResult();

            // Assert
            Assert.Multiple(() =>
            {
                data.ForEach((attachment) =>
                {
                    Assert.That(attachment.Id, Is.Not.EqualTo(0));
                    Assert.That(attachment.FileBytes, Is.Not.Null);
                    Assert.That(attachment.FileName, Is.Not.Null.Or.Empty);
                });
            });

            var attachment = data.FirstOrDefault();
            _attachmentId = attachment.Id;
            _attachmentName = attachment.FileName;
        }

        [Test]
        [Order(3)]
        public async Task GetAsync_SuccessfullyGetAttachment()
        {
            // Act
            var data = await _attachmentClient.GetAsync(_attachmentId).AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
            Assert.That(data.FileBytes, Is.Not.Null);
            Assert.That(data.FileName, Is.EqualTo(_attachmentName));
        }

        [Test]
        [Order(4)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = await _attachmentClient.DeleteAsync(_attachmentId).AssertResult();

            // Assert
            Assert.That(data, Is.True);
        }

        [Test]
        [Order(5)]
        public async Task DeleteAsync_AllSuccessfullyDeleted()
        {
            // Act
            var data = await _attachmentClient.DeleteAsync(_documentId, AttachmentDocumentType.IssuedInvoice).AssertResult();

            // Assert
            Assert.That(data, Is.True);
        }

        [Test]
        [Order(6)]
        public void UploadWithWrongFileName_ExceptionThrown()
        {
            // Act
            var model = new AttachmentUploadModel
            {
                FileName = "Wr<>ng“F|leNam?.docx"
            };

            AsyncTestDelegate action = async () => await _attachmentClient.UploadAsync(model).AssertResult();

            // Assert
            Assert.That(action, Throws.Exception.TypeOf<ValidationException>()
                .And.Message.EqualTo("File name contains one or more unsupported characters"));
        }

        private AttachmentUploadModel GetAttachmentUploadModel(int orderNumber)
        {
            return new AttachmentUploadModel
            {
                FileBytes = File.ReadAllBytes($"{TestContext.CurrentContext.TestDirectory}/{AttachmentPath}"),
                FileName = FileName.Insert(9, orderNumber.ToString()),
                DocumentType = AttachmentDocumentType.IssuedInvoice,
                DocumentId = _documentId
            };
        }
    }
}
