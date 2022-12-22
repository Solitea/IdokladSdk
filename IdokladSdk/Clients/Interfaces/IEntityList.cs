using System.Threading;
using IdokladSdk.Requests.Core;

namespace IdokladSdk.Clients.Interfaces
{
    /// <summary>
    /// Interface for list of entities.
    /// </summary>
    /// <typeparam name="TList">Type which implements list operations for particular entity.</typeparam>
    public interface IEntityList<out TList>
        where TList : class
    {
        /// <summary>
        /// List of entities. Returns an instance which allows operations on list of entities (filtering, sorting, etc.)
        /// and retrieving of data by calling <see cref="BaseList{TList,TClient,TGetModel,TFilter,TSort}.GetAsync(CancellationToken)"/>.
        /// </summary>
        /// <returns>Instance of descendant of <see cref="BaseList{TList,TClient,TGetModel,TFilter,TSort}"/>.</returns>
        TList List();
    }
}
