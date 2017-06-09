using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static API API = null;
        static void Main(string[] args)
        {

        }

        public static void Init(ref API apipoint)
        {
            API.Set(apipoint);
            API = API.Get();
            API.Print("Successfully initialized API for OrangeDotNET!");
        }
    }
}
