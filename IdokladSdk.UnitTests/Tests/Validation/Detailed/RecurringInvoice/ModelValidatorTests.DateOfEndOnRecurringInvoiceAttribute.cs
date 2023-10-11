using System;
using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model.RecurringInvoice;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelWithDateOfEndOnRecurringInvoiceAttribute_NotSetInModel_ReturnsInvalidModel()
        {
            // Arrange
            var model = new ModelWithDateOfEndOnRecurringInvoiceAttribute
            {
                TypeOfEnd = RecurrenceTypeOfEnd.OnSpecificDate
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.DateOfEnd), typeof(DateOfEndOnRecurringInvoiceAttribute), ValidationType.DateOfEndOnRecurringInvoice);
        }

        [Test]
        public void ModelWithDateOfEndOnRecurringInvoiceAttribute_SetNull_ReturnsInvalidModel()
        {
            // Arrange
            var model = new ModelWithDateOfEndOnRecurringInvoiceAttribute
            {
                TypeOfEnd = RecurrenceTypeOfEnd.OnSpecificDate, DateOfEnd = null
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.DateOfEnd), typeof(DateOfEndOnRecurringInvoiceAttribute), ValidationType.DateOfEndOnRecurringInvoice);
        }

        [Test]
        public void ModelWithDateOfEndOnRecurringInvoiceAttribute_ValidModel_ReturnsValidModel()
        {
            // Arrange
            var model = new ModelWithDateOfEndOnRecurringInvoiceAttribute
            {
                TypeOfEnd = RecurrenceTypeOfEnd.OnSpecificDate, DateOfEnd = DateTime.UtcNow.AddDays(1)
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }
    }
}
