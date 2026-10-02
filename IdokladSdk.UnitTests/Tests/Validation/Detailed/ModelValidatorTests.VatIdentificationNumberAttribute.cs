using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [TestCase("CZ12345678")]
        [TestCase("CZ123456789")]
        [TestCase("CZ1234567890")]
        [TestCase("SK1234567890")]
        [TestCase(null)]
        [TestCase("")]
        public void VatIdentificationNumberAttribute_ValidVatNumber_ModelIsValid(string vatNumber)
        {
            // Arrange
            var model = new ModelWithVatIdentificationNumberAttribute { VatIdentificationNumber = vatNumber };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [TestCase("1234567890")]
        [TestCase("CZ1234567")]
        [TestCase("CZ12345678901")]
        [TestCase("SK123456789")]
        [TestCase("SK12345678901")]
        [TestCase("DE12345678")]
        public void VatIdentificationNumberAttribute_InvalidVatNumber_ModelIsNotValid(string vatNumber)
        {
            // Arrange
            var model = new ModelWithVatIdentificationNumberAttribute { VatIdentificationNumber = vatNumber };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(
                result,
                nameof(ModelWithVatIdentificationNumberAttribute.VatIdentificationNumber),
                typeof(VatIdentificationNumberAttribute),
                ValidationType.VatIdentificationNumber);
        }
    }
}
