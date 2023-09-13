using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model.RecurringInvoice;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithCopyCountEndOnRecurringInvoiceNullableAttribute_CopyNotSet_ReturnsValidModel()
        {
            // Arrange
            var model = new ModelWithCopyCountEndOnRecurringInvoiceNullableAttribute
            {
                TypeOfEnd = RecurrenceTypeOfEnd.AfterNumberCreated
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithCopyCountEndOnRecurringInvoiceNullableAttribute_NullAsValue_ReturnsInvalidModel()
        {
            // Arrange
            var model = new ModelWithCopyCountEndOnRecurringInvoiceNullableAttribute
            {
                TypeOfEnd = RecurrenceTypeOfEnd.AfterNumberCreated, CopyCountEnd = null
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.CopyCountEnd), typeof(CopyCountEndOnRecurringInvoiceAttribute), ValidationType.CopyCountEndOnRecurringInvoice);
        }

        [Test]
        public void ModelWithCopyCountEndOnRecurringInvoiceNullableAttribute_ValidModel_ReturnsValidModel()
        {
            // Arrange
            var model = new ModelWithCopyCountEndOnRecurringInvoiceNullableAttribute
            {
                TypeOfEnd = RecurrenceTypeOfEnd.AfterNumberCreated, CopyCountEnd = 1
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }
    }
}
