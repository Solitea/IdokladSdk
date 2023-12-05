using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithBankAccountNumberAttribute
    {
        [BankAccountNumber]
        public string BankAccountNumber { get; set; }
    }
}
