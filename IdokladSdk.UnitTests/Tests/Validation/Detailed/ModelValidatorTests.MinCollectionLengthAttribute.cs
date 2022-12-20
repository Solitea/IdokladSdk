using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithMinCollectionLengthAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithMinCollectionLengthAttribute
            {
                RelatedEntityIds = new List<int> { 1 }
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithMinCollectionLengthAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithMinCollectionLengthAttribute();

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.RelatedEntityIds), typeof(MinCollectionLengthAttribute), ValidationType.MinCollectionLength);
        }
    }
}