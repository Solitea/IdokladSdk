using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed;

public partial class ModelValidatorTests
{
    [Test]
    public void ModelWithCannotEqualAttribute_ValidModel_ReturnsExpectedResults()
    {
        // Arrange
        var model = new ModelWithCannotEqualAttribute
        {
            Amount = 100.50m,
            IssuedInvoiceItemType = IssuedInvoiceItemType.ItemTypeNormal
        };

        // Act
        var result = _modelValidator.Validate(model);

        // Assert
        AssertIsValid(result);
    }

    [Test]
    public void ModelWithCannotEqualAttribute_InvalidModel_ReturnsExpectedResults()
    {
        // Arrange
        var model = new ModelWithCannotEqualAttribute
        {
            Amount = 0,
            IssuedInvoiceItemType = IssuedInvoiceItemType.ItemTypeReduce
        };

        // Act
        var result = _modelValidator.Validate(model);

        // Assert
        AssertIsNotValid(result, 2);
        AssertIsNotValidProperty(result, nameof(model.Amount), typeof(CannotEqualAttribute), ValidationType.CannotEqual);
        var attribute = (CannotEqualAttribute)GetValidationAttribute(result, nameof(model.Amount));
        Assert.That(attribute.InvalidValue, Is.EqualTo(0));
        Assert.That(attribute.Reason, Is.Not.Null);
        AssertIsNotValidProperty(result, nameof(model.IssuedInvoiceItemType), typeof(CannotEqualAttribute), ValidationType.CannotEqual);
        attribute = (CannotEqualAttribute)GetValidationAttribute(result, nameof(model.IssuedInvoiceItemType));
        Assert.That(attribute.InvalidValue, Is.EqualTo(IssuedInvoiceItemType.ItemTypeReduce));
        Assert.That(attribute.Reason, Is.Not.Null);
    }
}
