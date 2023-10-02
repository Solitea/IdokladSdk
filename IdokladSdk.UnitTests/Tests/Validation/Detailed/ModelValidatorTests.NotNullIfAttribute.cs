using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithNullIfAttribute_InValidData_ReturnsInValidModel()
        {
            // Arrange
            var model = new ModelWithNullIfAttribute
            {
                DependentValue = IssuedDocumentTemplateType.SalesOrder, PropertyValue = 0
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(
                result,
                nameof(model.PropertyValue),
                typeof(NullIfAttribute),
                ValidationType.NullIf);
        }

        [Test]
        public void ModelWithNullIfAttribute_ValidData_ReturnsValidModel()
        {
            // Arrange
            var model = new ModelWithNullIfAttribute
            {
                DependentValue = IssuedDocumentTemplateType.SalesOrder, PropertyValue = null
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }
    }
}
