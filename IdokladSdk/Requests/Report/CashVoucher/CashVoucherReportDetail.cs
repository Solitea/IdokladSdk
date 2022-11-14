using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Models.Report;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Report.CashVoucher
{
    /// <summary>
    /// CashVoucherReportDetail.
    /// </summary>
    public class CashVoucherReportDetail : ReportBaseDetail
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
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>API result.</returns>
        public Task<ApiResult<string>> GetAsync(ReportOption option = null, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            if (option == null)
            {
                return GetBaseAsync(resource, null, cancellationToken);
            }

            return GetBaseAsync(resource, new ExtendedReportOption { Language = option.Language, Compressed = option.Compressed }, cancellationToken);
        }

        /// <summary>
        /// Get image report.
        /// </summary>
        /// <param name="option">Option.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>API result.</returns>
        public Task<ApiResult<List<ReportImageGetModel>>> GetImageAsync(ReportImageOption option = null, CancellationToken cancellationToken = default)
        {
            var resource = GetImageResource();
            if (option == null)
            {
                return GetImageBaseAsync(resource, null, cancellationToken);
            }

            return GetImageBaseAsync(resource, new ExtendedReportImageOption { Language = option.Language }, cancellationToken);
        }

        private string GetImageResource()
        {
            return $"{Client.ResourceUrl}{_invoiceDocumentType}/{_invoiceId}/CashVoucherImage";
        }

        private string GetResource()
        {
            return $"{Client.ResourceUrl}{_invoiceDocumentType}/{_invoiceId}/CashVoucherPdf";
        }
    }
}
