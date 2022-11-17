using System;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.IssuedDocumentPayment;

[TestFixture]
public class IssuedDocumentPaymentTests : TestBase
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
    public async Task List_SuccessfullyGetAsync()
    {
        // Act
        var data = await _client.List().Sort(x => x.DateOfPayment.Asc()).GetAsync().AssertResult();

        // Assert
        Assert.GreaterOrEqual(data.TotalItems, 1);
    }

    [Test]
    [Order(1)]
    public async Task PaymentAsync_Post_Successfully()
    {
        // Act
        var defaultPayment = await _client.DefaultAsync(UnpaidInvoiceId).AssertResult();
        var postedPayment = await _client.PostAsync(defaultPayment).AssertResult();
        var retrievedPayment = await _client.Detail(postedPayment.Id).GetAsync().AssertResult();
        var deleted = await _client.DeleteAsync(retrievedPayment.Id).AssertResult();

        // Assert
        Assert.AreEqual(defaultPayment.InvoiceId, UnpaidInvoiceId);
        Assert.AreEqual(postedPayment.InvoiceId, UnpaidInvoiceId);
        Assert.AreEqual(retrievedPayment.InvoiceId, UnpaidInvoiceId);
        Assert.AreEqual(postedPayment.Id, retrievedPayment.Id);
        Assert.IsTrue(deleted);
    }

    [Test]
    [Order(2)]
    public async Task PaymentAsync_FullyUnpayAndFullyPay_Successfully()
    {
        // Act
        var dateOfPayment = DateTime.UtcNow.AddDays(-3);
        var unpaid = await _client.FullyUnpayAsync(PaidInvoiceId).AssertResult();
        var paid = await _client.FullyPayAsync(PaidInvoiceId, dateOfPayment).AssertResult();
        var paidInvoice = await DokladApi.IssuedInvoiceClient.Detail(PaidInvoiceId).GetAsync().AssertResult();

        // Assert
        Assert.IsTrue(unpaid);
        Assert.IsTrue(paid);
        Assert.AreEqual(dateOfPayment.Date, paidInvoice.DateOfPayment);
    }

    [Test]
    [Order(3)]
    public async Task Payment_Post_SuccessfullyAsync()
    {
        // Act
        var defaultPayment = await _client.DefaultAsync(UnpaidInvoiceId).AssertResult();
        var postedPayment = await _client.PostAsync(defaultPayment).AssertResult();
        var retrievedPayment = await _client.Detail(postedPayment.Id).GetAsync().AssertResult();
        var deleted = await _client.DeleteAsync(retrievedPayment.Id).AssertResult();

        // Assert
        Assert.AreEqual(defaultPayment.InvoiceId, UnpaidInvoiceId);
        Assert.AreEqual(postedPayment.InvoiceId, UnpaidInvoiceId);
        Assert.AreEqual(retrievedPayment.InvoiceId, UnpaidInvoiceId);
        Assert.AreEqual(postedPayment.Id, retrievedPayment.Id);
        Assert.IsTrue(deleted);
    }

    [Test]
    [Order(4)]
    public async Task Payment_FullyUnpayAndFullyPay_SuccessfullyAsync()
    {
        // Act
        var dateOfPayment = DateTime.UtcNow.AddDays(-3);
        var unpaid = await _client.FullyUnpayAsync(PaidInvoiceId).AssertResult();
        var paid = await _client.FullyPayAsync(PaidInvoiceId, dateOfPayment).AssertResult();
        var paidInvoice = await DokladApi.IssuedInvoiceClient.Detail(PaidInvoiceId).GetAsync().AssertResult();

        // Assert
        Assert.IsTrue(unpaid);
        Assert.IsTrue(paid);
        Assert.AreEqual(dateOfPayment.Date, paidInvoice.DateOfPayment);
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
        Assert.IsNotNull(paymentDetail.Data.CashVoucher);
    }

    [Test]
    public async Task GetPaymentsAsync_PaymentsForIssuedTaxDocument_SuccessfullyReturned()
    {
        // Act
        var data = await _client.PaymentsForIssuedTaxDocument().GetAsync().AssertResult();

        // Assert
        Assert.GreaterOrEqual(data.TotalItems, 1);
    }
}
