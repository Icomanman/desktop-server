using System;
using SimpleHttp;
using System.Threading;
namespace server
{
  class Program
  {
    static void Main(string[] args)
    {
			Route.Add("/", (req, res, props) =>
			{
				res.AsText("Pasok!");
			});


			HttpServer.ListenAsync(
				1630, 
				CancellationToken.None,
				Route.OnHttpRequestAsync
				).Wait();
    }
  }
}
