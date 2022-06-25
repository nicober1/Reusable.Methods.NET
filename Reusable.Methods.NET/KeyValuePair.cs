namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {
       
        public static string  GetValueForGivenKeyFromKeyValuePairListInput(
            this IEnumerable<KeyValuePair<string, string>> keyValue,string key)
        {

            return keyValue.First(x => x.Key.Contains(key)).Value;

        }
    }
}