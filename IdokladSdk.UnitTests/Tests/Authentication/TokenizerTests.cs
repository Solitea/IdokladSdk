using IdokladSdk.Authentication;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Authentication
{
    [TestFixture]
    public class TokenizerTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        [TestCase("abc")]
        [TestCase("{ \"claim\":\"claimValue\" }")]
        public void AccessToken_ParseClaims_ReturnsNull(string accessToken)
        {
            // Act
            var tokenizer = new Tokenizer
            {
                AccessToken = accessToken
            };

            // Assert
            Assert.IsNull(tokenizer.Claims);
        }
    }
}