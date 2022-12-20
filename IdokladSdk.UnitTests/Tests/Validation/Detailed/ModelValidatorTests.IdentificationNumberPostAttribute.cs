using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [TestCase("x", false)]
        [TestCase("x", true)]
        [TestCase("25568736", true)]
        [TestCase(null, false)]
        [TestCase(null, true)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase(" ", true)]
        public void IdentificationNumberPostAttribute_InvalidCombination_ThrowsException(string identificationNumber, bool hasNoIdentificationNumber)
        {
            // Arrange
            var model = new PostModelWithIdentificationNumberAttribute
            {
                HasNoIdentificationNumber = hasNoIdentificationNumber,
                IdentificationNumber = identificationNumber
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.IdentificationNumber), typeof(IdentificationNumberPostAttribute), ValidationType.IdentificationNumber);
        }

        [TestCase("25568736", false)]
        [TestCase("", true)]
        public void IdentificationNumberPostAttribute_ValidCombination_DoesNotThrowsException(string identificationNumber, bool hasNoIdentificationNumber)
        {
            // Arrange
            var model = new PostModelWithIdentificationNumberAttribute
            {
                HasNoIdentificationNumber = hasNoIdentificationNumber,
                IdentificationNumber = identificationNumber
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }
    }
}