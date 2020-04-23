using System.Collections.Generic;
using System.Linq;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.BankStatement;
using IdokladSdk.Models.IssuedInvoice;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.BankStatement
{
    /// <summary>
    /// BankStatementTests.
    /// </summary>
    public partial class BankStatementTests : TestBase
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
        public void List_SuccessfullyGetList()
        {
            // Act
            var data = _bankStatementClient.List().Get().AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
            var bankStatement = data.Items.FirstOrDefault();
            Assert.NotNull(bankStatement);
            Assert.AreEqual(BankStatementId, bankStatement.Id);
            Assert.AreEqual(100, bankStatement.Items.First().Prices.PaidAmount);
        }

        [Test]
        public void Detail_SuccessfullyGetDetail()
        {
            // Act
            var data = _bankStatementClient.Detail(BankStatementId).Get().AssertResult();

            // Assert
            Assert.AreEqual(BankStatementId, data.Id);
            Assert.AreEqual(100, data.Items.First().Prices.PaidAmount);
        }

        [Test]
        [Order(1)]
        public void Pair_SuccessfullyPairWithInvoice()
        {
            // Arrange
            var invoice = CreateInvoice();
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
            var data = _bankStatementClient.Pair(model).AssertResult();
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
        public void Delete_SuccessfullyDeletedStatement()
        {
            // Act
            var data = _bankStatementClient.Delete(_bankStatementId).AssertResult();

            // Assert
            Assert.IsTrue(data);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var result = _issuedInvoiceClient.Delete(_invoiceId).AssertResult();
            Assert.IsTrue(result, "Invoice not deleted");
        }

        private IssuedInvoiceGetModel CreateInvoice()
        {
            var defaultInvoice = _issuedInvoiceClient.Default().AssertResult();
            defaultInvoice.PartnerId = PartnerId;
            defaultInvoice.Description = "Invoice for pair";
            defaultInvoice.Items.Clear();
            defaultInvoice.Items.Add(new IssuedInvoiceItemPostModel
            {
                Name = "Test",
                Amount = 1,
                UnitPrice = 150
            });
            var invoice = _issuedInvoiceClient.Post(defaultInvoice).AssertResult();
            return invoice;
        }
    }
}
