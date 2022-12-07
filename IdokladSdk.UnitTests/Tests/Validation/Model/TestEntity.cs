using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Model;

public class TestEntity
{
    public string Id { get; set; }

    [Required]
    [StringLength(20)]
    public string IdentificationNumber { get; set; }

    [Required]
    public string Name { get; set; }

    [Range(1, 10)]
    public int? Rating { get; set; }

    [NullableRange(0.0, 99.99)]
    public NullableProperty<decimal> DiscountPercentage { get; set; }

    public DateTime NonNullableDate { get; set; }

    public DateTime? NullableDate { get; set; }
}
