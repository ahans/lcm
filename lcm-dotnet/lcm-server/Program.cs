using System;
using System.Net;
using LCM.LCM;

namespace LCM.Server
{
    /// <summary>
    /// Simple TCP provider server implementation
    /// </summary>
    class Server
    {
        public static void Main(string[] args)
        {
            try
            {
                int port = 7700;
                IPAddress address = IPAddress.Any;
                if ((args.Length > 0 && (args[0] == "-help" || args[0] == "--help" || args[0] == "/h")) || args.Length > 2)
                {
                    Console.Error.WriteLine("Usage: lcm-server.exe [ [address to bind to] port ]");
                    Console.Error.WriteLine("  defaults: any address, port " + port);
                    Console.Error.WriteLine("  examples:");
                    Console.Error.WriteLine("  `lcm-server.exe 1234' binds to all interfaces/addresses on port 1234");
                    Console.Error.WriteLine("  `lcm-server.exe localhost 1234' binds to localhost on port 1234");
                    return;
                }
                else if (args.Length == 1)
                {
                    port = Int32.Parse(args[0]);
                }
                else if (args.Length == 2)
                {
                    address = System.Net.Dns.GetHostAddresses(args[0])[0];
                    port = Int32.Parse(args[1]);
                }

                Console.Out.WriteLine("creating TCPService for " + address.ToString() + ":" + port);
                new TCPService(address, port);
            }
            catch (System.IO.IOException ex)
            {
                Console.Error.WriteLine("Ex: " + ex);
            }
        }
    }
}
