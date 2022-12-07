using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed;

public partial class ModelValidatorTests
{
    [Test]
    public void ModelWithNullableForeignKeyAttribute_ValidModel_ReturnsExpectedResults()
    {
        // Arrange
        var model = new ModelWithNullableForeignKeyAttribute
        {
            SalesPosEuqipmentId = 1
        };

        // Act
        var result = _modelValidator.Validate(model);

        // Assert
        AssertIsValid(result);
    }

    [Test]
    public void ModelWithNullableForeignKeyAttribute_InvalidModel_ReturnsExpectedResults()
    {
        // Arrange
        var model = new ModelWithNullableForeignKeyAttribute
        {
            SalesPosEuqipmentId = 0
        };

        // Act
        var result = _modelValidator.Validate(model);

        // Assert
        AssertIsNotValid(result, nameof(model.SalesPosEuqipmentId), typeof(NullableForeignKeyAttribute), ValidationType.NullableForeignKey);
    }

    [Test]
    public void ModelWithNullablePropertyAndNullableForeignKeyAttribute_InvalidModel_ReturnsExpectedResults()
    {
        // Arrange
        var model = new ModelWithNullablePropertyAndNullableForeignKeyAttribute
        {
            BankId = 0
        };

        // Act
        var result = _modelValidator.Validate(model);

        // Assert
        AssertIsNotValid(result, nameof(model.BankId), typeof(NullableForeignKeyAttribute), ValidationType.NullableForeignKey);
    }

    [Test]
    public void ModelWithNullablePropertyAndNullableForeignKeyAttribute_ValidModel_ReturnsExpectedResults()
    {
        // Arrange
        var model = new ModelWithNullablePropertyAndNullableForeignKeyAttribute
        {
            BankId = 1
        };

        // Act
        var result = _modelValidator.Validate(model);

        // Assert
        AssertIsValid(result);
    }

    [Test]
    public void ModelWithNullablePropertyAndNullableForeignKeyAttribute_ValidModelWithNull_ReturnsExpectedResults()
    {
        // Arrange
        var model = new ModelWithNullablePropertyAndNullableForeignKeyAttribute();

        // Act
        var result = _modelValidator.Validate(model);

        // Assert
        AssertIsValid(result);
    }
}
