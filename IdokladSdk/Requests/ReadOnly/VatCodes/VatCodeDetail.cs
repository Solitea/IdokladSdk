using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly.VatCode;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;

namespace IdokladSdk.Requests.ReadOnly.VatCodes
{
    /// <summary>
    /// Detail of VAT code.
    /// </summary>
    public class VatCodeDetail : ExpandableDetail<VatCodeDetail, VatCodeClient, VatCodeGetModel, VatCodeExpand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VatCodeDetail"/> class.
        /// </summary>
        /// <param name="id">VAT code id.</param>
        /// <param name="client">VAT code client.</param>
        public VatCodeDetail(int id, VatCodeClient client)
            : base(id, client)
        {
        }
    }
}
