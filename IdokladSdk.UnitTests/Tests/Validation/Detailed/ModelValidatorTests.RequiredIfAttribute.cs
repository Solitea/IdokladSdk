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
        public void ModelWithRequiredIfAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithRequiredIfAttribute
            {
                WasSent = true,
                DateOfSent = new DateTime(2020, 12, 3).ToUniversalTime(),
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithRequiredIfAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithRequiredIfAttribute
            {
                WasSent = true,
                DateOfSent = null,
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.DateOfSent), typeof(RequiredIfAttribute), ValidationType.RequiredIf);
            var attribute = (RequiredIfAttribute)GetValidationAttribute(result, nameof(model.DateOfSent));
            Assert.That(attribute.DependentProperty, Is.EqualTo(nameof(model.WasSent)));
            Assert.That(attribute.TargetValue, Is.EqualTo(true));
        }
    }
}
