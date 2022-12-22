using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithIbanAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithIbanAttribute()
            {
                Iban = "Wrong iban",
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.Iban), typeof(IbanAttribute), ValidationType.Iban);
        }

        [TestCase("SK3002000000003604642112")]
        [TestCase("")]
        [TestCase(null)]
        public void ModelWithIbanAttribute_ValidModel_ReturnsExpectedResults(string value)
        {
            // Arrange
            var model = new ModelWithIbanAttribute()
            {
                Iban = value,
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }
    }
}