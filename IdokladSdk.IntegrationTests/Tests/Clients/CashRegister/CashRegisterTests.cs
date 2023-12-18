using System;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.CashRegister;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.CashRegister
{
    public class CashRegisterTests : TestBase
    {
        private int _newCashRegisterId = 0;
        private CashRegisterClient _cashRegisterClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _cashRegisterClient = DokladApi.CashRegisterClient;
        }

        [Test]
        [Order(1)]
        public async Task PostAsync_SuccessfullyPosted()
        {
            // Arrange
            var model = CreatePostModel();

            // Act
            var data = await _cashRegisterClient.PostAsync(model).AssertResult();
            _newCashRegisterId = data.Id;

            // Assert
            Assert.That(data.Id, Is.Not.EqualTo(0));
            AssertData(model, data);
        }

        [Test]
        [Order(2)]
        public async Task DetailAsync_SuccessfullyGetDetail()
        {
            // Act
            var data = await _cashRegisterClient.Detail(_newCashRegisterId).Include(c => c.Currency).GetAsync().AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(_newCashRegisterId));
            Assert.That(data.Name, Is.Not.Empty);
            Assert.That(data.Currency, Is.Not.Null);
            Assert.That(data.Currency.Id, Is.EqualTo(data.CurrencyId));
        }

        [Test]
        [Order(3)]
        public async Task UpdateAsync_SuccessfullyUpdated()
        {
            var model = CreatePatchModel();

            // Act
            var data = await _cashRegisterClient.UpdateAsync(model).AssertResult();

            // Assert
            AssertData(model, data);
        }

        [Test]
        [Order(4)]
        public async Task ListAsync_SuccessfullyGetList()
        {
            // Act
            var data = await _cashRegisterClient.List().GetAsync().AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            var cashRegister = data.Items.FirstOrDefault(c => c.Id == _newCashRegisterId);
            Assert.That(cashRegister, Is.Not.Null);
            Assert.That(cashRegister.Name, Is.Not.Empty);
        }

        [Test]
        [Order(5)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = await _cashRegisterClient.DeleteAsync(_newCashRegisterId).AssertResult();

            // Assert
            Assert.That(data, Is.True);
        }

        private void AssertData(CashRegisterPatchModel patchModel, CashRegisterGetModel getModel)
        {
            Assert.That(getModel.CurrencyId, Is.EqualTo(patchModel.CurrencyId));
            Assert.That(getModel.DateInitialState, Is.EqualTo(patchModel.DateInitialState.Value));
            Assert.That(getModel.Id, Is.EqualTo(patchModel.Id));
            Assert.That(getModel.InitialState, Is.EqualTo(patchModel.InitialState.Value));
            Assert.That(getModel.IsDefault, Is.EqualTo(patchModel.IsDefault));
            Assert.That(getModel.Name, Is.EqualTo(patchModel.Name));
        }

        private void AssertData(CashRegisterPostModel postModel, CashRegisterGetModel getModel)
        {
            Assert.That(getModel.CurrencyId, Is.EqualTo(postModel.CurrencyId));
            Assert.That(getModel.DateInitialState, Is.EqualTo(postModel.DateInitialState));
            Assert.That(getModel.InitialState, Is.EqualTo(postModel.InitialState));
            Assert.That(getModel.IsDefault, Is.EqualTo(postModel.IsDefault));
            Assert.That(getModel.Name, Is.EqualTo(postModel.Name));
        }

        private CashRegisterPatchModel CreatePatchModel()
        {
            return new CashRegisterPatchModel()
            {
                CurrencyId = 2,
                DateInitialState = null,
                Id = _newCashRegisterId,
                InitialState = null,
                IsDefault = false,
                Name = "My updated cash register"
            };
        }

        private CashRegisterPostModel CreatePostModel()
        {
            return new CashRegisterPostModel
            {
                CurrencyId = 1,
                DateInitialState = new DateTime(2020, 4, 22).SetKindUtc(),
                InitialState = 10000m,
                IsDefault = false,
                Name = "My new cash register"
            };
        }
    }
}
