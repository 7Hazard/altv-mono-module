using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDotNET_Mono
{
    public class Program
    {
        static API API;
        static void Main(string[] args)
        {
            API.Set(API);
            API.Print("OrangeDotNET sucessfully loaded!");
        }
    }
}