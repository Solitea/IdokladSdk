using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model.Complex;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [Test]
        public void ComplexModel_Case1_ReturnsExpectedResults()
        {
            // Arrange
            var instance = new ComplexModel();
            var address = $"{nameof(ComplexModel.Address)}";
            var email = $"{nameof(ComplexModel.Email)}";
            var items = $"{nameof(ComplexModel.Items)}";

            // Act
            var validationResults = _modelValidator.Validate(instance);
            // Assert
            Assert.That(validationResults, Is.Not.Null);
            Assert.That(validationResults.IsValid, Is.False);
            Assert.That(validationResults.InvalidProperties, Is.Not.Null);
            Assert.That(validationResults.InvalidProperties.Count, Is.EqualTo(3));

            Assert.That(validationResults.InvalidProperties.ContainsKey(address), Is.True);
            var propertyValidationResult = validationResults.InvalidProperties[address];
            Assert.That(propertyValidationResult.Name, Is.EqualTo(address));
            Assert.That(propertyValidationResult.InvalidAttributes.Count, Is.EqualTo(1));
            Assert.That(propertyValidationResult.InvalidAttributes.First().ValidationAttribute.GetType(), Is.EqualTo(typeof(RequiredAttribute)));

            Assert.That(validationResults.InvalidProperties.ContainsKey(email), Is.True);
            propertyValidationResult = validationResults.InvalidProperties[email];
            Assert.That(propertyValidationResult.Name, Is.EqualTo(email));
            Assert.That(propertyValidationResult.InvalidAttributes.Count, Is.EqualTo(1));
            Assert.That(propertyValidationResult.InvalidAttributes.First().ValidationAttribute.GetType(), Is.EqualTo(typeof(RequiredAttribute)));

            Assert.That(validationResults.InvalidProperties.ContainsKey(items), Is.True);
            propertyValidationResult = validationResults.InvalidProperties[items];
            Assert.That(propertyValidationResult.Name, Is.EqualTo(items));
            Assert.That(propertyValidationResult.InvalidAttributes.Count, Is.EqualTo(1));
            Assert.That(propertyValidationResult.InvalidAttributes.First().ValidationAttribute.GetType(), Is.EqualTo(typeof(CollectionRangeAttribute)));
        }

        [Test]
        public void ComplexModel_Case2_ReturnsExpectedResults()
        {
            // Arrange
            var instance = new ComplexModel
            {
                Address = new AddressModel
                {
                    City = null,
                    PostalCode = "1234567",
                    Street = null
                },
                Email = "ThisEmailAddressIsProbablyLongerThatMaximumLengthOfThisPropertyAndIsNotValidEmailAddress",
                Items = new List<ItemModel>
            {
                new ItemModel
                {
                    Name = "VeryLongItemNameWhichExceedsMaximumItemLength",
                    Amount = 0,
                    Price = 0,
                    Discount = 110,
                    DiscountName = null
                }
            }
            };
            var addressCity = $"{nameof(ComplexModel.Address)}.{nameof(AddressModel.City)}";
            var addressPostalCode = $"{nameof(ComplexModel.Address)}.{nameof(AddressModel.PostalCode)}";
            var email = $"{nameof(ComplexModel.Email)}";
            var itemsName = $"{nameof(ComplexModel.Items)}[0].{nameof(ItemModel.Name)}";
            var itemsAmount = $"{nameof(ComplexModel.Items)}[0].{nameof(ItemModel.Amount)}";
            var itemsDiscount = $"{nameof(ComplexModel.Items)}[0].{nameof(ItemModel.Discount)}";
            var itemsDiscountName = $"{nameof(ComplexModel.Items)}[0].{nameof(ItemModel.DiscountName)}";

            // Act
            var validationResults = _modelValidator.Validate(instance);

            // Assert
            Assert.That(validationResults, Is.Not.Null);
            Assert.That(validationResults.IsValid, Is.False);
            Assert.That(validationResults.InvalidProperties, Is.Not.Null);
            Assert.That(validationResults.InvalidProperties.Count, Is.EqualTo(7));

            Assert.That(validationResults.InvalidProperties.ContainsKey(addressCity), Is.True);
            var propertyValidationResult = validationResults.InvalidProperties[addressCity];
            Assert.That(propertyValidationResult.Name, Is.EqualTo(addressCity));
            Assert.That(propertyValidationResult.InvalidAttributes.Count, Is.EqualTo(1));
            Assert.That(propertyValidationResult.InvalidAttributes.First().ValidationAttribute.GetType(), Is.EqualTo(typeof(RequiredAttribute)));

            Assert.That(validationResults.InvalidProperties.ContainsKey(addressPostalCode), Is.True);
            propertyValidationResult = validationResults.InvalidProperties[addressPostalCode];
            Assert.That(propertyValidationResult.Name, Is.EqualTo(addressPostalCode));
            Assert.That(propertyValidationResult.InvalidAttributes.Count, Is.EqualTo(1));
            Assert.That(propertyValidationResult.InvalidAttributes.First().ValidationAttribute.GetType(), Is.EqualTo(typeof(StringLengthAttribute)));

            Assert.That(validationResults.InvalidProperties.ContainsKey(email), Is.True);
            propertyValidationResult = validationResults.InvalidProperties[email];
            Assert.That(propertyValidationResult.Name, Is.EqualTo(email));
            Assert.That(propertyValidationResult.InvalidAttributes.Count, Is.EqualTo(2));
            Assert.That(propertyValidationResult.InvalidAttributes.ElementAt(0).ValidationAttribute.GetType(), Is.EqualTo(typeof(StringLengthAttribute)));
            Assert.That(propertyValidationResult.InvalidAttributes.ElementAt(1).ValidationAttribute.GetType(), Is.EqualTo(typeof(EmailAttribute)));

            Assert.That(validationResults.InvalidProperties.ContainsKey(itemsAmount), Is.True);
            propertyValidationResult = validationResults.InvalidProperties[itemsAmount];
            Assert.That(propertyValidationResult.Name, Is.EqualTo(itemsAmount));
            Assert.That(propertyValidationResult.InvalidAttributes.Count, Is.EqualTo(1));
            Assert.That(propertyValidationResult.InvalidAttributes.First().ValidationAttribute.GetType(), Is.EqualTo(typeof(CannotEqualAttribute)));

            Assert.That(validationResults.InvalidProperties.ContainsKey(itemsName), Is.True);
            propertyValidationResult = validationResults.InvalidProperties[itemsName];
            Assert.That(propertyValidationResult.Name, Is.EqualTo(itemsName));
            Assert.That(propertyValidationResult.InvalidAttributes.Count, Is.EqualTo(1));
            Assert.That(propertyValidationResult.InvalidAttributes.First().ValidationAttribute.GetType(), Is.EqualTo(typeof(StringLengthAttribute)));

            Assert.That(validationResults.InvalidProperties.ContainsKey(itemsDiscount), Is.True);
            propertyValidationResult = validationResults.InvalidProperties[itemsDiscount];
            Assert.That(propertyValidationResult.Name, Is.EqualTo(itemsDiscount));
            Assert.That(propertyValidationResult.InvalidAttributes.Count, Is.EqualTo(1));
            Assert.That(propertyValidationResult.InvalidAttributes.First().ValidationAttribute.GetType(), Is.EqualTo(typeof(System.ComponentModel.DataAnnotations.RangeAttribute)));

            Assert.That(validationResults.InvalidProperties.ContainsKey(itemsDiscountName), Is.True);
            propertyValidationResult = validationResults.InvalidProperties[itemsDiscountName];
            Assert.That(propertyValidationResult.Name, Is.EqualTo(itemsDiscountName));
            Assert.That(propertyValidationResult.InvalidAttributes.Count, Is.EqualTo(1));
            Assert.That(propertyValidationResult.InvalidAttributes.First().ValidationAttribute.GetType(), Is.EqualTo(typeof(RequiredIfHasValueAttribute)));
        }
    }
}