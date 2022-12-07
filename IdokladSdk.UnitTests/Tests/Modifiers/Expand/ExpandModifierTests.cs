using IdokladSdk.Requests.Core.Modifiers.Expand.Common;
using IdokladSdk.UnitTests.Tests.Modifiers.Model;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Modifiers.Expand;

public class ExpandModifierTests
{
    [Test]
    public void ExpandModifier_WithoutExpand_ReturnsNull()
    {
        // Arrange
        var modifier = new ExpandModifier<TestExpand>();

        // Act
        var queryParams = modifier.GetQueryParameters();

        // Assert
        Assert.IsNull(queryParams);
    }

    [Test]
    public void ExpandModifier_SingleExpand_ShortPath_ReturnsCorrectQueryParam()
    {
        // Arrange
        var modifier = new ExpandModifier<TestExpand>();
        modifier.Include(expand => expand.TestExpandModel1);

        // Act
        var queryParams = modifier.GetQueryParameters();

        // Assert
        Assert.AreEqual(1, queryParams.Count);
        Assert.IsTrue(queryParams.TryGetValue("include", out var expand));
        var expandString = "TestExpandModel1";
        Assert.AreEqual(expandString, expand);
    }

    [Test]
    public void ExpandModifier_SingleExpand_LongPath_ReturnsCorrectQueryParam()
    {
        // Arrange
        var modifier = new ExpandModifier<TestExpand>();
        modifier.Include(expand => expand.TestExpandModel1.TestExpandModel2);

        // Act
        var queryParams = modifier.GetQueryParameters();

        // Assert
        Assert.AreEqual(1, queryParams.Count);
        Assert.IsTrue(queryParams.TryGetValue("include", out var expand));
        var expandString = "TestExpandModel1(TestExpandModel2)";
        Assert.AreEqual(expandString, expand);
    }

    [Test]
    public void ExpandModifier_MultipleExpand_ShortPath_ReturnsCorrectQueryParam()
    {
        // Arrange
        var modifier = new ExpandModifier<TestExpand>();
        modifier.Include(expand => expand.TestExpandModel2);
        modifier.Include(expand => expand.TestExpandModel1);

        // Act
        var queryParams = modifier.GetQueryParameters();

        // Assert
        Assert.AreEqual(1, queryParams.Count);
        Assert.IsTrue(queryParams.TryGetValue("include", out var expand));
        var expandString = "TestExpandModel2,TestExpandModel1";
        Assert.AreEqual(expandString, expand);
    }

    [Test]
    public void ExpandModifier_MultipleExpand_LongPath_ReturnsCorrectQueryParam()
    {
        // Arrange
        var modifier = new ExpandModifier<TestExpand>();
        modifier.Include(expand => expand.TestExpandModel1.TestExpandModel2);
        modifier.Include(expand => expand.TestExpandModel1.TestExpandModel3);

        // Act
        var queryParams = modifier.GetQueryParameters();

        // Assert
        Assert.AreEqual(1, queryParams.Count);
        Assert.IsTrue(queryParams.TryGetValue("include", out var expand));
        var expandString = "TestExpandModel1(TestExpandModel2,TestExpandModel3)";
        Assert.AreEqual(expandString, expand);
    }

    [Test]
    public void ExpandModifier_MultipleExpand_MultipleLongPath_ReturnsCorrectQueryParam()
    {
        // Arrange
        var modifier = new ExpandModifier<TestExpand>();
        modifier.Include(expand => expand.TestExpandModel1.TestExpandModel3);
        modifier.Include(expand => expand.TestExpandModel1.TestExpandModel2.TestExpandModel3);

        // Act
        var queryParams = modifier.GetQueryParameters();

        // Assert
        Assert.AreEqual(1, queryParams.Count);
        Assert.IsTrue(queryParams.TryGetValue("include", out var expand));
        var expandString = "TestExpandModel1(TestExpandModel3,TestExpandModel2(TestExpandModel3))";
        Assert.AreEqual(expandString, expand);
    }
}
