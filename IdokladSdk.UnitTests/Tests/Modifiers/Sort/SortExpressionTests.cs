using IdokladSdk.Requests.Core.Modifiers.Sort.Common;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Modifiers.Sort
{
    public class SortExpressionTests
    {
        private static readonly object[] TestData =
        {
            new object[] { "Id", SortDirection.Asc, "Id~Asc" },
            new object[] { "Id", SortDirection.Desc, "Id~Desc" },
        };

        [TestCaseSource(nameof(TestData))]
        public void SortExpression_ReturnsCorrectString(string name, SortDirection sort, string expectedResult)
        {
            // Arrange
            var expression = new SortExpression(name, sort);

            // Act
            var expressionString = expression.ToString();

            // Assert
            Assert.AreEqual(expectedResult, expressionString);
        }
    }
}
