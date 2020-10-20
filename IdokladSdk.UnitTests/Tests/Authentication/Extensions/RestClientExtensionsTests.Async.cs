using IdokladSdk.Authentication.Extensions;
using IdokladSdk.Authentication.Models;
using IdokladSdk.Exceptions;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Authentication.Extensions
{
    public partial class RestClientExtensionsTests
    {
        [Test]
        public void RequestAuthorizationCodeToken_ServiceUnavailable_ThrowsAsync()
        {
            // Arrange
            var request = new AuthorizationCodeTokenRequest();

            // Assert
            Assert.ThrowsAsync<IdokladUnavailableException>(async () => await _serviceUnavailableClient.RequestAuthorizationCodeTokenAsync(request));
        }

        [Test]
        public void RequestClientCredentialsToken_ServiceUnavailable_ThrowsAsync()
        {
            // Arrange
            var request = new ClientCredentialsTokenRequest();

            // Assert
            Assert.ThrowsAsync<IdokladUnavailableException>(async () => await _serviceUnavailableClient.RequestClientCredentialsTokenAsync(request));
        }

        [Test]
        public void RequestPinToken_ServiceUnavailable_ThrowsAsync()
        {
            // Arrange
            var request = new PinTokenRequest();

            // Assert
            Assert.ThrowsAsync<IdokladUnavailableException>(async () => await _serviceUnavailableClient.RequestPinTokenAsync(request));
        }

        [Test]
        public void RequestRefreshToken_ServiceUnavailable_ThrowsAsync()
        {
            // Arrange
            var request = new RefreshTokenRequest();

            // Assert
            Assert.ThrowsAsync<IdokladUnavailableException>(async () => await _serviceUnavailableClient.RequestRefreshTokenAsync(request));
        }
    }
}
