using System;
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
    }
}
