using System;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;
using IdokladSdk.UnitTests.Tests.Modifiers.Model;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Modifiers
{
    [TestFixture]
    public class FilterModifierTests
    {
        [TestCase]
        public void FilterModifier_WithoutFilters_ReturnsNull()
        {
            // Arrange
            var modifier = new FilterModifier<TestFilter>();

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.IsNull(queryParams);
        }

        [TestCase]
        public void FilterModifier_SingleFilter_ReturnsCorrectQueryParam()
        {
            // Arrange
            var modifier = new FilterModifier<TestFilter>();
            Func<TestFilter, FilterExpression> filterExpression = (f) => f.Name.Contains("a");
            modifier.Filter(filterExpression);

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.AreEqual(2, queryParams.Count);
            Assert.IsTrue(queryParams.TryGetValue("filter", out var filter));
            var filterString = GetFilterExpression(filterExpression);
            Assert.AreEqual(filterString, filter);
            Assert.IsTrue(queryParams.TryGetValue("filterType", out var filterType));
            Assert.AreEqual("and", filterType);
        }

        [TestCase]
        public void FilterModifier_MultipleFiltersAtOnce_ReturnsCorrectQueryParam()
        {
            // Arrange
            var modifier = new FilterModifier<TestFilter>();
            Func<TestFilter, FilterExpression> filterExpression1 = (f) => f.Name.Contains("a");
            Func<TestFilter, FilterExpression> filterExpression2 = (f) => f.Date.IsLowerThan(DateTime.Now);
            modifier.Filter(filterExpression1, filterExpression2);
            modifier.FilterType(FilterType.Or);

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.AreEqual(2, queryParams.Count);
            Assert.IsTrue(queryParams.TryGetValue("filter", out var filter));
            var filter1 = GetFilterExpression(filterExpression1);
            var filter2 = GetFilterExpression(filterExpression2);
            Assert.AreEqual($"{filter1}|{filter2}", filter);
            Assert.IsTrue(queryParams.TryGetValue("filterType", out var filterType));
            Assert.AreEqual("or", filterType);
        }

        [TestCase]
        public void FilterModifier_MultipleFiltersOneByOne_ReturnsCorrectQueryParam()
        {
            // Arrange
            var modifier = new FilterModifier<TestFilter>();
            Func<TestFilter, FilterExpression> filterExpression1 = (f) => f.Id.IsEqual(100);
            Func<TestFilter, FilterExpression> filterExpression2 = (f) => f.Name.Contains("a.s.");
            Func<TestFilter, FilterExpression> filterExpression3 = (f) => f.Date.IsEqual(DateTime.Now);
            modifier.Filter(filterExpression1);
            modifier.Filter(filterExpression2);
            modifier.Filter(filterExpression3);

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.AreEqual(2, queryParams.Count);
            Assert.IsTrue(queryParams.TryGetValue("filter", out var filter));
            var filter1 = GetFilterExpression(filterExpression1);
            var filter2 = GetFilterExpression(filterExpression2);
            var filter3 = GetFilterExpression(filterExpression3);
            Assert.AreEqual($"{filter1}|{filter2}|{filter3}", filter);
            Assert.IsTrue(queryParams.TryGetValue("filterType", out var filterType));
            Assert.AreEqual("and", filterType);
        }

        private string GetFilterExpression(Func<TestFilter, FilterExpression> filter)
        {
            var filterableObject = new TestFilter();
            var filterExpression = filter.Invoke(filterableObject);

            return filterExpression.ToString();
        }
    }
}
