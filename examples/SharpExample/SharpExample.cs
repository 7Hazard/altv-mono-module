using SharpOrange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharpExample
{
    public class SharpExample
    {
        static API api;
        public SharpExample(API apip)
        {
            api = apip;
            api.Print("SharpExample started");

            Event.OnTick += MyTicks; // Haha goteem
            Event.OnPlayerConnect += MyPlayerConnects;
            Event.OnServerCommand += MyServerCommands;
            Event.OnEvent += MyEvents;

            //Client.AddScript("client.lua");
        }

        void MyTicks()
        {
            //api.Print("Ticking..."); // Will litterally print "Ticking..." every tick...
        }

        void MyPlayerConnects(int playerid)
        {
            api.SetPlayerPosition(playerid, 1000, 200, 80);
            api.CreateVehicle(Vehicle.Miljet, 1000, 210, 90, 1);
            api.GivePlayerWeapon(playerid, Weapon.AssaultRifle, 100);
            api.CreatePickup(Pickup.ParachuteBag, 1000, 190, 80, 1);
        }

        void MyServerCommands(string command)
        {
            api.Print("Command '"+command+"' was input");
        }

        void MyEvents(string e, object[] args)
        {
            switch(e)
            {
                case "TestEvent":
                    api.Print("'TestEvent' was triggered with data ");
                    foreach (object arg in args)
                        api.Print("'" + arg + "'");
                    break;
            }
        }
    }
}
