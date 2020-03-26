namespace IdokladSdk.Requests.Core.Interfaces
{
    /// <summary>
    /// Interface for paging of a list result.
    /// </summary>
    /// <typeparam name="TList">Return type.</typeparam>
    public interface IPageable<out TList>
    {
        /// <summary>
        /// Gets specified page of a list.
        /// </summary>
        /// <param name="page">Page number.</param>
        /// <returns>List of models.</returns>
        TList Page(int page = Constants.DefaultPage);

        /// <summary>
        /// Sets page size.
        /// </summary>
        /// <param name="pageSize">Page size (default 20).</param>
        /// <returns>List of models.</returns>
        TList PageSize(int pageSize = Constants.DefaultPageSize);
    }
}
