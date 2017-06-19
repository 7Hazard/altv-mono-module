using SharpOrange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpExample
{
    public class SharpExample
    {
        public static API api;
        public SharpExample(API apip)
        {
            api = apip;
            api.Print("Hello from SharpExample!");
            
        }
    }
}
