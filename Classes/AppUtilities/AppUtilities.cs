using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Runtime.InteropServices;

using System.Security.Policy;

namespace CryptoTrader.Classes
{
    public class AppUtilities
    {
        const int MAX_PATH = 255;

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName( [MarshalAs(UnmanagedType.LPTStr)] string path, [MarshalAs(UnmanagedType.LPTStr)]  StringBuilder shortPath, int shortPathLength);

        //==========================================================================================================================================================================================

        public static string GetShortPath(string path)
        {
            var shortPath = new StringBuilder(MAX_PATH);
            GetShortPathName(path, shortPath, MAX_PATH);
            return shortPath.ToString();
        }
        //==========================================================================================================================================================================================
        public string GetMotherBoardID()
        {
            string MotherBoardID = "";
            var managementObjectSearcher = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
            foreach (var managementObject in managementObjectSearcher.Get())
            {
                MotherBoardID= managementObject["SerialNumber"].ToString();
            }

            return MotherBoardID;
        }
//======================================================================================================================================================



    }
}
