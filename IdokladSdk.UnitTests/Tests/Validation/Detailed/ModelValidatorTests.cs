using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model.Complex;
using IdokladSdk.Validation;
using IdokladSdk.Validation.Attributes;
using IdokladSdk.Validation.Detailed.Model;
using NUnit.Framework;
using RangeAttribute = System.ComponentModel.DataAnnotations.RangeAttribute;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    [TestFixture]
    public class ModelValidatorTests
    {
        private ModelValidator _modelValidator;

        [SetUp]
        public void SetUp()
        {
            _modelValidator = new ModelValidator();
        }

        [Test]
        public void ModelWithRequiredAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithRequiredAttribute
            {
                Name = "aaa"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithRequiredAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithRequiredAttribute();

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.Name), typeof(RequiredAttribute), ValidationType.Required);
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
        public void ModelWithStringLengthAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithStringLengthAttribute
            {
                Name = "1234567890"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithStringLengthAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithStringLengthAttribute
            {
                Name = "123456789"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.Name), typeof(StringLengthAttribute), ValidationType.StringLength);
        }

        [Test]
        public void ModelWithRangeAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithRangeAttribute
            {
                Discount = 10
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithRangeAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithRangeAttribute
            {
                Discount = 150
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.Discount), typeof(RangeAttribute), ValidationType.Range);
        }

        [Test]
        public void ModelWithRegularExpressionAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithRegularExpressionAttribute
            {
                DocumentNumber = "123456"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithRegularExpressionAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithRegularExpressionAttribute
            {
                DocumentNumber = "AAA"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.DocumentNumber), typeof(RegularExpressionAttribute), ValidationType.RegularExpression);
        }

        [Test]
        public void ModelWithCannotEqualAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithCannotEqualAttribute
            {
                Amount = 100.50m,
                IssuedInvoiceItemType = IssuedInvoiceItemType.ItemTypeNormal
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithCannotEqualAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithCannotEqualAttribute
            {
                Amount = 0,
                IssuedInvoiceItemType = IssuedInvoiceItemType.ItemTypeReduce
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, 2);
            AssertIsNotValidProperty(result, nameof(model.Amount), typeof(CannotEqualAttribute), ValidationType.CannotEqual);
            var attribute = (CannotEqualAttribute)GetValidationAttribute(result, nameof(model.Amount));
            Assert.That(attribute.InvalidValue, Is.EqualTo(0));
            Assert.That(attribute.Reason, Is.Not.Null);
            AssertIsNotValidProperty(result, nameof(model.IssuedInvoiceItemType), typeof(CannotEqualAttribute), ValidationType.CannotEqual);
            attribute = (CannotEqualAttribute)GetValidationAttribute(result, nameof(model.IssuedInvoiceItemType));
            Assert.That(attribute.InvalidValue, Is.EqualTo(IssuedInvoiceItemType.ItemTypeReduce));
            Assert.That(attribute.Reason, Is.Not.Null);
        }

        [Test]
        public void ModelWithCollectionRangeAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithCollectionRangeAttribute
            {
                EntityIds = new List<int> { 1, 2 }
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithCollectionRangeAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithCollectionRangeAttribute();

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.EntityIds), typeof(CollectionRangeAttribute), ValidationType.CollectionRange);
            var attribute = (CollectionRangeAttribute)GetValidationAttribute(result, nameof(model.EntityIds));
            Assert.That(attribute.MinLength, Is.EqualTo(1));
            Assert.That(attribute.MaxLength, Is.EqualTo(2));
            Assert.That(attribute.AllowNull, Is.EqualTo(false));
        }

        [Test]
        public void ModelWithDateGreaterOrEqualAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithDateGreaterOrEqualThanAttribute
            {
                DateOfIssue = new DateTime(2020, 12, 3)
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithDateGreaterOrEqualAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithDateGreaterOrEqualThanAttribute();

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.DateOfIssue), typeof(DateGreaterOrEqualThanAttribute), ValidationType.DateGreaterOrEqualThan);
            var attribute = (DateGreaterOrEqualThanAttribute)GetValidationAttribute(result, nameof(model.DateOfIssue));
            Assert.That(attribute.MinDateTime, Is.EqualTo(new DateTime(1753, 1, 1)));
            Assert.That(attribute.AllowNull, Is.EqualTo(false));
        }

        [Test]
        public void ModelWithDateTimeAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithDateTimeAttribute
            {
                DateOfIssue = new DateTime(2020, 12, 3)
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithDateTimeAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithDateTimeAttribute();

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.DateOfIssue), typeof(DateTimeAttribute), ValidationType.DateTime);
            var attribute = (DateTimeAttribute)GetValidationAttribute(result, nameof(model.DateOfIssue));
            Assert.That(attribute.Minimum, Is.EqualTo(new DateTime(1753, 1, 1)));
            Assert.That(attribute.Maximum, Is.EqualTo(new DateTime(9999, 12, 31)));
        }

        [Test]
        public void ModelWithDecimalGreaterThanZeroAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithDecimalGreaterThanZeroAttribute
            {
                Amount = 100m
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithDecimalGreaterThanZeroAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithDecimalGreaterThanZeroAttribute();

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.Amount), typeof(DecimalGreaterThanZeroAttribute), ValidationType.DecimalGreaterThanZero);
        }

        [Test]
        public void ModelWithEmailAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithEmailAttribute
            {
                Email = "ales.micin@solitea.cz"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithEmailAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithEmailAttribute
            {
                Email = "ThisIsNotValidEmailAddress"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.Email), typeof(EmailAttribute), ValidationType.EmailAddress);
        }

        [Test]
        public void ModelWithEmailCollectionAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithEmailCollectionAttribute
            {
                OtherRecipients = new List<string>
                {
                    "ales.micin@solitea.cz",
                    "richard.loukota@solitea.cz"
                }
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithEmailCollectionAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithEmailCollectionAttribute
            {
                OtherRecipients = new List<string>
                {
                    "ThisIsNotValidEmailAddress",
                }
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.OtherRecipients), typeof(EmailCollectionAttribute), ValidationType.EmailCollection);
        }

        [Test]
        public void ModelWithMinCollectionLengthAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithMinCollectionLengthAttribute
            {
                RelatedEntityIds = new List<int> { 1 }
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithMinCollectionLengthAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithMinCollectionLengthAttribute();

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.RelatedEntityIds), typeof(MinCollectionLengthAttribute), ValidationType.MinCollectionLength);
        }

        [Test]
        public void ModelWithNotEmptyStringAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithNotEmptyStringAttribute
            {
                Description = "Some text"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithNotEmptyStringAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithNotEmptyStringAttribute
            {
                Description = string.Empty
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.Description), typeof(NotEmptyStringAttribute), ValidationType.NotEmptyString);
        }

        [Test]
        public void ModelWithNullableForeignKeyAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithNullableForeignKeyAttribute
            {
                SalesPosEuqipmentId = 1
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithNullableForeignKeyAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithNullableForeignKeyAttribute
            {
                SalesPosEuqipmentId = 0
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.SalesPosEuqipmentId), typeof(NullableForeignKeyAttribute), ValidationType.NullableForeignKey);
        }

        [Test]
        public void ModelWithRequiredIfAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithRequiredIfAttribute
            {
                WasSent = true,
                DateOfSent = new DateTime(2020, 12, 3)
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithRequiredIfAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithRequiredIfAttribute
            {
                WasSent = true,
                DateOfSent = null,
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.DateOfSent), typeof(RequiredIfAttribute), ValidationType.RequiredIf);
            var attribute = (RequiredIfAttribute)GetValidationAttribute(result, nameof(model.DateOfSent));
            Assert.That(attribute.DependentProperty, Is.EqualTo(nameof(model.WasSent)));
            Assert.That(attribute.TargetValue, Is.EqualTo(true));
        }

        [Test]
        public void ModelWithRequiredIfHasValueAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithRequiredIfHasValueAttribute
            {
                DateInitialState = new DateTime(2020, 12, 3),
                InitialState = 100000m
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithRequiredIfHasValueAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithRequiredIfHasValueAttribute
            {
                DateInitialState = new DateTime(2020, 12, 3),
                InitialState = null
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.InitialState), typeof(RequiredIfHasValueAttribute), ValidationType.RequiredIfHasValue);
            var attribute = (RequiredIfHasValueAttribute)GetValidationAttribute(result, nameof(model.InitialState));
            Assert.That(attribute.DependentProperty, Is.EqualTo(nameof(model.DateInitialState)));
        }

        [Test]
        public void ModelWithRequiredNonDefaultAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithRequiredNonDefaultAttribute
            {
                CurrencyId = 1
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithRequiredNonDefaultAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithRequiredNonDefaultAttribute();

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.CurrencyId), typeof(RequiredNonDefaultAttribute), ValidationType.RequiredNonDefault);
        }

        [Test]
        public void ModelWithIdentificationNumberAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithIdentificationNumberAttribute
            {
                IdentificationNumber = "68636938"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithIdentificationNumberAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithIdentificationNumberAttribute
            {
                IdentificationNumber = "12345678"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.IdentificationNumber), typeof(IdentificationNumberAttribute), ValidationType.IdentificationNumber);
        }

        [Test]
        public void ModelWithNumericSequenceNumberFormatAttribute_ValidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithNumericSequenceNumberFormatAttribute
            {
                LastNumber = null,
                NumberFormat = "FV{RR}{MM}{NNNN}"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [TestCase("x", false)]
        [TestCase("x", true)]
        [TestCase("25568736", true)]
        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase(" ", true)]
        public void ModelWithHasNoIdentificationNumber_InvalidModel_ReturnsExpectedResults(string identificationNumber, bool hasNoIdentificationNumber)
        {
            // Arrange
            var model = new ModelWithHasNoIdentificationNumber()
            {
                IdentificationNumber = identificationNumber,
                HasNoIdentificationNumber = hasNoIdentificationNumber
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.IdentificationNumber), typeof(IdentificationNumberAttribute), ValidationType.IdentificationNumber);
        }

        [TestCase("25568736", false)]
        [TestCase("", true)]
        public void ModelWithHasNoIdentificationNumber_ValidModel_ReturnsExpectedResults(string identificationNumber, bool hasNoIdentificationNumber)
        {
            // Arrange
            var model = new ModelWithHasNoIdentificationNumber()
            {
                IdentificationNumber = identificationNumber,
                HasNoIdentificationNumber = hasNoIdentificationNumber
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [TestCase("x", true)]
        [TestCase("x", null)]
        [TestCase("25568736", true)]
        [TestCase(null, false)]
        [TestCase(null, true)]
        [TestCase("", false)]
        [TestCase(" ", true)]
        [TestCase(" ", null)]
        public void ModelWithNullableHasNoIdentificationNumber_InvalidModel_ReturnsExpectedResults(string identificationNumber, bool? hasNoIdentificationNumber)
        {
            // Arrange
            var model = new ModelWithNullableHasNoIdentificationNumber()
            {
                IdentificationNumber = identificationNumber,
                HasNoIdentificationNumber = hasNoIdentificationNumber
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.IdentificationNumber), typeof(IdentificationNumberPatchAttribute), ValidationType.IdentificationNumber);
        }

        [TestCase("25568736", false)]
        [TestCase(null, null)]
        [TestCase("", true)]
        public void ModelWithNullableHasNoIdentificationNumber_ValidModel_ReturnsExpectedResults(string identificationNumber, bool? hasNoIdentificationNumber)
        {
            // Arrange
            var model = new ModelWithNullableHasNoIdentificationNumber()
            {
                IdentificationNumber = identificationNumber,
                HasNoIdentificationNumber = hasNoIdentificationNumber
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [Test]
        public void ModelWithNumericSequenceNumberFormatAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithNumericSequenceNumberFormatAttribute
            {
                LastNumber = 123,
                NumberFormat = "FV{RR}{MM}{NNNNN}"
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.NumberFormat), typeof(NumericSequenceNumberFormatAttribute), ValidationType.NumericSequenceNumberFormat);
        }

        [Test]
        public void ModelWithIbanAttribute_InvalidModel_ReturnsExpectedResults()
        {
            // Arrange
            var model = new ModelWithIbanAttribute()
            {
                Iban = "Wrong iban",
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.Iban), typeof(IbanAttribute), ValidationType.Iban);
        }

        [TestCase("SK3002000000003604642112")]
        [TestCase("")]
        [TestCase(null)]
        public void ModelWithIbanAttribute_ValidModel_ReturnsExpectedResults(string value)
        {
            // Arrange
            var model = new ModelWithIbanAttribute()
            {
                Iban = value,
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [TestCase("#000000")]
        [TestCase("#123456")]
        [TestCase("#abcdef")]
        [TestCase("#ABCDEF")]
        [TestCase("#a1B23C")]
        [TestCase("#ffFFff")]
        public void ModelWithColorAttribute_ValidModel_ReturnsExpectedResults(string value)
        {
            // Arrange
            var model = new ModelWithColorAttribute()
            {
                Color = value,
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsValid(result);
        }

        [TestCase("blue")]
        [TestCase("#aabbccd")]
        [TestCase("#abc")]
        [TestCase("#123")]
        [TestCase("abcdef")]
        [TestCase("123456")]
        public void ModelWithColorAttribute_InvalidModel_ReturnsExpectedResults(string value)
        {
            // Arrange
            var model = new ModelWithColorAttribute()
            {
                Color = value,
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, nameof(model.Color), typeof(ColorAttribute), ValidationType.Color);
        }

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
            Assert.That(propertyValidationResult.InvalidAttributes.First().ValidationAttribute.GetType(), Is.EqualTo(typeof(RangeAttribute)));

            Assert.That(validationResults.InvalidProperties.ContainsKey(itemsDiscountName), Is.True);
            propertyValidationResult = validationResults.InvalidProperties[itemsDiscountName];
            Assert.That(propertyValidationResult.Name, Is.EqualTo(itemsDiscountName));
            Assert.That(propertyValidationResult.InvalidAttributes.Count, Is.EqualTo(1));
            Assert.That(propertyValidationResult.InvalidAttributes.First().ValidationAttribute.GetType(), Is.EqualTo(typeof(RequiredIfHasValueAttribute)));
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

        private ValidationAttribute GetValidationAttribute(ModelValidationResult model)
        {
            return model.InvalidProperties.Values.First().InvalidAttributes.First().ValidationAttribute;
        }

        private ValidationAttribute GetValidationAttribute(ModelValidationResult model, string propertyName)
        {
            return model.InvalidProperties[propertyName].InvalidAttributes.First().ValidationAttribute;
        }
    }
}
