using System;
using System.Collections.Generic;
using System.Linq;
using IdokladSdk.Enums;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.PriceListItem;
using IdokladSdk.Models.ProformaInvoice;
using IdokladSdk.NetCore.TestApp.Examples.Extensions;

namespace IdokladSdk.NetCore.TestApp.Examples
{
    /// <summary>
    /// IssuedInvoice Examples.
    /// </summary>
    public class IssuedInvoiceExamples
    {
        private readonly DokladApi _api;

        public IssuedInvoiceExamples(DokladApi api)
        {
            _api = api;
        }

        public int CreateNewInvoice(int partnerId)
        {
            // Get default model containing default values based on agenda settings.
            var defaultInvoice = _api.IssuedInvoiceClient.Default().Data;

            // Set required properties
            defaultInvoice.PartnerId = partnerId;
            defaultInvoice.Description = "Test issued invoice";

            // Default invoice contains one item - we can modify it (fill in required fields) or we can delete it and add new items
            defaultInvoice.Items.RemoveAll(_ => true);
            defaultInvoice.Items.Add(new IssuedInvoiceItemPostModel
            {
                Amount = 1,
                Name = "ItemName",
                UnitPrice = 100
            });

            // Optionally call recount to get all prices of document.
            var recountModel = defaultInvoice.ToRecountModel();
            var recountedInvoice = _api.IssuedInvoiceClient.Recount(recountModel).Data;

            // Create new invoice
            var createdInvoice = _api.IssuedInvoiceClient.Post(defaultInvoice).CheckResult();
            return createdInvoice.Id;
        }

        public (int, int) AccountProforma_WithIssuedInvoiceDetail(int partnerId, int priceListItemId)
        {
            // Get default model containing default values based on agenda settings.
            var defaultProforma = _api.ProformaInvoiceClient.Default().Data;

            // Set required properties
            defaultProforma.PartnerId = partnerId;
            defaultProforma.Description = "Test proforma invoice 1";

            // Default proforma invoice contains one item - we can modify it (fill in required fields) or we can delete it and add new items
            defaultProforma.Items.RemoveAll(_ => true);
            defaultProforma.Items.Add(new ProformaInvoiceItemPostModel
            {
                Amount = 1,
                Name = "Proforma invoice item",
                UnitPrice = 100
            });

            // Create new proforma invoice
            var createdProforma = _api.ProformaInvoiceClient.Post(defaultProforma).CheckResult();

            // Pay proforma invoice
            FullyPayProformaInvoice(createdProforma.Id);

            // Get issued invoice for accounting of proforma invoice
            var accountingInvoice = _api.ProformaInvoiceClient.GetInvoiceForAccount(createdProforma.Id).Data;

            // Modify accounting invoice
            accountingInvoice.Note = "Accounting test";
            accountingInvoice.Items.Add(GetPriceListItem(priceListItemId), 2);

            // Create accounting invoice
            var createdAccountingInvoice = _api.IssuedInvoiceClient.Post(accountingInvoice).CheckResult();
            return (createdProforma.Id, createdAccountingInvoice.Id);
        }

        public (int, int) AccountProforma_WithoutIssuedInvoiceDetail(int partnerId)
        {
            // Get default model containing default values based on agenda settings.
            var defaultProforma = _api.ProformaInvoiceClient.Default().Data;

            // Set required properties
            defaultProforma.PartnerId = partnerId;
            defaultProforma.Description = "Test proforma invoice 2";

            // Default proforma invoice contains one item - we can modify it (fill in required fields) or we can delete it and add new items
            defaultProforma.Items.RemoveAll(_ => true);
            defaultProforma.Items.Add(new ProformaInvoiceItemPostModel
            {
                Amount = 1,
                Name = "ItemName",
                UnitPrice = 100
            });

            // Create new proforma invoice
            var createdProforma = _api.ProformaInvoiceClient.Post(defaultProforma).CheckResult();

            // Pay proforma invoice
            FullyPayProformaInvoice(createdProforma.Id);

            // Create accounting invoice - single API call without possibility to modify issued invoice before it's created
            var createdAccountingInvoice = _api.ProformaInvoiceClient.Account(createdProforma.Id).CheckResult();
            return (createdProforma.Id, createdAccountingInvoice.Id);
        }

        public int CreatePriceListItem()
        {
            // Get default model containing default values
            var defaultItem = _api.PriceListItemClient.Default().Data;

            // Set properties
            defaultItem.Amount = 100;
            defaultItem.Name = "Price list item 1";
            defaultItem.Price = 100;
            defaultItem.PriceType = PriceType.WithVat;
            defaultItem.Unit = "ks";
            defaultItem.VatRateType = VatRateType.Basic;

            // Create new price list item
            var createdItem = _api.PriceListItemClient.Post(defaultItem).CheckResult();
            return createdItem.Id;
        }

