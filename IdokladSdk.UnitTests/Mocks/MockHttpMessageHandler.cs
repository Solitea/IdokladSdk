using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IdokladSdk.UnitTests.Mocks
{
    public class MockHttpMessageHandler : HttpClientHandler
    {
        public virtual HttpResponseMessage MockSend(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(MockSend(request, cancellationToken));
        }
    }
}