using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithNullOrEmptyStringIfAttribute_InValidData_ReturnsInValidModel()
        {
            // Arrange
            var model = new ModelWithNullOrEmptyStringIfAttribute()
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

        [TestCase(IssuedDocumentTemplateType.SalesOrder, null)]
        [TestCase(IssuedDocumentTemplateType.SalesOrder, "")]
        [TestCase(IssuedDocumentTemplateType.IssuedInvoice, null)]
        [TestCase(IssuedDocumentTemplateType.IssuedInvoice, "")]
        [TestCase(IssuedDocumentTemplateType.IssuedInvoice, "test")]
        [TestCase(IssuedDocumentTemplateType.ProformaInvoice, "test")]
        public void ModelWithNullOrEmptyStringIfAttribute_ValidData_ReturnsValidModel(
            IssuedDocumentTemplateType dependentValue,
            string propertyValue)
        {
            // Arrange
            var model = new ModelWithNullOrEmptyStringIfAttribute
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
