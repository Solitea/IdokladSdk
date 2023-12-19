using IdokladSdk.Requests.Core.Modifiers.Select.Common;
using IdokladSdk.UnitTests.Tests.Modifiers.Model;
using IdokladSdk.UnitTests.Tests.Modifiers.Select.SelectModels;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Modifiers.Select
{
    public class SelectModifierTests
    {
        [Test]
        public void SelectModifier_WithoutSelect_ReturnsNull()
        {
            // Arrange
            var modifier = new SelectModifier<TestSelect>();

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.That(queryParams, Is.Null);
        }

        [Test]
        public void SelectModifier_NewExpression_SingleSelect_SingleProperty_ReturnsCorrectQueryParam()
        {
            // Arrange
            var modifier = new SelectModifier<TestSelect>();
            modifier.Select<BaseSelect>();

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.That(queryParams.Count, Is.EqualTo(1));
            Assert.That(queryParams.TryGetValue("select", out var select), Is.True);
            Assert.That(select, Is.EqualTo("Id"));
        }

        [Test]
        public void SelectModifier_NewExpression_MultipleExpressions_ReturnsCorrectQueryParamForOnlyLastSelect()
        {
            // Arrange
            var modifier = new SelectModifier<TestSelect>();
            modifier.Select<ExtendSelect>();

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.That(queryParams.Count, Is.EqualTo(1));
            Assert.That(queryParams.TryGetValue("select", out var select), Is.True);
            Assert.That(select, Is.EqualTo("Name,Model(Text),Items(Text),Id"));
        }

        [Test]
        public void SelectModifier_CustomModel_ReturnsCorrectQueryParam()
        {
            // Arrange
            var modifier = new SelectModifier<TestSelect>();
            modifier.Select<TestSelectCustomModel>();

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.That(queryParams.Count, Is.EqualTo(1));
            Assert.That(queryParams.TryGetValue("select", out var select), Is.True);
            Assert.That(select, Is.EqualTo("Name"));
        }
    }
}
