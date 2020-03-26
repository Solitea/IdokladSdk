using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReceivedDocumentPayment
{
    [TestFixture]
    public partial class ReceivedDocumentPaymentTests : TestBase
    {
        private const int PaidInvoiceId = 165435;
        private const int UnpaidInvoiceId = 165460;
        private ReceivedDocumentPaymentsClient _client;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            InitDokladApi();
            _client = DokladApi.ReceivedDocumentPaymentsClient;
        }

        [Test]
        public void List_SuccessfullyGet()
        {
            // Act
            var data = _client.List().Get().AssertResult();

            // Assert
            Assert.GreaterOrEqual(data.TotalItems, 1);
        }

        [Test]
        [Order(1)]
        public void Payment_Post_Successfully()
        {
            // Act
            var defaultPayment = _client.Default(UnpaidInvoiceId).AssertResult();
            var postedPayment = _client.Post(defaultPayment).AssertResult();
            var retrievedPayment = _client.Detail(postedPayment.Id).Get().AssertResult();
            var deleted = _client.Delete(retrievedPayment.Id).AssertResult();

            // Assert
            Assert.AreEqual(defaultPayment.InvoiceId, UnpaidInvoiceId);
            Assert.AreEqual(postedPayment.InvoiceId, UnpaidInvoiceId);
            Assert.AreEqual(retrievedPayment.InvoiceId, UnpaidInvoiceId);
            Assert.AreEqual(postedPayment.Id, retrievedPayment.Id);
            Assert.IsTrue(deleted);
        }

        [Test]
        [Order(2)]
        public void Payment_FullyPay_FullyUnpay_Successfully()
        {
            // Act
            var unpaid = _client.FullyUnpay(PaidInvoiceId).AssertResult();
            var paid = _client.FullyPay(PaidInvoiceId).AssertResult();

            // Assert
            Assert.IsTrue(unpaid);
            Assert.IsTrue(paid);
        }
    }
}
