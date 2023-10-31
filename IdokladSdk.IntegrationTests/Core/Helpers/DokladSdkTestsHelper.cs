using System.Collections.Generic;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.ProformaInvoice;

namespace IdokladSdk.IntegrationTests.Core.Helpers
{
    public static class DokladSdkTestsHelper
    {
        public static async Task<IssuedInvoiceGetModel> CreateDefaultIssuedInvoiceAsync(DokladApi api)
        {
            var model = new IssuedInvoicePostModel
            {
                AccountNumber = TestConstants.DefaultAccountNumber,
                Items = new List<IssuedInvoiceItemPostModel>() { GetDefaultIssuedInvoiceItemModel() },
                DateOfIssue = TestConstants.DefaultDate,
                DateOfMaturity = TestConstants.DefaultDate,
                DateOfPayment = TestConstants.DefaultDate,
                DateOfTaxing = TestConstants.DefaultDate,
                Description = TestConstants.DefaultDescription,
                DocumentSerialNumber = TestConstants.DefaultDocumentSerialNumber,
                CurrencyId = TestConstants.DefaultCurrencyId,
                PaymentOptionId = TestConstants.DefaultPaymentOptionId,
                NumericSequenceId = TestConstants.DefaultIssuedInvoiceNumericSequenceId,
                PartnerId = TestConstants.DefaultPartnerId,
            };
            var result = await api.IssuedInvoiceClient.PostAsync(model);
            return result.Data;
        }

        public static async Task<ProformaInvoiceGetModel> CreateDefaultProformaInvoiceAsync(DokladApi api)
        {
            var model = new ProformaInvoicePostModel
            {
                AccountNumber = TestConstants.DefaultAccountNumber,
                CurrencyId = TestConstants.DefaultCurrencyId,
                DateOfIssue = TestConstants.DefaultDate,
                DateOfMaturity = TestConstants.DefaultDate,
                DateOfPayment = TestConstants.DefaultDate,
                DateOfTaxing = TestConstants.DefaultDate,
                DateOfVatApplication = TestConstants.DefaultDate,
                Description = TestConstants.DefaultDescription,
                DocumentSerialNumber = TestConstants.DefaultDocumentSerialNumber,
                IsEet = false,
                IsIncomeTax = true,
                Items = new List<ProformaInvoiceItemPostModel>() { GetDefaultProformaInvoiceItemModel() },
                NumericSequenceId = TestConstants.DefaultProformaNumericSequenceId,
                PaymentOptionId = TestConstants.DefaultPaymentOptionId,
                PartnerId = TestConstants.DefaultPartnerId,
            };

            var result = await api.ProformaInvoiceClient.PostAsync(model);
            return result.Data;
        }

        private static IssuedInvoiceItemPostModel GetDefaultIssuedInvoiceItemModel()
        {
            return new IssuedInvoiceItemPostModel
            {
                Amount = 1,
                Name = TestConstants.DefaultItemName,
                UnitPrice = 100,
                PriceType = TestConstants.DefaultPriceType,
                VatRateType = TestConstants.DefaultVatRateType,
            };
        }

        private static ProformaInvoiceItemPostModel GetDefaultProformaInvoiceItemModel()
        {
            return new ProformaInvoiceItemPostModel
            {
                Amount = 1,
                IsTaxMovement = true,
                Name = TestConstants.DefaultItemName,
                PriceType = TestConstants.DefaultPriceType,
                UnitPrice = 1000,
                VatRateType = VatRateType.Zero,
            };
        }
    }
}
