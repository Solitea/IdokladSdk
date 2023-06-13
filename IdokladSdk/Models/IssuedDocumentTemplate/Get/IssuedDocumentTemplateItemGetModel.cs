using IdokladSdk.Models.IssuedDocumentTemplate.List;
using IdokladSdk.Models.PriceListItem;
using IdokladSdk.Models.ReadOnly.VatCode;

namespace IdokladSdk.Models.IssuedDocumentTemplate.Get
{
    /// <summary>
    /// IssuedDocumentTemplateItemGetModel.
    /// </summary>
    public class IssuedDocumentTemplateItemGetModel : IssuedDocumentTemplateListItemGetModel
    {
        /// <summary>
        /// Gets or sets price list item.
        /// </summary>
        public PriceListItemGetModel PriceListItem { get; set; }

        /// <summary>
        /// Gets or sets vat code.
        /// </summary>
        public VatCodeGetModel VatCode { get; set; }
    }
}
