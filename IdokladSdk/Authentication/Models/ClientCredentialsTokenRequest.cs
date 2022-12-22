using System.Collections.Generic;
using System.Net.Http;

namespace IdokladSdk.Authentication.Models
{
    internal class ClientCredentialsTokenRequest : TokenRequest
    {
        internal ClientCredentialsTokenRequest()
        {
            Scope = "idoklad_api";
        }

        internal override HttpRequestMessage ToHttpRequestMessage()
        {
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", ClientId),
                new KeyValuePair<string, string>("client_secret", ClientSecret),
                new KeyValuePair<string, string>("scope", Scope),
            };

            return new HttpRequestMessage(HttpMethod.Post, IdentityServerTokenUrl)
            {
                Content = new FormUrlEncodedContent(postData)
            };
        }
    }
}
