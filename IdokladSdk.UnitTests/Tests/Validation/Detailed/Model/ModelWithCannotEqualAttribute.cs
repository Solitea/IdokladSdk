using IdokladSdk.Enums;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithCannotEqualAttribute
    {
        [CannotEqual(0.0, "The amount must be either positive or negative.")]
        public decimal Amount { get; set; }

        [CannotEqual(IssuedInvoiceItemType.ItemTypeReduce, "Deduction item are no allowed.")]
        public IssuedInvoiceItemType IssuedInvoiceItemType { get; set; }
    }
}