using System.Collections.Generic;

namespace IdokladSdk.IntegrationTests.Tests.Clients.SalesReceipt.SelectModels
{
    /// <summary>
    /// SalesReceiptSelectPaymentModel.
    /// </summary>
    public class SalesReceiptSelectPaymentModel
    {
        /// <summary>
        /// Gets or sets payments.
        /// </summary>
        public List<PaymentSelectModel> Payments { get; set; }
    }
}