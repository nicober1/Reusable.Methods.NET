namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {

        public static string GetRuntimeEnvironmentGetRuntimeDirectory()
        {
            return RuntimeEnvironment.GetRuntimeDirectory();
        }

        public static string? GetEntryAssemblyLocationPath()
        {
            return Assembly.GetEntryAssembly()?.Location;
        }

        public static string? GetExecutingAssemblyLocationPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

    }

    
}