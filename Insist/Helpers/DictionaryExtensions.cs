using System;
using System.Collections.Generic;

namespace Insist.Helpers
{
    public static class DictionaryExtensions
    {
        public static bool TryGet<T>(this IDictionary<string, object> dictionary, string key, out Func<T, bool> value)
        {
            if (dictionary.TryGetValue(key, out var result) && result is Func<T, bool> func) {
                value = func;
                return true;
            }
            value = default(Func<T, bool>);
            return false;
        }

        public static void Set<T>(this IDictionary<string, object> dictionary, string key, Func<T, bool> value)
        {
            dictionary[key] = value;
        }
    }
}