using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using IdokladSdk.Requests.Core.Interfaces;
using IdokladSdk.Requests.Core.Path;

namespace IdokladSdk.Requests.Core.Modifiers.Expand.Common
{
    /// <summary>
    /// Query string expand modifier.
    /// </summary>
    /// <typeparam name="TExpandModel">ExpanModel type.</typeparam>
    public class ExpandModifier<TExpandModel> : IQueryStringModifier
    {
        private readonly PathCollection _expands = new PathCollection();

        /// <summary>
        /// Include properties from expand model.
        /// </summary>
        /// <param name="include">Properties to include.</param>
        public void Include(params Expression<Func<TExpandModel, ExpandableEntity>>[] include)
        {
            foreach (var expression in include)
            {
                var body = expression.Body.ToString();
                var path = body.Remove(0, body.IndexOf(".", StringComparison.Ordinal) + 1);
                _expands.Add(path);
            }
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetQueryParameters()
        {
            if (!_expands.Any())
            {
                return null;
            }

            return new Dictionary<string, string>
            {
                { "include",  _expands.ToString() }
            };
        }
    }
}
