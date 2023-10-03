using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model.RecurringInvoice;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [TestCase(RecurrenceType.Days, 0)]
        [TestCase(RecurrenceType.Years, 0)]
        [TestCase(RecurrenceType.Weeks, 0)]
        [TestCase(RecurrenceType.Months, 0)]
        public void ModelWithIssueLastDayOfMonthOnRecurringInvoiceAttribute_SetInvalidModel_ReturnsInvalidModel(
            RecurrenceType type, int count)
        {
            // Arrange
            var model = new ModelWithIssueLastDayOfMonthOnRecurringInvoiceAttribute
            {
                IssueLastDayOfMonth = true, RecurrenceType = type, RecurrenceCount = count
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.IssueLastDayOfMonth), typeof(IssueLastDayOfMonthOnRecurringInvoiceAttribute), ValidationType.IssueLastDayOfMonthOnRecurringInvoice);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ModelWithIssueLastDayOfMonthOnRecurringInvoiceAttribute_ValidModel_ReturnsInvalidModel(
            bool isLastDay)
        {
            // Arrange
            var model = new ModelWithIssueLastDayOfMonthOnRecurringInvoiceAttribute
            {
                IssueLastDayOfMonth = isLastDay, RecurrenceType = RecurrenceType.Months, RecurrenceCount = 1
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }
    }
}
