using System.Linq;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.BankAccount;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.BankAccount
{
    [TestFixture]
    public partial class BankAccountTests : TestBase
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
        public void Post_SuccessfullyPosted()
        {
            // Arrange
            var model = CreatePostModel();

            // Act
            var data = BankAccountClient.Post(model).AssertResult();
            _newBankAccountId = data.Id;

            // Assert
            Assert.Greater(data.Id, 0);
            AssertData(model, data);
        }

        [Test]
        [Order(2)]
        public void GetDetail_ReturnsDetail()
        {
            // Act
            var data = BankAccountClient.Detail(_newBankAccountId).Include(a => a.Bank).Get().AssertResult();

            // Assert
            Assert.AreEqual(_newBankAccountId, data.Id);
            Assert.NotNull(data.Bank);
            Assert.AreEqual(data.Bank.Id, data.BankId);
        }

        [Test]
        [Order(3)]
        public void Update_SuccessfullyUpdated()
        {
            // Arrange
            var model = CreatePatchModel();

            // Act
            var data = BankAccountClient.Update(model).AssertResult();

            // Assert
            AssertData(model, data);
        }

        [Test]
        [Order(4)]
        public void GetList_ReturnsList()
        {
            // Act
            var data = BankAccountClient.List().Filter(a => a.CurrencyId.IsNotEqual(0)).Get().AssertResult();

            // Assert
            Assert.Greater(data.Items.Count(), 0);
        }

        [Test]
        [Order(5)]
        public void Delete_SuccessfullyDeleted()
        {
            // Act
            var data = BankAccountClient.Delete(_newBankAccountId).AssertResult();

            // Assert
            Assert.True(data);
        }

        private void AssertData(BankAccountPatchModel patchModel, BankAccountGetModel getModel)
        {
            Assert.AreEqual(patchModel.AccountNumber, getModel.AccountNumber);
            Assert.AreEqual(patchModel.BankId.Value, getModel.BankId);
            Assert.AreEqual(patchModel.CurrencyId, getModel.CurrencyId);
            Assert.AreEqual(patchModel.Iban, getModel.Iban);
            Assert.AreEqual(patchModel.Id, getModel.Id);
            Assert.AreEqual(patchModel.Name, getModel.Name);
            Assert.AreEqual(patchModel.Swift, getModel.Swift);
            Assert.NotNull(getModel.Metadata);
        }

        private void AssertData(BankAccountPostModel postModel,  BankAccountGetModel getModel)
        {
            Assert.AreEqual(postModel.AccountNumber, getModel.AccountNumber);
            Assert.AreEqual(postModel.BankId, getModel.BankId);
            Assert.AreEqual(postModel.CurrencyId, getModel.CurrencyId);
            Assert.AreEqual(postModel.Iban, getModel.Iban);
            Assert.AreEqual(postModel.Name, getModel.Name);
            Assert.AreEqual(postModel.IsDefault, getModel.IsDefault);
            Assert.AreEqual(postModel.Swift, getModel.Swift);
            Assert.NotNull(getModel.Metadata);
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
