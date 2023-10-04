using System;
using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [TestCase(0)]
        [TestCase(1)]
        public void ModelWithDateGreaterOrEqualThanTodayAttribute_ValidModel_ReturnsValidModel(int addDays)
        {
            // Arrange
            var model = new ModelWithDateGreaterOrEqualThanTodayAttribute
            {
                Date = DateTime.UtcNow.AddDays(addDays)
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithDateGreaterOrEqualThanTodayAttribute_InValidModel_ReturnsInvalidModel()
        {
            // Arrange
            var model = new ModelWithDateGreaterOrEqualThanTodayAttribute
            {
                Date = DateTime.UtcNow.AddDays(-1)
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.Date), typeof(DateGreaterOrEqualThanTodayAttribute), ValidationType.DateGreaterOrEqualThanToday);
        }
    }
}
