using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using IdokladSdk.Clients;
using IdokladSdk.Requests.Core.Extensions;
using IdokladSdk.Requests.Core.Interfaces;
using IdokladSdk.Requests.Core.Modifiers.Expand.Common;

namespace IdokladSdk.Requests.Core
{
    /// <summary>
    /// Base class for detail requests with entity Id which supports inclusion of related models.
    /// </summary>
    /// <typeparam name="TDetail">Detail type.</typeparam>
    /// <typeparam name="TClient">Client type.</typeparam>
    /// <typeparam name="TGetModel">GetModel type.</typeparam>
    /// <typeparam name="TExpand">Expand type.</typeparam>
    public abstract partial class ExpandableDetail<TDetail, TClient, TGetModel, TExpand> : EntityDetail<TDetail, TClient, TGetModel>,
        IExpandable<TDetail, TExpand>
        where TDetail : ExpandableDetail<TDetail, TClient, TGetModel, TExpand>
        where TClient : BaseClient
        where TGetModel : new()
        where TExpand : new()
    {
        private readonly ExpandModifier<TExpand> _expand = new ExpandModifier<TExpand>();

        internal ExpandableDetail(TClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpandableDetail{TDetail, TClient, TGetModel, TExpand}"/> class.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <param name="client">Client.</param>
        protected ExpandableDetail(int id, TClient client)
            : base(id, client)
        {
        }

        /// <summary>
        /// Include other related models.
        /// </summary>
        /// <param name="include">Related models.</param>
        /// <returns>Detail.</returns>
        public TDetail Include(params Expression<Func<TExpand, ExpandableEntity>>[] include)
        {
            _expand.Include(include);
            return This;
        }

        /// <inheritdoc />
        protected override Dictionary<string, string> GetQueryParams()
        {
            var queryParams = base.GetQueryParams();
            queryParams.AddRange(_expand.GetQueryParameters());

            return queryParams;
        }
    }
}
