using System.Collections.Generic;
using System.Net.Http;

namespace IdokladSdk.Authentication.Models
{
    internal class AuthorizationCodeTokenRequest : TokenRequest
    {
        internal AuthorizationCodeTokenRequest()
        {
            Scope = "idoklad_api offline_access";
        }

        internal string Code { get; set; }

        internal string RedirectUri { get; set; }

        //internal override RestRequest ToRestRequest()
        //{
        //    //var request = new RestRequest(IdentityServerTokenUrl, Method.Post);

        //    //request.AddParameter("content-type", ContentType);
        //    //request.AddParameter("grant_type", "authorization_code");
        //    //request.AddParameter("client_id", ClientId);
        //    //request.AddParameter("client_secret", ClientSecret);
        //    //request.AddParameter("code", Code);
        //    //request.AddParameter("redirect_uri", RedirectUri);
        //    //request.AddParameter("scope", Scope);

        //    //return request;
        //    return null;
        //}

        internal override HttpRequestMessage ToHttpRequestMessage()
        {
            var postData = new List<KeyValuePair<string, string>>
            {
                //new KeyValuePair<string, string>("content-type", ContentType),
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("client_id", ClientId),
                new KeyValuePair<string, string>("client_secret", ClientSecret),
                new KeyValuePair<string, string>("code", Code),
                new KeyValuePair<string, string>("redirect_uri", RedirectUri),
                new KeyValuePair<string, string>("scope", Scope),
            };

            return new HttpRequestMessage(HttpMethod.Post, IdentityServerTokenUrl)
            {
                Content = new FormUrlEncodedContent(postData)
            };
        }
    }
}
