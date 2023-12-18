using System;
using System.Threading.Tasks;
using IdokladSdk.Clients.Readonly;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.ReadOnly;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly
{
    [TestFixture]
    public class CodeBooksChangesTests : TestBase
    {
        private static readonly object[] TestData =
        {
            new object[] { DateTime.MinValue, true },
            new object[] { DateTime.MaxValue, false }
        };

        private SystemClient _client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _client = DokladApi.SystemClient;
        }

        [TestCaseSource(nameof(TestData))]
        public async Task DetailAsync_SuccessfullyGet(DateTime lastCheck, bool expectedWasChanged)
        {
            // Act
            var data = await _client
                .CodeBooksChanges(lastCheck)
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
            AssertDetail(data, expectedWasChanged);
        }

        private void AssertDetail(CodeBooksChangesGetModel model, bool expectedWasChanged)
        {
            Assert.That(model.Country, Is.EqualTo(expectedWasChanged));
            Assert.That(model.Bank, Is.EqualTo(expectedWasChanged));
            Assert.That(model.ConstantSymbols, Is.EqualTo(expectedWasChanged));
            Assert.That(model.Currencies, Is.EqualTo(expectedWasChanged));
            Assert.That(model.ExchangeRates, Is.EqualTo(expectedWasChanged));
            Assert.That(model.PaymentOptions, Is.EqualTo(expectedWasChanged));
            Assert.That(model.VatCodes, Is.EqualTo(expectedWasChanged));
            Assert.That(model.VatRates, Is.EqualTo(expectedWasChanged));
            Assert.That(model.VatReverseChargeCodes, Is.EqualTo(expectedWasChanged));
        }
    }
}
