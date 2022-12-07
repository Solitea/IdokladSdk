using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed;

public partial class ModelValidatorTests
{
    [Test]
    public void ModelWithRequiredNonDefaultAttribute_ValidModel_ReturnsExpectedResults()
    {
        // Arrange
        var model = new ModelWithRequiredNonDefaultAttribute
        {
            CurrencyId = 1
        };

        // Act
        var result = _modelValidator.Validate(model);

        // Assert
        AssertIsValid(result);
    }

    [Test]
    public void ModelWithRequiredNonDefaultAttribute_InvalidModel_ReturnsExpectedResults()
    {
        // Arrange
        var model = new ModelWithRequiredNonDefaultAttribute();

        // Act
        var result = _modelValidator.Validate(model);

        // Assert
        AssertIsNotValid(result, nameof(model.CurrencyId), typeof(RequiredNonDefaultAttribute), ValidationType.RequiredNonDefault);
    }
}
