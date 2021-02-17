using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace server
{
	public class HTTPServer
	{

		private bool isRunning = false;

		private TcpListener listener;

		public HTTPServer(int port)
		{
			listener = new TcpListener(IPAddress.Any, port);
		}

		public void Start()
		{
			Thread serverThread = new Thread(new ThreadStart(Run));
		}

		private void Run()
		{
			isRunning = true;

			while (isRunning)
			{
				TcpClient client = listener.AcceptTcpClient();

				HandleClient(client);
				client.Close();
			}

			isRunning = false;
			listener.Stop();
		}

		private void HandleClient(TcpClient client)
		{

		}
	}
}
