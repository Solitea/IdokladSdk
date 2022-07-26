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
        public void ModelWithRequiredIfHasValueAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithRequiredIfHasValueAttribute
            {
                DateInitialState = new DateTime(2020, 12, 3),
                InitialState = 100000m
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithRequiredIfHasValueAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithRequiredIfHasValueAttribute
            {
                DateInitialState = new DateTime(2020, 12, 3),
                InitialState = null
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.InitialState), typeof(RequiredIfHasValueAttribute), ValidationType.RequiredIfHasValue);
            var attribute = (RequiredIfHasValueAttribute)GetValidationAttribute(result, nameof(model.InitialState));
            Assert.That(attribute.DependentProperty, Is.EqualTo(nameof(model.DateInitialState)));
        }
    }
}
