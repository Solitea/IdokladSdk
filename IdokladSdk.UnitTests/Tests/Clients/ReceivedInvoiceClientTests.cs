using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Authentication;
using IdokladSdk.Enums;
using IdokladSdk.Models.ReceivedInvoice;
using IdokladSdk.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NSubstitute;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Clients
{
    public class ReceivedInvoiceClientTests
    {
        [TestCase(ReceivedDocumentType.ReceivedInvoice, 5)]
        [TestCase(ReceivedDocumentType.ReceivedCreditNote, 13)]
        [TestCase(ReceivedDocumentType.ReceivedDebitNote, 14)]
        [TestCase(ReceivedDocumentType.ReceivedTaxDocument, 15)]
        [TestCase(ReceivedDocumentType.ReceivedProformaInvoice, 16)]
        public async Task DefaultAndPost_UseReceivedDocumentType(ReceivedDocumentType documentType, int apiValue)
        {
            using var handler = new RecordingHandler(_ => $"{{\"DocumentType\":{apiValue},\"IsEInvoice\":true,\"EInvoiceChannel\":3}}");
            using var httpClient = new HttpClient(handler);
            var client = CreateApi(httpClient).ReceivedInvoiceClient;

            var defaults = await client.DefaultAsync(documentType);
            var model = new ReceivedInvoicePostModel
            {
                DocumentType = documentType,
                CorrectedDocumentNumber = "original-123",
                CurrencyId = 1,
                DateOfMaturity = new DateTime(2026, 11, 30, 0, 0, 0, DateTimeKind.Utc),
                DateOfReceiving = new DateTime(2026, 11, 18, 0, 0, 0, DateTimeKind.Utc),
                Description = "Received document",
                PartnerId = 1,
                PaymentOptionId = 1,
                Items = new List<ReceivedInvoiceItemPostModel> { new ReceivedInvoiceItemPostModel { Name = "Item", Amount = 1 } }
            };
            var created = await client.PostAsync(model);

            Assert.That(handler.Requests[0].Method, Is.EqualTo(HttpMethod.Get));
            Assert.That(handler.Requests[0].Uri.AbsolutePath, Is.EqualTo("/v3/ReceivedInvoices/Default"));
            Assert.That(handler.Requests[0].Uri.Query, Is.EqualTo($"?documentType={apiValue}"));
            Assert.That(defaults.Data.DocumentType, Is.EqualTo(documentType));
            Assert.That(defaults.Data.IsEInvoice, Is.True);
            Assert.That(defaults.Data.EInvoiceChannel, Is.EqualTo(EInvoiceChannel.XmlSentViaPeppol));
            Assert.That(handler.Requests[1].Method, Is.EqualTo(HttpMethod.Post));
            Assert.That(handler.Requests[1].Uri.AbsolutePath, Is.EqualTo("/v3/ReceivedInvoices"));
            var body = JObject.Parse(handler.Requests[1].Body);
            Assert.That(body["DocumentType"].Value<int>(), Is.EqualTo(apiValue));
            Assert.That(body["CorrectedDocumentNumber"].Value<string>(), Is.EqualTo("original-123"));
            Assert.That(created.Data.DocumentType, Is.EqualTo(documentType));
        }

        [Test]
        public async Task Default_PreservesExistingCallsAndCombinesInboxWithDocumentType()
        {
            using var handler = new RecordingHandler(_ => "{\"DocumentType\":5}");
            using var httpClient = new HttpClient(handler);
            var client = CreateApi(httpClient).ReceivedInvoiceClient;

            await client.DefaultAsync();
            await client.DefaultAsync(42);
            await client.DefaultAsync(42, ReceivedDocumentType.ReceivedDebitNote);

            Assert.That(handler.Requests[0].Uri.Query, Is.Empty);
            Assert.That(handler.Requests[1].Uri.Query, Is.EqualTo("?inboxId=42"));
            Assert.That(handler.Requests[2].Uri.Query, Does.Contain("inboxId=42"));
            Assert.That(handler.Requests[2].Uri.Query, Does.Contain("documentType=14"));
            var body = JObject.FromObject(new ReceivedInvoicePostModel());
            Assert.That(body["DocumentType"].Type, Is.EqualTo(JTokenType.Null));
        }

        [Test]
        public async Task ListAndDetail_ReadCorrectionAndElectronicInvoiceMetadata()
        {
            const string document = "{\"Id\":42,\"DocumentType\":13,\"CorrectedDocumentNumber\":\"original-123\",\"IsEInvoice\":true,\"EInvoiceChannel\":3}";
            using var handler = new RecordingHandler(request => request.RequestUri.AbsolutePath.EndsWith("/42", StringComparison.Ordinal)
                ? document : $"{{\"Items\":[{document}],\"TotalItems\":1,\"TotalPages\":1}}");
            using var httpClient = new HttpClient(handler);
            var client = CreateApi(httpClient).ReceivedInvoiceClient;

            var list = await client.List()
                .Filter(filter => filter.DocumentType.IsEqual(ReceivedDocumentType.ReceivedCreditNote))
                .Filter(filter => filter.EInvoiceChannel.IsEqual(EInvoiceChannel.XmlSentViaPeppol))
                .Filter(filter => filter.IsEInvoice.IsEqual(true)).GetAsync();
            var detail = await client.Detail(42).GetAsync();

            var query = Uri.UnescapeDataString(handler.Requests[0].Uri.Query);
            Assert.That(query, Does.Contain("DocumentType~eq~ReceivedCreditNote"));
            Assert.That(query, Does.Contain("IsEInvoice~eq~true"));
            Assert.That(query, Does.Contain("EInvoiceChannel~eq~XmlSentViaPeppol"));
            Assert.That(handler.Requests[1].Uri.AbsolutePath, Is.EqualTo("/v3/ReceivedInvoices/42"));
            foreach (var model in new ReceivedInvoiceListGetModel[] { list.Data.Items.Single(), detail.Data })
            {
                Assert.That(model.DocumentType, Is.EqualTo(ReceivedDocumentType.ReceivedCreditNote));
                Assert.That(model.CorrectedDocumentNumber, Is.EqualTo("original-123"));
                Assert.That(model.IsEInvoice, Is.True);
                Assert.That(model.EInvoiceChannel, Is.EqualTo(EInvoiceChannel.XmlSentViaPeppol));
            }
        }

        [Test]
        public async Task Copy_ReadsPreservedTypeAndResetElectronicInvoiceData()
        {
            using var handler = new RecordingHandler(_ => "{\"DocumentType\":14,\"CorrectedDocumentNumber\":\"\",\"IsEInvoice\":false,\"EInvoiceChannel\":0}");
            using var httpClient = new HttpClient(handler);

            var result = await CreateApi(httpClient).ReceivedInvoiceClient.CopyAsync(42);

            Assert.That(handler.Requests.Single().Uri.AbsolutePath, Is.EqualTo("/v3/ReceivedInvoices/42/Copy"));
            Assert.That(result.Data.DocumentType, Is.EqualTo(ReceivedDocumentType.ReceivedDebitNote));
            Assert.That(result.Data.CorrectedDocumentNumber, Is.Empty);
            Assert.That(result.Data.IsEInvoice, Is.False);
            Assert.That(result.Data.EInvoiceChannel, Is.EqualTo(EInvoiceChannel.None));
        }

        [TestCase(0, true)]
        [TestCase(20, true)]
        [TestCase(21, false)]
        public void CorrectedDocumentNumber_ValidatesLengthAndPatchOmission(int length, bool isValid)
        {
            var patch = new ReceivedInvoicePatchModel { Id = 42 };
            var settings = new PatchRequestJsonSerializerSettings();
            Assert.That(JObject.Parse(JsonConvert.SerializeObject(patch, settings)).Property("CorrectedDocumentNumber"), Is.Null);

            patch.CorrectedDocumentNumber = new string('x', length);

            Assert.That(patch.Validate().IsValid, Is.EqualTo(isValid));
            var body = JObject.Parse(JsonConvert.SerializeObject(patch, settings));
            Assert.That(body["CorrectedDocumentNumber"].Value<string>(), Is.EqualTo(patch.CorrectedDocumentNumber));
        }

        private static DokladApi CreateApi(HttpClient httpClient)
        {
            var authentication = Substitute.For<IAuthentication>();
            var token = new Tokenizer { AccessToken = "test-token", ExpiresIn = 3600, GrantType = GrantType.ClientCredentials };
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

        private sealed class RecordedRequest
        {
            public HttpMethod Method { get; set; }

            public Uri Uri { get; set; }

            public string Body { get; set; }
        }

        private sealed class RecordingHandler : HttpMessageHandler
        {
            private readonly Func<HttpRequestMessage, string> _data;

            public RecordingHandler(Func<HttpRequestMessage, string> data)
            {
                _data = data;
            }

            public List<RecordedRequest> Requests { get; } = new List<RecordedRequest>();

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Requests.Add(new RecordedRequest
                {
                    Method = request.Method,
                    Uri = request.RequestUri,
                    Body = request.Content == null ? null : await request.Content.ReadAsStringAsync()
                });
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent($"{{\"IsSuccess\":true,\"Data\":{_data(request)}}}")
                };
            }
        }
    }
}
