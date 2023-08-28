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
        public void ModelWithDateOfEndOnRecurringInvoiceNullableAttribute_NotSetInModel_ReturnsValidModel()
        {
            // Arrange
            var model = new ModelWithDateOfEndOnRecurringInvoiceNullableAttribute
            {
                TypeOfEnd = RecurrenceTypeOfEnd.OnSpecificDate
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithDateOfEndOnRecurringInvoiceNullableAttribute_SetNull_ReturnsInValidModel()
        {
            // Arrange
            var model = new ModelWithDateOfEndOnRecurringInvoiceNullableAttribute
            {
                TypeOfEnd = RecurrenceTypeOfEnd.OnSpecificDate, DateOfEnd = null
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.DateOfEnd), typeof(DateOfEndOnRecurringInvoiceAttribute), ValidationType.DateOfEndOnRecurringInvoice);
        }

        [Test]
        public void ModelWithDateOfEndOnRecurringInvoiceNullableAttribute_ValidModel_ReturnsValidModel()
        {
            // Arrange
            var model = new ModelWithDateOfEndOnRecurringInvoiceNullableAttribute
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
