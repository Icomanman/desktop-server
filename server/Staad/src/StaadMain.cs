using OpenSTAADUI;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

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
				// OSt = Marshal.GetActiveObject("StaadPro.OpenSTAAD");
				OSt = Marshal.BindToMoniker("EXAMP11.STD");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString().Substring(0, 43));
			}

			if (OSt != null)
			{
				OpenSTAAD OpStd = OSt as OpenSTAAD;
				if (OpStd != null)
				{
					PID = OpStd.GetProcessId();
				}
				Console.WriteLine("ID: " + PID);
			}
			else
			{
				Console.WriteLine("No instance of STAAD was found.");
			}
			return;
		}

	}
}
