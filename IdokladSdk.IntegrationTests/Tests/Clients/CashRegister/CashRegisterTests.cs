using System;
using System.Linq;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.CashRegister;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.CashRegister
{
    public partial class CashRegisterTests : TestBase
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
        public void Post_SuccessfullyPosted()
        {
            // Arrange
            var model = CreatePostModel();

            // Act
            var data = _cashRegisterClient.Post(model).AssertResult();
            _newCashRegisterId = data.Id;

            // Assert
            Assert.Greater(data.Id, 0);
            AssertData(model, data);
        }

        [Test]
        [Order(2)]
        public void Detail_SuccessfullyGetDetail()
        {
            // Act
            var data = _cashRegisterClient.Detail(_newCashRegisterId).Include(c => c.Currency).Get().AssertResult();

            // Assert
            Assert.AreEqual(_newCashRegisterId, data.Id);
            Assert.IsNotEmpty(data.Name);
            Assert.NotNull(data.Currency);
            Assert.AreEqual(data.CurrencyId, data.Currency.Id);
        }

        [Test]
        [Order(3)]
        public void Update_SuccessfullyUpdated()
        {
            var model = CreatePatchModel();

            // Act
            var data = _cashRegisterClient.Update(model).AssertResult();

            // Assert
            AssertData(model, data);
        }

        [Test]
        [Order(4)]
        public void List_SuccessfullyGetList()
        {
            // Act
            var data = _cashRegisterClient.List().Filter(f => f.CurrencyId.IsNotEqual(0)).Get().AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
            var cashRegister = data.Items.FirstOrDefault(c => c.Id == _newCashRegisterId);
            Assert.NotNull(cashRegister);
            Assert.IsNotEmpty(cashRegister.Name);
        }

        [Test]
        [Order(5)]
        public void Delete_SuccessfullyDeleted()
        {
            // Act
            var data = _cashRegisterClient.Delete(_newCashRegisterId).AssertResult();

            // Assert
            Assert.True(data);
        }

        private void AssertData(CashRegisterPatchModel patchModel, CashRegisterGetModel getModel)
        {
            Assert.AreEqual(patchModel.CurrencyId, getModel.CurrencyId);
            Assert.AreEqual(patchModel.DateInitialState.Value, getModel.DateInitialState);
            Assert.AreEqual(patchModel.Id, getModel.Id);
            Assert.AreEqual(patchModel.InitialState.Value, getModel.InitialState);
            Assert.AreEqual(patchModel.IsDefault, getModel.IsDefault);
            Assert.AreEqual(patchModel.Name, getModel.Name);
        }

        private void AssertData(CashRegisterPostModel postModel, CashRegisterGetModel getModel)
        {
            Assert.AreEqual(postModel.CurrencyId, getModel.CurrencyId);
            Assert.AreEqual(postModel.DateInitialState, getModel.DateInitialState);
            Assert.AreEqual(postModel.InitialState, getModel.InitialState);
            Assert.AreEqual(postModel.IsDefault, getModel.IsDefault);
            Assert.AreEqual(postModel.Name, getModel.Name);
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
