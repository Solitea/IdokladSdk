﻿using IdokladSdk.Clients;
using IdokladSdk.Models.Payment.DocumentPayments.Sales.Detail;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.DocumentPayment.Sales
{
    /// <summary>
    /// SalesReceiptPaymentDetail.
    /// </summary>
    public class SalesReceiptPaymentDetail : ExpandableDetail<SalesReceiptPaymentDetail, DocumentPaymentClient,
        SalesDocumentPaymentForSalesReceiptGetModel, SalesDocumentPaymentForSalesReceiptExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesReceiptPaymentDetail"/> class.
        /// </summary>
        /// <param name="id">Payment id.</param>
        /// <param name="client">Sales receipt payment client.</param>
        public SalesReceiptPaymentDetail(int id, DocumentPaymentClient client) 
            : base(id, client)
        {
        }

        protected override string DetailName => "Sales/Get/SalesReceipt/";
    }
}
