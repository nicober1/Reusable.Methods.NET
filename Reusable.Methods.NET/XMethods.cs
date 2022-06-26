using Bogus;

namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {
        public static int GetRandomNumberWithinMaxValueInputUsingBogus(this int max)
        {
            return new Faker().Random.Number(new Faker().Random.Number(max));
        }
    }
}