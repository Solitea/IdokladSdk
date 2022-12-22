using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients.Readonly;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Common;
using IdokladSdk.Models.ReadOnly;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly
{
    [TestFixture]
    public class CodeBooksTests : TestBase
    {
        private SystemClient _client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _client = DokladApi.SystemClient;
        }

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

        private void AssertDetail(CodeBooksGetModel model)
        {
            Assert.NotNull(model.Banks);
            Assert.IsNotEmpty(model.Banks);
            AssertionsHelper.AssertDetail(model.Banks.First());
            Assert.NotNull(model.ConstantSymbols);
            Assert.IsNotEmpty(model.ConstantSymbols);
            AssertionsHelper.AssertDetail(model.ConstantSymbols.First());
            Assert.NotNull(model.Countries);
            Assert.IsNotEmpty(model.Countries);
            AssertionsHelper.AssertDetail(model.Countries.First());
            Assert.NotNull(model.Currencies);
            Assert.IsNotEmpty(model.Currencies);
            AssertionsHelper.AssertDetail(model.Currencies.First());
            Assert.NotNull(model.PaymentOptions);
            Assert.IsNotEmpty(model.PaymentOptions);
            AssertionsHelper.AssertDetail(model.PaymentOptions.First());
            Assert.NotNull(model.VatCodes);
            Assert.IsNotEmpty(model.VatCodes);
            AssertionsHelper.AssertDetail(model.VatCodes.First());
            Assert.NotNull(model.VatRates);
            Assert.IsNotEmpty(model.VatRates);
            AssertionsHelper.AssertDetail(model.VatRates.First());
            Assert.NotNull(model.VatReverseChargeCodes);
            Assert.IsNotEmpty(model.VatReverseChargeCodes);
            AssertionsHelper.AssertDetail(model.VatReverseChargeCodes.First());
        }
    }
}