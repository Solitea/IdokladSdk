using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed;

public partial class ModelValidatorTests
{
    [Test]
    public void ModelWithRegularExpressionAttribute_ValidModel_ReturnsExpectedResults()
    {
        // Arrange
        var model = new ModelWithRegularExpressionAttribute
        {
            DocumentNumber = "123456"
        };

        // Act
        var result = _modelValidator.Validate(model);

        // Assert
        AssertIsValid(result);
    }

    [Test]
    public void ModelWithRegularExpressionAttribute_InvalidModel_ReturnsExpectedResults()
    {
        // Arrange
        var model = new ModelWithRegularExpressionAttribute
        {
            DocumentNumber = "AAA"
        };

        // Act
        var result = _modelValidator.Validate(model);

        // Assert
        AssertIsNotValid(result, nameof(model.DocumentNumber), typeof(RegularExpressionAttribute), ValidationType.RegularExpression);
    }
}
