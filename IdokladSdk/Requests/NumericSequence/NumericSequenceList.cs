using IdokladSdk.Clients;
using IdokladSdk.Models.NumericSequence;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Core.Modifiers.Sort.BasicSorts;
using IdokladSdk.Requests.NumericSequence.Filter;

namespace IdokladSdk.Requests.NumericSequence
{
    /// <summary>
    /// NumericSequenceList.
    /// </summary>
    public class NumericSequenceList : BaseList<NumericSequenceList, NumericSequenceClient, NumericSequenceGetModel, NumericSequenceFilter, IdSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumericSequenceList"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public NumericSequenceList(NumericSequenceClient client)
            : base(client)
        {
        }
    }
}
