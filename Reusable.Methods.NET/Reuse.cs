using Bogus;

namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {
        public static Action<string> LoggerMethod { get; set; }

        public static string ProjectPath { get; set; }

        static Reuse()
        {
            LoggerMethod = Console.WriteLine;
            ProjectPath = ".";
        }

        public static void LogToConsole(this string message)
        {
            LoggerMethod.Invoke(message);
        }

        public static void LogToConsole(this object obj)
        {
            if (obj != null)
            {
                LoggerMethod.Invoke(obj.ToString());
            }
            else
            {
                LoggerMethod.Invoke("(null)");
            }
        }

        public static void Log()
        {
            "".LogToConsole();
        }

       

    }
}