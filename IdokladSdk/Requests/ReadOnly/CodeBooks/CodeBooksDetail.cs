using System.Collections.Generic;
using System.Globalization;
using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly;
using IdokladSdk.Requests.Core;

namespace IdokladSdk.Requests.ReadOnly.CodeBooks
{
    /// <summary>
    /// Detail of code books.
    /// </summary>
    public class CodeBooksDetail : BaseDetail<CodeBooksDetail, SystemClient, CodeBooksGetModel>
    {
        private readonly bool _includeVectorData;

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeBooksDetail"/> class.
        /// </summary>
        /// <param name="includeVectorData">Include vector data.</param>
        /// <param name="client">System client.</param>
        public CodeBooksDetail(bool includeVectorData, SystemClient client)
            : base(client)
        {
            _includeVectorData = includeVectorData;
        }

        /// <inheritdoc />
        protected override string DetailName => "GetCodeBooks";

        /// <inheritdoc />
        protected override Dictionary<string, string> GetQueryParams()
        {
            var queryParams = base.GetQueryParams();
            var includeVectorData = _includeVectorData.ToString(CultureInfo.InvariantCulture);
            queryParams.Add("includeVectorData", includeVectorData);
            return queryParams;
        }
    }
}
