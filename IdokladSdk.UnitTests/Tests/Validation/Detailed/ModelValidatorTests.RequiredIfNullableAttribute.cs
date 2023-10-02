using System;
using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void ModelWithNullableRequiredIfAttribute_PropertyNotSet_ReturnsValidModel(bool dependentValue)
        {
            // Arrange
            var model = new ModelWithNullableRequiredIfAttribute
            {
                DependentValue = dependentValue
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithNullableRequiredIfAttribute_DependentPropertyNotSet_ReturnsValidModel()
        {
            // Arrange
            var model = new ModelWithNullableRequiredIfAttribute
            {
                PropertyValue = new DateTime(2020, 1, 1)
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithNullableRequiredIfAttribute_InValidData_ReturnsInValidModel()
        {
            // Arrange
            var model = new ModelWithNullableRequiredIfAttribute
            {
                DependentValue = true,
                PropertyValue = null
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(
                result,
                nameof(model.PropertyValue),
                typeof(RequiredIfAttribute),
                ValidationType.RequiredIf);
        }

        [Test]
        public void ModelWithNullableRequiredIfAttribute_ValidData_ReturnsValidModel()
        {
            // Arrange
            var model = new ModelWithNullableRequiredIfAttribute
            {
                DependentValue = true,
                PropertyValue = new DateTime(2020, 1, 1)
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }
    }
}
