using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed;

public partial class ModelValidatorTests
{
    [Test]
    public void ModelWithRequiredAttribute_ValidModel_ReturnsExpectedResults()
    {
        // Arrange
        var model = new ModelWithRequiredAttribute
        {
            Name = "aaa"
        };

        // Act
        var result = _modelValidator.Validate(model);

        // Assert
        AssertIsValid(result);
    }

    [Test]
    public void ModelWithRequiredAttribute_InvalidModel_ReturnsExpectedResults()
    {
        // Arrange
        var model = new ModelWithRequiredAttribute();

        // Act
        var result = _modelValidator.Validate(model);

        // Assert
        AssertIsNotValid(result, nameof(model.Name), typeof(RequiredAttribute), ValidationType.Required);
    }
}
