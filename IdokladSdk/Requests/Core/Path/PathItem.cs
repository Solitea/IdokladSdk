using System;

namespace IdokladSdk.Requests.Core.Path
{
    /// <summary>
    /// Path item.
    /// </summary>
    public class PathItem
    {
        private readonly PathCollection _paths = new PathCollection();

        /// <summary>
        /// Initializes a new instance of the <see cref="PathItem"/> class.
        /// </summary>
        /// <param name="path">Item name.</param>
        public PathItem(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path should not be empty.", nameof(path));
            }

            var properties = path.Split(new[] { '.' }, 2);
            PropertyName = properties[0];
            if (properties.Length > 1)
            {
                var innerPropertyPath = properties[1];
                _paths.Add(innerPropertyPath);
            }
        }

        /// <summary>
        /// Gets property name.
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Add path item.
        /// </summary>
        /// <param name="name">Item name.</param>
        public void Add(string name)
        {
            _paths.Add(name);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (!_paths.Any())
            {
                return PropertyName;
            }

            var innerSelect = string.Join(",", _paths);

            return $"{PropertyName}({innerSelect})";
        }
    }
}
