using System.Collections.Generic;

namespace SquareSpaceSharp.Extensions
{
    public static class DictionaryExtensions
    {
        public static void AddRange(this IDictionary<string, object> dictionary, IEnumerable<KeyValuePair<string, object>> kvps)
        {
            foreach (var kvp in kvps)
            {
                dictionary.Add(kvp.Key, kvp.Value);
            }
        }
    }
}