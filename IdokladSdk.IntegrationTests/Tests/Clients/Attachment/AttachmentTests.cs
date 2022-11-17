using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.Attachment;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Attachment;

[TestFixture]
public class AttachmentTests : TestBase
{
    private const string FileName = "reportnew.pdf";
    private const int DocumentId = 913242;
    private const string AttachmentPath = "Tests/Clients/Attachment/File/report.pdf";
    private AttachmentClient _attachmentClient;
namespace IdokladSdk.IntegrationTests.Tests.Clients.Attachment
{
    [TestFixture]
    public partial class AttachmentTests : TestBase
    {
        private const string FileName = "reportnew.pdf";
        private const int DocumentId = 913242;
        private const string AttachmentPath = "Tests/Clients/Attachment/File/report.pdf";
        private int _attachmentId = 0;
        private string _attachmentName = string.Empty;
        private AttachmentClient _attachmentClient;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        InitDokladApi();
        _attachmentClient = DokladApi.AttachmentClient;
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
            var data1 = _attachmentClient.Upload(model1).AssertResult();
            var data2 = _attachmentClient.Upload(model2).AssertResult();
            var data3 = _attachmentClient.Upload(model3).AssertResult();

            // Assert
            Assert.IsTrue(data1);
            Assert.IsTrue(data2);
            Assert.IsTrue(data3);
        }

    [Test]
    [Order(2)]
    public async Task GetAsync_SuccessfullyGetAttachment()
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
                    Assert.That(attachment.FileName, Is.Not.Null.Or.Empty);
                });
            });

            var attachment = data.FirstOrDefault();
            _attachmentId = attachment.Id;
            _attachmentName = attachment.FileName;
        }

        [Test]
        [Order(3)]
        public void Get_SuccessfullyGetAttachment()
        {
            // Act
            var data = _attachmentClient.Get(_attachmentId).AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.NotNull(data.FileBytes);
            Assert.AreEqual(_attachmentName, data.FileName);
        }

        [Test]
        [Order(4)]
        public void Delete_SuccessfullyDeleted()
        {
            // Act
            var data = _attachmentClient.Delete(_attachmentId).AssertResult();

            // Assert
            Assert.IsTrue(data);
        }

        [Test]
        [Order(5)]
        public void Delete_AllSuccessfullyDeleted()
        {
            // Act
            var data = _attachmentClient.Delete(DocumentId, AttachmentDocumentType.IssuedInvoice).AssertResult();

        // Assert
        Assert.IsTrue(data);
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

        TestDelegate action = async () => await _attachmentClient.UploadAsync(model).AssertResult();

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
                DocumentId = DocumentId
            };
        }
    }
}
