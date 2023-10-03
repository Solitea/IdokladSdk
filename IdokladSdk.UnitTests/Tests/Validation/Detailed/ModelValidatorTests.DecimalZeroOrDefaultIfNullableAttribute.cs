using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithDecimalZeroOrDefaultIfNullableAttribute_PropertyNotSet_ReturnsValidModel()
        {
            // Arrange
            var model = new ModelWithDecimalZeroOrDefaultIfNullableAttribute
            {
                DependentValue = IssuedDocumentTemplateType.SalesOrder
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [TestCase(1)]
        [TestCase(0)]
        [TestCase(null)]
        public void
            ModelWithDecimalZeroOrDefaultIfNullableAttribute_DependentPropertyNotSet_ReturnsValidModel(
                decimal propertyValue)
        {
            // Arrange
            var model = new ModelWithDecimalZeroOrDefaultIfNullableAttribute
            {
                PropertyValue = propertyValue
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithDecimalZeroOrDefaultIfNullableAttribute_InvalidData_ReturnsInvalidModel()
        {
            // Arrange
            var model = new ModelWithDecimalZeroOrDefaultIfNullableAttribute
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

        [TestCase(IssuedDocumentTemplateType.SalesOrder, 0)]
        [TestCase(IssuedDocumentTemplateType.SalesOrder, null)]
        [TestCase(IssuedDocumentTemplateType.IssuedInvoice, 1)]
        [TestCase(IssuedDocumentTemplateType.ProformaInvoice, 1)]
        public void ModelWithDecimalZeroOrDefaultIfNullableAttribute_ValidData_ReturnsValidModel(
            IssuedDocumentTemplateType dependentValue,
            decimal propertyValue)
        {
            // Arrange
            var model = new ModelWithDecimalZeroOrDefaultIfNullableAttribute
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
