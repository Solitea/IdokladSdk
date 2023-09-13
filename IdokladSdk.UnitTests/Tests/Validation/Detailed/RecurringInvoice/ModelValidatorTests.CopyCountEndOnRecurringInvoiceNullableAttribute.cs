using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model.RecurringInvoice;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithCopyCountEndOnRecurringInvoiceAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithCopyCountEndOnRecurringInvoiceAttribute
            {
                TypeOfEnd = RecurrenceTypeOfEnd.AfterNumberCreated,
                CopyCountEnd = 1
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithCopyCountEndOnRecurringInvoiceAttribute_InValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithCopyCountEndOnRecurringInvoiceAttribute
            {
                TypeOfEnd = RecurrenceTypeOfEnd.AfterNumberCreated,
                CopyCountEnd = null
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.CopyCountEnd), typeof(CopyCountEndOnRecurringInvoiceAttribute), ValidationType.CopyCountEndOnRecurringInvoice);
        }
    }
}
