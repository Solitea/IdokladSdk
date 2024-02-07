using System;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;
using IdokladSdk.UnitTests.Tests.Modifiers.Model;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Modifiers
{
    [TestFixture]
    public class FilterModifierTests
    {
        [Test]
        public void FilterModifier_WithoutFilters_ReturnsNull()
        {
            // Arrange
            var modifier = new FilterModifier<TestFilter>();

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.That(queryParams, Is.Null);
        }

        [Test]
        public void FilterModifier_SingleFilter_ReturnsCorrectQueryParam()
        {
            // Arrange
            var modifier = new FilterModifier<TestFilter>();
            Func<TestFilter, FilterExpression> filterExpression = (f) => f.Name.Contains("a");
            modifier.Filter(filterExpression);

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.That(queryParams.Count, Is.EqualTo(1));
            Assert.That(queryParams.TryGetValue("filter", out var filter), Is.True);
            var filterString = GetFilterExpression(filterExpression);
            Assert.That(filter, Is.EqualTo(filterString));
        }

        [Test]
        public void FilterModifier_MultipleFiltersAtOnce_ReturnsCorrectQueryParam()
        {
            // Arrange
            var modifier = new FilterModifier<TestFilter>();
            Func<TestFilter, FilterExpression> filterExpression1 = (f) => f.Name.Contains("a");
            Func<TestFilter, FilterExpression> filterExpression2 = (f) => f.Date.IsLowerThan(DateTime.Now);
            modifier.Filter((f) => filterExpression1(f) || filterExpression2(f));

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.That(queryParams.Count, Is.EqualTo(1));
            Assert.That(queryParams.TryGetValue("filter", out var filter), Is.True);
            var filter1 = GetFilterExpression(filterExpression1);
            var filter2 = GetFilterExpression(filterExpression2);
            Assert.That(filter, Is.EqualTo($"({filter1}~or~{filter2})"));
        }

        [Test]
        public void FilterModifier_MultipleFiltersOneByOne_ReturnsCorrectQueryParam()
        {
            // Arrange
            var modifier = new FilterModifier<TestFilter>();
            Func<TestFilter, FilterExpressionBase> filterExpression1 = (f) => f.Id.IsEqual(100);
            Func<TestFilter, FilterExpressionBase> filterExpression2 = (f) => f.Name.Contains("a.s.");
            Func<TestFilter, FilterExpressionBase> filterExpression3 = (f) => f.Date.IsEqual(DateTime.Now);
            modifier.Filter(f => filterExpression1(f) && filterExpression2(f) && filterExpression3(f));

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.That(queryParams.Count, Is.EqualTo(1));
            Assert.That(queryParams.TryGetValue("filter", out var filter), Is.True);
            var filter1 = GetFilterExpression(filterExpression1);
            var filter2 = GetFilterExpression(filterExpression2);
            var filter3 = GetFilterExpression(filterExpression3);
            Assert.That(filter, Is.EqualTo($"(({filter1}~and~{filter2})~and~{filter3})"));
        }

        [Test]
        public void FilterModifier_TwoExpressionsWithAnd_ReturnsCorrectQueryParam()
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
        public void FilterModifier_ThreeExpressionsWithOr_ReturnsCorrectQueryParam()
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
        public void FilterModifier_AddSingleFilterAfterComplexFilter_ThrowsException()
        {
            // Arrange
            var modifier = new FilterModifier<TestFilter>();
            modifier.Filter(f => f.Name.Contains("a.s.") || f.Name.Contains("s.r.o."));

            // Act + Assert
            Assert.Throws<InvalidOperationException>(() => modifier.Filter(f => f.Id.IsEqual(1)));
        }

        [Test]
        public void FilterModifier_AddComplexFilterAfterSingleFilter_ThrowsException()
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

        private string GetFilterExpression(Func<TestFilter, FilterExpressionBase> filter)
        {
            var filterableObject = new TestFilter();
            var filterExpression = filter.Invoke(filterableObject);

            return filterExpression.ToString();
        }
    }
}
