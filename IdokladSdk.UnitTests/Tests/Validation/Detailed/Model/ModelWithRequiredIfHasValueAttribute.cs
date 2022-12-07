using System;
using IdokladSdk.Models.Common;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model;

public class ModelWithRequiredIfHasValueAttribute
{
    [RequiredIfHasValue(nameof(DateInitialState))]
    public decimal? InitialState { get; set; }

    [RequiredIfHasValue(nameof(InitialState))]
    public DateTime? DateInitialState { get; set; }

    [RequiredIfHasValue(nameof(Amount))]
    public NullableProperty<int> CurrencyId { get; set; }

    [RequiredIfHasValue(nameof(CurrencyId))]
    public NullableProperty<decimal> Amount { get; set; }
}
