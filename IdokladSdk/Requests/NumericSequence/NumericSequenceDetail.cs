using IdokladSdk.Clients;
using IdokladSdk.Models.NumericSequence;
using IdokladSdk.Requests.Core;

namespace IdokladSdk.Requests.NumericSequence
{
    /// <summary>
    /// NumericSequenceDetail.
    /// </summary>
    public class NumericSequenceDetail : EntityDetail<NumericSequenceDetail, NumericSequenceClient, NumericSequenceGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumericSequenceDetail"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="client">Client.</param>
        public NumericSequenceDetail(int id, NumericSequenceClient client)
            : base(id, client)
        {
        }
    }
}
