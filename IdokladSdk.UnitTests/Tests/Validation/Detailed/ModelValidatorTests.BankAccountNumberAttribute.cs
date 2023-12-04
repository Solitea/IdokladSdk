using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [TestCase("1234")]
        [TestCase("1234-1234")]
        [TestCase("001234")]
        [TestCase("123400")]
        [TestCase("")]
        [TestCase(null)]
        public void ModelWithBankAccountNumberAttribute_ValidModel_ReturnsExpectedResult(string bankAccountNumber)
        {
            // Arrange
            var model = new ModelWithBankAccountNumberAttribute { BankAccountNumber = bankAccountNumber };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [TestCase("test")]
        [TestCase("124I")]
        [TestCase(" 1234")]
        [TestCase("1234 ")]
        [TestCase(" ")]
        [TestCase("12&4")]
        [TestCase("12 34")]
        [TestCase("1234--1234")]
        [TestCase("12-34-56")]
        public void ModelWithBankAccountNumberAttribute_InvalidModel_ReturnsExpectedResult(string bankAccountNumber)
        {
            // Arrange
            var model = new ModelWithBankAccountNumberAttribute { BankAccountNumber = bankAccountNumber };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, 1);
        }
    }
}
