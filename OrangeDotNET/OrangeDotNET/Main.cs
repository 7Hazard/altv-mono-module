using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDotNET
{
    class Main
    {
        public static API API = null;
        unsafe Main(void* cPtr)
        {
            API API = new API((IntPtr)cPtr, false);
            API.Print("Successfully initialized API for OrangeDotNET!");
        }
    }
}
