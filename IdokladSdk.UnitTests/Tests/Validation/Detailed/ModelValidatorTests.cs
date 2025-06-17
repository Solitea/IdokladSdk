using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using IdokladSdk.Enums;
using IdokladSdk.Requests.Core.Extensions;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.UnitTests.Tests.Validation.Model;
using IdokladSdk.Validation;
using IdokladSdk.Validation.Detailed.Model;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    [TestFixture]
    public partial class ModelValidatorTests
    {
        private ModelValidator _modelValidator;

        [SetUp]
        public void SetUp()
        {
            _modelValidator = new ModelValidator();
        }

        [Test]
        public void ModelWithDataTypeAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithDataTypeAttribute
            {
                Email = "DataTypeAttributeValidationAlwaysReturnsTrue"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ApiValidator_RequiredPropertiesNotSet_ReturnsFalse()
        {
            // Arrange
            var entity = new TestEntity
            {
                NonNullableDate = DateTime.Now.SetKindUtc(),
                NullableDate = null
            };

            // Act
            var result = entity.Validate();

            // Assert
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.InvalidProperties.Count, Is.EqualTo(2));
            var memberNames = GetMembersNames(result);
            Assert.That(memberNames, Contains.Item(nameof(TestEntity.IdentificationNumber)));
            Assert.That(memberNames, Contains.Item(nameof(TestEntity.Name)));
        }

        [Test]
        public void ApiValidator_OtherValidationConditionsNotMet_ReturnsFalse()
        {
            // Arrange
            var entity = new TestEntity
            {
                IdentificationNumber = "123456789012345678901",
                Name = "something",
                Rating = 0,
                NonNullableDate = DateTime.Now,
                NullableDate = DateTime.Now
            };

            // Act
            var result = entity.Validate();

            // Assert
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.InvalidProperties.Count, Is.EqualTo(4));
            var memberNames = GetMembersNames(result);
            Assert.That(memberNames, Contains.Item(nameof(TestEntity.IdentificationNumber)));
            Assert.That(memberNames, Contains.Item(nameof(TestEntity.Rating)));
            Assert.That(memberNames, Contains.Item(nameof(TestEntity.NonNullableDate)));
            Assert.That(memberNames, Contains.Item(nameof(TestEntity.NullableDate)));
        }

        [Test]
        public void ApiValidator_AllConditionsAreMet_ReturnsTrue()
        {
            // Arrange
            var entity = new TestEntity
            {
                IdentificationNumber = "12345678901234567890",
                Name = "something",
                Rating = 1,
                NonNullableDate = DateTime.Now.SetKindUtc(),
                NullableDate = DateTime.Now.AddDays(1).SetKindUtc(),
            };

            // Act
            var result = entity.Validate();

            // Assert
            Assert.That(result.IsValid, Is.True);
            Assert.That(result.InvalidProperties.Count, Is.Zero);
        }

        [TestCase(null)]
        [TestCase(10)]
        public void ApiValidator_NullableRange_ValidValues_ReturnsTrue(decimal? discount)
        {
            // Arrange
            var entity = new TestEntity
            {
                IdentificationNumber = "something",
                Name = "something",
                NonNullableDate = DateTime.Now.SetKindUtc(),
                DiscountPercentage = discount
            };

            // Act
            var result = entity.Validate();

            // Assert
            Assert.That(result.IsValid, Is.True);
            Assert.That(result.InvalidProperties.Count, Is.Zero);
        }

        [Test]
        public void ApiValidator_NullableRange_OutOfRange_ReturnsFalse()
        {
            // Arrange
            var entity = new TestEntity
            {
                IdentificationNumber = "something",
                Name = "something",
                NonNullableDate = DateTime.Now.SetKindUtc(),
                DiscountPercentage = 1000m
            };

            // Act
            var result = entity.Validate();

            // Assert
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.InvalidProperties.Count, Is.EqualTo(1));
            var memberNames = GetMembersNames(result);
            Assert.That(memberNames, Contains.Item(nameof(TestEntity.DiscountPercentage)));
        }

        [Test]
        public void ApiValidator_NestedEntities_ValidValues_ReturnsTrue()
        {
            // Arrange
            var entity = new TestEntityWithNestedEntities
            {
                Entity = new TestEntity
                {
                    IdentificationNumber = "nested",
                    Name = "nested",
                    NonNullableDate = DateTime.Now.SetKindUtc(),
                    DiscountPercentage = 5m
                },
                Entities = new List<TestEntity>
            {
                new TestEntity
                {
                    IdentificationNumber = "nestedInCollection1",
                    Name = "nestedInCollection1",
                    NonNullableDate = DateTime.Now.SetKindUtc(),
                    DiscountPercentage = 5m
                },
                new TestEntity
                {
                    IdentificationNumber = "nestedInCollection2",
                    Name = "nestedInCollection2",
                    NonNullableDate = DateTime.Now.SetKindUtc(),
                    DiscountPercentage = 5m
                },
            }
            };

            // Act
            var result = entity.Validate();

            // Assert
            Assert.That(result.IsValid, Is.True);
            Assert.That(result.InvalidProperties.Count, Is.Zero);
        }

        [TestCaseSource(nameof(GetListOfDates))]
        public void ApiValidator_CollectionsOfDates_ValidUtcDate_IsValid(IEnumerable<DateTime> dates)
        {
            // Arrange
            var entity = new TestEntity
            {
                IdentificationNumber = "something",
                Name = "something",
                NonNullableDate = DateTime.UtcNow,
                Dates = dates,
            };

            // Act
            var result = entity.Validate();

            // Assert
            Assert.That(result.IsValid, Is.True);
            Assert.That(result.InvalidProperties, Is.Empty);
        }

        [TestCaseSource(nameof(GetListOfNullableDates))]
        public void ApiValidator_CollectionsOfNullableDates_ValidUtcDate_IsValid(IEnumerable<DateTime?> dates)
        {
            // Arrange
            var entity = new TestEntity
            {
                IdentificationNumber = "something",
                Name = "something",
                NonNullableDate = DateTime.UtcNow,
                NullableDates = dates,
            };

            // Act
            var result = entity.Validate();

            // Assert
            Assert.That(result.IsValid, Is.True);
            Assert.That(result.InvalidProperties, Is.Empty);
        }

        [Test]
        public void ApiValidator_CollectionsOfDates_NotValidDate_IsNotValid()
        {
            // Arrange
            var entity = new TestEntity
            {
                IdentificationNumber = "something",
                Name = "something",
                NonNullableDate = DateTime.UtcNow,
                Dates = new List<DateTime> { new (2024, 11, 22, 15, 30, 0, DateTimeKind.Local) },
            };

            // Act
            var result = entity.Validate();

            // Assert
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.InvalidProperties, Is.Not.Empty);
        }

        private static List<object> GetListOfDates()
        {
            return new List<object>
            {
                new object[] { null },
                new object[] { new List<DateTime>() },
                new object[] { new List<DateTime> { DateTime.UtcNow } }
            };
        }

        private static List<object> GetListOfNullableDates()
        {
            return new List<object>
            {
                new object[] { null },
                new object[] { new List<DateTime?>() },
                new object[] { new List<DateTime?> { new DateTime?(DateTime.UtcNow) } }
            };
        }

        private static string[] GetMembersNames(ModelValidationResult result)
        {
            return result.InvalidProperties.SelectMany(p => p.Value.InvalidAttributes)
                .SelectMany(_ => _.ValidationResult.MemberNames).ToArray();
        }

        private void AssertIsValid(ModelValidationResult model)
        {
            Assert.That(model, Is.Not.Null);
            Assert.That(model.IsValid, Is.True);
            Assert.That(model.InvalidProperties, Is.Not.Null);
            Assert.That(model.InvalidProperties.Count, Is.EqualTo(0));
        }

        private void AssertIsNotValid(ModelValidationResult result, string propertyName, Type attributeType, ValidationType validationType)
        {
            AssertIsNotValid(result, 1);
            AssertIsNotValidProperty(result, propertyName, attributeType, validationType);
        }

        private void AssertIsNotValid(ModelValidationResult result, int count)
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.InvalidProperties, Is.Not.Null);
            Assert.That(result.InvalidProperties.Count, Is.EqualTo(count));
        }

        private void AssertIsNotValidProperty(ModelValidationResult result, string propertyName, Type attributeType, ValidationType validationType)
        {
            Assert.That(result.InvalidProperties.ContainsKey(propertyName));
            var propertyValidationResult = result.InvalidProperties[propertyName];
            Assert.That(propertyValidationResult.Name, Is.EqualTo(propertyName));
            Assert.That(propertyValidationResult.ValidationContext, Is.Not.Null);
            Assert.That(propertyValidationResult.InvalidAttributes, Is.Not.Null);
            Assert.That(propertyValidationResult.InvalidAttributes.Count, Is.EqualTo(1));
            var attributeValidationResult = propertyValidationResult.InvalidAttributes.First();
            Assert.That(attributeValidationResult.ValidationType, Is.EqualTo(validationType));
            Assert.That(attributeValidationResult.ValidationAttribute, Is.Not.Null);
            Assert.That(attributeValidationResult.ValidationAttribute.GetType(), Is.EqualTo(attributeType));
            Assert.That(attributeValidationResult.ValidationResult, Is.Not.Null);
            Assert.That(attributeValidationResult.ValidationResult.ErrorMessage, Is.Not.Null.And.Not.Empty);
            Assert.That(attributeValidationResult.ValidationResult.MemberNames, Is.Not.Null);
        }

        private ValidationAttribute GetValidationAttribute(ModelValidationResult model, string propertyName)
        {
            return model.InvalidProperties[propertyName].InvalidAttributes.First().ValidationAttribute;
        }
    }
}
