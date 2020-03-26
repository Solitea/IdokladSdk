using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.CreditNote;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.CreditNote
{
    /// <summary>
    /// CreditNoteTestsAsync.
    /// </summary>
    public partial class CreditNoteTests
    {
        [Test]
        [Order(10)]
        public async Task DefaultAsync_SuccessfullyReturned()
        {
            // Act
            _creditNotePostModel = (await CreditNoteClient.DefaultAsync(CreditedIssuedInvoiceId)).AssertResult();

            // Assert
            AssertDefault(_creditNotePostModel);
        }

        [Test]
        [Order(11)]
        public async Task PostAsync_SuccessfullyPosted()
        {
            // Arrange
            CreatePostModel(_creditNotePostModel);

            // Act
            var creditNoteGetModel = (await CreditNoteClient.PostAsync(_creditNotePostModel)).AssertResult();
            _postedCreditNoteId = creditNoteGetModel.Id;

            // Assert
            ComparePostAndGetModels(_creditNotePostModel, creditNoteGetModel, false);
            ComparePostAndGetItems(_creditNotePostModel.Items, creditNoteGetModel.Items.Cast<CreditNoteItemListGetModel>().ToList());
        }

        [Test]
        [Order(12)]
        public async Task GetDetailAsync_ReturnsCreditNote()
        {
            // Act
            var creditNoteGetModel = (await CreditNoteClient.Detail(_postedCreditNoteId).GetAsync()).AssertResult();

            // Assert
            Assert.AreEqual(_postedCreditNoteId, creditNoteGetModel.Id);
            ComparePostAndGetModels(_creditNotePostModel, creditNoteGetModel, false);
            ComparePostAndGetItems(_creditNotePostModel.Items, creditNoteGetModel.Items.Cast<CreditNoteItemListGetModel>().ToList());
        }

        [Test]
        [Order(13)]
        public async Task GetListAsync_ReturnsCreditNotes()
        {
            // Act
            var data = (await CreditNoteClient
                .List()
                .Filter(c => c.Id.IsEqual(_postedCreditNoteId))
                .GetAsync())
                .AssertResult();

            // Assert
            Assert.NotNull(data.Items);
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.TotalPages, 0);
            var firstItem = data.Items.First();
            ComparePostAndGetModels(_creditNotePostModel, firstItem, false);
            ComparePostAndGetItems(_creditNotePostModel.Items, firstItem.Items);
        }

        [Test]
        [Order(14)]
        public async Task UpdateAsync_SuccessfullyUpdatedCreditNote()
        {
            // Arrange
            var creditNotePatchModel = CreatePatchModel();

            // Act
            var creditNoteGetModel = (await CreditNoteClient.UpdateAsync(creditNotePatchModel)).AssertResult();

            // Assert
            Assert.AreEqual(creditNotePatchModel.Id, creditNoteGetModel.Id);
            ComparePatchAndGetModels(creditNotePatchModel, creditNoteGetModel);
        }

        [Test]
        [Order(15)]
        public async Task RecountAsync_SuccessfullyRecounted()
        {
            // Arrange
            var creditNoteRecountPostModel = CreateRecountPostModel();

            // Act
            var creditNoteRecountGetModel = (await CreditNoteClient.RecountAsync(creditNoteRecountPostModel)).AssertResult();

            // Assert
            ComparePostAndGetRecountModels(creditNoteRecountPostModel, creditNoteRecountGetModel);
        }

        [Test]
        [Order(16)]
        public async Task OffsetNewCreditNoteAsync_SuccessfullyOffset()
        {
            // Arrange
            var result = (await IssuedDocumentPaymentClient.FullyUnpayAsync(CreditedIssuedInvoiceId)).AssertResult();
            Assert.True(result);
            _creditNoteToOffsetPostModel = (await CreditNoteClient.DefaultAsync(CreditedIssuedInvoiceId)).AssertResult();
            CreatePostModel(_creditNoteToOffsetPostModel);

            // Act
            var offsetCreditNote = (await CreditNoteClient.OffsetAsync(_creditNoteToOffsetPostModel)).AssertResult();
            _offsetCreditNoteId = offsetCreditNote.Id;

            // Assert
            Assert.AreEqual(_offsetCreditNoteId, offsetCreditNote.Id);
            ComparePostAndGetModels(_creditNoteToOffsetPostModel, offsetCreditNote, true);
            ComparePostAndGetItems(_creditNoteToOffsetPostModel.Items, offsetCreditNote.Items.Cast<CreditNoteItemListGetModel>().ToList());
            Assert.IsNotNull(offsetCreditNote.DateOfPayment);
        }

        [Test]
        [Order(17)]
        public async Task OffsetExistingCreditNoteAsync_SuccessfullyOffset()
        {
            // Arrange
            var result = (await IssuedDocumentPaymentClient.FullyUnpayAsync(CreditedIssuedInvoiceId)).AssertResult();
            Assert.True(result);
            result = (await IssuedDocumentPaymentClient.FullyUnpayAsync(_offsetCreditNoteId)).AssertResult();
            Assert.True(result);

            // Act
            var offsetCreditNote = (await CreditNoteClient.OffsetAsync(_offsetCreditNoteId)).AssertResult();

            // Assert
            Assert.AreEqual(_offsetCreditNoteId, offsetCreditNote.Id);
            ComparePostAndGetModels(_creditNoteToOffsetPostModel, offsetCreditNote, true);
            ComparePostAndGetItems(_creditNoteToOffsetPostModel.Items, offsetCreditNote.Items.Cast<CreditNoteItemListGetModel>().ToList());
            Assert.IsNotNull(offsetCreditNote.DateOfPayment);
        }

        [Test]
        [Order(18)]
        public async Task DeleteAsync_SuccessfullyDeletedCreditNote()
        {
            // Act
            var result1 = (await CreditNoteClient.DeleteAsync(_postedCreditNoteId)).AssertResult();
            var result2 = (await CreditNoteClient.DeleteAsync(_offsetCreditNoteId)).AssertResult();

            // Assert
            Assert.True(result1);
            Assert.True(result2);
        }
    }
}
