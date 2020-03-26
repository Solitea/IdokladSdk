using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Models.Report;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Report.CashVoucher
{
    /// <summary>
    /// CashVoucherReportDetail.
    /// </summary>
    public partial class CashVoucherReportDetail : ReportBaseDetail
    {
        private readonly InvoiceReportDocumentType _invoiceDocumentType;
        private readonly int _invoiceId;

        /// <summary>
        /// Initializes a new instance of the <see cref="CashVoucherReportDetail"/> class.
        /// </summary>
        /// <param name="invoiceId">Id.</param>
        /// <param name="client">Client.</param>
        /// <param name="documentType">Document type.</param>
        public CashVoucherReportDetail(int invoiceId, ReportClient client, InvoiceReportDocumentType documentType)
            : base(0, client, ReportDocumentType.CashVoucher)
        {
            _invoiceDocumentType = documentType;
            _invoiceId = invoiceId;
        }

        /// <summary>
        /// Get report.
        /// </summary>
        /// <param name="option">Option.</param>
        /// <returns>API result.</returns>
        public ApiResult<string> Get(ReportOption option = null)
        {
            var resource = GetResource();
            if (option == null)
            {
                return GetBase(resource, null);
            }

            return GetBase(resource, new ExtendedReportOption { Language = option.Language, Compressed = option.Compressed });
        }

        private string GetResource()
        {
            return $"{Client.ResourceUrl}{_invoiceDocumentType}/{_invoiceId}/CashVoucherPdf";
        }
    }
}
