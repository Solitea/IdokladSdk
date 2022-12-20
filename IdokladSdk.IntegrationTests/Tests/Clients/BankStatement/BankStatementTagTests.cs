using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core.Tags;
using IdokladSdk.Models.BankStatement;
using IdokladSdk.Requests.BankStatement;
using IdokladSdk.Requests.BankStatement.Filter;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.BankStatement
{
    [TestFixture]
    public class BankStatementTagTests : TaggableDocumentGetTestsBase<BankStatementClient, BankStatementDetail, BankStatementList, BankStatementGetModel,
        BankStatementListGetModel, BankStatementExpand, BankStatementFilter>
    {
        protected override int EntityWithoutTagsId => 991871;

        protected override int EntityWithTags1Id => 991869;

        protected override int EntityWithTags2Id => 991870;
    }
}