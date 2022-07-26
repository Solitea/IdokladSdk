using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
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
