using System;
using System.Collections.Generic;

namespace IdokladSdk.Requests.Core.Extensions
{
    /// <summary>
    /// Exntensions for Dictionary.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Add elements of another dictionary.
        /// </summary>
        /// <param name="target">Target ditionary.</param>
        /// <param name="source">Source dictionary.</param>
        /// <returns>Target ditionary with added elements.</returns>
        public static Dictionary<string, string> AddRange(
            this Dictionary<string, string> target,
            Dictionary<string, string> source)
        {
            if (target is null)
            {
                throw new ArgumentNullException("Target cannot be null.", nameof(target));
            }

            if (source != null)
            {
                foreach (var item in source)
                {
                    target.Add(item.Key, item.Value);
                }
            }

            return target;
        }
    }
}
