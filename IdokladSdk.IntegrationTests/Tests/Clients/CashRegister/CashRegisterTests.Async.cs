using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.CashRegister
{
    public partial class CashRegisterTests
    {
        [Test]
        public async Task ListAsync_SuccessfullyGetList()
        {
            // Act
            var data = (await _cashRegisterClient.List().GetAsync()).AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
            var cashRegister = data.Items.FirstOrDefault();
            Assert.NotNull(cashRegister);
            Assert.AreEqual(CashRegisterId, cashRegister.Id);
            Assert.AreEqual("Hlavní pokladna", cashRegister.Name);
        }

        [Test]
        public async Task DetailAsync_SuccessfullyGetDetail()
        {
            // Act
            var data = (await _cashRegisterClient.Detail(CashRegisterId).Include(c => c.Currency).GetAsync()).AssertResult();

            // Assert
            Assert.AreEqual(CashRegisterId, data.Id);
            Assert.AreEqual("Hlavní pokladna", data.Name);
            Assert.NotNull(data.Currency);
            Assert.AreEqual(data.CurrencyId, data.Currency.Id);
        }
    }
}
