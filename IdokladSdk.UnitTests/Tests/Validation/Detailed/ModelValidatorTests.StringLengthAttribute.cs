﻿using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithStringLengthAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithStringLengthAttribute
            {
                Name = "1234567890"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithStringLengthAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithStringLengthAttribute
            {
                Name = "123456789"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.Name), typeof(StringLengthAttribute), ValidationType.StringLength);
        }
    }
}