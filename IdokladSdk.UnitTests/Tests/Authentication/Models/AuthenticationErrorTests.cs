using IdokladSdk.Authentication.Models;
using IdokladSdk.Enums;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Authentication.Models
{
    [TestFixture]
    public class AuthenticationErrorTests
    {
        [TestCase("AuthErrorCode(0) - Agenda has Free status.", AuthenticationErrorCode.FreeSubscription)]
        [TestCase("AuthErrorCode(1) - Agenda has NeedToDowngrade status.", AuthenticationErrorCode.NeedToDowngrade)]
        [TestCase("AuthErrorCode(2) - Agenda has Expired status.", AuthenticationErrorCode.Expired)]
        [TestCase("AuthErrorCode(10)", null)]
        [TestCase("(20)AuthErrorCode", null)]
        [TestCase("(100)", null)]
        [TestCase("abcd(1)", null)]
        [TestCase("", null)]
        [TestCase("Random string", null)]
        public void GetErrorCode_ParsedCorrectly(string errorDescription, AuthenticationErrorCode? expectedResult)
        {
            // Arrange
            var authError = new AuthenticationError
            {
                ErrorDescription = errorDescription
            };

            // Assert
            Assert.AreEqual(expectedResult, authError.ErrorCode);
        }
    }
}
