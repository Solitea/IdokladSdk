using System;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Modifiers
{
    [TestFixture]
    public class FilterExpressionTests
    {
        private static readonly object[] TestData =
        {
            new object[] { "DateLastChange", FilterOperator.Lt, new DateTime(2019, 4, 22, 23, 45, 15), "(DateLastChange~lt~2019-04-22 23:45:15.000)" },
            new object[] { "StockBalance", FilterOperator.Lte, 100, "(StockBalance~lte~100)" },
            new object[] { "DocumentType", FilterOperator.Gt, 3, "(DocumentType~gt~3)" },
            new object[] { "PaymentStatus", FilterOperator.Gte, 1, "(PaymentStatus~gte~1)" },
            new object[] { "IsPaid", FilterOperator.Eq, true, "(IsPaid~eq~true)" },
            new object[] { "Exported", FilterOperator.Neq, false, "(Exported~!eq~false)" },
            new object[] { "Name", FilterOperator.Ct, "x", "(Name~ct:base64~eA==)", FilterValueCoding.Base64 },
            new object[] { "Name", FilterOperator.Nct, "x", "(Name~!ct:base64~eA==)", FilterValueCoding.Base64 },
            new object[] { "Name", FilterOperator.Eq, "Sey, #, (( )~and~or;'", "(Name~eq:base64~U2V5LCAjLCAoKCApfmFuZH5vcjsn)", FilterValueCoding.Base64 }
        };

        [TestCaseSource(nameof(TestData))]
        public void FilterExpression_ReturnsCorrectString(string name, FilterOperator @operator, object value, string expectedResult, FilterValueCoding valueCoding = FilterValueCoding.None)
        {
            // Arrange
            var expression = new FilterExpression(name, @operator, value, valueCoding);

            // Act
            var expressionString = expression.ToString();

            // Assert
            Assert.That(expressionString, Is.EqualTo(expectedResult));
        }
    }
}
