using System.Collections.Generic;
using IdokladSdk.Clients;
using IdokladSdk.Models.NumericSequence;
using IdokladSdk.Requests.Core;
using IdokladSdk.Response;

namespace IdokladSdk.Requests.NumericSequence
{
    /// <summary>
    /// NumericSequenceDetail.
    /// </summary>
    public partial class NumericSequenceDetail : EntityDetail<NumericSequenceDetail, NumericSequenceClient, NumericSequenceGetModel>
    {
        private readonly int? _year;

        /// <summary>
        /// Initializes a new instance of the <see cref="NumericSequenceDetail"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="year">Year.</param>
        /// <param name="client">Client.</param>
        public NumericSequenceDetail(int id, NumericSequenceClient client, int? year = null)
            : base(id, client)
        {
            _year = year;
        }

        private string DetailUrl => $"{ResourceUrl}/{Id}?year={_year}";

        /// <inheritdoc />
        protected override ApiResult<TResult> GetCore<TResult>(Dictionary<string, string> queryParams)
        {
            return Client.Get<TResult>(DetailUrl, queryParams);
        }
    }
}
