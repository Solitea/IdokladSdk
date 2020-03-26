using System;
using System.Threading.Tasks;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly
{
    [TestFixture]
    public partial class CodeBooksChangesTests : TestBase
    {
        [TestCaseSource(nameof(TestData))]
        public async Task DetailAsync_SuccessfullyGet(DateTime lastCheck, bool expectedWasChanged)
        {
            // Act
            var data = (await _client
                .CodeBooksChanges(lastCheck)
                .GetAsync())
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            AssertDetail(data, expectedWasChanged);
        }
    }
}
