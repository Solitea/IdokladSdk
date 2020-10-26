using System.Threading.Tasks;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.SalesReceipt
{
    public partial class SalesReceiptTests
    {
        [Test]
        [Order(7)]
        public async Task CopyAsync_SuccessfullyGetPosModel()
        {
            // Arrange
            var salesReceiptToCopy = _client.Detail(_salesReceiptId).Get().AssertResult();

            // Act
            var data = (await _client.CopyAsync(_salesReceiptId)).AssertResult();

            // Assert
            Assert.AreEqual(salesReceiptToCopy.PartnerId, data.PartnerId);
            Assert.AreEqual(salesReceiptToCopy.CurrencyId, data.CurrencyId);
        }

        [Test]
        public async Task RecountAsync_SuccessfullyRecounted()
        {
            // Arrange
            var model = CreateRecountPostModel();

            // Act
            var data = (await _client.RecountAsync(model)).AssertResult();

            // Assert
            AssertRecountModel(data, model);
        }
    }
}
