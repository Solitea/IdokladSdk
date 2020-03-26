using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly.VatCode;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.ReadOnly.VatCodes.Filter;

namespace IdokladSdk.Requests.ReadOnly.VatCodes
{
    /// <summary>
    /// List of VAT codes.
    /// </summary>
    public class VatCodeList : BaseList<VatCodeList, VatCodeClient, VatCodeListGetModel, VatCodeFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VatCodeList"/> class.
        /// </summary>
        /// <param name="client">VAT code client.</param>
        public VatCodeList(VatCodeClient client)
            : base(client)
        {
        }
    }
}
