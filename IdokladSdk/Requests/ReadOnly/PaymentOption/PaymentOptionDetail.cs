using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly.PaymentOption;
using IdokladSdk.Requests.Core;

namespace IdokladSdk.Requests.ReadOnly.PaymentOption
{
    /// <summary>
    /// Detail of payment option.
    /// </summary>
    public class PaymentOptionDetail : EntityDetail<PaymentOptionDetail, PaymentOptionClient, PaymentOptionGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentOptionDetail"/> class.
        /// </summary>
        /// <param name="id">Payment option id.</param>
        /// <param name="client">Payment option client.</param>
        public PaymentOptionDetail(int id, PaymentOptionClient client)
            : base(id, client)
        {
        }
    }
}
