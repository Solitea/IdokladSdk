using System.Threading;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Enums;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Log;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with log endpoints.
    /// </summary>
    public class LogClient : BaseClient, IEntityList<LogList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogClient" /> class.
        /// </summary>
        /// <param name="apiContext">API context.</param>
        public LogClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/Logs";

        /// <inheritdoc />
        public LogList List()
        {
            return new LogList(this);
        }

        /// <summary>
        /// List of entities. Returns an instance which allows operations on list of entities (filtering, sorting, etc.)
        /// and retrieving of data by calling <see cref="BaseList{TList,TClient,TGetModel,TFilter,TSort}.GetAsync(CancellationToken)"/>.
        /// </summary>
        /// <param name="entityId">Entity Id.</param>
        /// <param name="entityType">Entity type.</param>
        /// <returns>Instance of descendant of <see cref="BaseList{TList,TClient,TGetModel,TFilter,TSort}"/>.</returns>
        public LogEntityList List(int entityId, LogEntityType entityType)
        {
            return new LogEntityList(this, entityId, entityType);
        }
    }
}
