using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithLogoAndSignatureExtensionAttribute_InvalidExtensions_ReturnExpectedResults()
        {
            // Arrange
            var model = new ModelWithLogoAndSignatureExtensionAttribute { FileName = "image.txt" };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.FileName), typeof(LogoAndSignatureExtensionAttribute), ValidationType.LogoAndSignatureExtension);
        }

        [TestCase("image.png")]
        [TestCase("image.jpeg")]
        [TestCase("image.jpg")]
        [TestCase("image.gif")]
        public void ModelWithLogoAndSignatureExtensionAttribute_ValidModel_ReturnsExpectedResults(string fileName)
        {
            // Arrange
            var model = new ModelWithLogoAndSignatureExtensionAttribute { FileName = fileName };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }
    }
}
