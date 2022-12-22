using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model.Complex
{
    public class ComplexModel
    {
        [Required]
        public AddressModel Address { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        [Email]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [CollectionRange(1, 10)]
        public List<ItemModel> Items { get; set; }
    }
}