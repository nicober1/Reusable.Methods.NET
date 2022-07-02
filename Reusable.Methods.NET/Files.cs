using System.Net;
using Bogus;

namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {
        public static void DeleteAllFilesInDirectory(this string directoryPath)
        {
            Array.ForEach(Directory.GetFiles(directoryPath),
                File.Delete);
        }

        public static string[] GetAllFilesInDirectory(this string directoryPath)
        {
           return  Directory.GetFiles(directoryPath);
        }


    }
}