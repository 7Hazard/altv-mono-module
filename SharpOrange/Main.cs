using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpOrange
{
    public class SharpOrange
    {
        public static API API = null;
        SharpOrange(ref IntPtr apiptr)
        {
            API = API.__CreateInstance(apiptr);
            API.Print("[SharpOrange] Module successfully initialized!");
        }

        void LoadResource(String resource)
        {
            API.Print("Attempting to load resource "+resource);
        }
    }
}
