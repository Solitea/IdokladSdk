using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.ReceivedDocumentPayments;
using IdokladSdk.Models.ReceivedInvoice;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReceivedDocumentPayment
{
    [TestFixture]
    public class ReceivedDocumentPaymentTests : TestBase
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
        public async Task List_SuccessfullyGetAsync()
        {
            // Act
            var data = await _receivedDocumentPaymentClient.List().Sort(x => x.DateOfPayment.Asc()).GetAsync().AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        [Order(1)]
        public async Task Payment_Post_SuccessfullyAsync()
        {
            // Act
            var defaultPayment = await _receivedDocumentPaymentClient.DefaultAsync(UnpaidInvoiceId).AssertResult();
            var postedPayment = await _receivedDocumentPaymentClient.PostAsync(defaultPayment).AssertResult();
            var retrievedPayment = await _receivedDocumentPaymentClient.Detail(postedPayment.Id).GetAsync().AssertResult();
            var deleted = await _receivedDocumentPaymentClient.DeleteAsync(retrievedPayment.Id).AssertResult();

            // Assert
            Assert.That(defaultPayment.InvoiceId, Is.EqualTo(UnpaidInvoiceId));
            Assert.That(postedPayment.InvoiceId, Is.EqualTo(UnpaidInvoiceId));
            Assert.That(retrievedPayment.InvoiceId, Is.EqualTo(UnpaidInvoiceId));
            Assert.That(retrievedPayment.Id, Is.EqualTo(postedPayment.Id));
            Assert.That(deleted, Is.True);
        }

        [Test]
        [Order(2)]
        public async Task Payment_FullyPay_FullyUnpay_SuccessfullyAsync()
        {
            // Act
            var unpaid = await _receivedDocumentPaymentClient.FullyUnpayAsync(PaidInvoiceId).AssertResult();
            var paid = await _receivedDocumentPaymentClient.FullyPayAsync(PaidInvoiceId).AssertResult();

            // Assert
            Assert.That(unpaid, Is.True);
            Assert.That(paid, Is.True);
        }

        [Test]
        public async Task List_WithFilter_PaymentOptionId_ReturnsListAsync()
        {
            // Arrange
            var invoiceId = await PostReceivedInvoiceAsync();
            var initialPayments = await _receivedDocumentPaymentClient
                    .List()
                    .Filter(f => f.InvoiceId.IsEqual(invoiceId))
                    .GetAsync()
                    .AssertResult();
            Assert.That(initialPayments.Items, Is.Empty);
            var paymentOptionId = await PostPaymentAsync(invoiceId);

            // Act
            var payments = await _receivedDocumentPaymentClient
                .List()
                .Filter(f => f.InvoiceId.IsEqual(invoiceId) && f.PaymentOptionId.IsEqual(paymentOptionId))
                .GetAsync().AssertResult();

            // Assert
            Assert.That(payments.Items.Count(), Is.EqualTo(1));
            var deleted = await _receivedInvoiceClient.DeleteAsync(invoiceId).AssertResult();
            Assert.That(deleted, Is.True);
        }

        [Test]
        public async Task BatchPostAsync_SuccessfullyPosted()
        {
            // Arrange
            var unpaidInvoiceId = await PostReceivedInvoiceAsync();

            // Act
            var defaultPayment = await _receivedDocumentPaymentClient.DefaultAsync(unpaidInvoiceId).AssertResult();
            var batch = new List<ReceivedDocumentPaymentPostModel> { defaultPayment };
            var postedPayments = await _receivedDocumentPaymentClient.PostAsync(batch).AssertResult();
            var postedPayment = postedPayments.First();
            var retrievedPayment = await _receivedDocumentPaymentClient.Detail(postedPayment.Id).GetAsync().AssertResult();
            var deleted = await _receivedDocumentPaymentClient.DeleteAsync(retrievedPayment.Id).AssertResult();

            // Assert
            Assert.That(defaultPayment.InvoiceId, Is.EqualTo(unpaidInvoiceId));
            Assert.That(postedPayment.InvoiceId, Is.EqualTo(unpaidInvoiceId));
            Assert.That(retrievedPayment.InvoiceId, Is.EqualTo(unpaidInvoiceId));
            Assert.That(postedPayment.Id, Is.EqualTo(retrievedPayment.Id));
            Assert.That(deleted, Is.True);
        }

        [Test]
        public async Task BatchDeleteAsync_SuccessfullyPosted()
        {
            // Arrange
            var unpaidInvoiceId = await PostReceivedInvoiceAsync();
            var defaultPayment = await _receivedDocumentPaymentClient.DefaultAsync(unpaidInvoiceId).AssertResult();
            var batch = new List<ReceivedDocumentPaymentPostModel> { defaultPayment };
            var postedPayments = await _receivedDocumentPaymentClient.PostAsync(batch).AssertResult();
            var postedPayment = postedPayments.First();
            var retrievedPayment = await _receivedDocumentPaymentClient.Detail(postedPayment.Id).GetAsync().AssertResult();

            // Act
            var ids = new List<int> { postedPayment.Id };
            var deleteBatchResult = await _receivedDocumentPaymentClient.DeleteAsync(ids).AssertResult();

            // Assert
            Assert.That(postedPayment.Id, Is.EqualTo(retrievedPayment.Id));
            var deletedResult = deleteBatchResult.Single(i => i.Id == postedPayment.Id);
            Assert.That(deletedResult.IsSuccess, Is.True);
        }

        private async Task<int> PostPaymentAsync(int invoiceId)
        {
            var paymentOptions = (await DokladApi.PaymentOptionClient
                .List()
                .GetAsync()
                .AssertResult())
                .Items.ToList();

            var paymentOptionId = paymentOptions.First(w => !w.IsDefault).Id;
            var payment = await _receivedDocumentPaymentClient.DefaultAsync(invoiceId).AssertResult();
            payment.PaymentOptionId = paymentOptionId;
            payment.PaymentAmount = 10;
            await _receivedDocumentPaymentClient.PostAsync(payment).AssertResult();
            return paymentOptionId;
        }

        private async Task<int> PostReceivedInvoiceAsync()
        {
            var invoice = await _receivedInvoiceClient.DefaultAsync().AssertResult();
            invoice.PartnerId = PartnerId;
            invoice.Description = "desc";
            invoice.Items.Clear();
            invoice.Items.Add(
                new ReceivedInvoiceItemPostModel { Name = "item", UnitPrice = 1000 });
            var insertResult = await _receivedInvoiceClient.PostAsync(invoice).AssertResult();
            var unpaidInvoiceId = insertResult.Id;
            return unpaidInvoiceId;
        }
    }
}
