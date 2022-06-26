using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Formatting = Newtonsoft.Json.Formatting;

namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {
        public static JObject GetJObjectForJsonString(this string jsonBody)
        {
            return JObject.Parse(jsonBody);
        }

        public static dynamic? GetJPropertyFromJsonString(string jsonBody, string propertyName)
        {
            var obj = JObject.Parse(jsonBody);
            return obj.GetValue(propertyName, StringComparison.InvariantCultureIgnoreCase);
        }

        public static string FetchAttribute(string response, string id)
        {
            var b = (JObject)JsonConvert.DeserializeObject(response);
            var value = b?[id];
            return value?.ToString();
        }

        public static string ConvertXmlToJson(string xmlString)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xmlString);
            return JsonConvert.SerializeXmlNode(doc);
        }

        public static string SerializeObjectToJson(this object classObject)
        {
            ITraceWriter traceWriter = new MemoryTraceWriter();
            var jsonString = JsonConvert.SerializeObject(classObject, Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    TraceWriter = traceWriter,
                    Converters = { new JavaScriptDateTimeConverter() }
                });
            Console.WriteLine(traceWriter);
            return jsonString;
        }

        public static IEnumerable<JToken> AllChildren(JToken json)
        {
            foreach (var c in json.Children())
            {
                yield return c;
                foreach (var cc in AllChildren(c))
                {
                    yield return cc;
                }
            }
        }

        public static void WriteJsonToFile(string fileName, string json)
        {
            using var fs = File.Create(fileName);
            fs.Close();
            File.AppendAllText(fileName,
                JToken.Parse(json).ToString(Formatting.Indented));
        }
    }
}