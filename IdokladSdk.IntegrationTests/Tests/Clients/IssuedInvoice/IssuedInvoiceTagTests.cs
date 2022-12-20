using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Core.Tags;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;
using IdokladSdk.Requests.IssuedInvoice;
using IdokladSdk.Requests.IssuedInvoice.Filter;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.IssuedInvoice
{
    [TestFixture]
    public class IssuedInvoiceTagTests : TaggableDocumentTestsBase<IssuedInvoiceClient, IssuedInvoiceDetail, IssuedInvoiceList, IssuedInvoiceGetModel,
        IssuedInvoiceListGetModel, IssuedInvoicePostModel, IssuedInvoicePatchModel, IssuedInvoiceExpand, IssuedInvoiceFilter>
    {
        public const int IssuedInvoiceWithoutTagsId = 921653;

        public const int IssuedInvoiceWithTags1Id = 921555;

        public const int IssuedInvoiceWithTags2Id = 921556;

        protected override int EntityWithoutTagsId => IssuedInvoiceWithoutTagsId;

        protected override int EntityWithTags1Id => IssuedInvoiceWithTags1Id;

        protected override int EntityWithTags2Id => IssuedInvoiceWithTags2Id;

        [Test]
        public async Task Copy_SourceWithTags_CopiesTagsAsync()
        {
            // Act
            var result = await Client.CopyAsync(EntityWithTags1Id).AssertResult();

            // Assert
            AssertHasTagIds(result.Tags, new List<int> { Tag1Id, Tag2Id });
        }

        protected override void SetRequiredProperties(IssuedInvoicePostModel postModel)
        {
            postModel.Description = "Test issued invoice";
            postModel.PartnerId = PartnerId;
            postModel.Items.First().Name = "Item name";
        }
    }
}