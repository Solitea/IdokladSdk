using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IdokladSdk.NetCore.TestApp.Examples.Logging
{
    public class LoggingHandler : DelegatingHandler
    {
        public LoggingHandler()
            : base()
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Content != null)
            {
                // Log Request Body
                Console.WriteLine(await request.Content.ReadAsStringAsync());
            }

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            if (response.Content != null)
            {
                // Log Response Body
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

            return response;
        }
    }
}
