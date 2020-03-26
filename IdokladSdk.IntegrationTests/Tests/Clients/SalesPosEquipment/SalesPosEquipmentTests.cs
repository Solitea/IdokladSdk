using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.AuthProviders;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.SalesPosEquipment
{
    public class SalesPosEquipmentTests : TestBase
    {
        private readonly int _salesPosEquipmentId = 12902;
        private readonly int _pairedSalesPosEquipmentId = 12914;
        private SalesPosEquipmentClient _client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi<PinAuthProvider>();
            _client = DokladApi.SalesPosEquipmentClient;
        }

        [Test]
        public void Get_WithSelect_SuccessfullyGet()
        {
            // Act
            var data = _client.Detail(_salesPosEquipmentId)
                .Get()
                .AssertResult();

            Assert.AreEqual(_salesPosEquipmentId, data.Id);
        }

        [Test]
        public void GetList_SuccessfullyReturned()
        {
            // Act
            var data = _client.List().Get().AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.TotalPages, 0);
        }

        [Test]
        public void GetInfo_SuccessfullyReturned()
        {
            // Act
            var data = _client.Info().Get().AssertResult();

            // Assert
            Assert.AreEqual(_pairedSalesPosEquipmentId, data.Id);
        }
    }
}
