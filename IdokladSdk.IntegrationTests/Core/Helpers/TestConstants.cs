using System;
using IdokladSdk.Enums;

namespace IdokladSdk.IntegrationTests.Core.Helpers
{
    public static class TestConstants
    {
        public static readonly string DefaultAccountNumber = "123456";
        public static readonly int DefaultCurrencyId = 1;
        public static readonly int DefaultDocumentSerialNumber = 1;
        public static readonly DateTime DefaultDate = DateTime.UtcNow;
        public static readonly string DefaultDescription = "Description";
        public static readonly string DefaultItemName = "Item";
        public static readonly int DefaultIssuedInvoiceNumericSequenceId = 607899;
        public static readonly int DefaultProformaNumericSequenceId = 607900;
        public static readonly int DefaultPartnerId = 323823;
        public static readonly int DefaultPaymentOptionId = 1;
        public static readonly PriceType DefaultPriceType = PriceType.WithoutVat;
        public static readonly VatRateType DefaultVatRateType = VatRateType.Basic;
    }
}
