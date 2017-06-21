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
        static API api;
        public SharpExample(API apip)
        {
            api = apip;
            api.Print("SharpExample started!");

            Event.OnTick += MyTicks; // Haha goteem
            Event.OnPlayerConnect += MyPlayerConnect;
            Event.OnServerCommand += MyServerCommand;
        }

        void MyTicks()
        {
            api.Print("Ticking..."); // Will litterally print "Ticking..." every tick...
        }

        void MyPlayerConnect(int playerid)
        {
            api.Print(playerid+" connected!");
            api.SetPlayerPosition(playerid, 1000, 200, 500);
        }

        void MyServerCommand(string command)
        {
            api.Print("Command '"+command+"' was input");
        }
    }
}
