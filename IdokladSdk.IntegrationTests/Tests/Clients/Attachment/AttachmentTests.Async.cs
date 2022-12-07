using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.Attachment;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Attachment
{
    public partial class AttachmentTests
    {
        [Test]
        [Order(7)]
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
            Assert.IsTrue(data1);
            Assert.IsTrue(data2);
            Assert.IsTrue(data3);
        }

        [Test]
        [Order(8)]
        public async Task GetAsync_SuccessfullyGetAllAttachments()
        {
            // Act
            var data = await _attachmentClient.GetAsync(DocumentId, AttachmentDocumentType.IssuedInvoice).AssertResult();

            // Assert
            Assert.Multiple(() =>
            {
                data.ForEach((attachment) =>
                {
                    Assert.That(attachment.Id, Is.Not.EqualTo(0));
                    Assert.NotNull(attachment.FileBytes);
                    Assert.NotNull(attachment.FileName);
                });
            });

            var attachment = data.FirstOrDefault();
            Assert.NotNull(attachment);

            _attachmentId = attachment.Id;
            _attachmentName = attachment.FileName;

            Assert.That(_attachmentName, Is.Not.Null.Or.Empty);
        }

        [Test]
        [Order(9)]
        public async Task GetAsync_SuccessfullyGetAttachment()
        {
            // Act
            var data = await _attachmentClient.GetAsync(_attachmentId).AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.NotNull(data.FileBytes);
            Assert.AreEqual(_attachmentName, data.FileName);
        }

        [Test]
        [Order(10)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = await _attachmentClient.DeleteAsync(_attachmentId).AssertResult();

            // Assert
            Assert.IsTrue(data);
        }

        [Test]
        [Order(11)]
        public async Task DeleteAsync_AllSuccessfullyDeleted()
        {
            // Act
            var data = await _attachmentClient.DeleteAsync(DocumentId, AttachmentDocumentType.IssuedInvoice).AssertResult();

            // Assert
            Assert.IsTrue(data);
        }

        [Test]
        [Order(12)]
        public void UploadAsync_WithWrongFileName_ExceptionThrown()
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
    }
}
