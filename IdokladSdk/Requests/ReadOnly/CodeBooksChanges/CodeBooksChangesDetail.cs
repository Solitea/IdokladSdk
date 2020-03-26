using System;
using System.Collections.Generic;
using System.Globalization;
using IdokladSdk.Clients.Readonly;
using IdokladSdk.Models.ReadOnly;
using IdokladSdk.Requests.Core;

namespace IdokladSdk.Requests.ReadOnly
{
    /// <summary>
    /// Detail of code book changes.
    /// </summary>
    public class CodeBooksChangesDetail : BaseDetail<CodeBooksChangesDetail, SystemClient, CodeBooksChangesGetModel>
    {
        private readonly DateTime _lastCheck;

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeBooksChangesDetail"/> class.
        /// </summary>
        /// <param name="lastCheck">Date of last check.</param>
        /// <param name="client">System client.</param>
        public CodeBooksChangesDetail(DateTime lastCheck, SystemClient client)
            : base(client)
        {
            _lastCheck = lastCheck;
        }

        /// <inheritdoc />
        protected override string DetailName => $"GetCodeBooksChanges";

        /// <inheritdoc />
        protected override Dictionary<string, string> GetQueryParams()
        {
            var queryParams = base.GetQueryParams();
            var lastCheck = _lastCheck.ToString(Constants.DateFormat, CultureInfo.InvariantCulture);
            queryParams.Add("lastCheck", lastCheck);
            return queryParams;
        }
    }
}
