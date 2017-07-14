using SharpOrange.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharpOrange
{
    public static class Event
    {
        public static event Action OnTick = delegate { };
        static void TriggerOnTick()
        {
            //new Thread(new ThreadStart(OnTick)).Start();
            OnTick();
        }

        public delegate void OnServerCommandHandler(string command);
        public static event OnServerCommandHandler OnServerCommand = delegate { };
        static void TriggerOnServerCommand(string command)
        {
            OnServerCommand(command);
        }

        public delegate void OnPlayerConnectHandler(Player player);
        public static event OnPlayerConnectHandler OnPlayerConnect = delegate { };

        public delegate void OnPlayerDisconnectedHandler(Player player, int reason);
        public static event OnPlayerDisconnectedHandler OnPlayerDisconnected = delegate { };
        static void TriggerOnPlayerDisconnect(uint playerid, int reason)
        {
            Server.Players.TryGetValue(playerid, out Player player);
            OnPlayerDisconnected(player, reason);
        }

        public delegate void PlayerUpdateHandler(Player player);
        public static event PlayerUpdateHandler OnPlayerUpdate = delegate { };
        static void TriggerOnPlayerUpdate(uint playerid)
        {
            Server.Players.TryGetValue(playerid, out Player player);
            OnPlayerUpdate(player);
        }

        public delegate void OnKeyStateChangedHandler(Player player, int keycode, bool isUp);
        public static event OnKeyStateChangedHandler OnKeyStateChanged = delegate { };
        static void TriggerOnKeyStateChanged(uint playerid, int keycode, bool isUp)
        {
            Server.Players.TryGetValue(playerid, out Player player);
            OnKeyStateChanged(player, keycode, isUp);
        }

        public delegate void OnEventHandler(string eventname, object[] args);
        public static event OnEventHandler OnEvent = delegate { };
        static void TriggerOnEvent(string e, object[] args)
        {
            new Thread(new ThreadStart(task)).Start();
            void task() {
                if (e == "PlayerConnect")
                {
                    uint playerid = (UInt32)args[0];
                    Player player = new Player(playerid);
                    Server.Players.Add(playerid, player);
                    OnPlayerConnect(player);
                    return;
                }
                OnEvent(e, args);
            }
        }
    }
}
