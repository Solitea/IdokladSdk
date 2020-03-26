using System.Collections.Generic;

namespace IdokladSdk.NetCore.TestApp.Examples.Models
{
    public class ContactGridModel
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public Metadata Metadata { get; set; }

        public Country Country { get; set; }

        public List<Country> Countries { get; set; }
    }
}
