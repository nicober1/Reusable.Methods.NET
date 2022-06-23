using Newtonsoft.Json;

namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {
        public static T? DeserializeJsonInputStringOutputObject<T>(string json)
        {

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static List<T>? DeserializeJsonInputStringOutputObjectList<T>(string json)
        {

            return JsonConvert.DeserializeObject<List<T>>(json);
        }

    }
}