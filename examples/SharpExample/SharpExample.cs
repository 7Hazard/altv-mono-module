using SharpOrange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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

            TestMySQL();
        }

        void MyTicks()
        {
            //api.Print("Ticking..."); // Will litterally print "Ticking..." every tick...
        }

        void MyPlayerConnects(int playerid)
        {
            api.Print("Ayy, "+api.GetPlayerName(playerid)+" is tryin' to get in!");
            api.SetPlayerPosition(playerid, 1000, 200, 80);
            api.CreateVehicle(Vehicle.Miljet, 1000, 210, 90, 1);
            api.GivePlayerWeapon(playerid, Weapon.AssaultRifle, 100);
            api.CreatePickup(Pickup.ParachuteBag, 1000, 190, 80, 1);

            /*api.CreateVehicle((Vehicle)165154707, 1000, 210, 90, 1);
            api.GivePlayerWeapon(playerid, (Weapon)(-1074790547), 100);
            api.CreatePickup((Pickup)1735599485, 1000, 190, 80, 1);*/
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

        MySqlConnection conn;
        void TestMySQL()
        {
            conn = new MySqlConnection("Server=leizaki.com;Uid=gtaorange;Pwd=jizzle;Database=gtaorange;");
            try
            {
                conn.Open();
                api.Print("OPEN");
                conn.Close();
            }
            catch (MySqlException ex)
            {
                api.Print("Not Open\n" + ex);
            }
        }
    }
}
