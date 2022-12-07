using System;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Modifiers;

[TestFixture]
public class FilterExpressionTests
{
    private static readonly object[] TestData =
    {
        new object[] { "DateLastChange", FilterOperator.Lt, new DateTime(2019, 4, 22, 23, 45, 15), "DateLastChange~lt~2019-04-22 23:45" },
        new object[] { "StockBalance", FilterOperator.Lte, 100, "StockBalance~lte~100" },
        new object[] { "DocumentType", FilterOperator.Gt, 3, "DocumentType~gt~3" },
        new object[] { "PaymentStatus", FilterOperator.Gte, 1, "PaymentStatus~gte~1" },
        new object[] { "IsPaid", FilterOperator.Eq, true, "IsPaid~eq~true" },
        new object[] { "Exported", FilterOperator.Neq, false, "Exported~!eq~false" },
        new object[] { "Name", FilterOperator.Ct, "x", "Name~ct~x" },
        new object[] { "Name", FilterOperator.Nct, "x", "Name~!ct~x" }
    };

    [TestCaseSource(nameof(TestData))]
    public void FilterExpression_ReturnsCorrectString(string name, FilterOperator @operator, object value, string expectedResult)
    {
        // Arrange
        var expression = new FilterExpression(name, @operator, value);

        // Act
        var expressionString = expression.ToString();

        // Assert
        Assert.AreEqual(expectedResult, expressionString);
    }
}
