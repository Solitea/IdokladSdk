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

namespace IdokladSdk.IntegrationTests.Tests.Clients.ReadOnly.Common
{
    /// <summary>
    /// AssertionsHelper for read-only models.
    /// </summary>
    public static class AssertionsHelper
    {
        public static void AssertDetail(BankListGetModel model)
        {
            Assert.That(model.Code, Is.Not.Null);
            Assert.That(model.CountryId, Is.Not.Zero);
            Assert.That(model.DateLastChange, Is.GreaterThan(DateTime.MinValue));
            Assert.That(model.Id, Is.Not.Zero);
            Assert.That(model.Name, Is.Not.Empty);
            Assert.That(model.NumberCode, Is.Not.Empty);
            Assert.That(model.Swift, Is.Not.Null);
        }

        public static void AssertDetail(ConstantSymbolListGetModel model)
        {
            Assert.That(model.Code, Is.Not.Empty);
            Assert.That(model.CountryId, Is.Not.Zero);
            Assert.That(model.DateLastChange, Is.GreaterThan(DateTime.MinValue));
            Assert.That(model.Id, Is.Not.Zero);
            Assert.That(model.Name, Is.Not.Empty);
        }

        public static void AssertDetail(CountryListGetModel model)
        {
            Assert.That(model.Code, Is.Not.Empty);
            Assert.That(model.CurrencyId, Is.Not.Zero);
            Assert.That(model.DateLastChange, Is.GreaterThan(DateTime.MinValue));
            Assert.That(model.Id, Is.Not.Zero);
            Assert.That(model.Name, Is.Not.Empty);
            Assert.That(model.NameEnglish, Is.Not.Empty);
            Assert.That(model.NameGerman, Is.Not.Empty);
            Assert.That(model.NameSlovak, Is.Not.Empty);
        }

        public static void AssertDetail(CurrencyListGetModel model)
        {
            Assert.That(model.Code, Is.Not.Empty);
            Assert.That(model.CountryName, Is.Not.Empty);
            Assert.That(model.Id, Is.Not.Zero);
            Assert.That(model.Name, Is.Not.Empty);
            Assert.That(model.Symbol, Is.Not.Empty);
        }

        public static void AssertDetail(ExchangeRateListGetModel model)
        {
            Assert.That(model.Amount, Is.Not.Zero);
            Assert.That(model.CurrencyId, Is.Not.Zero);
            Assert.That(model.Date, Is.GreaterThan(DateTime.MinValue));
            Assert.That(model.DateLastChange, Is.GreaterThan(DateTime.MinValue));
            Assert.That(model.ExchangeListId, Is.Not.Zero);
            Assert.That(model.ExchangeRateValue, Is.Not.Zero);
            Assert.That(model.Id, Is.Not.Zero);
        }

        public static void AssertDetail(PaymentOptionListGetModel model)
        {
            Assert.That(model.Code, Is.Not.Empty);
            Assert.That(model.Id, Is.Not.Zero);
            Assert.That(model.DateLastChange, Is.GreaterThan(DateTime.MinValue));
            Assert.That(model.Name, Is.Not.Empty);
        }

        public static void AssertDetail(VatCodeListGetModel model)
        {
            Assert.That(model.Code, Is.Not.Null);
            Assert.That(model.CountryId, Is.Not.Zero);
            Assert.That(model.DateValidityFrom, Is.GreaterThan(DateTime.MinValue));
            Assert.That(model.DateValidityTo, Is.GreaterThan(DateTime.MinValue));
            Assert.That(model.Id, Is.Not.Zero);
            Assert.That(model.MoneyS3Code, Is.Not.Empty);
            Assert.That(model.MoneyS5Code, Is.Not.Empty);
            Assert.That(model.Name, Is.Not.Empty);
            Assert.That(model.VatReturnRow, Is.Not.Null);
        }

        public static void AssertDetail(VatRateListGetModel model)
        {
            Assert.That(model.CountryId, Is.Not.Zero);
            Assert.That(model.DateLastChange, Is.GreaterThan(DateTime.MinValue));
            Assert.That(model.DateValidityFrom, Is.GreaterThan(DateTime.MinValue));
            Assert.That(model.DateValidityTo, Is.LessThanOrEqualTo(DateTime.MaxValue));
            Assert.That(model.Id, Is.Not.Zero);
            Assert.That(model.Name, Is.Not.Empty);
            Assert.That(model.Rate, Is.Not.Zero);
        }

        public static void AssertDetail(VatReverseChargeCodeListGetModel model)
        {
            Assert.That(model.Code, Is.Not.Empty);
            Assert.That(model.DateCreated, Is.GreaterThan(DateTime.MinValue));
            Assert.That(model.DateLastChange, Is.GreaterThan(DateTime.MinValue));
            Assert.That(model.DateValidityFrom, Is.GreaterThan(DateTime.MinValue));
            Assert.That(model.DateValidityTo, Is.LessThanOrEqualTo(DateTime.MaxValue));
            Assert.That(model.Id, Is.Not.Zero);
            Assert.That(model.Name, Is.Not.Empty);
        }
    }
}
