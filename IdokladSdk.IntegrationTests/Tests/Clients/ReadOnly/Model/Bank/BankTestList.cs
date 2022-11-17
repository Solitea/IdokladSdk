using System;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Model.Bank;

public class BankTestList
{
    public int CountryId { get; set; }

    public DateTime DateLastChange { get; set; }

    public int Id { get; set; }

    public bool IsOutOfDate { get; set; }
}
