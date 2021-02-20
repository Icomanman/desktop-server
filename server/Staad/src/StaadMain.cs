using OpenSTAADUI;
using System;

namespace server.Staad.src
{
	class StaadMain
	{
		public static void Tak()
		{
			OpenSTAAD OSt = null;
			try
			{
				Type staadType = Type.GetTypeFromProgID("StaadPro.OpenSTAAD");
				Console.WriteLine(staadType);
			}
			catch
			{

			}

		}

	}
}
