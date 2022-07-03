using TimeSpan = System.TimeSpan;

namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {
       
       public static string CheckAddress(string url, IDictionary<string, string>? headers = null)
        {
           
                try
                {
                    using var client = new HttpClient();
                    client.Timeout = TimeSpan.FromSeconds(300);
                    if (headers == null)
                        return client.GetAsync(url).Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                    return client.GetAsync(url).Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    ex.LogToConsole();
                }
            

                return "[Running in PlaybackMode]";
        }

        public static string PostAddress(string url, string body, IDictionary<string, string>? headers = null)
        {
            try
            {
                using var client = new HttpClient();
                if (headers == null) return client.PostAsync(url, new StringContent(body)).Result.ToString();
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                return client.PostAsync(url, new StringContent(body)).Result.ToString();
            }
            catch (Exception ex)
            {
                ex.LogToConsole();
            }
            

            return "[Running in PlaybackMode]";
        }

    }
}