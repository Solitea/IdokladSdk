using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly.VatRate;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.ReadOnly.VatRate.Filter;

namespace IdokladSdk.Requests.ReadOnly.VatRate
{
    /// <summary>
    /// List of VAT rates.
    /// </summary>
    public class VatRateList : BaseList<VatRateList, VatRateClient, VatRateListGetModel, VatRateFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VatRateList"/> class.
        /// </summary>
        /// <param name="client">VAT rate client.</param>
        public VatRateList(VatRateClient client)
            : base(client)
        {
        }
    }
}
