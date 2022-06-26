//using Newtonsoft.Json;

//namespace Reusable.Methods.NET
//{
//    public static partial class Extension
//    {
//        public static string HyperLinkTeams(this string url, string message)
//        {
//            return "[" + message + "]" + "(" + url + ")";
//        }

//        public static void PostToMicrosoftTeams(this string message, string webHookUrl)
//        {
//            PostToMicrosoftTeams(message, webHookUrl, "green");
//        }

//        public static void PostToMicrosoftTeams(string message, string webHookUrl, string color)
//        {
//            if (message == null) return;
//            if (webHookUrl == null) return;
//            var themeColor = color.ToLower() switch
//            {
//                "red" => "eb2813",
//                "green" => "11f00a",
//                _ => null
//            };

//            var teamsMessageCard = new TeamsMessageCard
//            { ThemeColour = themeColor, Title = string.Empty, Text = message };
//            var json = JsonConvert.SerializeObject(teamsMessageCard);
//            PostRestApi(webHookUrl, json);
//        }

//        private class TeamsMessageCard
//        {
//            /// <summary>
//            ///     Gets the context
//            /// </summary>
//            [JsonProperty("@context")]
//            public string Context { get; } = "https://schema.org/extensions";

//            /// <summary>
//            ///     Gets the type
//            /// </summary>
//            [JsonProperty("@type")]
//            public string Type { get; } = "MessageCard";

//            /// <summary>
//            ///     Gets or sets the theme colour html code
//            /// </summary>
//            [JsonProperty("themeColor")]
//            public string ThemeColour { get; set; }

//            /// <summary>
//            ///     Gets or sets the title
//            /// </summary>
//            [JsonProperty("title")]
//            public string Title { get; set; }

//            /// <summary>
//            ///     Gets or sets the message text
//            /// </summary>
//            [JsonProperty("text")]
//            public string Text { get; set; }
//        }
//    }
//}