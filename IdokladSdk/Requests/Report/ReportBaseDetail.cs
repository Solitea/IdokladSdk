using System.Collections.Generic;
using System.Globalization;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Models.Report;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.Report
{
    /// <summary>
    /// ReportDetail.
    /// </summary>
    public partial class ReportBaseDetail
    {
        private readonly ReportDocumentType _documentType;

        private readonly int _id;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportBaseDetail" /> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="client">Report client.</param>
        /// <param name="documentType">Document type.</param>
        public ReportBaseDetail(int id, ReportClient client, ReportDocumentType documentType)
        {
            Client = client;
            _id = id;
            _documentType = documentType;
        }

        /// <summary>
        /// Gets Client.
        /// </summary>
        protected ReportClient Client { get; }

        /// <summary>
        /// Get report.
        /// </summary>
        /// <param name="option">Option.</param>
        /// <returns>API result.</returns>
        protected ApiResult<string> GetBase(ExtendedReportOption option)
        {
            var resource = GetResource(option);
            return GetBase(resource, option);
        }

        /// <summary>
        /// Get report.
        /// </summary>
        /// <param name="resource">Resource.</param>
        /// <param name="option">Option.</param>
        /// <returns>API result.</returns>
        protected ApiResult<string> GetBase(string resource, ExtendedReportOption option)
        {
            var queryParams = CreateQueryParams(option);
            return Client.Get<string>(resource, queryParams);
        }

        private Dictionary<string, string> CreateQueryParams(ExtendedReportOption option)
        {
            var queryParams = new Dictionary<string, string>();
            if (option != null)
            {
                queryParams.Add("compressed", option.Compressed.ToString(CultureInfo.InvariantCulture));
                if (option.Language != null)
                {
                    queryParams.Add("language", option.Language.ToString());
                }

                if (option.PaymentOption == PaymentOption.WithOnlyEetPayment)
                {
                    queryParams.Add("onlyEetPayments", "true");
                }
            }

            return queryParams;
        }

        private string GetResource(ExtendedReportOption option)
        {
            var pdfType = option == null ? "Pdf" :
                option.PaymentOption == PaymentOption.WithoutPayment ? "Pdf" : "PdfWithPayments";
            var resource = $"{Client.ResourceUrl}{_documentType}/{_id}/{pdfType}";
            return resource;
        }
    }
}
