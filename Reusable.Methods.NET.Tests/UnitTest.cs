using NUnit.Framework;

namespace Reusable.Methods.NET.Tests
{
    public class Tests
    {
        

        [Test]
        public void GetRuntimeEnvironmentGetRuntimeDirectoryTest()
        {
            var path = Extensions.GetRuntimeEnvironmentGetRuntimeDirectory();
            Assert.True(path.Contains("core", System.StringComparison.OrdinalIgnoreCase));
        }
    }
}