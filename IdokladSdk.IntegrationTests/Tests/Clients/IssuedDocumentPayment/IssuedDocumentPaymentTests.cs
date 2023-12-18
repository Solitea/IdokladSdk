using System;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Core.Helpers;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.IssuedDocumentPayment
{
    [TestFixture]
    public class IssuedDocumentPaymentTests : TestBase
    {
        private const int CashPaymentOptionId = 3;
        private IssuedDocumentPaymentClient _client;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            InitDokladApi();
            _client = DokladApi.IssuedDocumentPaymentClient;
        }

        [Test]
        public async Task List_SuccessfullyGetAsync()
        {
            // Act
            var data = await _client.List().Sort(x => x.DateOfPayment.Asc()).GetAsync().AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public async Task PaymentAsync_Post_Successfully()
        {
            // Arrange
            var model = DokladSdkTestsHelper.GetDefaultIssuedInvoicePostModel();
            model.DateOfPayment = null;
            var unpaidInvoiceId = (await DokladSdkTestsHelper.CreateDefaultIssuedInvoiceAsync(DokladApi, model)).Id;

            // Act
            var defaultPayment = await _client.DefaultAsync(unpaidInvoiceId).AssertResult();
            var postedPayment = await _client.PostAsync(defaultPayment).AssertResult();
            var retrievedPayment = await _client.Detail(postedPayment.Id).GetAsync().AssertResult();
            var deleted = await _client.DeleteAsync(retrievedPayment.Id).AssertResult();

            // Assert
            Assert.That(defaultPayment.InvoiceId, Is.EqualTo(unpaidInvoiceId));
            Assert.That(postedPayment.InvoiceId, Is.EqualTo(unpaidInvoiceId));
            Assert.That(retrievedPayment.InvoiceId, Is.EqualTo(unpaidInvoiceId));
            Assert.That(postedPayment.Id, Is.EqualTo(retrievedPayment.Id));
            Assert.That(deleted, Is.True);

            // TearDown
            await DokladApi.IssuedInvoiceClient.DeleteAsync(unpaidInvoiceId);
        }

        [Test]
        public async Task PaymentAsync_FullyUnpayAndFullyPay_Successfully()
        {
            // Arrange
            var paidInvoiceId = (await DokladSdkTestsHelper.CreateDefaultIssuedInvoiceAsync(DokladApi)).Id;
            var dateOfPayment = DateTime.UtcNow.AddDays(-3);

            // Act
            var unpaid = await _client.FullyUnpayAsync(paidInvoiceId).AssertResult();
            var paid = await _client.FullyPayAsync(paidInvoiceId, dateOfPayment).AssertResult();
            var paidInvoice = await DokladApi.IssuedInvoiceClient.Detail(paidInvoiceId).GetAsync().AssertResult();

            // Assert
            Assert.That(unpaid, Is.True);
            Assert.That(paid, Is.True);
            Assert.That(paidInvoice.DateOfPayment, Is.EqualTo(dateOfPayment.Date));

            // TearDown
            await DokladApi.IssuedInvoiceClient.DeleteAsync(paidInvoiceId);
        }

        [Test]
        public async Task Payment_Post_SuccessfullyAsync()
        {
            // Arrange
            var model = DokladSdkTestsHelper.GetDefaultIssuedInvoicePostModel();
            model.DateOfPayment = null;
            var unpaidInvoiceId = (await DokladSdkTestsHelper.CreateDefaultIssuedInvoiceAsync(DokladApi, model)).Id;

            // Act
            var defaultPayment = await _client.DefaultAsync(unpaidInvoiceId).AssertResult();
            var postedPayment = await _client.PostAsync(defaultPayment).AssertResult();
            var retrievedPayment = await _client.Detail(postedPayment.Id).GetAsync().AssertResult();
            var deleted = await _client.DeleteAsync(retrievedPayment.Id).AssertResult();

            // Assert
            Assert.That(defaultPayment.InvoiceId, Is.EqualTo(unpaidInvoiceId));
            Assert.That(postedPayment.InvoiceId, Is.EqualTo(unpaidInvoiceId));
            Assert.That(retrievedPayment.InvoiceId, Is.EqualTo(unpaidInvoiceId));
            Assert.That(postedPayment.Id, Is.EqualTo(retrievedPayment.Id));
            Assert.That(deleted, Is.True);

            // TearDown
            await DokladApi.IssuedInvoiceClient.DeleteAsync(unpaidInvoiceId);
        }

        [Test]
        public async Task Payment_FullyUnpayAndFullyPay_SuccessfullyAsync()
        {
            // Arrange
            var paidInvoiceId = (await DokladSdkTestsHelper.CreateDefaultIssuedInvoiceAsync(DokladApi)).Id;
            var dateOfPayment = DateTime.UtcNow.AddDays(-3);

            // Act
            var unpaid = await _client.FullyUnpayAsync(paidInvoiceId).AssertResult();
            var paid = await _client.FullyPayAsync(paidInvoiceId, dateOfPayment).AssertResult();
            var paidInvoice = await DokladApi.IssuedInvoiceClient.Detail(paidInvoiceId).GetAsync().AssertResult();

            // Assert
            Assert.That(unpaid, Is.True);
            Assert.That(paid, Is.True);
            Assert.That(paidInvoice.DateOfPayment, Is.EqualTo(dateOfPayment.Date));

            // TearDown
            await DokladApi.IssuedInvoiceClient.DeleteAsync(paidInvoiceId);
        }

        [Test]
        public async Task DetailAsync_WithCashVoucher_SuccessfullyReturned()
        {
            // Arrange
            var payments = await DokladApi.IssuedDocumentPaymentClient
                .List()
                .Filter(i => i.PaymentOptionId.IsEqual(CashPaymentOptionId))
                .GetAsync()
                .AssertResult();

            // Act
            var paymentDetail = await DokladApi.IssuedDocumentPaymentClient
                .Detail(payments.Items.First().Id)
                .Include(i => i.CashVoucher)
                .GetAsync();

            // Assert
            Assert.That(paymentDetail.Data.CashVoucher, Is.Not.Null);
        }

        [Test]
        public async Task GetPaymentsAsync_PaymentsForIssuedTaxDocument_SuccessfullyReturned()
        {
            // Act
            var data = await _client.PaymentsForIssuedTaxDocument().GetAsync().AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThanOrEqualTo(1));
        }
    }
}
