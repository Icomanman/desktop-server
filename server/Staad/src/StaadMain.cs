
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Reflection;

using OpenSTAADUI;

namespace server.Staad.src
{
    class StaadMain
    {
        public static bool Connect()
        {
            object PID = 0;
            object OSt = null;
            int count = 0;

            try
            {
                Type ostType = Type.GetTypeFromProgID("StaadPro.OpenSTAAD");
                string clsid = ostType.GUID.ToString();
                string targetName = String.Format("!{0}{1}{2}", "{", clsid, "}");

                Hashtable addedFileNames = new Hashtable();
                List<Helpers.RunningObjectInfo> runningObj = Helpers.GetRunningObjectsList();

                foreach (Helpers.RunningObjectInfo item in runningObj)
                {
                    string candidateName = item.Name.ToUpper();
                    if (candidateName.StartsWith(targetName))
                    {
                        count++;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("> StaadMain.cs: " + ex.ToString().Substring(0, 34));
            }

            return (count > 1);
        }

    }
}
