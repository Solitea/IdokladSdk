using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Authentication;
using NSubstitute;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Clients
{
    public class MeasureCodeClientTests
    {
        private const string UnitJson = "{\"Id\":42,\"Code\":\"C62\",\"Name\":\"piece\",\"Rank\":100,\"DateLastChange\":\"2026-11-09T08:48:57Z\"}";

        [Test]
        public async Task List_FiltersAndPagesMeasureCodes()
        {
            var requests = new List<Uri>();
            using var handler = CreateHandler($"{{\"IsSuccess\":true,\"Data\":{{\"Items\":[{UnitJson}],\"TotalItems\":21,\"TotalPages\":3}}}}", requests);
            using var httpClient = new HttpClient(handler);
            var api = CreateApi(httpClient);
            var changedSince = new DateTime(2026, 11, 1, 0, 0, 0, DateTimeKind.Utc);

            var result = await api.MeasureCodeClient.List()
                .Filter(filter => filter.Code.IsEqual("C62"))
                .Filter(filter => filter.DateLastChange.IsGreaterThan(changedSince))
                .Page(2).PageSize(10).GetAsync();

            Assert.That(requests.Single().AbsolutePath, Is.EqualTo("/v3/MeasureCodes"));
            var query = Uri.UnescapeDataString(requests.Single().Query);
            Assert.That(query, Does.Contain("Code~eq:base64~QzYy"));
            Assert.That(query, Does.Contain("DateLastChange~gt~2026-11-01"));
            Assert.That(query, Does.Contain("page=2"));
            Assert.That(query, Does.Contain("pageSize=10"));
            Assert.That(query, Does.Not.Contain("sort="));
            Assert.That(result.Data.TotalPages, Is.EqualTo(3));
            var unit = result.Data.Items.Single();
            Assert.That(unit.Id, Is.EqualTo(42));
            Assert.That(unit.Code, Is.EqualTo("C62"));
            Assert.That(unit.Name, Is.EqualTo("piece"));
            Assert.That(unit.Rank, Is.EqualTo(100));
            Assert.That(unit.DateLastChange, Is.EqualTo(new DateTime(2026, 11, 9, 8, 48, 57, DateTimeKind.Utc)));
            Assert.That(api.MeasureCodeClient, Is.SameAs(api.MeasureCodeClient));
        }

        [Test]
        public async Task Detail_ReadsMeasureCodeById()
        {
            var requests = new List<Uri>();
            using var handler = CreateHandler($"{{\"IsSuccess\":true,\"Data\":{UnitJson}}}", requests);
            using var httpClient = new HttpClient(handler);

            var result = await CreateApi(httpClient).MeasureCodeClient.Detail(42).GetAsync();

            Assert.That(requests.Single().AbsolutePath, Is.EqualTo("/v3/MeasureCodes/42"));
            Assert.That(result.Data.Code, Is.EqualTo("C62"));
        }

        [Test]
        public async Task SystemCodeBooks_ReadsMeasureCodesAndChangeFlag()
        {
            var requests = new List<Uri>();
            using var handler = new RecordingHandler(request =>
            {
                requests.Add(request.RequestUri);
                var data = request.RequestUri.AbsolutePath.EndsWith("Changes", StringComparison.Ordinal)
                    ? "{\"MeasureCodes\":true}"
                    : $"{{\"MeasureCodes\":[{UnitJson}]}}";
                return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent($"{{\"IsSuccess\":true,\"Data\":{data}}}") };
            });
            using var httpClient = new HttpClient(handler);
            var api = CreateApi(httpClient);

            var codeBooks = await api.SystemClient.CodeBooks().GetAsync();
            var changes = await api.SystemClient.CodeBooksChanges(new DateTime(2026, 11, 1, 0, 0, 0, DateTimeKind.Utc)).GetAsync();

            Assert.That(codeBooks.Data.MeasureCodes.Single().Code, Is.EqualTo("C62"));
            Assert.That(changes.Data.MeasureCodes, Is.True);
        }

        private static RecordingHandler CreateHandler(string response, List<Uri> requests)
        {
            return new RecordingHandler(request =>
            {
                Assert.That(request.Method, Is.EqualTo(HttpMethod.Get));
                requests.Add(request.RequestUri);
                return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(response) };
            });
        }

        private static DokladApi CreateApi(HttpClient httpClient)
        {
            var token = new Tokenizer { AccessToken = "test-token", ExpiresIn = 3600, GrantType = GrantType.ClientCredentials };
            var authentication = Substitute.For<IAuthentication>();
            authentication.GetTokenAsync(Arg.Any<HttpClient>(), Arg.Any<CancellationToken>()).Returns(Task.FromResult(token));
            return new DokladApi(new ApiContext(new ApiContextConfiguration
            {
                HttpClient = httpClient,
                AppName = "unit-tests",
                AppVersion = "1.0",
                Authentication = authentication,
                Configuration = new DokladConfiguration()
            }));
        }

        private sealed class RecordingHandler : HttpMessageHandler
        {
            private readonly Func<HttpRequestMessage, HttpResponseMessage> _response;

            public RecordingHandler(Func<HttpRequestMessage, HttpResponseMessage> response)
            {
                _response = response;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_response(request));
            }
        }
    }
}
