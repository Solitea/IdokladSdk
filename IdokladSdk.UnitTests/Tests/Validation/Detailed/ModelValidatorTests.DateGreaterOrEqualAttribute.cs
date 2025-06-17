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
        public void ModelWithDateGreaterOrEqualAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithDateGreaterOrEqualThanAttribute
            {
                DateOfIssue = new DateTime(2020, 12, 3).ToUniversalTime()
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithDateGreaterOrEqualAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithDateGreaterOrEqualThanAttribute();

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.DateOfIssue), typeof(DateGreaterOrEqualThanAttribute), ValidationType.DateGreaterOrEqualThan);
            var attribute = (DateGreaterOrEqualThanAttribute)GetValidationAttribute(result, nameof(model.DateOfIssue));
            Assert.That(attribute.MinDateTime, Is.EqualTo(new DateTime(1753, 1, 1)));
            Assert.That(attribute.AllowNull, Is.EqualTo(false));
        }
    }
}
