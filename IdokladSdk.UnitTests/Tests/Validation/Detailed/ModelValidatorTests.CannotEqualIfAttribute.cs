using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [TestCase(0)]
        [TestCase(0.0)]
        public void ModelWithCannotEqualIfAttribute_InValidData_ReturnsInValidModel(decimal propertyValue)
        {
            // Arrange
            var model = new ModelWithCannotEqualIfAttribute
            {
                DependentValue = IssuedDocumentTemplateType.SalesOrder, PropertyValue = propertyValue
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(
                result,
                nameof(model.PropertyValue),
                typeof(CannotEqualIfAttribute),
                ValidationType.CannotEqualIf);
        }

        [Test]
        public void ModelWithCannotEqualIfIntegerAttribute_InValidData_ReturnsInValidModel()
        {
            // Arrange
            var model = new ModelWithCannotEqualIfIntegerAttribute
            {
                DependentValue = IssuedDocumentTemplateType.SalesOrder,
                PropertyValue = 0
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(
                result,
                nameof(model.PropertyValue),
                typeof(CannotEqualIfAttribute),
                ValidationType.CannotEqualIf);
        }

        [TestCase(IssuedDocumentTemplateType.SalesOrder, 1)]
        [TestCase(IssuedDocumentTemplateType.IssuedInvoice, 0)]
        [TestCase(IssuedDocumentTemplateType.ProformaInvoice, 0)]
        public void ModelWithCannotEqualIfAttribute_ValidData_ReturnsValidModel(
            IssuedDocumentTemplateType dependentValue,
            int propertyValue)
        {
            // Arrange
            var model = new ModelWithCannotEqualIfAttribute
            {
                DependentValue = dependentValue, PropertyValue = propertyValue
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }
    }
}
