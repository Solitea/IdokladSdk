using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithDecimalRangeAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithDecimalRangeAttribute
            {
                Amount = 100m
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithDecimalRangeAttribute_InvalidData_ReturnsInvalidModel()
        {
            // Arrange
            var model = new ModelWithDecimalRangeAttribute
            {
                Amount = 2000000000000000000
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(
                result,
                nameof(model.Amount),
                typeof(DecimalRangeAttribute),
                ValidationType.Range);
        }
    }
}
