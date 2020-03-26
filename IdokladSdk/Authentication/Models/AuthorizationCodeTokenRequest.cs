using RestSharp;

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

        internal override IRestRequest ToRestRequest()
        {
            var request = new RestRequest(Method.POST);

            request.AddParameter("content-type", ContentType);
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("client_id", ClientId);
            request.AddParameter("client_secret", ClientSecret);
            request.AddParameter("code", Code);
            request.AddParameter("redirect_uri", RedirectUri);
            request.AddParameter("scope", Scope);

            return request;
        }
    }
}
