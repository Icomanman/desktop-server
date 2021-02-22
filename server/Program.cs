using server.Staad.src;
using server.Robot.src;
using SimpleHttp;
using System;
using System.Threading;
using OpenSTAADUI;

namespace server
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            //Route.Add("/", (req, res, props) =>
            //{
            //	res.AsText("pasok!");
            //});

            //HttpServer.ListenAsync(
            //	1630,
            //	CancellationToken.None,
            //	Route.OnHttpRequestAsync
            //	).Wait();
            bool isStaadRunning = false;

            isStaadRunning = StaadMain.Connect();

            if(isStaadRunning == false)
            {
                Console.WriteLine("No instance of Staad was found.");
            }

            Console.ReadKey();

        }
    }
}
