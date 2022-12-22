using System.Collections.Generic;
using System.Net.Http;

namespace IdokladSdk.Authentication.Models
{
    internal class RefreshTokenRequest : TokenRequest
    {
        internal string RefreshToken { get; set; }

        internal override HttpRequestMessage ToHttpRequestMessage()
        {
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("client_id", ClientId),
                new KeyValuePair<string, string>("client_secret", ClientSecret),
                new KeyValuePair<string, string>("scope", Scope),
                new KeyValuePair<string, string>("refresh_token", RefreshToken),
            };

            return new HttpRequestMessage(HttpMethod.Post, IdentityServerTokenUrl)
            {
                Content = new FormUrlEncodedContent(postData)
            };
        }
    }
}
