using IdokladSdk.Clients;
using IdokladSdk.Enums;

namespace IdokladSdk.Requests.Report.CashVoucher
{
    /// <summary>
    /// CashVoucherReport.
    /// </summary>
    public class CashVoucherReport : Report
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashVoucherReport"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public CashVoucherReport(ReportClient client)
            : base(client, ReportDocumentType.CashVoucher)
        {
        }

        /// <summary>
        /// Detail.
        /// </summary>
        /// <param name="invoiceId">Invoice id.</param>
        /// <param name="documentType">Invoice document type.</param>
        /// <returns>Detail of issued invoice report.</returns>
        public CashVoucherReportDetail DetailForInvoice(int invoiceId, InvoiceReportDocumentType documentType)
        {
            return new CashVoucherReportDetail(invoiceId, Client, documentType);
        }

        /// <summary>
        /// List.
        /// </summary>
        /// <returns>Return list.</returns>
        public CashVoucherReportList List()
        {
            return new CashVoucherReportList(Client);
        }
    }
}
