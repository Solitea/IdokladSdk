using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [TestCase("x", true)]
        [TestCase("x", null)]
        [TestCase("25568736", true)]
        [TestCase(null, false)]
        [TestCase(null, true)]
        [TestCase("", false)]
        [TestCase(" ", true)]
        [TestCase(" ", null)]
        public void ModelWithNullableHasNoIdentificationNumber_InvalidModel_ReturnsExpectedResults(string identificationNumber, bool? hasNoIdentificationNumber)
        {
            // Arrange
            var model = new ModelWithNullableHasNoIdentificationNumber()
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
        [TestCase(null, null)]
        [TestCase("", true)]
        public void ModelWithNullableHasNoIdentificationNumber_ValidModel_ReturnsExpectedResults(string identificationNumber, bool? hasNoIdentificationNumber)
        {
            // Arrange
            var model = new ModelWithNullableHasNoIdentificationNumber()
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
}
