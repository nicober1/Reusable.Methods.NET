using System.Collections;

namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {
        public static Task<IDictionary> GetEnvironmentVariablesAsDictionary()
        {
            return Task.FromResult(Environment.GetEnvironmentVariables());
        }

        public static bool IfVisualStudioIde()
        {
            var dict = Environment.GetEnvironmentVariables();
            return !string.IsNullOrEmpty((string?)dict["VisualStudioEdition"]);
        }

    }
}