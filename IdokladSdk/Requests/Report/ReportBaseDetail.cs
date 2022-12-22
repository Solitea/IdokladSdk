using System.Collections.Generic;
using System.Globalization;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Models.Report;

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

        private Dictionary<string, string> CreateImageQueryParams(ExtendedReportImageOption option)
        {
            var queryParams = new Dictionary<string, string>();
            if (option != null)
            {
                if (option.Language != null)
                {
                    queryParams.Add("language", option.Language.ToString());
                }

                if (option.Resolution != null)
                {
                    queryParams.Add("resolution", option.Resolution.ToString());
                }

                if (option.PaymentOption == PaymentOption.WithOnlyEetPayment)
                {
                    queryParams.Add("onlyEetPayments", "true");
                }
            }

            return queryParams;
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

        private string GetImageResource(ExtendedReportImageOption option)
        {
            var pdfType = option == null ? "Image" :
                option.PaymentOption == PaymentOption.WithoutPayment ? "Image" : "ImageWithPayments";
            var resource = $"{Client.ResourceUrl}{_documentType}/{_id}/{pdfType}";
            return resource;
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
