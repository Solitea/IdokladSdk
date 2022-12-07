using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed;

public partial class ModelValidatorTests
{
    [TestCaseSource(nameof(GetValidModelsWithRangeAttribute))]
    public void ModelWithNullableRangeAttribute_ValidModel_ReturnsExpectedResults(ModelWithNullableRangeAttribute model)
    {
        // Act
        var result = _modelValidator.Validate(model);

        // Assert
        AssertIsValid(result);
    }

    [Test]
    public void ModelWithNullableRangeAttribute_InvalidModel_ReturnsExpectedResults()
    {
        // Arrange
        var model = new ModelWithNullableRangeAttribute
        {
            Amount = 150
        };

        // Act
        var result = _modelValidator.Validate(model);

        // Assert
        AssertIsNotValid(result, nameof(model.Amount), typeof(NullableRangeAttribute), ValidationType.Range);
        Assert.That(result.InvalidProperties[nameof(model.Amount)].InvalidAttributes[0].ValidationResult.ErrorMessage, Is.EqualTo("The field Amount must be between 0 and 100."));
    }

    private static IList<object> GetValidModelsWithRangeAttribute()
    {
        return new List<object>
        {
            new ModelWithNullableRangeAttribute(),
            new ModelWithNullableRangeAttribute { Amount = 10m },
            new ModelWithNullableRangeAttribute { Amount = null }
        };
    }
}
