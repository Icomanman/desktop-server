
using SimpleHttp;
using System;
using System.Threading;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Json;

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
                    string content_type = req.ContentType;

                    string s = reader.ReadToEnd();
                    Console.WriteLine("Content Type: {0}", content_type);
                    Console.WriteLine("Path: {0}", s);


                if (content_type == "application/json" || content_type.Contains("text"))
                    {
                        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        Console.WriteLine("> ...writing the requested file in {0}.", desktop);
                        StreamWriter file = File.CreateText(desktop + "\\request.txt");
                        file.WriteLine(s);
                        file.Close();
                    }

                    body.Close();
                    reader.Close();
                }

                res.AsText("pasok!");
                res.StatusCode = 200;
                res.Close();
            }, "POST");

            Route.Add("/api", (req, res, props) =>
            {
                res.AsText("GET request was successful.");
                res.StatusCode = 200;
                res.Close();
            });

            HttpServer.ListenAsync(1630, CancellationToken.None, Route.OnHttpRequestAsync).Wait();

            Console.ReadKey();

        }
    }
}
