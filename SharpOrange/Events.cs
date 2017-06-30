using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpOrange
{
    public class Event
    {
        public static event Action OnTick = delegate { };
        static void Tick()
        {
            OnTick();
        }

        public delegate void ServerCommandHandler(string command);
        public static event ServerCommandHandler OnServerCommand = delegate { };
        static void ServerCommand(string command)
        {
            OnServerCommand(command);
        }

        public delegate void PlayerConnectedHandler(int playerid);
        public static event PlayerConnectedHandler OnPlayerConnect = delegate { };
        static void PlayerConnected(int playerid)
        {
            OnPlayerConnect(playerid);
        }

        public delegate void PlayerDisconnectedHandler(int playerid, int reason);
        public static event PlayerDisconnectedHandler OnPlayerDisconnected = delegate { };
        static void PlayerDisconnected(int playerid, int reason)
        {
            OnPlayerDisconnected(playerid, reason);
        }

        public delegate void PlayerUpdatedHandler(int playerid);
        public static event PlayerUpdatedHandler OnPlayerUpdated = delegate { };
        static void PlayerUpdated(int playerid)
        {
            OnPlayerUpdated(playerid);
        }

        public delegate void KeyStateChangedHandler(int playerid, int keycode, bool isUp);
        public static event KeyStateChangedHandler OnKeyStateChanged = delegate { };
        static void KeyStateChanged(int playerid, int keycode, bool isUp)
        {
            OnKeyStateChanged(playerid, keycode, isUp);
        }

        public delegate void EventHandler(string eventname, object[] args);
        public static event EventHandler OnEvent = delegate { };
        static void EEvent(string eventname, object[] args)
        {
            OnEvent(eventname, args);
        }
    }
}
