using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly.VatReverseChargeCode;
using IdokladSdk.Requests.Core;

namespace IdokladSdk.Requests.ReadOnly.VatReverseChargeCodes
{
    /// <summary>
    /// Detail of VAT reverse charge code.
    /// </summary>
    public class VatReverseChargeCodeDetail : EntityDetail<VatReverseChargeCodeDetail, VatReverseChargeCodeClient, VatReverseChargeCodeGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VatReverseChargeCodeDetail"/> class.
        /// </summary>
        /// <param name="id">VAT reverse charge code id.</param>
        /// <param name="client">VAT reverse charge code client.</param>
        public VatReverseChargeCodeDetail(int id, VatReverseChargeCodeClient client)
            : base(id, client)
        {
        }
    }
}
