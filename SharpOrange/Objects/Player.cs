using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpOrange.Objects
{
    public class Player
    {
        internal Player(long playerid)
        {
            ID = playerid;
            //Name = Server.GetPlayerName(playerid);
            //Position = Server.GetPlayerPosition(playerid);
        }

        public long ID { get; }
        public string Name
        {
            get
            {
                return Server.GetPlayerName(ID);
            }
            set
            {
                Server.SetPlayerName(ID, value);
            }
        }
        public Vector3 Position
        {
            get
            {
                return Server.GetPlayerPosition(ID);
            }
            set
            {
                Server.SetPlayerPosition(ID, value.x, value.y, value.z);
            }
        }
    }
}
