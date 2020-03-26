using System.Threading.Tasks;
using IdokladSdk.Authentication;

namespace IdokladSdk.NetCore.TestApp.Examples
{
    public class EetPinAuthenticationExample
    {
        // Values specific to your agenda
        private const string ClientId = "ClientId";
        private const string ClientSecret = "ClientSecret";

        // Values specific to your application
        private const string AppName = "application name";
        private const string AppVersion = "application version";

        private ApiContext _context;
        private DokladApi _api;

        public async Task PinAuthorization_Authorize_UseApi_SaveRefreshToken_AuthorizeAgain()
        {
            // Create instance of authentication using one-time pin, which you retrieved before this step from iDoklad Web
            var initialAuthentication = new PinAuthentication(ClientId, ClientSecret, "pin");

            // Initialize context and api
            InitializeContextAndApi(initialAuthentication);

            // Use api as usual
            var agenda = await _api.AccountClient.Agendas.Current().GetAsync();
            var contact = await _api.ContactClient.Detail(123).GetAsync();

            // Before shutting down the application, save refresh token
            var refreshToken = initialAuthentication.RefreshToken;

            // Afterwards, when loading the application, use refresh token when creating authentication
            var subsequentAuthentication = new PinAuthentication(ClientId, ClientSecret, null, refreshToken);

            // Initialize context and api
            InitializeContextAndApi(subsequentAuthentication);

            // Use api as usual
            var issuedInvoice = await _api.IssuedInvoiceClient.DefaultAsync();
        }

        public async Task PinAuthorization_RetrieveAndSaveRefreshToken()
        {
            // Create instance of authentication using one-time pin, which you retreived before this step from iDoklad Web
            var initialAuthentication = new PinAuthentication(ClientId, ClientSecret, "pin");

            // Request access token, with this call refresh token will be requested as well
            var tokenizer = await initialAuthentication.GetTokenAsync();

            // Retrieve refresh token (both values are the same) and save it
            var refreshToken1 = tokenizer.RefreshToken;
            var refreshToken2 = initialAuthentication.RefreshToken;

            // Afterwards, refresh token is used for authentication
            var subsequentAuthentication = new PinAuthentication(ClientId, ClientSecret, null, refreshToken1 ?? refreshToken2);

            // Initialize context and api
            InitializeContextAndApi(subsequentAuthentication);

            // Use api as usual
            var apiResult = await _api.IssuedInvoiceClient.DefaultAsync();

            var defaultIssuedInvoice = apiResult.Data;
        }

        private void InitializeContextAndApi(IAuthentication authentication)
        {
            _context = new ApiContext(AppName, AppVersion, authentication);
            _api = new DokladApi(_context);
        }
    }
}
