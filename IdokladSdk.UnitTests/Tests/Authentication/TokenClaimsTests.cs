using System.Collections.Generic;
using System.Security.Claims;
using IdokladSdk.Authentication;
using IdokladSdk.Enums;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Authentication
{
    [TestFixture]
    public class TokenClaimsTests
    {
        [TestCaseSource(nameof(GetLicenceStatusTestCases))]
        public void LicenceStatus_ParsedCorrectlly(IEnumerable<Claim> claims, LicenceStatus? licenceStatus)
        {
            // Arrange
            var tokenClaims = new TokenClaims(claims);

            // Act
            var parseLicenceStatus = tokenClaims.LicenceStatus;

            // Assert
            Assert.AreEqual(licenceStatus, parseLicenceStatus);
        }

        [TestCaseSource(nameof(GetUserRightsTestCases))]
        public void UserRight_ParsedCorrectlly(IEnumerable<Claim> claims, UserRight? userRight)
        {
            // Arrange
            var tokenClaims = new TokenClaims(claims);

            // Act
            var parseUserRight = tokenClaims.UserRight;

            // Assert
            Assert.AreEqual(userRight, parseUserRight);
        }

        private static object[] GetLicenceStatusTestCases()
        {
            return new object[]
            {
                new object[] { new List<Claim> { new Claim("licence_status", "0") }, null },
                new object[] { new List<Claim> { new Claim("licence_status", "1") }, LicenceStatus.Ok },
                new object[] { new List<Claim> { new Claim("licence_status", "2") }, LicenceStatus.Changed },
                new object[] { new List<Claim> { new Claim("licence_status", "3") }, LicenceStatus.WillExpireSoon },
                new object[] { new List<Claim> { new Claim("licence_status", "4") }, LicenceStatus.NeedToDowngrade },
                new object[] { new List<Claim> { new Claim("licence_status", "5") }, LicenceStatus.Expired },
                new object[] { new List<Claim> { new Claim("licence_status", "6") }, null },
                new object[] { new List<Claim> { new Claim("licence_status", "xyz") }, null },
                new object[] { new List<Claim> { new Claim("licence_status", string.Empty) }, null },
                new object[] { new List<Claim> { new Claim("qwerty", "abc") }, null },
                new object[] { new List<Claim>(), null },
                new object[] { null, null }
            };
        }

        private static object[] GetUserRightsTestCases()
        {
            return new object[]
            {
                new object[] { new List<Claim> { new Claim("user_rights", "0") }, null },
                new object[] { new List<Claim> { new Claim("user_rights", "Admin") }, UserRight.Admin },
                new object[] { new List<Claim> { new Claim("user_rights", "User") }, UserRight.User },
                new object[] { new List<Claim> { new Claim("user_rights", "NoRights") }, UserRight.NoRights },
                new object[] { new List<Claim> { new Claim("user_rights", "xyz") }, null },
                new object[] { new List<Claim> { new Claim("qwerty", "abc") }, null },
                new object[] { new List<Claim>(), null },
                new object[] { null, null }
            };
        }
    }
}
