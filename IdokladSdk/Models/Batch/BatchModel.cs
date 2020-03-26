using System.Collections.Generic;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.Batch
{
    /// <summary>
    /// Model for batch operations.
    /// </summary>
    /// <typeparam name="T">Return type.</typeparam>
    public class BatchModel<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchModel{T}"/> class.
        /// </summary>
        public BatchModel()
        {
            Items = new List<T>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchModel{T}"/> class.
        /// </summary>
        /// <param name="items">Items.</param>
        public BatchModel(IList<T> items)
        {
            Items = items;
        }

        /// <summary>
        /// Gets or sets individual batch items, which have the same meaning as in the non-batch version.
        /// </summary>
        [CollectionRange(1, 50)]
        public IList<T> Items { get; set; }
    }
}
