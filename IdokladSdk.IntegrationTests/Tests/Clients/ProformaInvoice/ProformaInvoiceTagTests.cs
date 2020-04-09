using System.Collections.Generic;
using System.Linq;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Core.Tags;
using IdokladSdk.Models.ProformaInvoice;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;
using IdokladSdk.Requests.ProformaInvoice;
using IdokladSdk.Requests.ProformaInvoice.Filter;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ProformaInvoice
{
    [TestFixture]
    public class ProformaInvoiceTagTests : TaggableDocumentTestsBase<ProformaInvoiceClient, ProformaInvoiceDetail, ProformaInvoiceList, ProformaInvoiceGetModel,
        ProformaInvoiceListGetModel, ProformaInvoicePostModel, ProformaInvoicePatchModel, ProformaInvoiceExpand, ProformaInvoiceFilter>
    {
        protected override int EntityWithoutTagsId => 921865;

        protected override int EntityWithTags1Id => 921853;

        protected override int EntityWithTags2Id => 921859;

        [Test]
        public void Account_ProformaWithTags_CopiesTags()
        {
            // Act
            var result = Client.GetInvoiceForAccount(EntityWithTags1Id).AssertResult();

            // Assert
            this.AssertHasTagIds(result.Tags, new List<int> { Tag1Id, Tag2Id });
        }

        [Test]
        public void Copy_SourceWithTags_CopiesTags()
        {
            // Act
            var result = Client.Copy(EntityWithTags1Id).AssertResult();

            // Assert
            this.AssertHasTagIds(result.Tags, new List<int> { Tag1Id, Tag2Id });
        }

        protected override void SetRequiredProperties(ProformaInvoicePostModel postModel)
        {
            postModel.Description = "Test proforma invoice";
            postModel.PartnerId = PartnerId;
            postModel.Items.First().Name = "Item name";
        }
    }
}
