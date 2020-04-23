using System;
using IdokladSdk.Requests.Core.Modifiers.Sort.Common;
using IdokladSdk.UnitTests.Tests.Modifiers.Model;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Modifiers.Sort
{
    public class SortModifierTests
    {
        [Test]
        public void SortModifier_WithoutSort_ReturnsNull()
        {
            // Arrange
            var modifier = new SortModifier<TestSort>();

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.IsNull(queryParams);
        }

        [Test]
        public void SortModifier_SingleSort_ReturnsCorrectQueryParam()
        {
            // Arrange
            var modifier = new SortModifier<TestSort>();
            Func<TestSort, SortExpression> sortExpression = (f) => f.Id.Asc();
            modifier.Sort(sortExpression);

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.AreEqual(1, queryParams.Count);
            Assert.IsTrue(queryParams.TryGetValue("sort", out var sort));
            var sortString = GetSortExpression(sortExpression);
            Assert.AreEqual(sortString, sort);
        }

        [Test]
        public void SortModifier_MultipleSortsAtOnce_ReturnsCorrectQueryParam()
        {
            // Arrange
            var modifier = new SortModifier<TestSort>();
            Func<TestSort, SortExpression> sortExpression1 = (f) => f.Id.Asc();
            Func<TestSort, SortExpression> sortExpression2 = (f) => f.Name.Desc();
            modifier.Sort(sortExpression1, sortExpression2);

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.AreEqual(1, queryParams.Count);
            Assert.IsTrue(queryParams.TryGetValue("sort", out var sort));
            var sort1 = GetSortExpression(sortExpression1);
            var sort2 = GetSortExpression(sortExpression2);
            Assert.AreEqual($"{sort1}|{sort2}", sort);
        }

        [Test]
        public void SortModifier_MultipleSortsOneByOne_ReturnsCorrectQueryParam()
        {
            // Arrange
            var modifier = new SortModifier<TestSort>();
            Func<TestSort, SortExpression> sortExpression1 = (f) => f.Id.Asc();
            Func<TestSort, SortExpression> sortExpression2 = (f) => f.Name.Desc();
            modifier.Sort(sortExpression1);
            modifier.Sort(sortExpression2);

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.AreEqual(1, queryParams.Count);
            Assert.IsTrue(queryParams.TryGetValue("sort", out var sort));
            var sort1 = GetSortExpression(sortExpression1);
            var sort2 = GetSortExpression(sortExpression2);
            Assert.AreEqual($"{sort1}|{sort2}", sort);
        }

        private string GetSortExpression(Func<TestSort, SortExpression> sort)
        {
            var sortableObject = new TestSort();
            var sortExpression = sort.Invoke(sortableObject);

            return sortExpression.ToString();
        }
    }
}
