using RestSharp;

namespace IdokladSdk.Authentication.Models
{
    internal class RefreshTokenRequest : TokenRequest
    {
        internal GrantType GrantType { get; set; }

        internal string RefreshToken { get; set; }

        internal override RestRequest ToRestRequest()
        {
            var request = new RestRequest(IdentityServerTokenUrl, Method.Post);

            request.AddParameter("content-type", ContentType);
            request.AddParameter("grant_type", "refresh_token");
            request.AddParameter("client_id", ClientId);
            request.AddParameter("client_secret", ClientSecret);
            request.AddParameter("scope", Scope);
            request.AddParameter("refresh_token", RefreshToken);

            return request;
        }
    }
}
