using System.Security.Authentication;
using IdokladSdk.Authentication.Models;
using Newtonsoft.Json;
using RestSharp;

namespace IdokladSdk.Authentication.Extensions
{
    internal static partial class RestClientExtensions
    {
        internal static Tokenizer RequestAuthorizationCodeToken(this RestClient client, AuthorizationCodeTokenRequest tokenRequest)
        {
            return Execute(client, tokenRequest, GrantType.AuthorizationCode);
        }

        internal static Tokenizer RequestClientCredentialsToken(this RestClient client, ClientCredentialsTokenRequest tokenRequest)
        {
            return Execute(client, tokenRequest, GrantType.ClientCredentials);
        }

        internal static Tokenizer RequestPinToken(this RestClient client, PinTokenRequest tokenRequest)
        {
            return Execute(client, tokenRequest, GrantType.Pin);
        }

        internal static Tokenizer RequestRefreshToken(this RestClient client, RefreshTokenRequest tokenRequest)
        {
            return Execute(client, tokenRequest, tokenRequest.GrantType);
        }

        private static Tokenizer Execute(RestClient client, TokenRequest tokenRequest, GrantType grantType)
        {
            var request = tokenRequest.ToRestRequest();
            var response = client.Execute(request);

            return ProcessResponse(response, grantType);
        }

        private static Tokenizer ProcessResponse(IRestResponse response, GrantType grantType)
        {
            var tokenizer = JsonConvert.DeserializeObject<Tokenizer>(response.Content);
            tokenizer.GrantType = grantType;

            if (string.IsNullOrEmpty(tokenizer.AccessToken))
            {
                var errorMessage = JsonConvert.DeserializeObject<dynamic>(response.Content).error;
                throw new AuthenticationException("Authentication failed: " + errorMessage);
            }

            return tokenizer;
        }
    }
}
