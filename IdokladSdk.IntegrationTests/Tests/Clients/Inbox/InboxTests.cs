using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.Inbox.Get;
using IdokladSdk.Models.Inbox.Post;
using IdokladSdk.Response;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Inbox
{
    [TestFixture]
    public class InboxTests : TestBase
    {
        private const string AttachmentPath = "Tests/Clients/Attachment/File/report.pdf";
        private const int NonExistingInboxItemId = int.MaxValue;
        private InboxClient _inboxClient;
        private ReceivedInvoiceClient _receivedInvoiceClient;
        private int _firstInboxItemId;
        private int _secondInboxItemId;
        private int _receivedInvoiceId;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _inboxClient = DokladApi.InboxClient;
            _receivedInvoiceClient = DokladApi.ReceivedInvoiceClient;
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await DeleteIfExistsAsync(_firstInboxItemId);
            await DeleteIfExistsAsync(_secondInboxItemId);
        }

        [Test]
        [Order(1)]
        public async Task RegisterAsync_SuccessfullyReturned()
        {
            // Act
            var data = await _inboxClient.RegisterAsync().AssertResult();

            // Assert
            Assert.That(data.InboxEmail, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        [Order(2)]
        public async Task PostAsync_SuccessfullyPosted()
        {
            // Arrange
            var model = CreatePostModel();

            // Act
            var data = await _inboxClient.PostAsync(model).AssertResult();
            var inboxItem = data.Single();
            _firstInboxItemId = inboxItem.Id;

            // Assert
            Assert.That(data, Has.Count.EqualTo(1));
            Assert.That(inboxItem.Id, Is.GreaterThan(0));
            Assert.That(inboxItem.Attachment, Is.Not.Null);
            Assert.That(inboxItem.Attachment.FileOriginalName, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        [Order(3)]
        public async Task ListAsync_FilterById_SuccessfullyReturned()
        {
            Assume.That(_firstInboxItemId, Is.GreaterThan(0), "Inbox item was not created.");

            // Act
            var data = await _inboxClient.List()
                .Filter(item => item.Id.IsEqual(_firstInboxItemId))
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.Items.Any(item => item.Id == _firstInboxItemId), Is.True);
        }

        [Test]
        [Order(4)]
        public async Task DetailAsync_SuccessfullyReturned()
        {
            Assume.That(_firstInboxItemId, Is.GreaterThan(0), "Inbox item was not created.");
            ApiResult<InboxDetailGetModel> detailResult = null;

            // Act
            Assert.That(
                async () =>
                {
                    detailResult = await _inboxClient.Detail(_firstInboxItemId).GetAsync();
                    return detailResult.IsSuccess;
                },
                Is.True.After(1).Minutes.PollEvery(10).Seconds);

            var data = detailResult.Data;

            // Assert
            Assert.That(data.Id, Is.EqualTo(_firstInboxItemId));
            Assert.That(data.Attachment, Is.Not.Null);
            Assert.That(data.Attachment.AttachmentId, Is.GreaterThan(0));
            Assert.That(data.Attachment.AttachmentFileOriginalName, Is.Not.Null.And.Not.Empty);
            Assert.That(data.Attachment.StorageType, Is.EqualTo(AttachmentStorageType.Inbox));
        }

        [Test]
        [Order(5)]
        public async Task AttachDocumentAsync_SdkDocument_SuccessfullyAttached()
        {
            Assume.That(_firstInboxItemId, Is.GreaterThan(0), "Inbox item was not created.");

            // Arrange
            _receivedInvoiceId = await ResolveExistingReceivedInvoiceIdAsync();
            await WaitForInboxItemReadyForAttachAsync(_firstInboxItemId);
            var model = new InboxAttachDocumentPostModel
            {
                Id = _firstInboxItemId,
                DocumentId = _receivedInvoiceId,
                DocumentType = InboxAttachmentDocumentType.ReceivedInvoice
            };

            // Act
            var data = await _inboxClient.AttachDocumentAsync(model).AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(_firstInboxItemId));
            Assert.That(data.ProcessedDocument, Is.Not.Null);
            Assert.That(data.ProcessedDocument.DocumentId, Is.EqualTo(_receivedInvoiceId));
            Assert.That(data.ProcessedDocument.DocumentType, Is.EqualTo(InboxAttachmentDocumentType.ReceivedInvoice));
        }

        [Test]
        [Order(6)]
        public async Task DetachDocumentAsync_SdkDocument_SuccessfullyDetached()
        {
            Assume.That(_firstInboxItemId, Is.GreaterThan(0), "Inbox item was not created.");
            Assume.That(_receivedInvoiceId, Is.GreaterThan(0), "Received invoice was not created.");

            // Arrange
            var model = new InboxDetachDocumentPostModel { Id = _firstInboxItemId };

            // Act
            var data = await _inboxClient.DetachDocumentAsync(model).AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(_firstInboxItemId));
            Assert.That(data.ProcessedDocument == null || data.ProcessedDocument.DocumentId == 0, Is.True);
        }

        [Test]
        [Order(7)]
        public async Task AttachDocumentAsync_NonExistingInboxItem_Fails()
        {
            // Arrange
            var model = new InboxAttachDocumentPostModel
            {
                Id = NonExistingInboxItemId,
                DocumentId = 1,
                DocumentType = InboxAttachmentDocumentType.ReceivedInvoice
            };

            // Act
            var result = await _inboxClient.AttachDocumentAsync(model);

            // Assert
            AssertFailedResult(result);
        }

        [Test]
        [Order(8)]
        public async Task DetachDocumentAsync_NonExistingInboxItem_Fails()
        {
            // Arrange
            var model = new InboxDetachDocumentPostModel { Id = NonExistingInboxItemId };

            // Act
            var result = await _inboxClient.DetachDocumentAsync(model);

            // Assert
            AssertFailedResult(result);
        }

        [Test]
        [Order(9)]
        public async Task RequestAiReviewAsync_NonExistingInboxItem_Fails()
        {
            // Arrange
            var model = new InboxAIReviewPostModel { Id = NonExistingInboxItemId };

            // Act
            var result = await _inboxClient.RequestAiReviewAsync(model);

            // Assert
            AssertFailedResult(result);
        }

        [Test]
        [Order(10)]
        public async Task DeleteAsync_WithDeleteAttachmentParameter_SuccessfullyDeleted()
        {
            Assume.That(_firstInboxItemId, Is.GreaterThan(0), "Inbox item was not created.");

            // Act
            var data = await _inboxClient.DeleteAsync(_firstInboxItemId, true).AssertResult();
            _firstInboxItemId = 0;

            // Assert
            Assert.That(data, Is.True);
        }

        [Test]
        [Order(11)]
        public async Task PostAsync_ItemForDefaultDelete_SuccessfullyPosted()
        {
            // Arrange
            var model = CreatePostModel();

            // Act
            var data = await _inboxClient.PostAsync(model).AssertResult();
            _secondInboxItemId = data.Single().Id;

            // Assert
            Assert.That(_secondInboxItemId, Is.GreaterThan(0));
        }

        [Test]
        [Order(12)]
        public async Task DeleteAsync_DefaultOverload_SuccessfullyDeleted()
        {
            Assume.That(_secondInboxItemId, Is.GreaterThan(0), "Inbox item was not created.");
            ApiResult<bool> deleteResult = null;

            // Act & Assert
            Assert.That(
                async () =>
                {
                    deleteResult = await _inboxClient.DeleteAsync(_secondInboxItemId);
                    return deleteResult.IsSuccess;
                },
                Is.True.After(1).Minutes.PollEvery(10).Seconds);
            _secondInboxItemId = 0;
        }

        private static void AssertFailedResult(ApiResult result)
        {
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.StatusCode, Is.Not.EqualTo(HttpStatusCode.OK));
            Assert.That(result.Message, Is.Not.Null.And.Not.Empty);
        }

        private static InboxPostModel CreatePostModel()
        {
            return new InboxPostModel
            {
                Attachments =
                [
                    new InboxAttachmentPostModel
                    {
                        Data = Convert.ToBase64String(
                            File.ReadAllBytes($"{TestContext.CurrentContext.TestDirectory}/{AttachmentPath}")),
                        FileName = $"inbox-test-{Guid.NewGuid():N}.pdf"
                    },
                ]
            };
        }

        private async Task DeleteIfExistsAsync(int inboxItemId)
        {
            if (inboxItemId <= 0)
            {
                return;
            }

            var result = await _inboxClient.DeleteAsync(inboxItemId, true);
            if (!result.IsSuccess && result.StatusCode != HttpStatusCode.NotFound)
            {
                Assert.Fail($"Failed to cleanup inbox item '{inboxItemId}'. {result.Message}");
            }
        }

        private async Task<int> ResolveExistingReceivedInvoiceIdAsync()
        {
            var list = await _receivedInvoiceClient.List().GetAsync().AssertResult();
            Assert.That(list.TotalItems, Is.GreaterThan(0), "No existing received invoices found for attach test.");

            return list.Items.First().Id;
        }

        private async Task WaitForInboxItemReadyForAttachAsync(int inboxItemId)
        {
            Assert.That(
                async () =>
                {
                    var detailResult = await _inboxClient.Detail(inboxItemId).GetAsync();
                    return detailResult.IsSuccess
                           && detailResult.StatusCode == HttpStatusCode.OK
                           && detailResult.Data != null
                           && detailResult.Data.Status != InboxAttachmentStatus.InSeyforInboxProcessing;
                },
                Is.True.After(1).Minutes.PollEvery(10).Seconds,
                $"Inbox item '{inboxItemId}' was not ready for attach.");
        }
    }
}
