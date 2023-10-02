using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithRangeNullableAttribute_InValidData_ReturnsInValidModel()
        {
            // Arrange
            var model = new ModelWithRangeNullableAttribute
            {
                RangeValue = -1.2m
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(
                result,
                nameof(model.RangeValue),
                typeof(RangeNullableAttribute),
                ValidationType.RangeNullable);
        }

        [Test]
        public void ModelWithRangeNullableAttribute_ValidData_ReturnsValidModel()
        {
            // Arrange
            var model = new ModelWithRangeNullableAttribute
            {
                RangeValue = 0.1m
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }
    }
}
