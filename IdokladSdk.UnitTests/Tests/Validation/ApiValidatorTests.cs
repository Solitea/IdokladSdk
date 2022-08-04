using System;
using System.Collections.Generic;
using System.Linq;
using IdokladSdk.Requests.Core.Extensions;
using IdokladSdk.UnitTests.Tests.Validation.Model;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation
{
    [TestFixture]
    public class ApiValidatorTests
    {
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
            var result = ApiValidator.ValidateObject(entity, out var errors);

            // Assert
            Assert.False(result);
            Assert.AreEqual(2, errors.Count);
            var memberNames = errors.SelectMany(error => error.MemberNames).ToList();
            Assert.Contains(nameof(TestEntity.IdentificationNumber), memberNames);
            Assert.Contains(nameof(TestEntity.Name), memberNames);
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
            var result = ApiValidator.ValidateObject(entity, out var errors);

            // Assert
            Assert.False(result);
            Assert.AreEqual(4, errors.Count);
            var memberNames = errors.SelectMany(error => error.MemberNames).ToList();
            Assert.Contains(nameof(TestEntity.IdentificationNumber), memberNames);
            Assert.Contains(nameof(TestEntity.Rating), memberNames);
            Assert.Contains(nameof(TestEntity.NonNullableDate), memberNames);
            Assert.Contains(nameof(TestEntity.NullableDate), memberNames);
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
            var result = ApiValidator.ValidateObject(entity, out var errors);

            // Assert
            Assert.True(result);
            Assert.Zero(errors.Count);
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
            var result = ApiValidator.ValidateObject(entity, out var errors);

            // Assert
            Assert.True(result);
            Assert.AreEqual(0, errors.Count);
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
            var result = ApiValidator.ValidateObject(entity, out var errors);

            // Assert
            Assert.False(result);
            Assert.AreEqual(1, errors.Count);
            var memberNames = errors.SelectMany(error => error.MemberNames).ToList();
            Assert.Contains(nameof(TestEntity.DiscountPercentage), memberNames);
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
            var result = ApiValidator.ValidateObject(entity, out var errors);

            // Assert
            Assert.True(result);
            Assert.AreEqual(0, errors.Count);
        }

        [Test]
        public void ApiValidator_NestedEntities_InvalidValues_ReturnsFalse()
        {
            // Arrange
            var entity = new TestEntityWithNestedEntities
            {
                Entity = new TestEntity(),
                Entities = new List<TestEntity>
                {
                    new TestEntity
                    {
                        Name = "nestedInCollection1",
                        NonNullableDate = DateTime.Now.SetKindUtc(),
                        DiscountPercentage = 1000m
                    },
                    new TestEntity
                    {
                        Name = "nestedInCollection2",
                    },
                }
            };

            // Act
            var result = ApiValidator.ValidateObject(entity, out var errors);

            // Assert
            Assert.False(result);
            Assert.AreEqual(7, errors.Count);

            var memberNames = errors.SelectMany(error => error.MemberNames).ToList();
            Assert.AreEqual(1, memberNames.Count(x => x == nameof(TestEntity.Name)));
            Assert.AreEqual(1, memberNames.Count(x => x == nameof(TestEntity.DiscountPercentage)));
            Assert.AreEqual(2, memberNames.Count(x => x == nameof(TestEntity.NonNullableDate)));
            Assert.AreEqual(3, memberNames.Count(x => x == nameof(TestEntity.IdentificationNumber)));
        }
    }
}
