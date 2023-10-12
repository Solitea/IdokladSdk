using System.Collections.Generic;
using System.Linq;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.PriceListItem;

namespace IdokladSdk.NetCore.TestApp.Examples.Extensions
{
    /// <summary>
    /// Extensions for map issued invoice models.
    /// </summary>
    public static class IssuedInvoiceExtensions
    {
        /// <summary>
        /// Adds new issued invoice item containing specific amount of the price list item.
        /// </summary>
        /// <param name="items">Issued invoice items.</param>
        /// <param name="priceListItem">Price list item.</param>
        /// <param name="amount">Amount.</param>
        /// <returns>List.</returns>
        public static List<IssuedInvoiceItemPostModel> Add(this List<IssuedInvoiceItemPostModel> items, PriceListItemGetModel priceListItem, int amount)
        {
            if (priceListItem == null)
            {
                return items;
            }

            var item = new IssuedInvoiceItemPostModel
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
            items?.Add(item);

            return items;
        }

        /// <summary>
        /// Maps issued invoice to recount model.
        /// </summary>
        /// <param name="source">Issued invoice.</param>
        /// <returns>Recount model.</returns>
        public static IssuedInvoiceRecountPostModel ToRecountModel(this IssuedInvoicePostModel source)
        {
            if (source == null)
            {
                return null;
            }

            return new IssuedInvoiceRecountPostModel
            {
                CurrencyId = source.CurrencyId,
                DiscountPercentage = source.DiscountPercentage,
                DateOfTaxing = source.DateOfTaxing,
                ExchangeRate = source.ExchangeRate,
                ExchangeRateAmount = source.ExchangeRateAmount,
                Items = source.Items.Select(ToRecountModel).ToList(),
                PaymentOptionId = source.PaymentOptionId
            };
        }

        /// <summary>
        /// Maps issued invoice item to recount model.
        /// </summary>
        /// <param name="source">Issued invoice item.</param>
        /// <returns>Recount model.</returns>
        public static IssuedInvoiceItemRecountPostModel ToRecountModel(this IssuedInvoiceItemPostModel source)
        {
            if (source == null)
            {
                return null;
            }

            return new IssuedInvoiceItemRecountPostModel
            {
                Name = source.Name,
                UnitPrice = source.UnitPrice,
                Amount = source.Amount,
                DiscountPercentage = source.DiscountPercentage,
                PriceType = source.PriceType,
                VatRateType = source.VatRateType
            };
        }
    }
}
