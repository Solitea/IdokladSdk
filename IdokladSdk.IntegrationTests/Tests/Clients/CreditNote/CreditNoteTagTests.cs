using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Core.Tags;
using IdokladSdk.IntegrationTests.Tests.Clients.IssuedInvoice;
using IdokladSdk.Models.CreditNote;
using IdokladSdk.Models.CreditNote.Post;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;
using IdokladSdk.Requests.CreditNote;
using IdokladSdk.Requests.CreditNote.Filter;
using IdokladSdk.Response;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.CreditNote
{
    [TestFixture]
    public class CreditNoteTagTests : TaggableDocumentTestsBase<CreditNoteClient, CreditNoteDetail, CreditNoteList, CreditNoteGetModel,
        CreditNoteListGetModel, CreditNoteDefaultPostModel, CreditNotePatchModel, CreditNoteExpand, CreditNoteFilter>
    {
        protected override int EntityWithoutTagsId => 921789;

        protected override int EntityWithTags1Id => 921787;

        protected override int EntityWithTags2Id => 921788;

        [Test]
        public async Task Default_SourceWithTags_CopiesTags_BaseAsync()
        {
            // Act
            var result = await Client.DefaultAsync(IssuedInvoiceTagTests.IssuedInvoiceWithTags1Id).AssertResult();

            // Assert
            AssertHasTagIds(result.Tags, new List<int> { Tag1Id, Tag2Id });
        }

        protected override Task<ApiResult<CreditNoteDefaultPostModel>> DefaultAsync() => Client.DefaultAsync(IssuedInvoiceTagTests.IssuedInvoiceWithoutTagsId);

        protected override void SetRequiredProperties(CreditNoteDefaultPostModel postModel)
        {
            postModel.CreditNoteReason = "Some reason";
            postModel.Description = "Test credit note";
            postModel.PartnerId = PartnerId;
            postModel.Items.First().Name = "Item name";
        }
    }
}