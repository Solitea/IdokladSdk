using IdokladSdk.Requests.Core;

namespace IdokladSdk.Clients.Interfaces
{
    /// <summary>
    /// Interface for detail of an entity.
    /// </summary>
    /// <typeparam name="TDetail">Type which implements detail operations for particular entity.</typeparam>
    public interface IEntityDetail<out TDetail>
    {
        /// <summary>
        /// Detail of entity with given Id. Returns an instance which allows operations on detail of entity
        /// (e.g. inclusion of nested objects) and retrieving of data by calling <see cref="BaseDetail{TDetail,TClient,TGetModel}.Get()"/>.
        /// </summary>
        /// <param name="id">Entity Id.</param>
        /// <returns>Instance of descendant of <see cref="BaseDetail{TDetail,TClient,TGetModel}"/>.</returns>
        TDetail Detail(int id);
    }
}
