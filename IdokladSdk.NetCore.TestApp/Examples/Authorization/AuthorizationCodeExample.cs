using System.Net.Http;
using System.Threading.Tasks;
using IdokladSdk.Authentication;
using IdokladSdk.Builders;

namespace IdokladSdk.NetCore.TestApp.Examples
{
    public class AuthorizationCodeExample
    {
        // Values specific to your agenda
        private const string ClientId = "ClientId";
        private const string ClientSecret = "ClientSecret";

        // Values specific to your application
        private const string AppName = "application name";
        private const string AppVersion = "application version";
        private readonly HttpClient _httpClient;
        private DokladApi _api;

        public AuthorizationCodeExample(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AuthorizationCode_Authorize_SaveRefreshToken_AuthorizeAgain(string authorizationCode, string redirectUri)
        {
            // Create instance of authentication using one-time code, which you retrieved before this step
            var initialAuthentication = new AuthorizationCodeAuthentication(ClientId, ClientSecret, authorizationCode, redirectUri);

            // Initialize context and api
            InitializeApi(authorizationCode, redirectUri, null);

            // Use api as usual
            var agenda = await _api.AccountClient.Agendas.Current().GetAsync();
            var contact = await _api.ContactClient.Detail(123).GetAsync();

            // Before shutting down the application, save refresh token
            var refreshToken = initialAuthentication.RefreshToken;

            // Initialize context and api
            InitializeApi(null, null, refreshToken);

            // Use api as usual
            var issuedInvoice = await _api.IssuedInvoiceClient.DefaultAsync();
        }

        public async Task AuthorizationCode_RetrieveAndSaveRefreshToken(string authorizationCode, string redirectUri)
        {
            // Create instance of authentication using one-time code, which you retreived before this step
            var initialAuthentication = new AuthorizationCodeAuthentication(ClientId, ClientSecret, authorizationCode, redirectUri);

            // Request access token, with this call refresh token will be requested as well
            var tokenizer = await initialAuthentication.GetTokenAsync();

            // Retrieve refresh token (both values are the same) and save it
            var refreshToken1 = tokenizer.RefreshToken;
            var refreshToken2 = initialAuthentication.RefreshToken;

            // Initialize api
            InitializeApi(null, null, refreshToken1 ?? refreshToken2);

            // Use api as usual
            var issuedInvoice = await _api.IssuedInvoiceClient.DefaultAsync();
        }

        private void InitializeApi(string authorizationCode, string redirectUri, string refreshToken)
        {
            var builder = new DokladApiBuilder(AppName, AppVersion).AddHttpClientForApi(_httpClient);

            if (string.IsNullOrEmpty(refreshToken))
            {
                builder.AddAuthorizationCodeAuthentication(ClientId, ClientSecret, authorizationCode, redirectUri);
            }
            else
            {
                builder.AddAuthorizationCodeAuthentication(ClientId, ClientSecret, refreshToken);
            }

            _api = builder.Build();
        }
    }
}
