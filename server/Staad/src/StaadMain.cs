
using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices;

using OpenSTAADUI;

namespace server.Staad.src
{
    class StaadMain
    {
        public static OpenSTAAD Connect()
        {
            OpenSTAAD OSt = null;
            int count = 0;

            try
            {
                Type ostType = Type.GetTypeFromProgID("StaadPro.OpenSTAAD");
                string clsid = ostType.GUID.ToString();
                string targetName = String.Format("!{0}{1}{2}", "{", clsid, "}").ToUpper();

                List<Helpers.RunningObjectInfo> runningObj = Helpers.GetRunningObjectsList();

                foreach (Helpers.RunningObjectInfo item in runningObj)
                {
                    string candidateName = item.Name.ToUpper();

                    if (candidateName.StartsWith(targetName))
                    {
                        OSt = item.Value as OpenSTAAD;
                        OpenSTAAD weh = item.Value as OpenSTAAD;
                        count++;
                    }
                }

                if (OSt == null)
                {
                    Hashtable objTab = Helpers.GetRunningObjHash();
                    IDictionaryEnumerator rotEnum = objTab.GetEnumerator();

                    while (rotEnum.MoveNext())
                    {
                        string candidateName = ((string)rotEnum.Key).ToUpper();
                        // OSt = Marshal.BindToMoniker(candidateName) as OpenSTAAD;
                    }
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("> StaadMain.cs: " + ex.ToString().Substring(0, 34));
            }

            // return (count > 1);
            return OSt;
        }


        public static void OpenApp()
        {

            string path = @"C:\Users\GiulianoDiEnrico\Documents\010 Swan House\Outgoing\B Calcs\STAAD Models\SH - 011.std";
            var staadHandler = new OpenSTAADClass();

            staadHandler.OpenSTAADFile(path);

        }
    }
}
