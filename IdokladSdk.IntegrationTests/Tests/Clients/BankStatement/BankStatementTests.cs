using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.BankStatement;
using IdokladSdk.Models.BankStatement.Patch;
using IdokladSdk.Models.BankStatement.Recount;
using IdokladSdk.Models.Common.PairedDocument;
using IdokladSdk.Models.IssuedInvoice;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.BankStatement
{
    /// <summary>
    /// BankStatementTests.
    /// </summary>
    public class BankStatementTests : TestBase
    {
        private const int PartnerId = 323823;
        private const int BankStatementId = 990771;
        private const int UnpaidIssuedInvoice = 914456;
        private const int UnpaidProformaInvoice = 922399;
        private const int UnpaidReceivedInvoice = 165460;
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
        public async Task Default_SucessfullyGetAsync()
        {
            // Act
            var bankStatementIssue = await _bankStatementClient.DefaultAsync(MovementType.Issue).AssertResult();
            var bankStatementEntry = await _bankStatementClient.DefaultAsync(MovementType.Entry).AssertResult();

            // Assert
            Assert.That(bankStatementIssue.MovementType, Is.Not.EqualTo(bankStatementEntry.MovementType));
            Assert.That(bankStatementIssue.MovementType, Is.EqualTo(MovementType.Issue));
            Assert.That(bankStatementEntry.MovementType, Is.EqualTo(MovementType.Entry));
        }

        [TestCaseSource(nameof(GetDefaultBankStatements))]
        public async Task Default_SucessfullyGetAsync(PairedDocumentType documentType, int documentId)
        {
            // Act
            var bankStatement = await _bankStatementClient.DefaultAsync(documentType, documentId).AssertResult();

            // Assert
            Assert.That(bankStatement.PairedDocument?.DocumentType, Is.EqualTo(documentType));
            Assert.That(bankStatement.PairedDocument?.DocumentId, Is.EqualTo(documentId));
        }

        [Test]
        public async Task ListAsync_SuccessfullyGetList()
        {
            // Act
            var data = await _bankStatementClient.List().GetAsync().AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            var bankStatement = data.Items.FirstOrDefault();
            Assert.That(bankStatement, Is.Not.Null);
            Assert.That(bankStatement.Id, Is.EqualTo(BankStatementId));
            Assert.That(bankStatement.Items.First().Prices.PaidAmount, Is.EqualTo(100));
        }

        [Test]
        public async Task DetailAsync_SuccessfullyGetDetail()
        {
            // Act
            var data = await _bankStatementClient.Detail(BankStatementId).GetAsync().AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(BankStatementId));
            Assert.That(data.Items.First().Prices.PaidAmount, Is.EqualTo(100));
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
            var data = await _bankStatementClient.PairAsync(model).AssertResult();
            _bankStatementId = data.CreatedBankStatement.Id;

            // Assert
            Assert.That(data.WasPaired, Is.True);
            Assert.That(data.PairedInvoiceId, Is.EqualTo(invoice.Id));
            var item = data.CreatedBankStatement.Items.First();
            Assert.That(item.VariableSymbol, Is.EqualTo(invoice.VariableSymbol));
            Assert.That(item.Prices.PaidAmount, Is.EqualTo(invoice.Prices.TotalWithVat));
            Assert.That(data.CreatedBankStatement.Tags.FirstOrDefault(t => t.TagId == Tag1Id), Is.Not.Null);
        }

        [Test]
        [Order(2)]
        public async Task DeleteAsync_SuccessfullyDeletedStatement()
        {
            // Act
            var data = await _bankStatementClient.DeleteAsync(_bankStatementId).AssertResult();

            // Assert
            Assert.That(data, Is.True);
        }

        [Test]
        [Order(3)]
        public async Task Post_SuccessfullyAsync()
        {
            // Arrange
            var bankStatementName = $"Issued invoice for test: {UnpaidIssuedInvoice}";

            // Act
            var bankStatement = await _bankStatementClient.DefaultAsync(PairedDocumentType.IssuedInvoice, UnpaidIssuedInvoice).AssertResult();
            bankStatement.Description = bankStatementName;
            var postedBankStatement = await _bankStatementClient.PostAsync(bankStatement).AssertResult();
            _bankStatementId = postedBankStatement.Id;
            var deletedResult = await _bankStatementClient.DeleteAsync(_bankStatementId).AssertResult();

            // Assert
            Assert.That(bankStatement.PairedDocument.DocumentId, Is.EqualTo(UnpaidIssuedInvoice));
            Assert.That(postedBankStatement.PairedDocument.DocumentId, Is.EqualTo(UnpaidIssuedInvoice));
            Assert.That(postedBankStatement.Description, Is.EqualTo(bankStatementName));
            Assert.That(deletedResult, Is.True);
        }

        [Test]
        [Order(4)]
        public async Task Update_SuccessfullyUpdated()
        {
            // Arrange
            var originalBankStatement = await _bankStatementClient.Detail(BankStatementId).GetAsync().AssertResult();
            var updatedDescription = $"UpdatedDescription_{DateTime.UtcNow:dd/MM/yyyy/mm/ss}";
            Assert.That(originalBankStatement.Description, Is.Not.EqualTo(updatedDescription));
            var bankStatementPatchModel = new BankStatementPatchModel
            {
                Id = BankStatementId,
                Description = updatedDescription,
            };

            // Act
            var patchResult = await _bankStatementClient.UpdateAsync(bankStatementPatchModel).AssertResult();

            // Assert
            Assert.That(patchResult.Description, Is.EqualTo(updatedDescription));
        }

        [Test]
        [Order(5)]
        public async Task Notifications_AreNotEmpty()
        {
            // Act
            var result = await _bankStatementClient.NotificationsAsync();

            // Assert
            Assert.That(result.Data, Is.Not.Empty);
        }

        [Test]
        public async Task Recount_SuccessfullyRecounted()
        {
            // Arrange
            var recountModel = new BankStatementRecountPostModel
            {
                CurrencyId = 1,
                DateOfTransaction = DateTime.UtcNow,
                ExchangeRate = 1,
                ExchangeRateAmount = 1,
                Items = new List<BankStatementItemRecountPostModel>
                {
                    new BankStatementItemRecountPostModel
                    {
                        Id = 1,
                        UnitPrice = 100,
                        PriceType = PriceType.WithoutVat,
                        VatRateType = VatRateType.Basic,
                    },
                },
            };

            // Act
            var result = await _bankStatementClient.RecountAsync(recountModel).AssertResult();

            // Assert
            Assert.That(result.Prices.TotalWithoutVat, Is.EqualTo(100));
            Assert.That(result.Prices.TotalWithVat, Is.EqualTo(121));
        }

        [Test]
        public async Task Update_SuccessfullyUnpairs()
        {
            // Arrange
            var issuedInvoice = await CreateInvoiceAsync();
            _invoiceId = issuedInvoice.Id;
            var defaultBankStatement = await _bankStatementClient.DefaultAsync(PairedDocumentType.IssuedInvoice, _invoiceId).AssertResult();
            var postedBankStatement = await _bankStatementClient.PostAsync(defaultBankStatement).AssertResult();
            Assert.That(postedBankStatement.PairedDocument, Is.Not.Null);
            _bankStatementId = postedBankStatement.Id;
            var bankStatementPatchModel = new BankStatementPatchModel { Id = _bankStatementId, PairedDocument = new PairedDocumentPatchModel { DocumentId = null, DocumentType = null }, };

            // Act
            var patchResult = await _bankStatementClient.UpdateAsync(bankStatementPatchModel).AssertResult();

            // Assert
            Assert.That(patchResult.PairedDocument, Is.Null);
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            var result = await _issuedInvoiceClient.DeleteAsync(_invoiceId).AssertResult();
            Assert.That(result, Is.True, "Invoice not deleted");

            var deleteResult = await _bankStatementClient.DeleteAsync(_bankStatementId).AssertResult();
            Assert.That(deleteResult, Is.True);
        }

        private static List<object> GetDefaultBankStatements()
        {
            return new List<object>
            {
                new object[] { PairedDocumentType.IssuedInvoice, UnpaidIssuedInvoice },
                new object[] { PairedDocumentType.ProformaInvoice, UnpaidProformaInvoice },
                new object[] { PairedDocumentType.ReceivedInvoice, UnpaidReceivedInvoice }
            };
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
}
