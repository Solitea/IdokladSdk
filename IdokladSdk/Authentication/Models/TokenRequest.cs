using RestSharp;

namespace IdokladSdk.Authentication.Models
{
    internal abstract class TokenRequest
    {
        internal const string ContentType = "application/x-www-form-urlencoded";

        internal string ClientId { get; set; }

        internal string ClientSecret { get; set; }

        internal string Scope { get; set; }

        internal abstract IRestRequest ToRestRequest();
    }
}
