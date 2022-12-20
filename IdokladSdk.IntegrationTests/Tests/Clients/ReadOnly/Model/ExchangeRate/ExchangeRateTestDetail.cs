using IdokladSdk.Models.ReadOnly.Currency;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Model.ExchangeRate
{
    public class ExchangeRateTestDetail
    {
        public CurrencyGetModel Currency { get; set; }

        public decimal Amount { get; set; }

        public int CurrencyId { get; set; }

        public decimal ExchangeRateValue { get; set; }
    }
}