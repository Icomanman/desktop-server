using server.Staad.src;
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

			StaadMain.Tak();
			Console.ReadKey();
		}
	}
}
