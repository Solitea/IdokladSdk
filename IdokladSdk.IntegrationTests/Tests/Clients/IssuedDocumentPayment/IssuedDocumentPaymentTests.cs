using System;
using System.Linq;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.IssuedDocumentPayment
{
    [TestFixture]
    public partial class IssuedDocumentPaymentTests : TestBase
    {
        private const int PaidInvoiceId = 913255;
        private const int UnpaidInvoiceId = 913242;
        private const int CashPaymentOptionId = 3;
        private IssuedDocumentPaymentClient _client;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            InitDokladApi();
            _client = DokladApi.IssuedDocumentPaymentClient;
        }

        [Test]
        public void List_SuccessfullyGet()
        {
            // Act
            var data = _client.List().Sort(x => x.DateOfPayment.Asc()).Get().AssertResult();

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
        public void Payment_FullyUnpayAndFullyPay_Successfully()
        {
            // Act
            var dateOfPayment = DateTime.UtcNow.AddDays(-3);
            var unpaid = _client.FullyUnpay(PaidInvoiceId).AssertResult();
            var paid = _client.FullyPay(PaidInvoiceId, dateOfPayment).AssertResult();
            var paidInvoice = DokladApi.IssuedInvoiceClient.Detail(PaidInvoiceId).Get().AssertResult();

            // Assert
            Assert.IsTrue(unpaid);
            Assert.IsTrue(paid);
            Assert.AreEqual(dateOfPayment.Date, paidInvoice.DateOfPayment);
        }

        [Test]
        public void Detail_WithCashVoucher_SuccessfullyReturned()
        {
            // Arrange
            var payments = DokladApi.IssuedDocumentPaymentClient
                .List()
                .Filter(i => i.PaymentOptionId.IsEqual(CashPaymentOptionId))
                .Get()
                .AssertResult();

            // Act
            var paymentDetail = DokladApi.IssuedDocumentPaymentClient
                .Detail(payments.Items.First().Id)
                .Include(i => i.CashVoucher)
                .Get();

            // Assert
            Assert.IsNotNull(paymentDetail.Data.CashVoucher);
        }

        [Test]
        public void GetPayments_PaymentsForIssuedTaxDocument_SuccessfullyReturned()
        {
            // Act
            var data = _client.PaymentsForIssuedTaxDocument().Get().AssertResult();

            // Assert
            Assert.GreaterOrEqual(data.TotalItems, 1);
        }
    }
}
