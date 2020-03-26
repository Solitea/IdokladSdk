using RestSharp;

namespace IdokladSdk.Authentication.Models
{
    internal class RefreshTokenRequest : TokenRequest
    {
        internal GrantType GrantType { get; set; }

        internal string RefreshToken { get; set; }

        internal override IRestRequest ToRestRequest()
        {
            var request = new RestRequest(Method.POST);

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
