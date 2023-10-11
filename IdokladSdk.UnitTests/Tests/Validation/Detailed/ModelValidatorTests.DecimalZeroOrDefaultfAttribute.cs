using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithDecimalZeroOrDefaultIfAttribute_InvalidData_ReturnsInvalidModel()
        {
            // Arrange
            var model = new ModelWithDecimalZeroOrDefaultIfAttribute
            {
                DependentValue = IssuedDocumentTemplateType.SalesOrder, PropertyValue = 1
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(
                result,
                nameof(model.PropertyValue),
                typeof(DecimalZeroOrDefaultIfAttribute),
                ValidationType.DecimalZeroOrDefaultIf);
        }

        [Test]
        public void ModelWithDecimalZeroOrDefaultIfAttribute_ValidData_ReturnsValidModel()
        {
            // Arrange
            var model = new ModelWithDecimalZeroOrDefaultIfAttribute
            {
                DependentValue = IssuedDocumentTemplateType.SalesOrder, PropertyValue = 0.0m
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }
    }
}
