using IdokladSdk.Models.ReadOnly.Country;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Model.VatRate
{
    public class VatRateTestDetail
    {
        public CountryGetModel Country { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Rate { get; set; }
    }
}
