using IdokladSdk.Exceptions;
using IdokladSdk.Models.Account;
using IdokladSdk.Validation;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation
{
    [TestFixture]
    public class AgendaValidatorTests
    {
        [TestCase("x", true)]
        [TestCase("x", null)]
        [TestCase("25568736", true)]
        [TestCase(null, false)]
        [TestCase(null, true)]
        [TestCase("", false)]
        [TestCase(" ", true)]
        [TestCase(" ", null)]
        public void ValidatePatch_IdentificationNumber_InvalidCombination_ThrowsException(string identificationNumber, bool? hasNoIdentificationNumber)
        {
            // Arrange
            var model = new AgendaPatchModel
            {
                Contact = new AgendaContactPatchModel
                {
                    IdentificationNumber = identificationNumber,
                    HasNoIdentificationNumber = hasNoIdentificationNumber
                }
            };

            // Act
            TestDelegate action = () => AgendaValidator.ValidatePatch(model);

            // Assert
            Assert.Throws<IdokladSdkException>(action);
        }

        [TestCase("25568736", false)]
        [TestCase(null, null)]
        [TestCase("", true)]
        public void ValidatePatch_IdentificationNumber_ValidCombination_DoesNotThrows(string identificationNumber, bool? hasNoIdentificationNumber)
        {
            // Arrange
            var model = new AgendaPatchModel
            {
                Contact = new AgendaContactPatchModel
                {
                    IdentificationNumber = identificationNumber,
                    HasNoIdentificationNumber = hasNoIdentificationNumber
                }
            };

            // Act
            TestDelegate action = () => AgendaValidator.ValidatePatch(model);

            // Assert
            Assert.DoesNotThrow(action);
        }
    }
}
