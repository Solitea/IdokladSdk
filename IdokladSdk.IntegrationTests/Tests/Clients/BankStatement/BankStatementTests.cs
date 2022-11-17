using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.BankStatement;
using IdokladSdk.Models.IssuedInvoice;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.BankStatement;

/// <summary>
/// BankStatementTests.
/// </summary>
public class BankStatementTests : TestBase
{
    private const int PartnerId = 323823;
    private const int BankStatementId = 990771;
    private const int Tag1Id = 990;
    private BankStatementClient _bankStatementClient;
    private IssuedInvoiceClient _issuedInvoiceClient;
    private int _invoiceId;
    private int _bankStatementId;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        InitDokladApi();
        _bankStatementClient = DokladApi.BankStatementClient;
        _issuedInvoiceClient = DokladApi.IssuedInvoiceClient;
    }

    [Test]
    public async Task ListAsync_SuccessfullyGetList()
    {
        // Act
        var data = (await _bankStatementClient.List().GetAsync()).AssertResult();

        // Assert
        Assert.Greater(data.TotalItems, 0);
        var bankStatement = data.Items.FirstOrDefault();
        Assert.NotNull(bankStatement);
        Assert.AreEqual(BankStatementId, bankStatement.Id);
        Assert.AreEqual(100, bankStatement.Items.First().Prices.PaidAmount);
    }

    [Test]
    public async Task DetailAsync_SuccessfullyGetDetail()
    {
        // Act
        var data = (await _bankStatementClient.Detail(BankStatementId).GetAsync()).AssertResult();

        // Assert
        Assert.AreEqual(BankStatementId, data.Id);
        Assert.AreEqual(100, data.Items.First().Prices.PaidAmount);
    }

    [Test]
    [Order(1)]
    public async Task PairAsync_SuccessfullyPairWithInvoice()
    {
        // Arrange
        var invoice = await CreateInvoiceAsync();
        _invoiceId = invoice.Id;
        var model = new BankStatementPairingPostModel
        {
            Amount = 150,
            AccountNumber = "2102290124",
            BankCode = "2700",
            PartnerAccountNumber = invoice.PartnerAddress.AccountNumber,
            PartnerBankCode = invoice.PartnerAddress.BankCode,
            VariableSymbol = invoice.VariableSymbol,
            MovementType = MovementType.Entry,
            CurrencyCode = "CZK",
            Tags = new List<int> { Tag1Id }
        };

        // Act
        var data = (await _bankStatementClient.PairAsync(model)).AssertResult();
        _bankStatementId = data.CreatedBankStatement.Id;

        // Assert
        Assert.IsTrue(data.WasPaired);
        Assert.AreEqual(invoice.Id, data.PairedInvoiceId);
        var item = data.CreatedBankStatement.Items.First();
        Assert.AreEqual(invoice.VariableSymbol, item.VariableSymbol);
        Assert.AreEqual(invoice.Prices.TotalWithVat, item.Prices.PaidAmount);
        Assert.IsNotNull(data.CreatedBankStatement.Tags.FirstOrDefault(t => t.TagId == Tag1Id));
    }

    [Test]
    [Order(2)]
    public async Task DeleteAsync_SuccessfullyDeletedStatement()
    {
        // Act
        var data = (await _bankStatementClient.DeleteAsync(_bankStatementId)).AssertResult();

        // Assert
        Assert.IsTrue(data);
    }

    [OneTimeTearDown]
    public async Task TearDown()
    {
        var result = await _issuedInvoiceClient.DeleteAsync(_invoiceId).AssertResult();
        Assert.IsTrue(result, "Invoice not deleted");
    }

    private async Task<IssuedInvoiceGetModel> CreateInvoiceAsync()
    {
        var defaultInvoice = await _issuedInvoiceClient.DefaultAsync().AssertResult();
        defaultInvoice.PartnerId = PartnerId;
        defaultInvoice.Description = "Invoice for pair";
        defaultInvoice.Items.Clear();
        defaultInvoice.Items.Add(new IssuedInvoiceItemPostModel
        {
            Name = "Test",
            Amount = 1,
            UnitPrice = 150
        });
        var invoice = await _issuedInvoiceClient.PostAsync(defaultInvoice).AssertResult();
        return invoice;
    }
}
