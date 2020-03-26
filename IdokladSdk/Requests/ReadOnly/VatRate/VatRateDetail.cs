using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly.VatRate;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.ReadOnly.VatRate
{
    /// <summary>
    /// Detail of VAT rate.
    /// </summary>
    public class VatRateDetail : ExpandableDetail<VatRateDetail, VatRateClient, VatRateGetModel, VatRateExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VatRateDetail"/> class.
        /// </summary>
        /// <param name="id">VAT rate id.</param>
        /// <param name="client">VAT rate client.</param>
        public VatRateDetail(int id, VatRateClient client)
            : base(id, client)
        {
        }
    }
}
