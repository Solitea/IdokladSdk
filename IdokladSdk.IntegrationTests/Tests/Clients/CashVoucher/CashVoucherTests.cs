using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.CashVoucher;
using IdokladSdk.Models.CashVoucher.Pair;
using IdokladSdk.Models.CashVoucher.Recount;
using IdokladSdk.Models.Common.PairedDocument;
using IdokladSdk.Models.IssuedInvoice;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.CashVoucher
{
    [TestFixture]
    public class CashVoucherTests : TestBase
    {
        private const int CashVoucherId = 643249;
        private const int PartnerId = 323823;
        private const int UnpaidIssuedInvoice = 914456;
        private const int UnpaidReceivedInvoice = 165460;
        private readonly List<int> _invoiceIdsToDelete = new List<int>();

        private CashVoucherClient _client;
        private IssuedInvoiceClient _issuedInvoiceClient;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            InitDokladApi();
            _client = DokladApi.CashVoucherClient;
            _issuedInvoiceClient = DokladApi.IssuedInvoiceClient;
        }

        [Test]
        public async Task Default_SuccessfullyGetAsync()
        {
            // Act
            var cashVoucherIssue = await _client.DefaultAsync(MovementType.Issue).AssertResult();
            var cashVoucherEntry = await _client.DefaultAsync(MovementType.Entry).AssertResult();

            // Assert
            Assert.That(cashVoucherIssue.MovementType, Is.Not.EqualTo(cashVoucherEntry.MovementType));
            Assert.That(cashVoucherIssue.MovementType, Is.EqualTo(MovementType.Issue));
            Assert.That(cashVoucherEntry.MovementType, Is.EqualTo(MovementType.Entry));
        }

        [Test]
        [TestCaseSource(nameof(GetDefaultVouchers))]
        public async Task Default_SuccessfullyGetAsync(PairedDocumentType documentType, int documentId)
        {
            // Act
            var cashVoucher = await _client.DefaultAsync(documentType, documentId).AssertResult();

            // Assert
            Assert.That(cashVoucher.PairedDocument.DocumentType, Is.EqualTo(documentType));
            Assert.That(cashVoucher.PairedDocument.DocumentId, Is.EqualTo(documentId));
        }

        [Test]
        public async Task Detail_SuccessfullyGetAsync()
        {
            // Act
            var cashVoucher = await _client.Detail(CashVoucherId).GetAsync().AssertResult();

            // Assert
            Assert.That(cashVoucher.Id, Is.EqualTo(CashVoucherId));
            Assert.That(cashVoucher.Items.First().Price, Is.EqualTo(150m));
        }

        [Test]
        public async Task List_SuccessfullyGetAsync()
        {
            // Act
            var cashVouchers = await _client.List().GetAsync().AssertResult();

            // Assert
            Assert.That(cashVouchers.TotalItems, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public async Task PairWithDocument_SuccessfullyPaired()
        {
            // Arrange
            var invoice = await CreateInvoice();
            _invoiceIdsToDelete.Add(invoice.Id);
            var cashVoucherForPairing = await CreateCashVoucher();
            var pairModel = new CashVoucherPairPostModel
            {
                CashVoucherId = cashVoucherForPairing.Id,
                DocumentId = invoice.Id,
                DocumentType = PairedDocumentType.IssuedInvoice
            };

            // Act
            var pairResult = await _client.PairWithDocumentAsync(pairModel).AssertResult();
            var cashVoucher = await _client.Detail(cashVoucherForPairing.Id).GetAsync().AssertResult();

            // Assert
            Assert.That(pairResult, Is.True);
            Assert.That(cashVoucher.PairedDocument.DocumentId, Is.EqualTo(invoice.Id));
            Assert.That(cashVoucher.PairedDocument.DocumentType, Is.EqualTo(PairedDocumentType.IssuedInvoice));
        }

        [Test]
        public async Task Post_SuccessfullyAsync()
        {
            // Arrange
            var cashVoucherName = $"Issued invoice for test: {UnpaidIssuedInvoice}";

            // Act
            var defaultCashVoucher = await _client.DefaultAsync(PairedDocumentType.IssuedInvoice, UnpaidIssuedInvoice).AssertResult();
            defaultCashVoucher.Name = cashVoucherName;
            var cashVoucher = await _client.PostAsync(defaultCashVoucher).AssertResult();
            var deleteResult = await _client.DeleteAsync(cashVoucher.Id).AssertResult();

            // Assert
            Assert.That(cashVoucher.PairedDocument.DocumentId, Is.EqualTo(UnpaidIssuedInvoice));
            Assert.That(cashVoucher.PairedDocument.DocumentType, Is.EqualTo(PairedDocumentType.IssuedInvoice));
            Assert.That(cashVoucher.Name, Is.EqualTo(cashVoucherName));
            Assert.That(deleteResult, Is.True);
        }

        [Test]
        public async Task Delete_CashVoucherDeletedSuccessfully()
        {
            // Arrange
            var cashVoucherName = $"Issued invoice for test: {UnpaidIssuedInvoice}";
            var defaultCashVoucher = await _client.DefaultAsync(PairedDocumentType.IssuedInvoice, UnpaidIssuedInvoice).AssertResult();
            defaultCashVoucher.Name = cashVoucherName;
            var cashVoucher = await _client.PostAsync(defaultCashVoucher).AssertResult();

            // Act
            var deleteResult = await _client.DeleteAsync(cashVoucher.Id).AssertResult();

            // Assert
            Assert.That(deleteResult, Is.True);
        }

        [Test]
        public async Task Recount_SuccessfullyRecounted()
        {
            // Arrange
            var recountModel = new CashVoucherRecountPostModel
            {
                CurrencyId = 1,
                DateOfTransaction = DateTime.UtcNow,
                ExchangeRate = 1,
                ExchangeRateAmount = 1,
                Items =
                [
                    new ()
                    {
                        CustomVat = 10,
                        Id = 1,
                        UnitPrice = 100,
                        PriceType = PriceType.WithoutVat,
                        VatRateType = VatRateType.Basic,
                    },
                ],
            };

            // Act
            var result = await _client.RecountAsync(recountModel).AssertResult();

            // Assert
            var vatRateSummaryItem = result.Prices.VatRateSummary.First();
            Assert.That(vatRateSummaryItem.TotalWithoutVat, Is.EqualTo(100));
            Assert.That(vatRateSummaryItem.TotalWithVat, Is.EqualTo(110));
        }

        [Test]
        public async Task Update_SuccessfullyUpdates()
        {
            // Arrange
            var originalCashVoucher = await _client.Detail(CashVoucherId).GetAsync().AssertResult();
            var updatedName = $"UpdatedName_{DateTime.UtcNow:dd/MM/yyyy/mm/ss}";
            Assert.That(originalCashVoucher.Name, Is.Not.EqualTo(updatedName));
            var cashVoucherPatchModel = new CashVoucherPatchModel { Id = CashVoucherId, Name = updatedName };

            // Act
            var patchResult = await _client.UpdateAsync(cashVoucherPatchModel).AssertResult();

            // Assert
            Assert.That(patchResult.Name, Is.EqualTo(updatedName));
        }

        [Test]
        public async Task Update_SuccessfullyUnpairs()
        {
            // Arrange
            var issuedInvoice = await CreateInvoice();
            _invoiceIdsToDelete.Add(issuedInvoice.Id);
            var defaultCashVoucher = await _client.DefaultAsync(PairedDocumentType.IssuedInvoice, issuedInvoice.Id).AssertResult();
            var postedCashVoucher = await _client.PostAsync(defaultCashVoucher).AssertResult();
            Assert.That(postedCashVoucher.PairedDocument, Is.Not.Null);
            var bankStatementPatchModel = new CashVoucherPatchModel { Id = postedCashVoucher.Id, PairedDocument = new PairedDocumentPatchModel { DocumentId = null, DocumentType = null }, };

            // Act
            var patchResult = await _client.UpdateAsync(bankStatementPatchModel).AssertResult();

            // Assert
            Assert.That(patchResult.PairedDocument, Is.Null);
        }

        [OneTimeTearDown]
        public async Task TearDown()
        {
            var tasks = _invoiceIdsToDelete.Select(id => _issuedInvoiceClient.DeleteAsync(id));
            await Task.WhenAll(tasks);
        }

        private static IList<object> GetDefaultVouchers()
        {
            return new List<object> { new object[] { PairedDocumentType.IssuedInvoice, UnpaidIssuedInvoice }, new object[] { PairedDocumentType.ReceivedInvoice, UnpaidReceivedInvoice } };
        }

        private async Task<IssuedInvoiceGetModel> CreateInvoice()
        {
            var defaultInvoice = await _issuedInvoiceClient.DefaultAsync().AssertResult();
            defaultInvoice.PartnerId = PartnerId;
            defaultInvoice.Description = "Invoice for pair";
            defaultInvoice.Items.Clear();
            defaultInvoice.Items.Add(new IssuedInvoiceItemPostModel { Name = "Test", Amount = 1, UnitPrice = 150 });
            var invoice = await _issuedInvoiceClient.PostAsync(defaultInvoice).AssertResult();
            return invoice;
        }

        private async Task<CashVoucherGetModel> CreateCashVoucher()
        {
            var model = new CashVoucherPostModel
            {
                CashRegisterId = 173503,
                DateOfTransaction = DateTime.UtcNow,
                DocumentSerialNumber = 300,
                IsIncomeTax = true,
                Items = new List<CashVoucherItemPostModel>()
                {
                    new CashVoucherItemPostModel
                    {
                        Name = "Test",
                        Price = 150,
                        PriceType = PriceTypeWithoutOnlyBase.WithoutVat,
                        VatRateType = VatRateType.Zero,
                    }
                },
                MovementType = MovementType.Entry,
                Name = "Test",
                Person = "TestPerson",
                VariableSymbol = "20250500",
            };

            var casVoucher = await _client.PostAsync(model).AssertResult();
            return casVoucher;
        }
    }
}
