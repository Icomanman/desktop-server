
using SimpleHttp;
using System;
using System.Threading;

namespace server
{
    class Program
    {
        public static void Main(string[] args)
        {

            Route.Add("/api", (req, res, props) =>
            {
                res.AsText("pasok!");
                
                res.StatusCode = 200;
                Console.WriteLine("Opening a Staad Instance...");
                
                if (req != null)
                {
                    Console.WriteLine(req.Headers.ToString());
                }
                res.Close();
            }, "POST");

            HttpServer.ListenAsync(1630, CancellationToken.None, Route.OnHttpRequestAsync).Wait();

            Console.ReadKey();

        }
    }
}
