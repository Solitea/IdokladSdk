using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Requests.ReadOnly.PaymentOption;

namespace IdokladSdk.Clients.Readonly
{
    /// <summary>
    /// Client for communication with PaymentOptions endpoints.
    /// </summary>
    public class PaymentOptionClient :
        BaseClient,
        IEntityDetail<PaymentOptionDetail>,
        IEntityList<PaymentOptionList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentOptionClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public PaymentOptionClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/PaymentOptions";

        /// <inheritdoc/>
        public PaymentOptionDetail Detail(int id)
        {
            return new PaymentOptionDetail(id, this);
        }

        /// <inheritdoc/>
        public PaymentOptionList List()
        {
            return new PaymentOptionList(this);
        }
    }
}
