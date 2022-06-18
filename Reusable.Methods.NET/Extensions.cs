using System.Runtime.InteropServices;

namespace Reusable.Methods.NET
{
    public static partial class Extensions
    {

        public static string GetRuntimeEnvironmentGetRuntimeDirectory()
        {
            return RuntimeEnvironment.GetRuntimeDirectory();
        }

    }
}