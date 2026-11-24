using System;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.RegisteredSale
{
    public class RegisteredSaleTests : TestBase
    {
        private readonly int _salesReceiptId = 224892;
        private RegisteredSaleClient _registeredSaleClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _registeredSaleClient = DokladApi.RegisteredSaleClient;
        }

        [Test]
        public async Task List_SuccessfullyGetAsync()
        {
            // Act
            var data = await _registeredSaleClient.List().GetAsync().AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
        }

        [Test]
        public async Task Detail_SuccessfullyGetAsync()
        {
            // Act
            var data = await _registeredSaleClient.Detail(RegisteredSaleType.SalesReceipt, _salesReceiptId).GetAsync().AssertResult();

            // Assert
            Assert.That(data.SalesReceiptId, Is.EqualTo(_salesReceiptId));
        }

        [Test]
        public async Task Default_SuccessfullyGetAsync()
        {
            // Act
            var data = await _registeredSaleClient.DefaultAsync().AssertResult();

            // Assert
            Assert.That(data.ReceiptNumber, Is.Not.Null);
        }

        [Test]
        public async Task Post_SuccessfullyCreatedAsync()
        {
            // Arrange
            var model = await _registeredSaleClient.DefaultAsync().AssertResult();
            model.Pok = "1688efca-7a53-4aaf-88b3-a3fbacd98c42-ff";
            model.ReceiptNumber = "001";
            model.SalesOfficeDesignation = 2;
            model.Uuid = Guid.NewGuid();
            model.TotalWithVat = 123.45m;
            model.TotalAdvancePayment = 20m;
            model.TotalFromAdvancePayment = 10m;

            // Act
            var data = await _registeredSaleClient.PostAsync(RegisteredSaleType.SalesReceipt, _salesReceiptId, model).AssertResult();

            // Assert
            Assert.That(data.Uuid, Is.EqualTo(model.Uuid));
            Assert.That(data.Pok, Is.EqualTo(model.Pok));
            Assert.That(data.TotalWithVat, Is.EqualTo(model.TotalWithVat));
            Assert.That(data.TotalAdvancePayment, Is.EqualTo(model.TotalAdvancePayment));
            Assert.That(data.TotalFromAdvancePayment, Is.EqualTo(model.TotalFromAdvancePayment));
            Assert.That(data.ReceiptNumber, Is.EqualTo(model.ReceiptNumber));
            Assert.That(data.SalesOfficeDesignation, Is.EqualTo(model.SalesOfficeDesignation));
        }
    }
}
