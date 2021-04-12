using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Detailed.Model;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed
{
    [TestFixture]
    public class ValidationAttributeExtensionTests
    {
        [Test]
        public void GetValidationType_AllIdokladModelAttributes_DoesNotFail()
        {
            // Arrange
            var referenceType = typeof(ValidatableModel);
            var namespacePrefix = string.Join(".", referenceType.Namespace.Split(".").Take(2));
            var allModels = referenceType.Assembly.GetTypes()
                .Where(t => t.Namespace != null && t.Namespace.StartsWith(namespacePrefix))
                .ToList();
            Assert.That(allModels, Is.Not.Empty, $"No models were found in namespace starting with {namespacePrefix}.");
            var allModelProperties = allModels.SelectMany(m => m.GetRuntimeProperties().Where(IsPublicProperty))
                .ToList();
            var allPropertyAttributes = allModelProperties.SelectMany(p => p.GetCustomAttributes()
                .OfType<ValidationAttribute>())
                .ToList();

            // Act
            TestDelegate action = () =>
            {
                foreach (var attribute in allPropertyAttributes)
                {
                    attribute.GetValidationType();
                }
            };

            // Assert
            Assert.That(action, new ThrowsNothingConstraint());
        }

        private bool IsPublicProperty(PropertyInfo p) => (p.GetMethod != null && p.GetMethod.IsPublic) || (p.SetMethod != null && p.SetMethod.IsPublic);
    }
}
