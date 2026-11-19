using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Authentication;
using IdokladSdk.Enums;
using NSubstitute;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Clients
{
    public class ReceivedDocumentPaymentsClientTests
    {
        [Test]
        public async Task List_FiltersReceivedDocumentPayments()
        {
            var requests = new List<Uri>();
            using var handler = new RecordingHandler(request =>
            {
                requests.Add(request.RequestUri);
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        "{\"IsSuccess\":true,\"Data\":{\"Items\":[],\"TotalItems\":0,\"TotalPages\":0}}")
                };
            });
            using var httpClient = new HttpClient(handler);
            var api = CreateApi(httpClient);
            var paymentDate = new DateTime(2026, 11, 10, 0, 0, 0, DateTimeKind.Utc);

            await api.ReceivedDocumentPaymentsClient.List()
                .Filter(filter => filter.DateOfPayment.IsGreaterThanOrEqual(paymentDate))
                .Filter(filter => filter.InvoiceId.Contains([12, 34]))
                .Filter(filter => filter.PartnerId.IsEqual(56))
                .Filter(filter => filter.DocumentType.IsEqual(ReceivedDocumentPaymentDocumentType.ReceivedInvoice))
                .Filter(filter => filter.PaymentOptionId.IsEqual(2))
                .Filter(filter => filter.InvoiceDocumentNumber.Contains("INV-2026"))
                .Filter(filter => filter.Partner.Contains("Supplier"))
                .GetAsync();

            Assert.That(requests, Has.Count.EqualTo(1));
            Assert.That(requests.Single().AbsolutePath, Is.EqualTo("/v3/ReceivedDocumentPayments"));
            var query = Uri.UnescapeDataString(requests.Single().Query);
            Assert.That(query, Does.Contain("DateOfPayment~gte~2026-11-10+00:00:00.000"));
            Assert.That(query, Does.Contain("InvoiceId~ct~12,34"));
            Assert.That(query, Does.Contain("PartnerId~eq~56"));
            Assert.That(query, Does.Contain("DocumentType~eq~ReceivedInvoice"));
            Assert.That(query, Does.Contain("PaymentOptionId~eq~2"));
            Assert.That(query, Does.Contain("InvoiceDocumentNumber~ct:base64~SU5WLTIwMjY="));
            Assert.That(query, Does.Contain("Partner~ct:base64~U3VwcGxpZXI="));
        }

        private static DokladApi CreateApi(HttpClient httpClient)
        {
            var token = new Tokenizer
            {
                AccessToken = "test-token", ExpiresIn = 3600, GrantType = GrantType.ClientCredentials
            };
            var authentication = Substitute.For<IAuthentication>();
            authentication.GetTokenAsync(Arg.Any<HttpClient>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(token));
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

            protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
                return Task.FromResult(_response(request));
            }
        }
    }
}
