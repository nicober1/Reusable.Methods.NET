using System.Net;
using Bogus;

namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {
        public static string GetHostNameUsingDns()
        {
            return Dns.GetHostName();
        } 
        
        public static IPAddress[] GetHostAddressesUsingDns()
        {
            return Dns.GetHostAddresses(Dns.GetHostName());
        }
    }
}