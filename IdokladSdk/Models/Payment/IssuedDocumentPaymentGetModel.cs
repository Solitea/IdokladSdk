using IdokladSdk.Models.RegisteredSale;

namespace IdokladSdk.Models.Payment
{
    /// <summary>
    /// IssuedDocumentPaymentGetModel.
    /// </summary>
    public class IssuedDocumentPaymentGetModel
    {
        /// <summary>
        /// Gets or sets the registered sale for the payment.
        /// </summary>
        public RegisteredSaleGetModel RegisteredSale { get; set; }
    }
}
