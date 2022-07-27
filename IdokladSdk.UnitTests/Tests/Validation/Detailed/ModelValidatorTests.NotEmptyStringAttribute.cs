using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithNotEmptyStringAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithNotEmptyStringAttribute
            {
                Description = "Some text"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithNotEmptyStringAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithNotEmptyStringAttribute
            {
                Description = string.Empty
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.Description), typeof(NotEmptyStringAttribute), ValidationType.NotEmptyString);
        }
    }
}
