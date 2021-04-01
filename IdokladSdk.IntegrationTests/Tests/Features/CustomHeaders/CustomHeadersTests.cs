using System;
using System.Collections.Generic;
using System.Linq;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Features.CustomHeaders
{
    [TestFixture]
    public class CustomHeadersTests : TestBase
    {
        private static readonly Action<DokladApi> SetLanguageCzShortcut = (api) => api.ApiContext.SetLanguage(Language.Cz);
        private static readonly Action<DokladApi> SetLanguageSkShortcut = (api) => api.ApiContext.SetLanguage(Language.Sk);
        private static readonly Action<DokladApi> SetLanguageDeShortcut = (api) => api.ApiContext.SetLanguage(Language.De);
        private static readonly Action<DokladApi> SetLanguageEnShortcut = (api) => api.ApiContext.SetLanguage(Language.En);
        private static readonly Action<DokladApi> SetLanguageCzHeader = (api) => api.ApiContext.Headers["Accept-Language"] = "cs-CZ";
        private static readonly Action<DokladApi> SetLanguageSkHeader = (api) => api.ApiContext.Headers["Accept-Language"] = "sk-SK";
        private static readonly Action<DokladApi> SetLanguageDeHeader = (api) => api.ApiContext.Headers["Accept-Language"] = "de-DE";
        private static readonly Action<DokladApi> SetLanguageEnHeader = (api) => api.ApiContext.Headers["Accept-Language"] = "en-US";

        private static readonly object[] TestData =
        {
            new object[] { SetLanguageCzShortcut, "Zaokrouhlení" },
            new object[] { SetLanguageSkShortcut, "Zaokrúhlenie" },
            new object[] { SetLanguageDeShortcut, "Runden" },
            new object[] { SetLanguageEnShortcut, "Rounding" },
            new object[] { SetLanguageCzHeader, "Zaokrouhlení" },
            new object[] { SetLanguageSkHeader, "Zaokrúhlenie" },
            new object[] { SetLanguageDeHeader, "Runden" },
            new object[] { SetLanguageEnHeader, "Rounding" }
        };

        public IssuedInvoiceClient IssuedInvoiceClient { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            IssuedInvoiceClient = DokladApi.IssuedInvoiceClient;
        }

        [TestCaseSource(nameof(TestData))]
        public void SetLanguage_SuccessfullySet(Action<DokladApi> setLanguage, string expectedString)
        {
            // Arrange
            var recountPostModel = CreateRecountPostModel();

            // Act
            setLanguage(DokladApi);
            var recountGetModel = IssuedInvoiceClient.Recount(recountPostModel).AssertResult();

            // Assert
            Assert.AreEqual(expectedString, GetRoundingItem(recountGetModel));
        }

        private static IssuedInvoiceRecountPostModel CreateRecountPostModel()
        {
            var model = new IssuedInvoiceRecountPostModel
            {
                CurrencyId = 1,
                DateOfTaxing = DateTime.Today.SetKindUtc(),
                PaymentOptionId = 1,
                Items = new List<IssuedInvoiceItemRecountPostModel>
                {
                    new IssuedInvoiceItemRecountPostModel
                    {
                        Amount = 1,
                        PriceType = PriceType.WithVat,
                        UnitPrice = 10.1m,
                        VatRateType = VatRateType.Basic
                    }
                }
            };

            return model;
        }

        private static string GetRoundingItem(IssuedInvoiceRecountGetModel model)
        {
            return model.Items.FirstOrDefault(i => i.ItemType == IssuedInvoiceItemType.ItemTypeRound).Name;
        }
    }
}
