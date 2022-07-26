using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [TestCase("#000000")]
        [TestCase("#123456")]
        [TestCase("#abcdef")]
        [TestCase("#ABCDEF")]
        [TestCase("#a1B23C")]
        [TestCase("#ffFFff")]
        public void ModelWithColorAttribute_ValidModel_ReturnsExpectedResults(string value)
        {
            // Arrange
            var model = new ModelWithColorAttribute()
            {
                Color = value,
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [TestCase("blue")]
        [TestCase("#aabbccd")]
        [TestCase("#abc")]
        [TestCase("#123")]
        [TestCase("abcdef")]
        [TestCase("123456")]
        public void ModelWithColorAttribute_InvalidModel_ReturnsExpectedResults(string value)
        {
            // Arrange
            var model = new ModelWithColorAttribute()
            {
                Color = value,
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.Color), typeof(ColorAttribute), ValidationType.Color);
        }
    }
}
