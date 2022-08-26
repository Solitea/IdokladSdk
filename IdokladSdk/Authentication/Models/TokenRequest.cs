using System;
using RestSharp;

namespace IdokladSdk.Authentication.Models
{
    internal abstract class TokenRequest
    {
        internal const string ContentType = "application/x-www-form-urlencoded";

        internal string ClientId { get; set; }

        internal string ClientSecret { get; set; }

        internal Uri IdentityServerTokenUrl { get; set; }

        internal string Scope { get; set; }

        internal abstract RestRequest ToRestRequest();
    }
}
