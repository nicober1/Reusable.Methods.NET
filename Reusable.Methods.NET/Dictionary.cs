namespace Reusable.Methods.NET;

    public static partial class Reuse
    {
       

        public static string DictionaryToPairString<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, string pairSeparator, string keyValueSeparator = "=")
        {
            return string.Join(Environment.NewLine, dictionary.Select(pair => pair.Key + keyValueSeparator + pair.Value));
        }
    }
