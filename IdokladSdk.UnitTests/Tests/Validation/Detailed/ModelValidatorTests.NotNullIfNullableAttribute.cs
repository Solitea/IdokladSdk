using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithNullIfNullableAttribute_PropertyNotSet_ReturnsValidModel()
        {
            // Arrange
            var model = new ModelWithNullIfNullableAttribute()
            {
                DependentValue = IssuedDocumentTemplateType.SalesOrder
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [TestCase(0)]
        [TestCase(null)]
        public void ModelWithNullIfNullableAttribute_DependentPropertyNotSet_ReturnsValidModel(int? propertyValue)
        {
            // Arrange
            var model = new ModelWithNullIfNullableAttribute
            {
                PropertyValue = propertyValue
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithNullIfNullableAttribute_InValidData_ReturnsInValidModel()
        {
            // Arrange
            var model = new ModelWithNullIfNullableAttribute
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
                typeof(NullIfAttribute),
                ValidationType.NullIf);
        }

        [TestCase(IssuedDocumentTemplateType.SalesOrder, null)]
        [TestCase(IssuedDocumentTemplateType.IssuedInvoice, 0)]
        public void ModelWithNullIfNullableAttribute_ValidData_ReturnsValidModel(
            IssuedDocumentTemplateType dependentValue,
            int? propertyValue)
        {
            // Arrange
            var model = new ModelWithNullIfNullableAttribute
            {
                DependentValue = dependentValue,
                PropertyValue = propertyValue
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }
    }
}
