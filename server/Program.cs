
using SimpleHttp;
using System;
using System.Threading;
using System.IO;
using System.Text;

namespace server
{
    class Program
    {
        public static void Main(string[] args)
        {

            Route.Add("/api", (req, res, props) =>
            {
                if (req != null)
                {
                    Stream body = req.InputStream;
                    Encoding encoding = req.ContentEncoding;
                    StreamReader reader = new StreamReader(body, encoding);

                    Console.WriteLine("Content Type: {0}", req.ContentType);

                    string s = reader.ReadToEnd();
                    Console.WriteLine("Path: {0}", s);

                    body.Close();
                    reader.Close();
                }

                res.AsText("pasok!");
                res.StatusCode = 200;
                res.Close();
            }, "POST");

            Route.Add("/api", (req, res, props) =>
            {
                res.AsText("pasok!");
                res.StatusCode = 200;
                res.Close();
            });

            HttpServer.ListenAsync(1630, CancellationToken.None, Route.OnHttpRequestAsync).Wait();

            Console.ReadKey();

        }
    }
}
