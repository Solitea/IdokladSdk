using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Requests.CashVoucher.Filter;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;

namespace IdokladSdk.Requests.Report.CashVoucher
{
    /// <summary>
    /// CashVoucherReportList.
    /// </summary>
    public class CashVoucherReportList : BaseReportList<CashVoucherReportList, ReportClient, string, CashVoucherFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashVoucherReportList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public CashVoucherReportList(ReportClient client)
            : base(client, ReportDocumentType.CashVoucher)
        {
        }
    }
}
