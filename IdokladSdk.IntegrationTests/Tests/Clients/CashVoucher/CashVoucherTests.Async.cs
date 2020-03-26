using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.CashVoucher
{
    public partial class CashVoucherTests
    {
        [Test]
        public async Task Default_SucessfullyGetAsync()
        {
            // Act
            var cashVoucherIssue = (await _client.DefaultAsync(MovementType.Issue)).AssertResult();
            var cashVoucherEntry = (await _client.DefaultAsync(MovementType.Entry)).AssertResult();

            // Assert
            Assert.AreNotEqual(cashVoucherIssue.MovementType, cashVoucherEntry.MovementType);
            Assert.AreEqual(cashVoucherIssue.MovementType, MovementType.Issue);
            Assert.AreEqual(cashVoucherEntry.MovementType, MovementType.Entry);
        }

        [Test]
        [TestCaseSource(nameof(GetDefaultVouchers))]
        public async Task Default_SucessfullyGetAsync(MovementType movementType, InvoiceType invoiceType, int invoiceId)
        {
            // Act
            var cashVoucher = (await _client.DefaultAsync(movementType, invoiceType, invoiceId)).AssertResult();

            // Assert
            Assert.AreEqual(cashVoucher.MovementType, movementType);
            Assert.AreEqual(cashVoucher.InvoiceType, invoiceType);
            Assert.AreEqual(cashVoucher.InvoiceId, invoiceId);
        }

        [Test]
        public async Task Detail_SucessfullyGetAsync()
        {
            // Act
            var cashVoucher = (await _client.Detail(CashVoucherId).GetAsync()).AssertResult();

            // Assert
            Assert.AreEqual(cashVoucher.Id, CashVoucherId);
            Assert.AreEqual(cashVoucher.Items.First().Price, 500m);
        }

        [Test]
        public async Task List_SucessfullyGetAsync()
        {
            // Act
            var cashVouchers = (await _client.List().GetAsync()).AssertResult();

            // Assert
            Assert.GreaterOrEqual(cashVouchers.TotalItems, 1);
        }

        [Test]
        public async Task Post_SucessfullyAsync()
        {
            // Arrange
            var cashVoucherName = $"Issued invoice for test: {UnpaidIssuedInvoice}";

            // Act
            var cashVoucher = (await _client.DefaultAsync(MovementType.Issue, InvoiceType.Issued, UnpaidIssuedInvoice)).AssertResult();
            cashVoucher.Name = cashVoucherName;
            var postedCashVoucher = (await _client.PostAsync(cashVoucher)).AssertResult();
            var paired = (await _client.PairAsync(postedCashVoucher.Id, InvoiceType.Issued, UnpaidIssuedInvoice)).AssertResult();
            var deleted = (await _client.DeleteAsync(postedCashVoucher.Id)).AssertResult();

            // Assert
            Assert.AreEqual(cashVoucher.InvoiceId, UnpaidIssuedInvoice);
            Assert.AreEqual(postedCashVoucher.InvoiceId, UnpaidIssuedInvoice);
            Assert.AreEqual(postedCashVoucher.Name, cashVoucherName);
            Assert.IsTrue(paired);
            Assert.IsTrue(deleted);
        }
    }
}
