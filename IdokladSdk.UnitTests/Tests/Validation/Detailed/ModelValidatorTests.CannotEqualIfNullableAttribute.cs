using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithCannotEqualIfNullableAttribute_PropertyNotSet_ReturnsValidModel()
        {
            // Arrange
            var model = new ModelWithCannotEqualIfNullableAttribute()
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
        public void
            ModelWithCannotEqualIfNullableAttribute_DependentPropertyNotSet_ReturnsValidModel(
                decimal propertyValue)
        {
            // Arrange
            var model = new ModelWithCannotEqualIfNullableAttribute
            {
                PropertyValue = propertyValue
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithCannotEqualIfNullableAttribute_InValidData_ReturnsInValidModel()
        {
            // Arrange
            var model = new ModelWithCannotEqualIfNullableAttribute
            {
                DependentValue = IssuedDocumentTemplateType.SalesOrder, PropertyValue = 0
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
        public void ModelWithCannotEqualIfNullableAttribute_ValidData_ReturnsValidModel(
            IssuedDocumentTemplateType dependentValue,
            decimal propertyValue)
        {
            // Arrange
            var model = new ModelWithCannotEqualIfNullableAttribute
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
