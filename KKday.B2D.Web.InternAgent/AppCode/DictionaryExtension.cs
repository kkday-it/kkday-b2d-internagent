using System;
using System.Collections.Generic;
 
public static class DictionaryExtension
{
    public static TV GetValue<TK, TV>(this IDictionary<TK, TV> dict, TK key, TV defaultValue = default(TV))
    {
        TV value;
        return dict.TryGetValue(key, out value) ? value : defaultValue;
    }
}
 
