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
        /// <summary>
        /// Initializes a new instance of the <see cref="CodeBooksDetail"/> class.
        /// </summary>
        /// <param name="client">System client.</param>
        public CodeBooksDetail(SystemClient client)
            : base(client)
        {
        }

        /// <inheritdoc />
        protected override string DetailName => "GetCodeBooks";
    }
}
