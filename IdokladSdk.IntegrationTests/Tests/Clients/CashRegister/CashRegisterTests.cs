using System.Linq;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.CashRegister
{
    public partial class CashRegisterTests : TestBase
    {
        private const int CashRegisterId = 173503;
        private CashRegisterClient _cashRegisterClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _cashRegisterClient = DokladApi.CashRegisterClient;
        }

        [Test]
        public void List_SuccessfullyGetList()
        {
            // Act
            var data = _cashRegisterClient.List().Filter(f => f.CurrencyId.IsNotEqual(0)).Get().AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
            var cashRegister = data.Items.FirstOrDefault();
            Assert.NotNull(cashRegister);
            Assert.AreEqual(CashRegisterId, cashRegister.Id);
            Assert.AreEqual("Hlavní pokladna", cashRegister.Name);
        }

        [Test]
        public void Detail_SuccessfullyGetDetail()
        {
            // Act
            var data = _cashRegisterClient.Detail(CashRegisterId).Include(c => c.Currency).Get().AssertResult();

            // Assert
            Assert.AreEqual(CashRegisterId, data.Id);
            Assert.AreEqual("Hlavní pokladna", data.Name);
            Assert.NotNull(data.Currency);
            Assert.AreEqual(data.CurrencyId, data.Currency.Id);
        }
    }
}
