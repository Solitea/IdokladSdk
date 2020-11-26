using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.CashRegister
{
    public partial class CashRegisterTests
    {
        [Test]
        [Order(6)]
        public async Task PostAsync_SuccessfullyPosted()
        {
            // Arrange
            var model = CreatePostModel();

            // Act
            var data = (await _cashRegisterClient.PostAsync(model)).AssertResult();
            _newCashRegisterId = data.Id;

            // Assert
            Assert.Greater(data.Id, 0);
            AssertData(model, data);
        }

        [Test]
        [Order(7)]
        public async Task DetailAsync_SuccessfullyGetDetail()
        {
            // Act
            var data = (await _cashRegisterClient.Detail(_newCashRegisterId).Include(c => c.Currency).GetAsync()).AssertResult();

            // Assert
            Assert.AreEqual(_newCashRegisterId, data.Id);
            Assert.IsNotEmpty(data.Name);
            Assert.NotNull(data.Currency);
            Assert.AreEqual(data.CurrencyId, data.Currency.Id);
        }

        [Test]
        [Order(8)]
        public async Task UpdateAsync_SuccessfullyUpdated()
        {
            var model = CreatePatchModel();

            // Act
            var data = (await _cashRegisterClient.UpdateAsync(model)).AssertResult();

            // Assert
            AssertData(model, data);
        }

        [Test]
        [Order(9)]
        public async Task ListAsync_SuccessfullyGetList()
        {
            // Act
            var data = (await _cashRegisterClient.List().GetAsync()).AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
            var cashRegister = data.Items.FirstOrDefault(c => c.Id == _newCashRegisterId);
            Assert.NotNull(cashRegister);
            Assert.IsNotEmpty(cashRegister.Name);
        }

        [Test]
        [Order(10)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = (await _cashRegisterClient.DeleteAsync(_newCashRegisterId)).AssertResult();

            // Assert
            Assert.True(data);
        }
    }
}
