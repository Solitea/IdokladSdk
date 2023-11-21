using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core.Tags;
using IdokladSdk.Models.CashVoucher;
using IdokladSdk.Requests.CashVoucher;
using IdokladSdk.Requests.CashVoucher.Filter;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;
using IdokladSdk.Response;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.CashVoucher
{
    [TestFixture]
    public class CashVoucherTagTests : TaggableDocumentTestsBase<CashVoucherClient, CashVoucherDetail, CashVoucherList, CashVoucherGetModel,
        CashVoucherListGetModel, CashVoucherDefaultGetModel, CashVoucherPostModel, CashVoucherPatchModel, CashVoucherExpand, CashVoucherFilter>
    {
        protected override int EntityWithoutTagsId => 588920;

        protected override int EntityWithTags1Id => 588918;

        protected override int EntityWithTags2Id => 588919;

        protected override Task<ApiResult<CashVoucherDefaultGetModel>> DefaultAsync() => Client.DefaultAsync(MovementType.Issue);

        protected override void SetRequiredProperties(CashVoucherPostModel postModel)
        {
            postModel.Name = "Test cash voucher";
            postModel.Items.First().Name = "Item name";
            postModel.Items.First().Price = 100;
        }
    }
}
