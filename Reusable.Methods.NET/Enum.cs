using Bogus;

namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {
        public static class EnumConverter
        {
            public static string[] ToStringArray<T>()
            {
                return Enum.GetNames(typeof(T)).ToArray();
            }

            public static Array ToValueArray<T>()
            {
                return Enum.GetValues(typeof(T));
            }

            public static List<T> ToListOfValues<T>()
            {
                return Enum.GetValues(typeof(T)).Cast<T>().ToList();
            }

            public static IEnumerable<T> ToEnumerable<T>()
            {
                return (T[])Enum.GetValues(typeof(T));
            }
        }
    }
}