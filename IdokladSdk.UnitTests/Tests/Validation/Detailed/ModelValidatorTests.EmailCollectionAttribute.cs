using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;
using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed;

public partial class ModelValidatorTests
{
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
}
