using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using IdokladSdk.Enums;

namespace IdokladSdk.Authentication
{
    /// <summary>
    /// Token claims.
    /// </summary>
    public class TokenClaims
    {
        /// <summary>
        /// Licence status claim name.
        /// </summary>
        public const string LicenceStatusClaim = "license_status";

        /// <summary>
        /// User rights claim name.
        /// </summary>
        public const string UserRightsClaim = "user_rights";

        private readonly IEnumerable<Claim> _claims;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenClaims"/> class.
        /// </summary>
        /// <param name="claims">Claims.</param>
        public TokenClaims(IEnumerable<Claim> claims)
        {
            _claims = claims;
        }

        /// <summary>
        /// Gets licence status claim.
        /// </summary>
        public LicenceStatus? LicenceStatus => GetLicenceStatus();

        /// <summary>
        /// Gets user right claim.
        /// </summary>
        public UserRight? UserRight => GetUserRight();

        private LicenceStatus? GetLicenceStatus()
        {
            var claim = _claims?.FirstOrDefault(x => x.Type == LicenceStatusClaim);

            if (Enum.TryParse<LicenceStatus>(claim?.Value, out var value) && Enum.IsDefined(typeof(LicenceStatus), value))
            {
                return value;
            }

            return null;
        }

        private UserRight? GetUserRight()
        {
            var claim = _claims?.FirstOrDefault(x => x.Type == UserRightsClaim);

            return claim != null && Enum.IsDefined(typeof(UserRight), claim.Value)
                ? (UserRight?)Enum.Parse(typeof(UserRight), claim.Value)
                : null;
        }
    }
}
