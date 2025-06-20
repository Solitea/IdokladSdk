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
        public void DateTimeAttribute_DefaultRange_Expected()
        {
            // Arrange
            var minimum = new DateTime(1753, 1, 1);
            var maximum = new DateTime(9999, 12, 31);

            // Act
            var attribute = new DateTimeAttribute();

            // Assert
            var attributeMax = Convert.ToDateTime(attribute.Maximum);
            var attributeMin = Convert.ToDateTime(attribute.Minimum);
            Assert.That(attributeMin, Is.EqualTo(minimum));
            Assert.That(attributeMax, Is.EqualTo(maximum));
        }

        [TestCaseSource(nameof(GetValidModelsWithDateTimeAttribute))]
        public void ModelWithDateTimeAttribute_ValidModel_ReturnsExpectedResults(ModelWithDateTimeAttribute model)
        {
            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [TestCaseSource(nameof(GetInvalidModelsWithDateTimeAttribute))]
        public void ModelWithDateTimeAttribute_InvalidModel_ReturnsExpectedResults(ModelWithDateTimeAttribute model, string propertyName)
        {
            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, propertyName, typeof(DateTimeAttribute), ValidationType.DateTime);
        }

        private static IList<object[]> GetInvalidModelsWithDateTimeAttribute()
        {
            return new List<object[]>
        {
            new object[] { new ModelWithDateTimeAttribute { DateOfIssue = DateTime.MinValue.ToUniversalTime() }, nameof(ModelWithDateTimeAttribute.DateOfIssue) },
            new object[] { new ModelWithDateTimeAttribute { DateOfIssue = DateTime.UtcNow, DateOfPayment = DateTime.MinValue.ToUniversalTime() }, nameof(ModelWithDateTimeAttribute.DateOfPayment) }
        };
        }

        private static IList<object> GetValidModelsWithDateTimeAttribute()
        {
            var date = new DateTime(2020, 12, 3).ToUniversalTime();

            return new List<object>
        {
            new ModelWithDateTimeAttribute { DateOfIssue = date },
            new ModelWithDateTimeAttribute { DateOfIssue = date, DateOfPayment = date },
            new ModelWithDateTimeAttribute { DateOfIssue = date, DateOfPayment = null }
        };
        }
    }
}
