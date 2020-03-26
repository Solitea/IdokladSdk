using System;
using System.Collections.Generic;
using System.Linq;

namespace IdokladSdk.Requests.Core.Path
{
    /// <summary>
    /// Collection of paths.
    /// </summary>
    public class PathCollection
    {
        private readonly HashSet<PathItem> _paths = new HashSet<PathItem>();

        /// <summary>
        /// Add path.
        /// </summary>
        /// <param name="path">Path.</param>
        public void Add(string path)
        {
            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            var properties = path.Split(new[] { '.' }, 2);
            var propertyName = properties[0];
            if (_paths.Any(s => s.PropertyName == propertyName))
            {
                if (properties.Length > 1)
                {
                    var innerPropertyPath = properties[1];
                    _paths.First(s => s.PropertyName == propertyName).Add(innerPropertyPath);
                }
            }
            else
            {
                _paths.Add(new PathItem(path));
            }
        }

        /// <summary>
        /// Check whether collection is empty or not.
        /// </summary>
        /// <returns><c>true</c> if collection contains elements, otherwise <c>false</c>.</returns>
        public bool Any()
        {
            return _paths.Any();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (!_paths.Any())
            {
                return string.Empty;
            }

            var formatted = string.Join(",", _paths);

            return formatted;
        }
    }
}
