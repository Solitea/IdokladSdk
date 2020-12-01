using System.ComponentModel.DataAnnotations;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model.Complex
{
    public class ItemModel
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [CannotEqual(0, "Amount cannot be null")]
        public decimal Amount { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Range(0, 100)]
        public double Discount { get; set; }

        [RequiredIfHasValue(nameof(ItemModel.Discount))]
        public string DiscountName { get; set; }
    }
}
