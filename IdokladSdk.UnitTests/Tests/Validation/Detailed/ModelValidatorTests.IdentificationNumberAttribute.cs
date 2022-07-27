using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithIdentificationNumberAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithIdentificationNumberAttribute
            {
                IdentificationNumber = "68636938"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithIdentificationNumberAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithIdentificationNumberAttribute
            {
                IdentificationNumber = "12345678"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.IdentificationNumber), typeof(IdentificationNumberAttribute), ValidationType.IdentificationNumber);
        }

        [TestCase("x", false)]
        [TestCase("x", true)]
        [TestCase("25568736", true)]
        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase(" ", true)]
        public void ModelWithHasNoIdentificationNumber_InvalidModel_ReturnsExpectedResults(string identificationNumber, bool hasNoIdentificationNumber)
        {
            // Arrange
            var model = new ModelWithHasNoIdentificationNumber()
            {
                IdentificationNumber = identificationNumber,
                HasNoIdentificationNumber = hasNoIdentificationNumber
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.IdentificationNumber), typeof(IdentificationNumberAttribute), ValidationType.IdentificationNumber);
        }

        [TestCase("25568736", false)]
        [TestCase("", true)]
        public void ModelWithHasNoIdentificationNumber_ValidModel_ReturnsExpectedResults(string identificationNumber, bool hasNoIdentificationNumber)
        {
            // Arrange
            var model = new ModelWithHasNoIdentificationNumber()
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
