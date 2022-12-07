using IdokladSdk.Requests.Core.Modifiers.Select.Common;
using IdokladSdk.UnitTests.Tests.Modifiers.Model;
using IdokladSdk.UnitTests.Tests.Modifiers.Select.SelectModels;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Modifiers.Select;

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
        Assert.IsNull(queryParams);
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
        Assert.AreEqual(1, queryParams.Count);
        Assert.IsTrue(queryParams.TryGetValue("select", out var select));
        Assert.AreEqual("Id", select);
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
        Assert.AreEqual(1, queryParams.Count);
        Assert.IsTrue(queryParams.TryGetValue("select", out var select));
        Assert.AreEqual("Name,Model(Text),Items(Text),Id", select);
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
        Assert.AreEqual(1, queryParams.Count);
        Assert.IsTrue(queryParams.TryGetValue("select", out var select));
        Assert.AreEqual("Name", select);
    }
}
