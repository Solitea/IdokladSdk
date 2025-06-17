using System;
using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ModelDateGreaterOrEqualThanAnotherDate_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithDateGreaterOrEqualThanAnotherDateAttribute()
            {
                DateOfIssue = new DateTime(2020, 10, 10).ToUniversalTime(),
            };
            model.DateOfExpiration = model.DateOfIssue.AddDays(-1);

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.DateOfExpiration), typeof(DateGreaterThanOrEqualThanAnotherDateAttribute), ValidationType.DateGreaterOrEqualThanAnotherDate);
        }

        [Test]
        public void ModelDateGreaterOrEqualThanAnotherDate_DefaultDateTimeValueDisabled_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithDateGreaterOrEqualThanAnotherDateAttribute()
            {
                DateOfExpiration = Constants.DefaultDateTime,
                DateOfIssue = new DateTime(2020, 10, 10).ToUniversalTime(),
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.DateOfExpiration), typeof(DateGreaterThanOrEqualThanAnotherDateAttribute), ValidationType.DateGreaterOrEqualThanAnotherDate);
        }

        [Test]
        public void ModelDateGreaterOrEqualThanAnotherDate_DefaultDateTimeValueEnabled_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithDateGreaterOrEqualThanAnotherDateAttributeDefaultDate()
            {
                DateOfExpiration = Constants.DefaultDateTime,
                DateOfIssue = new DateTime(2020, 10, 10).ToUniversalTime(),
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelNullableDateGreaterOrEqualThanAnotherDate_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithNullableDateGreaterOrEqualThanAnotherDateAttribute()
            {
                DateOfIssue = new DateTime(2020, 10, 10).ToUniversalTime(),
            };
            model.DateOfVatClaim = model.DateOfIssue.AddDays(-1);

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.DateOfVatClaim), typeof(DateGreaterThanOrEqualThanAnotherDateAttribute), ValidationType.DateGreaterOrEqualThanAnotherDate);
        }

        [Test]
        public void ModelNullableDateGreaterOrEqualThanAnotherNullableDate_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithNullableDateGreaterOrEqualThanAnotherNullableDateAttribute()
            {
                DateOfIssue = new DateTime(2020, 10, 10).ToUniversalTime(),
            };
            model.DateOfVatClaim = model.DateOfIssue.Value.AddDays(-1);

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.DateOfVatClaim), typeof(DateGreaterThanOrEqualThanAnotherDateAttribute), ValidationType.DateGreaterOrEqualThanAnotherDate);
        }

        [TestCaseSource(nameof(GetValidModelsWithNullableDateGreaterOrEqualThanAnotherDateAttribute))]
        public void ModelNullableDateGreaterOrEqualThanAnotherDate_ValidModel_ReturnsExpectedResults(ModelWithNullableDateGreaterOrEqualThanAnotherDateAttribute model)
        {
            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelNullablePropertyDateGreaterOrEqualThanAnotherNullableDate_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithNullablePropertyDateGreaterOrEqualThanAnotherNullableDateAttribute()
            {
                DateOfIssue = new DateTime(2020, 10, 10).ToUniversalTime(),
            };
            model.DateOfVatClaim = model.DateOfIssue.Value.AddDays(-1);

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.DateOfVatClaim), typeof(DateGreaterThanOrEqualThanAnotherDateAttribute), ValidationType.DateGreaterOrEqualThanAnotherDate);
        }

        [TestCaseSource(nameof(GetValidModelsWithNullablePropertyDateGreaterOrEqualThanAnotherNullableDateAttribute))]
        public void ModelNullablePropertyDateGreaterOrEqualThanAnotherNullableDate_ValidModel_ReturnsExpectedResults(ModelWithNullablePropertyDateGreaterOrEqualThanAnotherNullableDateAttribute model)
        {
            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        private static IList<object> GetValidModelsWithNullableDateGreaterOrEqualThanAnotherDateAttribute()
        {
            var defaultDateTime = new DateTime(2020, 10, 10).ToUniversalTime();

            return new List<object>
        {
            new ModelWithNullableDateGreaterOrEqualThanAnotherDateAttribute { DateOfIssue = defaultDateTime },
            new ModelWithNullableDateGreaterOrEqualThanAnotherDateAttribute { DateOfIssue = defaultDateTime, DateOfVatClaim = defaultDateTime },
        };
        }

        private static IList<object> GetValidModelsWithNullablePropertyDateGreaterOrEqualThanAnotherNullableDateAttribute()
        {
            var defaultDateTime = new DateTime(2020, 10, 10).ToUniversalTime();

            return new List<object>
        {
            new ModelWithNullablePropertyDateGreaterOrEqualThanAnotherNullableDateAttribute(),
            new ModelWithNullablePropertyDateGreaterOrEqualThanAnotherNullableDateAttribute { DateOfIssue = defaultDateTime, DateOfVatClaim = defaultDateTime },
            new ModelWithNullablePropertyDateGreaterOrEqualThanAnotherNullableDateAttribute { DateOfVatClaim = defaultDateTime },
            new ModelWithNullablePropertyDateGreaterOrEqualThanAnotherNullableDateAttribute { DateOfIssue = defaultDateTime },
        };
        }
    }
}
