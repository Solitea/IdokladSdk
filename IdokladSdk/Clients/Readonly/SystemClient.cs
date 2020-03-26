using System;
using IdokladSdk.Requests.ReadOnly;
using IdokladSdk.Requests.ReadOnly.CodeBooks;

namespace IdokladSdk.Clients.Readonly
{
    /// <summary>
    /// Client for communication with System endpoints.
    /// </summary>
    public class SystemClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemClient"/> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public SystemClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/System";

        /// <summary>
        /// System tables.
        /// </summary>
        /// <returns>Content of all system tables.</returns>
        public CodeBooksDetail CodeBooks()
        {
            return new CodeBooksDetail(this);
        }

        /// <summary>
        /// Information about system tables changes.
        /// </summary>
        /// <returns>Indication if individual system tables have been changed since the last check.</returns>
        /// <param name="lastCheck">Date of the last check.</param>
        public CodeBooksChangesDetail CodeBooksChanges(DateTime lastCheck)
        {
            return new CodeBooksChangesDetail(lastCheck, this);
        }
    }
}
