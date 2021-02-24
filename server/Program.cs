using server.Staad.src;
using server.Robot.src;
using SimpleHttp;
using System;
using System.Threading;
using OpenSTAADUI;
using VBConsole;

namespace server
{
    class Program
    {
        public static void Main(string[] args)
        {
            OpenSTAADClass OSt = null;
            string path = @"C:\Users\GiulianoDiEnrico\Documents\010 Swan House\Outgoing\B Calcs\STAAD Models\SH-011.std";

            Route.Add("/", (req, res, props) =>
            {
                res.AsText("pasok!");
                Console.WriteLine("Opening a Staad Instance...");
                // Module1.Main();
                OSt = Module1.GetStaad(path, true) as OpenSTAADClass;
                Console.WriteLine(OSt);
            });

            Route.Add("/close", (req, res, props) =>
            {
                res.AsText("closing...");
                Console.WriteLine("Closing Staad Instance...");
                if(OSt != null)
                {
                    OSt.Quit();
                }
                else
                {
                    Console.WriteLine("null");
                    Module1.GetStaad(path, false);
                }
                
            });

            HttpServer.ListenAsync(
                1630,
                CancellationToken.None,
                Route.OnHttpRequestAsync
                ).Wait();

            // OSt = StaadMain.Connect();

            if (OSt == null)
            {
                Console.WriteLine("No instance of Staad was found.");
            }

            // StaadMain.OpenApp();

            Console.ReadKey();

        }
    }
}
