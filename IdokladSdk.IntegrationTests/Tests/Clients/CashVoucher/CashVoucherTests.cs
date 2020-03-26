using System.Collections.Generic;
using System.Linq;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.CashVoucher
{
    [TestFixture]
    public partial class CashVoucherTests : TestBase
    {
        private const int CashVoucherId = 587154;
        private const int UnpaidIssuedInvoice = 914456;
        private const int UnpaidReceivedInvoice = 165460;

        private CashVoucherClient _client;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            InitDokladApi();
            _client = DokladApi.CashVoucherClient;
        }

        [Test]
        public void Default_SucessfullyGet()
        {
            // Act
            var cashVoucherIssue = _client.Default(MovementType.Issue).AssertResult();
            var cashVoucherEntry = _client.Default(MovementType.Entry).AssertResult();

            // Assert
            Assert.AreNotEqual(cashVoucherIssue.MovementType, cashVoucherEntry.MovementType);
            Assert.AreEqual(cashVoucherIssue.MovementType, MovementType.Issue);
            Assert.AreEqual(cashVoucherEntry.MovementType, MovementType.Entry);
        }

        [Test]
        [TestCaseSource(nameof(GetDefaultVouchers))]
        public void Default_SucessfullyGet(MovementType movementType, InvoiceType invoiceType, int invoiceId)
        {
            // Act
            var cashVoucher = _client.Default(movementType, invoiceType, invoiceId).AssertResult();

            // Assert
            Assert.AreEqual(cashVoucher.MovementType, movementType);
            Assert.AreEqual(cashVoucher.InvoiceType, invoiceType);
            Assert.AreEqual(cashVoucher.InvoiceId, invoiceId);
        }

        [Test]
        public void Detail_SucessfullyGet()
        {
            // Act
            var cashVoucher = _client.Detail(CashVoucherId).Get().AssertResult();

            // Assert
            Assert.AreEqual(cashVoucher.Id, CashVoucherId);
            Assert.AreEqual(cashVoucher.Items.First().Price, 500m);
        }

        [Test]
        public void List_SucessfullyGet()
        {
            // Act
            var cashVouchers = _client.List().Get().AssertResult();

            // Assert
            Assert.GreaterOrEqual(cashVouchers.TotalItems, 1);
        }

        [Test]
        public void Post_Sucessfully()
        {
            // Arrange
            var cashVoucherName = $"Issued invoice for test: {UnpaidIssuedInvoice}";

            // Act
            var cashVoucher = _client.Default(MovementType.Issue, InvoiceType.Issued, UnpaidIssuedInvoice).AssertResult();
            cashVoucher.Name = cashVoucherName;
            var postedCashVoucher = _client.Post(cashVoucher).AssertResult();
            var paired = _client.Pair(postedCashVoucher.Id, InvoiceType.Issued, UnpaidIssuedInvoice).AssertResult();
            var deleted = _client.Delete(postedCashVoucher.Id).AssertResult();

            // Assert
            Assert.AreEqual(cashVoucher.InvoiceId, UnpaidIssuedInvoice);
            Assert.AreEqual(postedCashVoucher.InvoiceId, UnpaidIssuedInvoice);
            Assert.AreEqual(postedCashVoucher.Name, cashVoucherName);
            Assert.IsTrue(paired);
            Assert.IsTrue(deleted);
        }

        private static IList<object> GetDefaultVouchers()
        {
            return new List<object>
            {
                new object[] { MovementType.Issue, InvoiceType.Issued, UnpaidIssuedInvoice },
                new object[] { MovementType.Entry, InvoiceType.Received, UnpaidReceivedInvoice }
            };
        }
    }
}
