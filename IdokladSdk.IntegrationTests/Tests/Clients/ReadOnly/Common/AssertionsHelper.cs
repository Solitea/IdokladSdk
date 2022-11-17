using System;
using IdokladSdk.Models.ReadOnly.Bank;
using IdokladSdk.Models.ReadOnly.ConstantSymbol;
using IdokladSdk.Models.ReadOnly.Country;
using IdokladSdk.Models.ReadOnly.Currency;
using IdokladSdk.Models.ReadOnly.ExchangeRate;
using IdokladSdk.Models.ReadOnly.PaymentOption;
using IdokladSdk.Models.ReadOnly.VatCode;
using IdokladSdk.Models.ReadOnly.VatRate;
using IdokladSdk.Models.ReadOnly.VatReverseChargeCode;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Common;

/// <summary>
/// AssertionsHelper for read-only models.
/// </summary>
public static class AssertionsHelper
{
    public static void AssertDetail(BankListGetModel model)
    {
        Assert.NotNull(model.Code);
        Assert.NotZero(model.CountryId);
        Assert.Greater(model.DateLastChange, DateTime.MinValue);
        Assert.NotZero(model.Id);
        Assert.IsNotEmpty(model.Name);
        Assert.IsNotEmpty(model.NumberCode);
        Assert.NotNull(model.Swift);
    }

    public static void AssertDetail(ConstantSymbolListGetModel model)
    {
        Assert.IsNotEmpty(model.Code);
        Assert.NotZero(model.CountryId);
        Assert.Greater(model.DateLastChange, DateTime.MinValue);
        Assert.NotZero(model.Id);
        Assert.IsNotEmpty(model.Name);
    }

    public static void AssertDetail(CountryListGetModel model)
    {
        Assert.IsNotEmpty(model.Code);
        Assert.NotZero(model.CurrencyId);
        Assert.Greater(model.DateLastChange, DateTime.MinValue);
        Assert.NotZero(model.Id);
        Assert.IsNotEmpty(model.Name);
        Assert.IsNotEmpty(model.NameEnglish);
        Assert.IsNotEmpty(model.NameGerman);
        Assert.IsNotEmpty(model.NameSlovak);
    }

    public static void AssertDetail(CurrencyListGetModel model)
    {
        Assert.IsNotEmpty(model.Code);
        Assert.IsNotEmpty(model.CountryName);
        Assert.NotZero(model.Id);
        Assert.IsNotEmpty(model.Name);
        Assert.IsNotEmpty(model.Symbol);
    }

    public static void AssertDetail(ExchangeRateListGetModel model)
    {
        Assert.NotZero(model.Amount);
        Assert.NotZero(model.CurrencyId);
        Assert.Greater(model.Date, DateTime.MinValue);
        Assert.Greater(model.DateLastChange, DateTime.MinValue);
        Assert.NotZero(model.ExchangeListId);
        Assert.NotZero(model.ExchangeRateValue);
        Assert.NotZero(model.Id);
    }

    public static void AssertDetail(PaymentOptionListGetModel model)
    {
        Assert.IsNotEmpty(model.Code);
        Assert.NotZero(model.Id);
        Assert.Greater(model.DateLastChange, DateTime.MinValue);
        Assert.IsNotEmpty(model.Name);
    }

    public static void AssertDetail(VatCodeListGetModel model)
    {
        Assert.NotNull(model.Code);
        Assert.NotZero(model.CountryId);
        Assert.Greater(model.DateValidityFrom, DateTime.MinValue);
        Assert.Greater(model.DateValidityTo, DateTime.MinValue);
        Assert.NotZero(model.Id);
        Assert.IsNotEmpty(model.MoneyS3Code);
        Assert.IsNotEmpty(model.MoneyS5Code);
        Assert.IsNotEmpty(model.Name);
        Assert.NotNull(model.VatReturnRow);
    }

    public static void AssertDetail(VatRateListGetModel model)
    {
        Assert.NotZero(model.CountryId);
        Assert.Greater(model.DateLastChange, DateTime.MinValue);
        Assert.Greater(model.DateValidityFrom, DateTime.MinValue);
        Assert.LessOrEqual(model.DateValidityTo, DateTime.MaxValue);
        Assert.NotZero(model.Id);
        Assert.IsNotEmpty(model.Name);
        Assert.NotZero(model.Rate);
    }

    public static void AssertDetail(VatReverseChargeCodeListGetModel model)
    {
        Assert.IsNotEmpty(model.Code);
        Assert.Greater(model.DateCreated, DateTime.MinValue);
        Assert.Greater(model.DateLastChange, DateTime.MinValue);
        Assert.Greater(model.DateValidityFrom, DateTime.MinValue);
        Assert.LessOrEqual(model.DateValidityTo, DateTime.MaxValue);
        Assert.NotZero(model.Id);
        Assert.IsNotEmpty(model.Name);
    }
}
