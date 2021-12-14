using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.BankAccount
{
    public partial class BankAccountTests
    {
        [Test]
        [Order(6)]
        public async Task PostAsync_SuccessfullyPosted()
        {
            // Arrange
            var model = CreatePostModel();

            // Act
            var data = (await BankAccountClient.PostAsync(model)).AssertResult();
            _newBankAccountId = data.Id;

            // Assert
            Assert.Greater(data.Id, 0);
            AssertData(model, data);
        }

        [Test]
        [Order(7)]
        public async Task GetDetailAsync_ReturnsDetail()
        {
            // Act
            var data = (await BankAccountClient.Detail(_newBankAccountId).Include(a => a.Bank).GetAsync()).AssertResult();

            // Assert
            Assert.AreEqual(_newBankAccountId, data.Id);
            Assert.NotNull(data.Bank);
            Assert.AreEqual(data.Bank.Id, data.BankId);
        }

        [Test]
        [Order(8)]
        public async Task UpdateAsync_SuccessfullyUpdated()
        {
            // Arrange
            var model = CreatePatchModel();

            // Act
            var data = (await BankAccountClient.UpdateAsync(model)).AssertResult();

            // Assert
            AssertData(model, data);
        }

        [Test]
        [Order(9)]
        public async Task GetListAsync_ReturnsList()
        {
            // Act
            var data = (await BankAccountClient.List().Filter(a => a.CurrencyId.IsNotEqual(0)).GetAsync()).AssertResult();

            // Assert
            Assert.Greater(data.Items.Count(), 0);
        }

        [Test]
        [Order(10)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = (await BankAccountClient.DeleteAsync(_newBankAccountId)).AssertResult();

            // Assert
            Assert.True(data);
        }
    }
}
