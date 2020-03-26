using RestSharp;

namespace IdokladSdk.Authentication.Models
{
    internal class ClientCredentialsTokenRequest : TokenRequest
    {
        internal ClientCredentialsTokenRequest()
        {
            Scope = "idoklad_api";
        }

        internal override IRestRequest ToRestRequest()
        {
            var request = new RestRequest(Method.POST);

            request.AddParameter("content-type", ContentType);
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("client_id", ClientId);
            request.AddParameter("client_secret", ClientSecret);
            request.AddParameter("scope", Scope);

            return request;
        }
    }
}
