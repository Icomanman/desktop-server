using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace server.Staad.src
{
    class Helpers
    {
        [DllImport("ole32.dll")]
        private static extern int GetRunningObjectsTable(
            int reserved,
            out IRunningObjectTable prot
            );

        [DllImport("ole32.dll")]
        private static extern int CreateBindCtx(
            int reserved,
            out IBindCtx ppbc
            );
        public class RunningObjectInfo
        {
            public string Name
            {
                get;
                set;
            }

            public object Value
            {
                get;
                set;
            }
        }

        public static List<RunningObjectInfo> GetRunningObjectsList()
        {
            try
            {
                List<RunningObjectInfo> result = new List<RunningObjectInfo>();

                IntPtr numFetched = new IntPtr();
                IRunningObjectTable runningObjectTable;
                IEnumMoniker monikerEnum;
                IMoniker[] monikers = new IMoniker[1];

                GetRunningObjectsTable(0, out runningObjectTable);

                runningObjectTable.EnumRunning(out monikerEnum);
                monikerEnum.Reset();

                while (monikerEnum.Next(1, monikers, numFetched) == 0)
                {
                    IBindCtx ctx;
                    CreateBindCtx(0, out ctx);

                    string runningObjName;
                    monikers[0].GetDisplayName(ctx, null, out runningObjName);

                    object runningObjVal;
                    runningObjectTable.GetObject(monikers[0], out runningObjVal);

                    RunningObjectInfo objInfo = new RunningObjectInfo
                    {
                        Name = runningObjName,
                        Value = runningObjVal
                    };

                    result.Add(objInfo);
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("> Helpers.cs: " + ex.ToString().Substring(0, 116));
                throw;
            }
        }

    }
}
