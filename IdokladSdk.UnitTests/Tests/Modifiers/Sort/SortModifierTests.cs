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
            Assert.That(queryParams, Is.Null);
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
            Assert.That(queryParams.Count, Is.EqualTo(1));
            Assert.That(queryParams.TryGetValue("sort", out var sort), Is.True);
            var sortString = GetSortExpression(sortExpression);
            Assert.That(sort, Is.EqualTo(sortString));
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
            Assert.That(queryParams.Count, Is.EqualTo(1));
            Assert.That(queryParams.TryGetValue("sort", out var sort), Is.True);
            var sort1 = GetSortExpression(sortExpression1);
            var sort2 = GetSortExpression(sortExpression2);
            Assert.That(sort, Is.EqualTo($"{sort1}|{sort2}"));
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
            Assert.That(queryParams.Count, Is.EqualTo(1));
            Assert.That(queryParams.TryGetValue("sort", out var sort), Is.True);
            var sort1 = GetSortExpression(sortExpression1);
            var sort2 = GetSortExpression(sortExpression2);
            Assert.That(sort, Is.EqualTo($"{sort1}|{sort2}"));
        }

        private string GetSortExpression(Func<TestSort, SortExpression> sort)
        {
            var sortableObject = new TestSort();
            var sortExpression = sort.Invoke(sortableObject);

            return sortExpression.ToString();
        }
    }
}
