using System.Collections.Generic;
using System.Net.Http;

namespace IdokladSdk.Authentication.Models
{
    internal class RefreshTokenRequest : TokenRequest
    {
        //internal GrantType GrantType { get; set; }

        internal string RefreshToken { get; set; }

        //internal override RestRequest ToRestRequest()
        //{
        //    //var request = new RestRequest(IdentityServerTokenUrl, Method.Post);

        //    //request.AddParameter("content-type", ContentType);
        //    //request.AddParameter("grant_type", "refresh_token");
        //    //request.AddParameter("client_id", ClientId);
        //    //request.AddParameter("client_secret", ClientSecret);
        //    //request.AddParameter("scope", Scope);
        //    //request.AddParameter("refresh_token", RefreshToken);

        //    //return request;
        //    return null;
        //}

        internal override HttpRequestMessage ToHttpRequestMessage()
        {
            var postData = new List<KeyValuePair<string, string>>
            {
                //new KeyValuePair<string, string>("content-type", ContentType),
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
