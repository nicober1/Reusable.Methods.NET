namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {
        public static IDictionary<string, object> GetConfigDictionaryUsingKeysPerFile(string? path = null)
        {
            var root = Reuse.GetExecutingAssemblyLocationPath() + path;
            var cb = new ConfigurationBuilder().AddKeyPerFile(x =>
            {
                x.FileProvider = new PhysicalFileProvider(root);
                x.Optional = true;
                x.IgnoreCondition = fileName => fileName.StartsWith("Ignore_");
            });
            return cb.Properties;
        }

        public static IEnumerable<KeyValuePair<string, string>> GetConfigAsKeyValuePairsAndSetAsEnvironmentVariables(
            string? path = null)
        {
            path ??= "/Config";
            var root = Reuse.GetExecutingAssemblyLocationPath() + path;
            var secrets = new List<KeyValuePair<string, string>>();
            foreach (var secretFile in Directory.GetFiles(root, "*.*", SearchOption.AllDirectories))
            {
                var content = File.ReadAllText(secretFile);
                var name = Path.GetFileName(secretFile);
                secrets.Add(new KeyValuePair<string, string>(name, content));
                Environment.SetEnvironmentVariable(name, content);
            }

            return secrets;
        }
    }
}