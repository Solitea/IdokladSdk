using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.Models.Log;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Log.Filter;
using IdokladSdk.Requests.Log.Sort;

namespace IdokladSdk.Requests.Log
{
    /// <summary>
    /// List of logs for specific entity.
    /// </summary>
    public class LogEntityList : BaseList<LogEntityList, LogClient, LogGetModel, LogEntityFilter, LogSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogEntityList"/> class.
        /// </summary>
        /// <param name="client">Log client.</param>
        /// <param name="entityId">Entity Id.</param>
        /// <param name="entityType">Entity type.</param>
        public LogEntityList(LogClient client, int entityId, LogEntityType entityType)
            : base(client)
        {
            ListName = $"{entityId}/{entityType}";
        }
    }
}
