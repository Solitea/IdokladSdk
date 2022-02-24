using System.ComponentModel.DataAnnotations;
using System.Linq;
using IdokladSdk.Models.Base;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.SourceGenerator
{
    [TestFixture]
    public class RequiredFieldsSourceGeneratorTests
    {
        [Test]
        public void RequiredFiledsDictionary_ModelsInDictionaryEqualsModelsInCode()
        {
            // Arrange
            var validableModelType = typeof(ValidatableModel);
            var models = validableModelType.Assembly.GetTypes()
                .Where(type => validableModelType.IsAssignableFrom(type))
                .Where(type => type.GetProperties().Any(property => property.GetCustomAttributes(typeof(RequiredAttribute), true).Any()));
            // Act
            var missingModels = models.Except(Constants.RequiredFields.Keys);
            var unnecessaryModels = Constants.RequiredFields.Keys.Except(models);

            // Assert
            Assert.AreEqual(0, missingModels.Count(), "Some models missing in dictionary");
            Assert.AreEqual(0, unnecessaryModels.Count(), "Some models are unnecessary in dictionary");
        }

        [Test]
        public void RequiredFiledsDictionary_PropertiesInDictionaryEqualsPropertiesInCode()
        {
            // Arrange
            var validableModelType = typeof(ValidatableModel);
            var modelsWithProperties = validableModelType.Assembly.GetTypes()
                .Where(type => validableModelType.IsAssignableFrom(type))
                .Where(type => type.GetProperties().Any(property => property.GetCustomAttributes(typeof(RequiredAttribute), true).Any()))
                .Select(type => new { Type = type, Properties = type.GetProperties().Where(property => property.GetCustomAttributes(typeof(RequiredAttribute), true).Any()).Select(property => property.Name) });

            foreach (var model in modelsWithProperties)
            {
                // Act
                var missingModels = model.Properties.Except(Constants.RequiredFields[model.Type]);
                var unnecessaryModels = Constants.RequiredFields[model.Type].Except(model.Properties);

                // Assert
                Assert.AreEqual(0, missingModels.Count(), "Some properties missing in dictionary");
                Assert.AreEqual(0, unnecessaryModels.Count(), "Some properties are unnecessary in dictionary");
            }
        }
    }
}
