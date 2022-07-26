using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithNumericSequenceNumberFormatAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithNumericSequenceNumberFormatAttribute
            {
                LastNumber = 123,
                NumberFormat = "FV{RR}{MM}{NNNNN}"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.NumberFormat), typeof(NumericSequenceNumberFormatAttribute), ValidationType.NumericSequenceNumberFormat);
        }

        [Test]
        public void ModelWithNumericSequenceNumberFormatAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithNumericSequenceNumberFormatAttribute
            {
                LastNumber = null,
                NumberFormat = "FV{RR}{MM}{NNNN}"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }
    }
}
