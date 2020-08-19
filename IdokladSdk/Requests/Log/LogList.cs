using IdokladSdk.Clients;
using IdokladSdk.Models.Log;
using IdokladSdk.Requests.Core;
using IdokladSdk.Requests.Log.Filter;
using IdokladSdk.Requests.Log.Sort;

namespace IdokladSdk.Requests.Log
{
    /// <summary>
    /// List of logs.
    /// </summary>
    public class LogList : BaseList<LogList, LogClient, LogGetModel, LogFilter, LogSort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogList"/> class.
        /// </summary>
        /// <param name="client">Log client.</param>
        public LogList(LogClient client)
            : base(client)
        {
        }
    }
}
