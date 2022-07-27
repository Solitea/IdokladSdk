using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithEmailAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithEmailAttribute
            {
                Email = "ales.micin@solitea.cz"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithEmailAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithEmailAttribute
            {
                Email = "ThisIsNotValidEmailAddress"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.Email), typeof(EmailAttribute), ValidationType.EmailAddress);
        }
    }
}
