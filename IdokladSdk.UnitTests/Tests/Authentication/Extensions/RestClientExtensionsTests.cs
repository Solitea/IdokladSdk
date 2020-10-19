using System.Net;
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
        private RestClient _serviceUnavailableClient;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _serviceUnavailableClient = Substitute.For<RestClient>();
            _serviceUnavailableClient.Execute(Arg.Any<IRestRequest>()).Returns(new RestResponse { StatusCode = HttpStatusCode.ServiceUnavailable });
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
        public void RequestClientCredentialsToken_ServiceUnavailable_Throws()
        {
            // Arrange
            var request = new ClientCredentialsTokenRequest();

            // Assert
            Assert.Throws<IdokladUnavailableException>(() => _serviceUnavailableClient.RequestClientCredentialsToken(request));
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
        public void RequestRefreshToken_ServiceUnavailable_Throws()
        {
            // Arrange
            var request = new RefreshTokenRequest();

            // Assert
            Assert.Throws<IdokladUnavailableException>(() => _serviceUnavailableClient.RequestRefreshToken(request));
        }
    }
}
