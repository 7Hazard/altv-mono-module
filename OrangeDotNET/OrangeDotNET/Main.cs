using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDotNET
{
    public class Main
    {
        API API = API.Get();
        Main()
        {
            API.Print("OrangeDotNET succesfully initialized!");
        }
    }
}
