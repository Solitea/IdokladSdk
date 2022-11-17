using IdokladSdk.Models.ReadOnly.Country;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Model.Bank;

public class BankTestDetail
{
    public CountryGetModel Country { get; set; }

    public int Id { get; set; }

    public string Name { get; set; }
}
