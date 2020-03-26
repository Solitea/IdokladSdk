using IdokladSdk.Models.ReadOnly.Currency;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Model.Country
{
    public class CountryTestDetail
    {
        public CurrencyGetModel Currency { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
