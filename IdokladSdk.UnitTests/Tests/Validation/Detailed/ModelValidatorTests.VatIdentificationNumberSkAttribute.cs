using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [TestCase("2022249295")]
        [TestCase("2021879959")]
        [TestCase("2020261353")]
        [TestCase(null)]
        [TestCase("")]
        public void VatIdentificationNumberSkAttribute_ValidVatNumber_ModelIsValid(string vatNumber)
        {
            // Arrange
            var model = new ModelWithVatIdentificationNumberSkAttribute
            {
                VatIdentificationNumberSk = vatNumber
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [TestCase("1234567890")]
        [TestCase("3216549871")]
        [TestCase("123456789")]
        [TestCase("SK1234567890")]
        [TestCase("12345678901")]
        [TestCase("123456789 ")]
        public void VatIdentificationNumberSkAttribute_InvalidVatNumber_ModelIsNotValid(string vatNumber)
        {
            // Arrange
            var model = new ModelWithVatIdentificationNumberSkAttribute
            {
                VatIdentificationNumberSk = vatNumber
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(
                result,
                nameof(ModelWithVatIdentificationNumberSkAttribute.VatIdentificationNumberSk),
                typeof(VatIdentificationNumberSkAttribute),
                ValidationType.VatIdentificationNumberSk);
        }
    }
}
