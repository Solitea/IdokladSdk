using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithDecimalGreaterThanZeroAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithDecimalGreaterThanZeroAttribute
            {
                Amount = 100m
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithDecimalGreaterThanZeroAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithDecimalGreaterThanZeroAttribute();

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.Amount), typeof(DecimalGreaterThanZeroAttribute), ValidationType.DecimalGreaterThanZero);
        }
    }
}
