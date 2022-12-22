using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using IdokladSdk.Authentication.Extensions;
using IdokladSdk.Authentication.Models;
using IdokladSdk.Exceptions;
using IdokladSdk.UnitTests.Mocks;
using NSubstitute;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Authentication.Extensions
{
    [TestFixture]
    public partial class RestClientExtensionsTests
    {
        private HttpClient _serviceUnavailableClient;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var httpHandler = Substitute.ForPartsOf<MockHttpMessageHandler>();
            _serviceUnavailableClient = new HttpClient(httpHandler)
            {
                BaseAddress = new Uri("https://api.idoklad.cz")
            };

            httpHandler.MockSend(Arg.Any<HttpRequestMessage>(), Arg.Any<CancellationToken>())
                .Returns(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));
        }

        [Test]
        public void RequestAuthorizationCodeToken_ServiceUnavailable_ThrowsAsync()
        {
            // Arrange
            var request = new AuthorizationCodeTokenRequest();

            // Assert
            Assert.ThrowsAsync<IdokladUnavailableException>(async () => await _serviceUnavailableClient.SendRequestAsync(request));
        }

        [Test]
        public void RequestClientCredentialsToken_ServiceUnavailable_ThrowsAsync()
        {
            // Arrange
            var request = new ClientCredentialsTokenRequest();

            // Assert
            Assert.ThrowsAsync<IdokladUnavailableException>(async () => await _serviceUnavailableClient.SendRequestAsync(request));
        }

        [Test]
        public void RequestPinToken_ServiceUnavailable_ThrowsAsync()
        {
            // Arrange
            var request = new PinTokenRequest();

            // Assert
            Assert.ThrowsAsync<IdokladUnavailableException>(async () => await _serviceUnavailableClient.SendRequestAsync(request));
        }

        [Test]
        public void RequestRefreshToken_ServiceUnavailable_ThrowsAsync()
        {
            // Arrange
            var request = new RefreshTokenRequest();

            // Assert
            Assert.ThrowsAsync<IdokladUnavailableException>(async () => await _serviceUnavailableClient.SendRequestAsync(request));
        }
    }
}