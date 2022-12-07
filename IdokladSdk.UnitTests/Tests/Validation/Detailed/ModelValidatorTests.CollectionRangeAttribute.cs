using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed;

public partial class ModelValidatorTests
{
    [Test]
    public void ModelWithCollectionRangeAttribute_ValidModel_ReturnsExpectedResults()
    {
        // Arrange
        var model = new ModelWithCollectionRangeAttribute
        {
            EntityIds = new List<int> { 1, 2 }
        };

        // Act
        var result = _modelValidator.Validate(model);

        // Assert
        AssertIsValid(result);
    }

    [Test]
    public void ModelWithCollectionRangeAttribute_InvalidModel_ReturnsExpectedResults()
    {
        // Arrange
        var model = new ModelWithCollectionRangeAttribute();

        // Act
        var result = _modelValidator.Validate(model);

        // Assert
        AssertIsNotValid(result, nameof(model.EntityIds), typeof(CollectionRangeAttribute), ValidationType.CollectionRange);
        var attribute = (CollectionRangeAttribute)GetValidationAttribute(result, nameof(model.EntityIds));
        Assert.That(attribute.MinLength, Is.EqualTo(1));
        Assert.That(attribute.MaxLength, Is.EqualTo(2));
        Assert.That(attribute.AllowNull, Is.EqualTo(false));
    }
}
