using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithNullOrEmptyStringIfNullableAttribute_PropertyNotSet_ReturnsValidModel()
        {
            // Arrange
            var model = new ModelWithNullOrEmptyStringIfNullableAttribute()
            {
                DependentValue = IssuedDocumentTemplateType.SalesOrder
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [TestCase("test")]
        [TestCase("")]
        [TestCase(null)]
        public void
            ModelWithNullOrEmptyStringIfNullableAttribute_DependentPropertyNotSet_ReturnsValidModel(
                string propertyValue)
        {
            // Arrange
            var model = new ModelWithNullOrEmptyStringIfNullableAttribute
            {
                PropertyValue = propertyValue
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithNullOrEmptyStringIfNullableAttribute_InValidData_ReturnsInValidModel()
        {
            // Arrange
            var model = new ModelWithNullOrEmptyStringIfNullableAttribute
            {
                DependentValue = IssuedDocumentTemplateType.SalesOrder, PropertyValue = "test"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(
                result,
                nameof(model.PropertyValue),
                typeof(NullOrEmptyStringIfAttribute),
                ValidationType.NullOrEmptyStringIf);
        }

        [TestCase(IssuedDocumentTemplateType.SalesOrder, "")]
        [TestCase(IssuedDocumentTemplateType.SalesOrder, null)]
        [TestCase(IssuedDocumentTemplateType.IssuedInvoice, "")]
        [TestCase(IssuedDocumentTemplateType.IssuedInvoice, null)]
        [TestCase(IssuedDocumentTemplateType.IssuedInvoice, "test")]
        [TestCase(IssuedDocumentTemplateType.ProformaInvoice, "test")]
        public void ModelWithNullOrEmptyStringIfNullableAttribute_ValidData_ReturnsValidModel(
            IssuedDocumentTemplateType dependentValue,
            string propertyValue)
        {
            // Arrange
            var model = new ModelWithNullOrEmptyStringIfNullableAttribute
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
