using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Authentication;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Models.EInvoiceSettings;
using Newtonsoft.Json.Linq;
using NSubstitute;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Clients
{
    /// <summary>
    /// Tests for electronic invoice API contracts.
    /// </summary>
    [TestFixture]
    public class EInvoiceClientTests
    {
        [Test]
        public async Task EInvoiceSettingsClient_UsesExpectedRoutesAndRequestBodies()
        {
            using var handler = new RecordingHandler(request =>
                request.Method == HttpMethod.Get ? "{\"IsSuccess\":true,\"Data\":[]}" : "{\"IsSuccess\":true,\"Data\":true}");
            using var httpClient = new HttpClient(handler);
            var context = CreateContext(httpClient);
            var client = new EInvoiceSettingsClient(context);

            await client.GetAsync();
            await client.PostAsync(new EInvoiceSettingsPostModel
            {
                ClientId = "client-id",
                ClientSecret = "secret",
                IsSendingEnabled = true,
                Type = AccessPointType.SeyforSk
            });
            await client.UpdateAsync(new EInvoiceSettingsPatchModel { Id = 42, IsReceivingEnabled = true });
            await client.DeleteAsync(42);

            Assert.That(handler.Requests, Has.Count.EqualTo(4));
            Assert.That(handler.Requests[0].Method, Is.EqualTo("GET"));
            Assert.That(handler.Requests[0].Path, Is.EqualTo("/v3/EInvoiceSettings"));
            Assert.That(handler.Requests[1].Method, Is.EqualTo("POST"));
            Assert.That(handler.Requests[1].Path, Is.EqualTo("/v3/EInvoiceSettings"));
            Assert.That(JObject.Parse(handler.Requests[1].Body)["ClientSecret"].Value<string>(), Is.EqualTo("secret"));
            Assert.That(handler.Requests[2].Method, Is.EqualTo("PATCH"));
            Assert.That(handler.Requests[2].Path, Is.EqualTo("/v3/EInvoiceSettings"));
            var patch = JObject.Parse(handler.Requests[2].Body);
            Assert.That(patch["Id"].Value<int>(), Is.EqualTo(42));
            Assert.That(patch["IsReceivingEnabled"].Value<bool>(), Is.True);
            Assert.That(patch.Property("ClientSecret"), Is.Null);
            Assert.That(patch.Property("IsSendingEnabled"), Is.Null);
            Assert.That(handler.Requests[3].Method, Is.EqualTo("DELETE"));
            Assert.That(handler.Requests[3].Path, Is.EqualTo("/v3/EInvoiceSettings/42"));
        }

        [Test]
        public async Task ValidatePeppolAsync_UsesAttachmentIdAndReadsStructuredErrors()
        {
            const string response = "{\"IsSuccess\":true,\"Data\":{\"IsValid\":false,\"Errors\":[{\"Location\":\"Invoice/ID\",\"Message\":\"Invalid value\",\"RuleId\":\"R1\",\"Stage\":2}]}}";
            using var handler = new RecordingHandler(_ => response);
            using var httpClient = new HttpClient(handler);
            var client = new AttachmentClient(CreateContext(httpClient));

            var result = await client.ValidatePeppolAsync(123);

            Assert.That(handler.Requests, Has.Count.EqualTo(1));
            Assert.That(handler.Requests[0].Method, Is.EqualTo("GET"));
            Assert.That(handler.Requests[0].Path, Is.EqualTo("/v3/Attachments/ValidatePeppol/123"));
            Assert.That(result.Data.IsValid, Is.False);
            Assert.That(result.Data.Errors, Has.Count.EqualTo(1));
            Assert.That(System.Linq.Enumerable.First(result.Data.Errors).Stage, Is.EqualTo(ApiPeppolValidationStage.Xsd));
            Assert.That(System.Linq.Enumerable.First(result.Data.Errors).RuleId, Is.EqualTo("R1"));
        }

        [Test]
        public async Task GetPeppolAttachmentsAsync_UsesAttachmentIdAndReadsZipArchive()
        {
            var zipBytes = new byte[] { 0x50, 0x4B, 0x03, 0x04 };
            var response = $"{{\"IsSuccess\":true,\"Data\":{{\"Id\":123,\"FileName\":\"invoice.zip\",\"FileBytes\":\"{Convert.ToBase64String(zipBytes)}\"}}}}";
            using var handler = new RecordingHandler(_ => response);
            using var httpClient = new HttpClient(handler);
            var client = new AttachmentClient(CreateContext(httpClient));

            var result = await client.GetPeppolAttachmentsAsync(123);

            Assert.That(handler.Requests, Has.Count.EqualTo(1));
            Assert.That(handler.Requests[0].Method, Is.EqualTo("GET"));
            Assert.That(handler.Requests[0].Path, Is.EqualTo("/v3/Attachments/PeppolAttachments/123"));
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Data.Id, Is.EqualTo(123));
            Assert.That(result.Data.FileName, Is.EqualTo("invoice.zip"));
            Assert.That(result.Data.FileBytes, Is.EqualTo(zipBytes));
        }

        private static ApiContext CreateContext(HttpClient httpClient)
        {
            var token = new Tokenizer
            {
                AccessToken = "test-token",
                ExpiresIn = 3600,
                GrantType = GrantType.ClientCredentials
            };
            var authentication = Substitute.For<IAuthentication>();
            authentication.GetTokenAsync(Arg.Any<HttpClient>(), Arg.Any<CancellationToken>()).Returns(Task.FromResult(token));

            return new ApiContext(new ApiContextConfiguration
            {
                HttpClient = httpClient,
                AppName = "unit-tests",
                AppVersion = "1.0",
                Authentication = authentication,
                Configuration = new DokladConfiguration()
            });
        }

        private sealed class RecordingHandler : HttpMessageHandler
        {
            private readonly Func<HttpRequestMessage, string> _responseBody;

            public RecordingHandler(Func<HttpRequestMessage, string> responseBody)
            {
                _responseBody = responseBody;
            }

            public List<RecordedRequest> Requests { get; } = new List<RecordedRequest>();

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Requests.Add(new RecordedRequest
                {
                    Method = request.Method.Method,
                    Path = request.RequestUri.AbsolutePath,
                    Body = request.Content == null ? null : await request.Content.ReadAsStringAsync()
                });

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(_responseBody(request))
                };
            }
        }

        private sealed class RecordedRequest
        {
            public string Method { get; set; }

            public string Path { get; set; }

            public string Body { get; set; }
        }
    }
}
