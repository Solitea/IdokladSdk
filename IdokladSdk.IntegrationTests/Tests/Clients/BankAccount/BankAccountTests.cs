using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.BankAccount;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.BankAccount
{
    [TestFixture]
    public class BankAccountTests : TestBase
    {
        private int _newBankAccountId = 0;

        public BankAccountClient BankAccountClient { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            BankAccountClient = DokladApi.BankAccountClient;
        }

        [Test]
        [Order(1)]
        public async Task PostAsync_SuccessfullyPosted()
        {
            // Arrange
            var model = CreatePostModel();

            // Act
            var data = (await BankAccountClient.PostAsync(model)).AssertResult();
            _newBankAccountId = data.Id;

            // Assert
            Assert.That(data.Id, Is.GreaterThan(0));
            AssertData(model, data);
        }

        [Test]
        [Order(2)]
        public async Task GetDetailAsync_ReturnsDetail()
        {
            // Act
            var data = (await BankAccountClient.Detail(_newBankAccountId).Include(a => a.Bank).GetAsync()).AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(_newBankAccountId));
            Assert.That(data.Bank, Is.Not.Null);
            Assert.That(data.BankId, Is.EqualTo(data.Bank.Id));
        }

        [Test]
        [Order(3)]
        public async Task UpdateAsync_SuccessfullyUpdated()
        {
            // Arrange
            var model = CreatePatchModel();

            // Act
            var data = await BankAccountClient.UpdateAsync(model).AssertResult();

            // Assert
            AssertData(model, data);
        }

        [Test]
        [Order(4)]
        public async Task GetListAsync_ReturnsList()
        {
            // Act
            var data = (await BankAccountClient.List().Filter(a => a.CurrencyId.IsNotEqual(0)).GetAsync()).AssertResult();

            // Assert
            Assert.That(data.Items.Count(), Is.GreaterThan(0));
        }

        [Test]
        [Order(5)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = (await BankAccountClient.DeleteAsync(_newBankAccountId)).AssertResult();

            // Assert
            Assert.That(data, Is.True);
        }

        private void AssertData(BankAccountPatchModel patchModel, BankAccountGetModel getModel)
        {
            Assert.That(getModel.AccountNumber, Is.EqualTo(patchModel.AccountNumber));
            Assert.That(getModel.BankId, Is.EqualTo(patchModel.BankId.Value));
            Assert.That(getModel.CurrencyId, Is.EqualTo(patchModel.CurrencyId));
            Assert.That(getModel.Iban, Is.EqualTo(patchModel.Iban));
            Assert.That(getModel.Id, Is.EqualTo(patchModel.Id));
            Assert.That(getModel.Name, Is.EqualTo(patchModel.Name));
            Assert.That(getModel.Swift, Is.EqualTo(patchModel.Swift));
            Assert.That(getModel.Metadata, Is.Not.Null);
        }

        private void AssertData(BankAccountPostModel postModel, BankAccountGetModel getModel)
        {
            Assert.That(getModel.AccountNumber, Is.EqualTo(postModel.AccountNumber));
            Assert.That(getModel.BankId, Is.EqualTo(postModel.BankId));
            Assert.That(getModel.CurrencyId, Is.EqualTo(postModel.CurrencyId));
            Assert.That(getModel.Iban, Is.EqualTo(postModel.Iban));
            Assert.That(getModel.Name, Is.EqualTo(postModel.Name));
            Assert.That(getModel.IsDefault, Is.EqualTo(postModel.IsDefault));
            Assert.That(getModel.Swift, Is.EqualTo(postModel.Swift));
            Assert.That(getModel.Metadata, Is.Not.Null);
        }

        private BankAccountPatchModel CreatePatchModel()
        {
            return new BankAccountPatchModel
            {
                AccountNumber = string.Empty,
                BankId = 59,
                CurrencyId = 1,
                Iban = "SK3002000000003604642112",
                Id = _newBankAccountId,
                Name = "My updated bank account",
                Swift = "SUBASKBX"
            };
        }

        private BankAccountPostModel CreatePostModel()
        {
            return new BankAccountPostModel
            {
                AccountNumber = "27-7493690207",
                BankId = 7,
                CurrencyId = 1,
                Iban = "CZ9101000000277493690207",
                IsDefault = false,
                Name = "My new bank account",
                Swift = "KOMBCZPP"
            };
        }
    }
}
