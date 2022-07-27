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
        public void ModelWithDateTimeAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithDateTimeAttribute
            {
                DateOfIssue = new DateTime(2020, 12, 3)
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithDateTimeAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithDateTimeAttribute();

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.DateOfIssue), typeof(DateTimeAttribute), ValidationType.DateTime);
            var attribute = (DateTimeAttribute)GetValidationAttribute(result, nameof(model.DateOfIssue));
            Assert.That(attribute.Minimum, Is.EqualTo(new DateTime(1753, 1, 1)));
            Assert.That(attribute.Maximum, Is.EqualTo(new DateTime(9999, 12, 31)));
        }
    }
}
