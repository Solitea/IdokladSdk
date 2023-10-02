using System.Collections.Generic;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.IssuedDocumentTemplate.Recount
{
    /// <summary>
    /// IssuedDocumentTemplateRecountGetModel.
    /// </summary>
    public class IssuedDocumentTemplateRecountGetModel
    {
        /// <summary>
        /// Gets or sets currency id.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets discount percentage.
        /// </summary>
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets document type.
        /// </summary>
        public IssuedDocumentTemplateType DocumentType { get; set; }

        /// <summary>
        /// Gets or sets items.
        /// </summary>
        public List<IssuedDocumentTemplateItemRecountGetModel> Items { get; set; }

        /// <summary>
        /// Gets or sets payment id.
        /// </summary>
        public int PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets prices.
        /// </summary>
        public TemplatePrices Prices { get; set; }
    }
}
