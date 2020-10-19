using System.Net;
using System.Threading;
using IdokladSdk.Authentication.Extensions;
using IdokladSdk.Authentication.Models;
using IdokladSdk.Exceptions;
using NSubstitute;
using NUnit.Framework;
using RestSharp;

namespace IdokladSdk.UnitTests.Tests.Authentication.Extensions
{
    [TestFixture]
    public class RestClientExtensionsTests
    {
        private IRestClient _serviceUnavailableClient;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _serviceUnavailableClient = Substitute.For<IRestClient>();
            _serviceUnavailableClient.Execute(Arg.Any<IRestRequest>()).Returns(new RestResponse { StatusCode = HttpStatusCode.ServiceUnavailable });
            _serviceUnavailableClient.ExecuteAsync(Arg.Any<IRestRequest>(), Arg.Any<Method>(), Arg.Any<CancellationToken>())
                                        .Returns(new RestResponse { StatusCode = HttpStatusCode.ServiceUnavailable });
        }

        [Test]
        public void RequestAuthorizationCodeToken_ServiceUnavailable_Throws()
        {
            // Arrange
            var request = new AuthorizationCodeTokenRequest();

            // Assert
            Assert.Throws<IdokladUnavailableException>(() => _serviceUnavailableClient.RequestAuthorizationCodeToken(request));
        }

        [Test]
        public void RequestAuthorizationCodeToken_ServiceUnavailable_ThrowsAsync()
        {
            // Arrange
            var request = new AuthorizationCodeTokenRequest();

            // Assert
            Assert.ThrowsAsync<IdokladUnavailableException>(async () => await _serviceUnavailableClient.RequestAuthorizationCodeTokenAsync(request));
        }

        [Test]
        public void RequestClientCredentialsToken_ServiceUnavailable_Throws()
        {
            // Arrange
            var request = new ClientCredentialsTokenRequest();

            // Assert
            Assert.Throws<IdokladUnavailableException>(() => _serviceUnavailableClient.RequestClientCredentialsToken(request));
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
        public void RequestPinToken_ServiceUnavailable_Throws()
        {
            // Arrange
            var request = new PinTokenRequest();

            // Assert
            Assert.Throws<IdokladUnavailableException>(() => _serviceUnavailableClient.RequestPinToken(request));
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
        public void RequestRefreshToken_ServiceUnavailable_Throws()
        {
            // Arrange
            var request = new RefreshTokenRequest();

            // Assert
            Assert.Throws<IdokladUnavailableException>(() => _serviceUnavailableClient.RequestRefreshToken(request));
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
