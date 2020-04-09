using System.Collections.Generic;
using System.Linq;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Core.Tags;
using IdokladSdk.IntegrationTests.Tests.Clients.IssuedInvoice;
using IdokladSdk.Models.CreditNote;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;
using IdokladSdk.Requests.CreditNote;
using IdokladSdk.Requests.CreditNote.Filter;
using IdokladSdk.Response;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.CreditNote
{
    [TestFixture]
    public class CreditNoteTagTests : TaggableDocumentTestsBase<CreditNoteClient, CreditNoteDetail, CreditNoteList, CreditNoteGetModel,
        CreditNoteListGetModel, CreditNotePostModel, CreditNotePatchModel, CreditNoteExpand, CreditNoteFilter>
    {
        protected override int EntityWithoutTagsId => 921789;

        protected override int EntityWithTags1Id => 921787;

        protected override int EntityWithTags2Id => 921788;

        [Test]
        public void Default_SourceWithTags_CopiesTags_Base()
        {
            // Act
            var result = Client.Default(IssuedInvoiceTagTests.IssuedInvoiceWithTags1Id).AssertResult();

            // Assert
            this.AssertHasTagIds(result.Tags, new List<int> { Tag1Id, Tag2Id });
        }

        protected override ApiResult<CreditNotePostModel> Default() => Client.Default(IssuedInvoiceTagTests.IssuedInvoiceWithoutTagsId);

        protected override void SetRequiredProperties(CreditNotePostModel postModel)
        {
            postModel.CreditNoteReason = "Some reason";
            postModel.Description = "Test credit note";
            postModel.PartnerId = PartnerId;
            postModel.Items.First().Name = "Item name";
        }
    }
}
