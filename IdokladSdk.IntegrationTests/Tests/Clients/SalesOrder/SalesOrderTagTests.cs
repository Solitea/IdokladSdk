using System.Linq;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core.Tags;
using IdokladSdk.Models.SalesOrder;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;
using IdokladSdk.Requests.SalesOrder;
using IdokladSdk.Requests.SalesOrder.Filter;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.SalesOrder
{
    [TestFixture]
    public class SalesOrderTagTests : TaggableDocumentTestsBase<SalesOrderClient, SalesOrderDetail, SalesOrderList, SalesOrderGetModel,
        SalesOrderListGetModel, SalesOrderPostModel, SalesOrderPatchModel, SalesOrderExpand, SalesOrderFilter>
    {
        protected override int EntityWithoutTagsId => 2300;

        protected override int EntityWithTags1Id => 2298;

        protected override int EntityWithTags2Id => 2299;

        protected override void SetRequiredProperties(SalesOrderPostModel postModel)
        {
            postModel.Description = "Test sales order";
            postModel.PartnerId = PartnerId;
            postModel.Items.First().Name = "Item name";
        }
    }
}