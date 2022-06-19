using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Reusable.Methods.NET.Tests
{
    public class Tests
    {
        

        [Test]
        public void GetRuntimeEnvironmentGetRuntimeDirectoryTest()
        {
            var path = Reuse.GetRuntimeEnvironmentGetRuntimeDirectory();
            Console.WriteLine(path);
            Assert.True(path.Contains("core", StringComparison.OrdinalIgnoreCase));
        }

        [Test]
        public void GetEnvironmentVariablesAsDictionaryTest()
        {
            var dict = Reuse.GetEnvironmentVariablesAsDictionary().GetAwaiter().GetResult();
            
            foreach (var i in dict.Cast<DictionaryEntry>().Where(i => i.Key.ToString()!.ToLower().StartsWith('v')))
            {
                Console.WriteLine("{0} -> {1}", i.Key, i.Value);
            }

            foreach (var i in dict.Cast<DictionaryEntry>())
            {
                Console.WriteLine("{0} -> {1}", i.Key, i.Value);
            }
        }

        [Test]
        public void IfVisualStudioIdeTest()
        {
            var dict = Reuse.IfVisualStudioIde();

            switch (dict)
            {
                case true:
                    Assert.True(dict);
                    break;
                default:
                    Console.WriteLine("Not Visual Studio IDE");
                    break;
            }
        }
    }
}