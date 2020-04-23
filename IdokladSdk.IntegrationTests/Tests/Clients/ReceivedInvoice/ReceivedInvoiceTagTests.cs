using System.Collections.Generic;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Core.Tags;
using IdokladSdk.Models.ReceivedInvoice;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;
using IdokladSdk.Requests.ReceivedInvoice;
using IdokladSdk.Requests.ReceivedInvoice.Filter;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReceivedInvoice
{
    [TestFixture]
    public class ReceivedInvoiceTagTests : TaggableDocumentTestsBase<ReceivedInvoiceClient, ReceivedInvoiceDetail, ReceivedInvoiceList, ReceivedInvoiceGetModel,
        ReceivedInvoiceListGetModel, ReceivedInvoicePostModel, ReceivedInvoicePatchModel, ReceivedInvoiceExpand, ReceivedInvoiceFilter>
    {
        protected override int EntityWithoutTagsId => 167066;

        protected override int EntityWithTags1Id => 167064;

        protected override int EntityWithTags2Id => 167065;

        [Test]
        public void Copy_SourceWithTags_CopiesTags()
        {
            // Act
            var result = Client.Copy(EntityWithTags1Id).AssertResult();

            // Assert
            AssertHasTagIds(result.Tags, new List<int> { Tag1Id, Tag2Id });
        }

        protected override void SetRequiredProperties(ReceivedInvoicePostModel postModel)
        {
            postModel.Description = "Test received invoice";
            postModel.PartnerId = PartnerId;
            postModel.Items.Add(new ReceivedInvoiceItemPostModel
            {
                Name = "Test item",
                UnitPrice = 100
            });
        }
    }
}
