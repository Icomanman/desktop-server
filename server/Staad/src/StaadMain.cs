using OpenSTAADUI;
using System;
using System.Runtime.InteropServices;

namespace server.Staad.src
{
	class StaadMain
	{
		public static void Connect()
		{
			object PID = 0;
			object OSt = null;
			try
			{
				Type OStType = Type.GetTypeFromProgID("StaadPro.OpenSTAAD");
				// string clsid = OStType.GUID.ToString();
				// Console.WriteLine("This is the id: " + clsid);
				PID = 1;

				OSt = Marshal.GetActiveObject("StaadPro.OpenSTAAD");
				if (OSt != null)
				{

					// PID = OSt.GetProcessId();
					Console.WriteLine("ID: " + PID);
					
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				// throw;
			}
			
			return;
		}

	}
}
