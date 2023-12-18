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
            var data = await _client
                .CodeBooks()
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
            AssertDetail(data);
        }

        private void AssertDetail(CodeBooksGetModel model)
        {
            Assert.That(model.Banks, Is.Not.Null);
            Assert.That(model.Banks, Is.Not.Empty);
            AssertionsHelper.AssertDetail(model.Banks.First());
            Assert.That(model.ConstantSymbols, Is.Not.Null);
            Assert.That(model.ConstantSymbols, Is.Not.Empty);
            AssertionsHelper.AssertDetail(model.ConstantSymbols.First());
            Assert.That(model.Countries, Is.Not.Null);
            Assert.That(model.Countries, Is.Not.Empty);
            AssertionsHelper.AssertDetail(model.Countries.First());
            Assert.That(model.Currencies, Is.Not.Null);
            Assert.That(model.Currencies, Is.Not.Empty);
            AssertionsHelper.AssertDetail(model.Currencies.First());
            Assert.That(model.PaymentOptions, Is.Not.Null);
            Assert.That(model.PaymentOptions, Is.Not.Empty);
            AssertionsHelper.AssertDetail(model.PaymentOptions.First());
            Assert.That(model.VatCodes, Is.Not.Null);
            Assert.That(model.VatCodes, Is.Not.Empty);
            AssertionsHelper.AssertDetail(model.VatCodes.First());
            Assert.That(model.VatRates, Is.Not.Null);
            Assert.That(model.VatRates, Is.Not.Empty);
            AssertionsHelper.AssertDetail(model.VatRates.First());
            Assert.That(model.VatReverseChargeCodes, Is.Not.Null);
            Assert.That(model.VatReverseChargeCodes, Is.Not.Empty);
            AssertionsHelper.AssertDetail(model.VatReverseChargeCodes.First());
        }
    }
}
