﻿using System.Collections.Generic;
using System.Net.Http;

namespace IdokladSdk.Authentication.Models
{
    internal class PinTokenRequest : TokenRequest
    {
        internal PinTokenRequest()
        {
            Scope = "eet offline_access";
        }

        internal string Pin { get; set; }

        //internal override RestRequest ToRestRequest()
        //{
        //    //var request = new RestRequest(IdentityServerTokenUrl, Method.Post);

        //    //request.AddParameter("content-type", ContentType);
        //    //request.AddParameter("grant_type", "pin");
        //    //request.AddParameter("client_id", ClientId);
        //    //request.AddParameter("client_secret", ClientSecret);
        //    //request.AddParameter("pin", Pin);
        //    //request.AddParameter("scope", Scope);

        //    //return request;
        //    return null;
        //}

        internal override HttpRequestMessage ToHttpRequestMessage()
        {
            var postData = new List<KeyValuePair<string, string>>
            {
                //new KeyValuePair<string, string>("content-type", ContentType),
                new KeyValuePair<string, string>("grant_type", "pin"),
                new KeyValuePair<string, string>("client_id", ClientId),
                new KeyValuePair<string, string>("client_secret", ClientSecret),
                new KeyValuePair<string, string>("pin", Pin),
                new KeyValuePair<string, string>("scope", Scope),
            };

            return new HttpRequestMessage(HttpMethod.Post, IdentityServerTokenUrl)
            {
                Content = new FormUrlEncodedContent(postData)
            };
        }
    }
}
