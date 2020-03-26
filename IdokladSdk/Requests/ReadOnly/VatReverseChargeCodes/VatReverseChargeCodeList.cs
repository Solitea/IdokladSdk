using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly.VatReverseChargeCode;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.ReadOnly.VatReverseChargeCodes.Filter;

namespace IdokladSdk.Requests.ReadOnly.VatReverseChargeCodes
{
    /// <summary>
    /// List of VAT reverse charge codes.
    /// </summary>
    public class VatReverseChargeCodeList : BaseList<VatReverseChargeCodeList, VatReverseChargeCodeClient, VatReverseChargeCodeListGetModel, VatReverseChargeCodeFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VatReverseChargeCodeList"/> class.
        /// </summary>
        /// <param name="client">Bank client.</param>
        public VatReverseChargeCodeList(VatReverseChargeCodeClient client)
            : base(client)
        {
        }
    }
}
