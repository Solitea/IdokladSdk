using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed;

public partial class ModelValidatorTests
{
    [TestCase("x", false)]
    [TestCase("x", true)]
    [TestCase("x", null)]
    [TestCase("25568736", true)]
    [TestCase(null, false)]
    [TestCase(null, true)]
    [TestCase("", false)]
    [TestCase(" ", false)]
    [TestCase(" ", true)]
    [TestCase(" ", null)]
    public void PatchModelWithIdentificationNumber_InvalidModel_ReturnsIsNotValid(string identificationNumber, bool? hasNoIdentificationNumber)
    {
        // Arrange
        var model = new PatchModelWithIdentificationNumberAttribute()
        {
            IdentificationNumber = identificationNumber,
            HasNoIdentificationNumber = hasNoIdentificationNumber
        };

        // Act
        var result = _modelValidator.Validate(model);

        // Assert
        AssertIsNotValid(result, nameof(model.IdentificationNumber), typeof(IdentificationNumberPatchAttribute), ValidationType.IdentificationNumber);
    }

    [TestCase("25568736", false)]
    [TestCase("", true)]
    [TestCase(null, null)]
    public void PatchModelWithIdentificationNumberAttribute_ValidModel_ReturnsIsValid(string identificationNumber, bool? hasNoIdentificationNumber)
    {
        // Arrange
        var model = new PatchModelWithIdentificationNumberAttribute()
        {
            IdentificationNumber = identificationNumber,
            HasNoIdentificationNumber = hasNoIdentificationNumber
        };

        // Act
        var result = _modelValidator.Validate(model);

        // Assert
        AssertIsValid(result);
    }
}
