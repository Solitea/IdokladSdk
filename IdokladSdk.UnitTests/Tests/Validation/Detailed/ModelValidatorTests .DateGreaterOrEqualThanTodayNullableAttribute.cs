using System;
using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithDateGreaterOrEqualThanTodayNullableAttribute_DateNotSet_ReturnsValidModel()
        {
            // Arrange
            var model = new ModelWithDateGreaterOrEqualThanTodayNullableAttribute();

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithDateGreaterOrEqualThanTodayNullableAttribute_DateSetToNull_ReturnsInvalidModel()
        {
            // Arrange
            var model = new ModelWithDateGreaterOrEqualThanTodayNullableAttribute { Date = null };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.Date), typeof(DateGreaterOrEqualThanTodayAttribute), ValidationType.DateGreaterOrEqualThanToday);
        }

        [TestCase(0)]
        [TestCase(1)]
        public void ModelWithDateGreaterOrEqualThanTodayNullableAttribute_ValidModel_ReturnsValidModel(int addDays)
        {
            // Arrange
            var model = new ModelWithDateGreaterOrEqualThanTodayNullableAttribute
            {
                Date = DateTime.UtcNow.AddDays(addDays)
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }
    }
}
