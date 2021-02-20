using server.Staad.src;
using server.Robot.src;
using SimpleHttp;
using System;
using System.Threading;

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

            //StaadMain.Tak();
            StaadMain.Quit();
            Console.ReadKey();

            //RobotMain.Bot();

        }
	}
}
