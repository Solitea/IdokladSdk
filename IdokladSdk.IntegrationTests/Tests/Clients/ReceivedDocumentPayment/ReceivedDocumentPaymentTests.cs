using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.ReceivedInvoice;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReceivedDocumentPayment;

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
        Assert.GreaterOrEqual(data.TotalItems, 1);
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
        Assert.AreEqual(defaultPayment.InvoiceId, UnpaidInvoiceId);
        Assert.AreEqual(postedPayment.InvoiceId, UnpaidInvoiceId);
        Assert.AreEqual(retrievedPayment.InvoiceId, UnpaidInvoiceId);
        Assert.AreEqual(postedPayment.Id, retrievedPayment.Id);
        Assert.IsTrue(deleted);
    }

    [Test]
    [Order(2)]
    public async Task Payment_FullyPay_FullyUnpay_SuccessfullyAsync()
    {
        // Act
        var unpaid = await _receivedDocumentPaymentClient.FullyUnpayAsync(PaidInvoiceId).AssertResult();
        var paid = await _receivedDocumentPaymentClient.FullyPayAsync(PaidInvoiceId).AssertResult();

        // Assert
        Assert.IsTrue(unpaid);
        Assert.IsTrue(paid);
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
        Assert.IsEmpty(initialPayments.Items);
        var paymentOptionId = await PostPaymentAsync(invoiceId);

        // Act
        var payments = await _receivedDocumentPaymentClient
            .List()
            .Filter(f => f.InvoiceId.IsEqual(invoiceId), f => f.PaymentOptionId.IsEqual(paymentOptionId))
            .GetAsync().AssertResult();

        // Assert
        Assert.AreEqual(1, payments.Items.Count());
        var deleted = await _receivedInvoiceClient.DeleteAsync(invoiceId).AssertResult();
        Assert.IsTrue(deleted);
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
