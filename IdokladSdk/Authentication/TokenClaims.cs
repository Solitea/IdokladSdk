using System;
using System.Collections.Generic;
using System.Globalization;
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
        private const string LicenceStatusClaim = "licence_status";
        private const string UserRightsClaim = "user_rights";
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
            var intValue = Convert.ToInt32(claim?.Value, CultureInfo.InvariantCulture);

            return intValue > 0 && intValue <= Enum.GetValues(typeof(LicenceStatus)).Length
                ? (LicenceStatus?)Enum.ToObject(typeof(LicenceStatus), intValue)
                : null;
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
