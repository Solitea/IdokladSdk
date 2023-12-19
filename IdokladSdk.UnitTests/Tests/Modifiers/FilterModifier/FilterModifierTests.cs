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
            Assert.That(queryParams, Is.Null);
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
            Assert.That(queryParams.Count, Is.EqualTo(2));
            Assert.That(queryParams.TryGetValue("filter", out var filter), Is.True);
            var filterString = GetFilterExpression(filterExpression);
            Assert.That(filter, Is.EqualTo(filterString));
            Assert.That(queryParams.TryGetValue("filterType", out var filterType), Is.True);
            Assert.That(filterType, Is.EqualTo("and"));
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
            Assert.That(queryParams.Count, Is.EqualTo(2));
            Assert.That(queryParams.TryGetValue("filter", out var filter), Is.True);
            var filter1 = GetFilterExpression(filterExpression1);
            var filter2 = GetFilterExpression(filterExpression2);
            Assert.That(filter, Is.EqualTo($"{filter1}|{filter2}"));
            Assert.That(queryParams.TryGetValue("filterType", out var filterType), Is.True);
            Assert.That(filterType, Is.EqualTo("or"));
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
            Assert.That(queryParams.Count, Is.EqualTo(2));
            Assert.That(queryParams.TryGetValue("filter", out var filter), Is.True);
            var filter1 = GetFilterExpression(filterExpression1);
            var filter2 = GetFilterExpression(filterExpression2);
            var filter3 = GetFilterExpression(filterExpression3);
            Assert.That(filter, Is.EqualTo($"{filter1}|{filter2}|{filter3}"));
            Assert.That(queryParams.TryGetValue("filterType", out var filterType), Is.True);
            Assert.That(filterType, Is.EqualTo("and"));
        }

        [Test]
        public void FilterModifier_TwoSimpleExpressionsWithAnd_ReturnsCorrectQueryParam()
        {
            // Arrange
            var modifier = new FilterModifier<TestFilter>();
            Func<TestFilter, FilterExpression> filterExpression1 = (f) => f.Id.IsEqual(100);
            Func<TestFilter, FilterExpression> filterExpression2 = (f) => f.Name.Contains("a.s.");
            modifier.Filter(f => filterExpression1(f) && filterExpression2(f));

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.That(queryParams.Count, Is.EqualTo(1));
            Assert.That(queryParams.TryGetValue("filter", out var filter), Is.True);
            var filter1 = GetFilterExpression(filterExpression1);
            var filter2 = GetFilterExpression(filterExpression2);
            Assert.That(filter, Is.EqualTo($"({filter1}~and~{filter2})"));
        }

        [Test]
        public void FilterModifier_ThreeSimpleExpressionsWithOr_ReturnsCorrectQueryParam()
        {
            // Arrange
            var modifier = new FilterModifier<TestFilter>();
            Func<TestFilter, FilterExpression> filterExpression1 = (f) => f.Name.Contains("a.s.");
            Func<TestFilter, FilterExpression> filterExpression2 = (f) => f.Name.Contains("s.r.o.");
            Func<TestFilter, FilterExpression> filterExpression3 = (f) => f.Name.Contains("k.s.");
            modifier.Filter(f => filterExpression1(f) || filterExpression2(f) || filterExpression3(f));

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.That(queryParams.Count, Is.EqualTo(1));
            Assert.That(queryParams.TryGetValue("filter", out var filter), Is.True);
            var filter1 = GetFilterExpression(filterExpression1);
            var filter2 = GetFilterExpression(filterExpression2);
            var filter3 = GetFilterExpression(filterExpression3);
            Assert.That(filter, Is.EqualTo($"(({filter1}~or~{filter2})~or~{filter3})"));
        }

        [Test]
        public void FilterModifier_ComplexExpression_ReturnsCorrectQueryParam()
        {
            // Arrange
            var modifier = new FilterModifier<TestFilter>();
            Func<TestFilter, FilterExpression> filterExpression1 = (f) => f.Id.IsEqual(100);
            Func<TestFilter, FilterExpression> filterExpression2 = (f) => f.Name.Contains("a.s.");
            Func<TestFilter, FilterExpression> filterExpression3 = (f) => f.Name.Contains("s.r.o.");
            Func<TestFilter, FilterExpression> filterExpression4 = (f) => f.Name.Contains("s.r.o.");
            Func<TestFilter, FilterExpression> filterExpression5 = (f) => f.Date.IsLowerThan(new DateTime(2020, 1, 1));
            modifier.Filter(f => (filterExpression1(f) && (filterExpression2(f) || filterExpression3(f) || filterExpression4(f))) || filterExpression5(f));

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.That(queryParams.Count, Is.EqualTo(1));
            Assert.That(queryParams.TryGetValue("filter", out var filter), Is.True);
            var filter1 = GetFilterExpression(filterExpression1);
            var filter2 = GetFilterExpression(filterExpression2);
            var filter3 = GetFilterExpression(filterExpression3);
            var filter4 = GetFilterExpression(filterExpression4);
            var filter5 = GetFilterExpression(filterExpression5);
            Assert.That(filter, Is.EqualTo($"(({filter1}~and~(({filter2}~or~{filter3})~or~{filter4}))~or~{filter5})"));
        }

        [Test]
        public void FilterModifier_AddSimpleFilterAfterComplexFilter_ThrowsException()
        {
            // Arrange
            var modifier = new FilterModifier<TestFilter>();
            modifier.Filter(f => f.Name.Contains("a.s.") || f.Name.Contains("s.r.o."));

            // Act + Assert
            Assert.Throws<InvalidOperationException>(() => modifier.Filter(f => f.Id.IsEqual(1)));
        }

        [Test]
        public void FilterModifier_AddComplexFilterAfterSimpleFilter_ThrowsException()
        {
            // Arrange
            var modifier = new FilterModifier<TestFilter>();
            modifier.Filter(f => f.Id.IsEqual(1));

            // Act + Assert
            Assert.Throws<InvalidOperationException>(() => modifier.Filter(f => f.Name.Contains("a.s.") || f.Name.Contains("s.r.o.")));
        }

        [Test]
        public void FilterModifier_AddComplexFilterAfterComplexFilter_ThrowsException()
        {
            // Arrange
            var modifier = new FilterModifier<TestFilter>();
            modifier.Filter(f => f.Name.Contains("a.s.") || f.Name.Contains("s.r.o."));

            // Act + Assert
            Assert.Throws<InvalidOperationException>(() => modifier.Filter(f => f.Name.Contains("aaa") || f.Name.Contains("bbb")));
        }

        [Test]
        public void FilterModifier_AddComplexFilterAfterFilterType_ThrowsException()
        {
            // Arrange
            var modifier = new FilterModifier<TestFilter>();
            modifier.FilterType(FilterType.Or);

            // Act + Assert
            Assert.Throws<InvalidOperationException>(() => modifier.Filter(f => f.Name.Contains("a.s.") || f.Name.Contains("s.r.o.")));
        }

        [Test]
        public void FilterModifier_AddFilterTypeAfterComplexFilter_ThrowsException()
        {
            // Arrange
            var modifier = new FilterModifier<TestFilter>();
            modifier.Filter(f => f.Name.Contains("a.s.") || f.Name.Contains("s.r.o."));

            // Act + Assert
            Assert.Throws<InvalidOperationException>(() => modifier.FilterType(FilterType.And));
        }

        private string GetFilterExpression(Func<TestFilter, FilterExpression> filter)
        {
            var filterableObject = new TestFilter();
            var filterExpression = filter.Invoke(filterableObject);

            return filterExpression.ToString();
        }
    }
}
