using System.Threading.Tasks;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReceivedDocumentPayment
{
    public partial class ReceivedDocumentPaymentTests
    {
        [Test]
        public async Task List_SuccessfullyGetAsync()
        {
            // Act
            var data = (await _client.List().GetAsync()).AssertResult();

            // Assert
            Assert.GreaterOrEqual(data.TotalItems, 1);
        }

        [Test]
        [Order(3)]
        public async Task Payment_Post_SuccessfullyAsync()
        {
            // Act
            var defaultPayment = (await _client.DefaultAsync(UnpaidInvoiceId)).AssertResult();
            var postedPayment = (await _client.PostAsync(defaultPayment)).AssertResult();
            var retrievedPayment = (await _client.Detail(postedPayment.Id).GetAsync()).AssertResult();
            var deleted = (await _client.DeleteAsync(retrievedPayment.Id)).AssertResult();

            // Assert
            Assert.AreEqual(defaultPayment.InvoiceId, UnpaidInvoiceId);
            Assert.AreEqual(postedPayment.InvoiceId, UnpaidInvoiceId);
            Assert.AreEqual(retrievedPayment.InvoiceId, UnpaidInvoiceId);
            Assert.AreEqual(postedPayment.Id, retrievedPayment.Id);
            Assert.IsTrue(deleted);
        }

        [Test]
        [Order(4)]
        public async Task Payment_FullyPay_FullyUnpay_SuccessfullyAsync()
        {
            // Act
            var unpaid = (await _client.FullyUnpayAsync(PaidInvoiceId)).AssertResult();
            var paid = (await _client.FullyPayAsync(PaidInvoiceId)).AssertResult();

            // Assert
            Assert.IsTrue(unpaid);
            Assert.IsTrue(paid);
        }
    }
}
