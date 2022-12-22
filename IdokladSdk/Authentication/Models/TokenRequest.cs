using System;
using System.Net.Http;

namespace IdokladSdk.Authentication.Models
{
    /// <summary>
    /// TokenRequest.
    /// </summary>
    public abstract class TokenRequest
    {
        //internal const string ContentType = "application/x-www-form-urlencoded";

        internal string ClientId { get; set; }

        internal string ClientSecret { get; set; }

        internal GrantType GrantType { get; set; }

        internal Uri IdentityServerTokenUrl { get; set; }

        internal string Scope { get; set; }

        //internal abstract RestRequest ToRestRequest();

        internal abstract HttpRequestMessage ToHttpRequestMessage();
    }
}
