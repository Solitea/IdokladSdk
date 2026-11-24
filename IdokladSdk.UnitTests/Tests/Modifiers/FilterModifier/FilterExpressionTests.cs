using System;
using IdokladSdk.Enums;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;
using IdokladSdk.Requests.RegisteredSale.Filter;
using IdokladSdk.Requests.SalesReceipt.Filter;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Modifiers
{
    [TestFixture]
    public class FilterExpressionTests
    {
        private static readonly object[] TestData =
        {
            new object[] { "DateLastChange", FilterOperator.Lt, new DateTime(2019, 4, 22, 23, 45, 15), "(DateLastChange~lt~2019-04-22 23:45:15.000)", FilterValueCoding.None },
            new object[] { "StockBalance", FilterOperator.Lte, 100, "(StockBalance~lte~100)", FilterValueCoding.None },
            new object[] { "DocumentType", FilterOperator.Gt, 3, "(DocumentType~gt~3)", FilterValueCoding.None },
            new object[] { "PaymentStatus", FilterOperator.Gte, 1, "(PaymentStatus~gte~1)", FilterValueCoding.None },
            new object[] { "IsPaid", FilterOperator.Eq, true, "(IsPaid~eq~true)", FilterValueCoding.None },
            new object[] { "Exported", FilterOperator.Neq, false, "(Exported~!eq~false)", FilterValueCoding.None },
            new object[] { "Name", FilterOperator.Ct, "x", "(Name~ct:base64~eA==)", FilterValueCoding.Base64 },
            new object[] { "Name", FilterOperator.Nct, "x", "(Name~!ct:base64~eA==)", FilterValueCoding.Base64 },
            new object[] { "Name", FilterOperator.Eq, "Sey, #, (( )~and~or;'", "(Name~eq:base64~U2V5LCAjLCAoKCApfmFuZH5vcjsn)", FilterValueCoding.Base64 }
        };

        [TestCaseSource(nameof(TestData))]
        public void FilterExpression_ReturnsCorrectString(string name, FilterOperator @operator, object value, string expectedResult, FilterValueCoding valueCoding)
        {
            // Arrange
            var expression = new FilterExpression(name, @operator, value, valueCoding);

            // Act
            var expressionString = expression.ToString();

            // Assert
            Assert.That(expressionString, Is.EqualTo(expectedResult));
        }

        [Test]
        public void RegisteredSaleIdFilters_HandleListsAndNullableValues()
        {
            var filter = new RegisteredSaleFilter();

            Assert.That(filter.CashVoucherId.Contains(new[] { 1, 2 }).ToString(), Is.EqualTo("(CashVoucherId~ct~1,2)"));
            Assert.That(filter.CashVoucherId.IsEqual(null).ToString(), Is.EqualTo("(CashVoucherId~eq~null)"));
            Assert.That(filter.IssuedInvoiceId.IsEqual(1).ToString(), Is.EqualTo("(IssuedInvoiceId~eq~1)"));
        }

        [Test]
        public void SalesReceiptEetFilters_UseApiFieldNames()
        {
            var filter = new SalesReceiptFilter();

            Assert.That(filter.IsEet.IsEqual(true).ToString(), Is.EqualTo("(IsEet~eq~true)"));
            Assert.That(filter.EetStatus.IsEqual(EetStatus.Registered).ToString(), Is.EqualTo("(EetStatus~eq~Registered)"));
        }
    }
}
