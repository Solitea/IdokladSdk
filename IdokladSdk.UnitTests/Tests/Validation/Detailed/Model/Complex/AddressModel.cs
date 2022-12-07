using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model.Complex;

public class AddressModel
{
    [Required]
    [StringLength(50)]
    public string City { get; set; }

    [StringLength(6)]
    public string PostalCode { get; set; }

    [StringLength(50)]
    public string Street { get; set; }
}
