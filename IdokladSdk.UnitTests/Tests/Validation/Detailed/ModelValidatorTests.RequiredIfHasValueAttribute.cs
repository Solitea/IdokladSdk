using System;
using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    public partial class ModelValidatorTests
    {
        [TestCaseSource(nameof(GetValidModelsWithRequiredIfHasValueAttribute))]
        public void ModelWithRequiredIfHasValueAttribute_ValidModel_ReturnsExpectedResults(ModelWithRequiredIfHasValueAttribute model)
        {
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
                InitialState = null,
                Amount = 50m,
                CurrencyId = null
            };

            // Act
            var result = _modelValidator.Validate(model);

            // Assert
            AssertIsNotValid(result, 2);
            AssertIsNotValidProperty(result, nameof(model.InitialState), typeof(RequiredIfHasValueAttribute), ValidationType.RequiredIfHasValue);
            AssertIsNotValidProperty(result, nameof(model.CurrencyId), typeof(RequiredIfHasValueAttribute), ValidationType.RequiredIfHasValue);

            var initialStateAttribute = (RequiredIfHasValueAttribute)GetValidationAttribute(result, nameof(model.InitialState));
            Assert.That(initialStateAttribute.DependentProperty, Is.EqualTo(nameof(model.DateInitialState)));

            var currencyIdAttribute = (RequiredIfHasValueAttribute)GetValidationAttribute(result, nameof(model.CurrencyId));
            Assert.That(currencyIdAttribute.DependentProperty, Is.EqualTo(nameof(model.Amount)));
        }

        private static IList<object> GetValidModelsWithRequiredIfHasValueAttribute()
        {
            return new List<object>
        {
            new ModelWithRequiredIfHasValueAttribute(),
            new ModelWithRequiredIfHasValueAttribute
            {
                DateInitialState = new DateTime(2020, 12, 3),
                InitialState = 100000m
            },
            new ModelWithRequiredIfHasValueAttribute
            {
                CurrencyId = 1,
                Amount = 50m
            }
        };
        }
    }
}