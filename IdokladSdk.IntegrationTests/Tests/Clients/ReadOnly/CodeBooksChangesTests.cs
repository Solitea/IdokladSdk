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
            var data = (await _client
                .CodeBooksChanges(lastCheck)
                .GetAsync())
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            AssertDetail(data, expectedWasChanged);
        }

        private void AssertDetail(CodeBooksChangesGetModel model, bool expectedWasChanged)
        {
            Assert.AreEqual(expectedWasChanged, model.Country);
            Assert.AreEqual(expectedWasChanged, model.Bank);
            Assert.AreEqual(expectedWasChanged, model.ConstantSymbols);
            Assert.AreEqual(expectedWasChanged, model.Currencies);
            Assert.AreEqual(expectedWasChanged, model.ExchangeRates);
            Assert.AreEqual(expectedWasChanged, model.PaymentOptions);
            Assert.AreEqual(expectedWasChanged, model.VatCodes);
            Assert.AreEqual(expectedWasChanged, model.VatRates);
            Assert.AreEqual(expectedWasChanged, model.VatReverseChargeCodes);
        }
    }
}
