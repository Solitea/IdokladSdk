using System.Threading.Tasks;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly
{
    [TestFixture]
    public partial class CodeBooksTests : TestBase
    {
        [Test]
        public async Task DetailAsync_SuccessfullyGet()
        {
            // Act
            var data = (await _client
                .CodeBooks()
                .GetAsync())
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            AssertDetail(data);
        }
    }
}
