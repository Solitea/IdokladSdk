using System;
using IdokladSdk.Clients;

namespace IdokladSdk.Requests.Core
{
    /// <summary>
    /// Base class for detail requests with entity Id.
    /// </summary>
    /// <typeparam name="TDetail">Detail type.</typeparam>
    /// <typeparam name="TClient">Client type.</typeparam>
    /// <typeparam name="TGetModel">GetModel type.</typeparam>
    public abstract partial class EntityDetail<TDetail, TClient, TGetModel> : BaseDetail<TDetail, TClient, TGetModel>
        where TDetail : EntityDetail<TDetail, TClient, TGetModel>
        where TClient : BaseClient
        where TGetModel : new()
    {
        internal EntityDetail(TClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityDetail{TDetail, TClient, TGetModel}"/> class.
        /// </summary>
        /// <param name="id">Entity Id.</param>
        /// <param name="client">Client.</param>
        protected EntityDetail(int id, TClient client)
            : base(client)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Detail id has to be greater than 0.", nameof(id));
            }

            Id = id;
        }

        /// <summary>
        /// Gets Id.
        /// </summary>
        protected int Id { get; }
    }
}
