using System.Linq;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.ReceivedInvoice;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReceivedDocumentPayment
{
    [TestFixture]
    public partial class ReceivedDocumentPaymentTests : TestBase
    {
        private const int PaidInvoiceId = 165435;
        private const int UnpaidInvoiceId = 165460;
        private const int PartnerId = 323823;
        private ReceivedDocumentPaymentsClient _receivedDocumentPaymentClient;
        private ReceivedInvoiceClient _receivedInvoiceClient;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            InitDokladApi();
            _receivedDocumentPaymentClient = DokladApi.ReceivedDocumentPaymentsClient;
            _receivedInvoiceClient = DokladApi.ReceivedInvoiceClient;
        }

        [Test]
        public void List_SuccessfullyGet()
        {
            // Act
            var data = _receivedDocumentPaymentClient.List().Sort(x => x.DateOfPayment.Asc()).Get().AssertResult();

            // Assert
            Assert.GreaterOrEqual(data.TotalItems, 1);
        }

        [Test]
        [Order(1)]
        public void Payment_Post_Successfully()
        {
            // Act
            var defaultPayment = _receivedDocumentPaymentClient.Default(UnpaidInvoiceId).AssertResult();
            var postedPayment = _receivedDocumentPaymentClient.Post(defaultPayment).AssertResult();
            var retrievedPayment = _receivedDocumentPaymentClient.Detail(postedPayment.Id).Get().AssertResult();
            var deleted = _receivedDocumentPaymentClient.Delete(retrievedPayment.Id).AssertResult();

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
            var unpaid = _receivedDocumentPaymentClient.FullyUnpay(PaidInvoiceId).AssertResult();
            var paid = _receivedDocumentPaymentClient.FullyPay(PaidInvoiceId).AssertResult();

            // Assert
            Assert.IsTrue(unpaid);
            Assert.IsTrue(paid);
        }

        [Test]
        public void List_WithFilter_PaymentOptionId_ReturnsList()
        {
            // Arrange
            var invoiceId = PostReceivedInvoice();
            var initialPayments = _receivedDocumentPaymentClient
                    .List()
                    .Filter(f => f.InvoiceId.IsEqual(invoiceId))
                    .Get().AssertResult();
            Assert.IsEmpty(initialPayments.Items);
            var paymentOptionId = PostPayment(invoiceId);

            // Act
            var payments = _receivedDocumentPaymentClient
                .List()
                .Filter(f => f.InvoiceId.IsEqual(invoiceId), f => f.PaymentOptionId.IsEqual(paymentOptionId))
                .Get().AssertResult();

            // Assert
            Assert.AreEqual(1, payments.Items.Count());
            var deleted = _receivedInvoiceClient.Delete(invoiceId).AssertResult();
            Assert.IsTrue(deleted);
        }

        private int PostPayment(int invoiceId)
        {
            var paymentOptions = DokladApi.PaymentOptionClient
                .List()
                .Get()
                .AssertResult()
                .Items.ToList();

            var paymentOptionId = paymentOptions.First(w => !w.IsDefault).Id;
            var payment = _receivedDocumentPaymentClient.Default(invoiceId).AssertResult();
            payment.PaymentOptionId = paymentOptionId;
            payment.PaymentAmount = 10;
            _receivedDocumentPaymentClient.Post(payment).AssertResult();
            return paymentOptionId;
        }

        private int PostReceivedInvoice()
        {
            var invoice = _receivedInvoiceClient.Default().Data;
            invoice.PartnerId = PartnerId;
            invoice.Description = "desc";
            invoice.Items.Clear();
            invoice.Items.Add(
                new ReceivedInvoiceItemPostModel { Name = "item", UnitPrice = 1000 });
            var insertResult = _receivedInvoiceClient.Post(invoice).AssertResult();
            var unpaidInvoiceId = insertResult.Id;
            return unpaidInvoiceId;
        }
    }
}
