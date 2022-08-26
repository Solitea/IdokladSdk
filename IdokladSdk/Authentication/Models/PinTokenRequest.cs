﻿using RestSharp;

namespace IdokladSdk.Authentication.Models
{
    internal class PinTokenRequest : TokenRequest
    {
        internal PinTokenRequest()
        {
            Scope = "eet offline_access";
        }

        internal string Pin { get; set; }

        internal override RestRequest ToRestRequest()
        {
            var request = new RestRequest(IdentityServerTokenUrl, Method.Post);

            request.AddParameter("content-type", ContentType);
            request.AddParameter("grant_type", "pin");
            request.AddParameter("client_id", ClientId);
            request.AddParameter("client_secret", ClientSecret);
            request.AddParameter("pin", Pin);
            request.AddParameter("scope", Scope);

            return request;
        }
    }
}
