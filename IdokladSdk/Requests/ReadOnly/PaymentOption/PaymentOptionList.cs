using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly.PaymentOption;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.ReadOnly.PaymentOption.Filter;

namespace IdokladSdk.Requests.ReadOnly.PaymentOption
{
    /// <summary>
    /// List of payment options.
    /// </summary>
    public class PaymentOptionList : BaseList<PaymentOptionList, PaymentOptionClient, PaymentOptionListGetModel, PaymentOptionFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentOptionList"/> class.
        /// </summary>
        /// <param name="client">Payment option client.</param>
        public PaymentOptionList(PaymentOptionClient client)
            : base(client)
        {
        }
    }
}
