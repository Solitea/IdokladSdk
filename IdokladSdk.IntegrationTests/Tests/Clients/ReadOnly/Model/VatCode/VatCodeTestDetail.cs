using IdokladSdk.Models.ReadOnly.Country;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Model.VatCode
{
    public class VatCodeTestDetail
    {
        public string Code { get; set; }

        public CountryGetModel Country { get; set; }

        public string Name { get; set; }
    }
}