        public void UpdateInvoice_AddItemFromPriceList(int invoiceId, int priceListItemId)
        {
            // Create update model containing id (required) and only properties to be updated.
            // Update first invoice item's amount and add new invoice item containing price list item.
            var invoiceUpdateModel = new IssuedInvoicePatchModel
            {
                Id = invoiceId,
                Description = "Updated invoice",
                Items = new List<IssuedInvoiceItemPatchModel>
                {
                    new IssuedInvoiceItemPatchModel
                    {
                        Id = GetFirstRowId(invoiceId),
                        Amount = 5
                    },
                    AddPriceListItem(priceListItemId, 2)
                }
            };

            // Update the invoice
            var updatedInvoice = _api.IssuedInvoiceClient.Update(invoiceUpdateModel).Data;
        }

        public void UpdateInvoice_NullableProperties(int invoiceId)
        {
            // Entity's properties which can be null are of NullableProperty<T> type in order to distinguish
            // between non-changing the property value and explicit setting to null.
            var secondRow = new IssuedInvoiceItemPatchModel
            {
                Id = GetSecondRowId(invoiceId)
            };

            // At this point, properties DiscountPercentage, PriceListItemId and VatCodeId wouldn't be changed in iDoklad - their IsSet
            // property contains false.

            // Explicit set VatCodeId of last row to null - no explicit conversion to NullableProperty<int> needed.
            secondRow.VatCodeId = null;

            // Set DiscountPercentage to 10% - no explicit conversion to NullableProperty<decimal> needed.
            secondRow.DiscountPercentage = 10m;

            // In some cases, explicit conversion is required to determine the type of expression result.
            // Set specific value or null - DiscountPercentage in iDoklad will be changed
            secondRow.DiscountPercentage = DateTime.Today.DayOfWeek == DayOfWeek.Friday ? (NullableProperty<decimal>)5 : null;
            secondRow.DiscountPercentage = DateTime.Today.DayOfWeek == DayOfWeek.Sunday ? new NullableProperty<decimal>(10) : null;

            // Preserve original value in iDoklad - DiscountPercentage in iDoklad won't be changed
            secondRow.DiscountPercentage = default;

            // Property value can be accessed by its Value property or we can use implicit conversion.
            var discountPercentage1 = secondRow.DiscountPercentage.Value;
            decimal? discountPercentage2 = secondRow.DiscountPercentage;

            // Create update model for first row. If we didn't include it in invoice update model, it would be removed.
            var firstRow = new IssuedInvoiceItemPatchModel
            {
                Id = GetFirstRowId(invoiceId)
            };

            // Create invoice update model.
            var invoiceUpdateModel = new IssuedInvoicePatchModel
            {
                Id = invoiceId,
                Items = new List<IssuedInvoiceItemPatchModel>
                {
                    firstRow,
                    secondRow
                }
            };

            // Update the invoice
            var updatedInvoice = _api.IssuedInvoiceClient.Update(invoiceUpdateModel).Data;
        }

        private IssuedInvoiceItemPatchModel AddPriceListItem(int priceListItemId, int amount)
        {
            // Get price list item
            var priceListItem = GetPriceListItem(priceListItemId);

            // Create new issued invoice item model. Model is of IssuedInvoiceItemPatchModel because we are updating the invoice.
            var issuedInvoiceItem = new IssuedInvoiceItemPatchModel
            {
                Name = priceListItem.Name,
                Amount = amount,
                Code = priceListItem.Code,
                PriceType = priceListItem.PriceType,
                UnitPrice = priceListItem.Price,
                Unit = priceListItem.Unit,
                VatRateType = priceListItem.VatRateType,
                PriceListItemId = priceListItem.Id
            };

            return issuedInvoiceItem;
        }

        private int GetFirstRowId(int issuedInvoiceId)
        {
            return _api.IssuedInvoiceClient
                .Detail(issuedInvoiceId)
                .Get(invoice => invoice.Items.FirstOrDefault(item => item.ItemType == IssuedInvoiceItemType.ItemTypeNormal))
                .Data.Id;
        }

        private int GetSecondRowId(int issuedInvoiceId)
        {
            return _api.IssuedInvoiceClient
                .Detail(issuedInvoiceId)
                .Get(invoice => invoice.Items.Where(item => item.ItemType == IssuedInvoiceItemType.ItemTypeNormal).Skip(1).FirstOrDefault())
                .Data.Id;
        }

        private PriceListItemGetModel GetPriceListItem(int priceListItemId)
        {
            var priceListItem = _api.PriceListItemClient.Detail(priceListItemId).Get().Data;
            return priceListItem;
        }

        private void FullyPayProformaInvoice(int proformaInvoiceId)
        {
            _api.IssuedDocumentPaymentClient.FullyPay(proformaInvoiceId, DateTime.Today.ToUniversalTime()).CheckResult();
        }
    }
}
