using System.Linq;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core.Tags;
using IdokladSdk.Models.SalesReceipt;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;
using IdokladSdk.Requests.SalesReceipt;
using IdokladSdk.Requests.SalesReceipt.Filter;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.SalesReceipt
{
    [TestFixture]
    public class SalesReceiptTagTests : TaggableDocumentTestsBase<SalesReceiptClient, SalesReceiptDetail, SalesReceiptList, SalesReceiptGetModel,
        SalesReceiptListGetModel, SalesReceiptPostModel, SalesReceiptPatchModel, SalesReceiptExpand, SalesReceiptFilter>
    {
        protected override int EntityWithoutTagsId => 226484;

        protected override int EntityWithTags1Id => 226482;

        protected override int EntityWithTags2Id => 226483;

        protected override void SetRequiredProperties(SalesReceiptPostModel postModel)
        {
            postModel.Name = "Test sales receipt";
            postModel.Items.First().Name = "Item name";
        }
    }
}
