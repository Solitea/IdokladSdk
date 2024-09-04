namespace IdokladSdk.Authentication
{
    internal class AuthenticationMessageConstants
    {
        public const string ClientCredetialsRefreshTokenNotSupported = "ClientCredentials grant type doesn't use refresh token.";

        public const string RequiredAuthenticationCode = "Authentication code has to be specified.";

        public const string RequiredApplicationId = "Application Id has to be specified.";

        public const string RequiredClientId = "Client Id has to be specified.";

        public const string RequiredClientSecret = "Client secret has to be specified.";

        public const string RequiredPinOrRefreshToken = "PIN or RefreshToken has to be specified.";

        public const string RequiredRedirectUri = "Redirect URI has to be specified.";

        public const string RequiredRefreshToken = "RefreshToken has to be specified.";
    }
}
