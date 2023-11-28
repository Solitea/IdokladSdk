using IdokladSdk.Enums;

namespace IdokladSdk.Models.SalesOrder
{
    /// <summary>
    /// Default model.
    /// </summary>
    public class SalesOrderDefaultGetModel : SalesOrderPostModel
    {
        /// <summary>
        /// Gets or sets Vat regime.
        /// </summary>
        public VatRegime VatRegime { get; set; }
    }
}
