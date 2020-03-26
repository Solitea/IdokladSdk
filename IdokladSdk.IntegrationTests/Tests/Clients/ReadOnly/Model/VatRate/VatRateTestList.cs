using System;
using IdokladSdk.Enums;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Model.VatRate
{
    public class VatRateTestList
    {
        public int CountryId { get; set; }

        public DateTime DateValidityFrom { get; set; }

        public DateTime DateValidityTo { get; set; }

        public VatRateType RateType { get; set; }
    }
}
