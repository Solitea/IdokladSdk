using System.Collections.Generic;

namespace IdokladSdk.Requests.Core.Extensions
{
    /// <summary>
    /// Extensions for Object.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns <see cref="Dictionary{TKey, TValue}"/> representing <see cref="object"/> property names as keys and property values as values />.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns><see cref="Dictionary{TKey, TValue}"/> representing object properties as dictionary.</returns>
        public static Dictionary<string, string> AsDictionary(this object obj)
        {
            var result = new Dictionary<string, string>();
            foreach (var property in obj.GetType().GetProperties())
            {
                result.Add(property.Name, property.GetValue(obj).ToString());
            }

            return result;
        }
    }
}
