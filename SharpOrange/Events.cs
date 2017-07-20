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
        public static event Action OnServerUnload = delegate { };
        static void TriggerOnServerUnload()
        {
            Task.Run(() => OnServerUnload());
        }

        public static event Action OnTick = delegate { };
        static void TriggerOnTick()
        {
            Task.Run(() => OnTick());
        }

        public delegate void OnServerCommandHandler(string command);
        public static event OnServerCommandHandler OnServerCommand = delegate { };
        static void TriggerOnServerCommand(string command)
        {
            Task.Run(() => OnServerCommand(command));
        }

        public delegate void OnPlayerConnectHandler(Player player);
        public static event OnPlayerConnectHandler OnPlayerConnect = delegate { };

        public delegate void OnPlayerDisconnectHandler(Player player, long reason);
        public static event OnPlayerDisconnectHandler OnPlayerDisconnect = delegate { };

        public delegate void OnPlayerDeathHandler(Player player, Player killer, long weapon);
        public static event OnPlayerDeathHandler OnPlayerDeath = delegate { };

        public delegate void OnPlayerRespawnHandler(Player player, Vector3 deathPosition);
        public static event OnPlayerRespawnHandler OnPlayerRespawn= delegate { };

        public delegate void OnPlayerEnterVehicleHandler(Player player, Vehicle vehicle);
        /// <summary>
        /// Called when a player enters a vehicle
        /// </summary>
        /// <param name="player"></param>
        /// <param name="vehicle"></param>
        public static event OnPlayerEnterVehicleHandler OnPlayerEnterVehicle = delegate { };

        public delegate void OnPlayerExitVehicleHandler(Player player, Vehicle vehicle);
        public static event OnPlayerExitVehicleHandler OnPlayerExitVehicle = delegate { };

        public delegate void PlayerUpdateHandler(Player player);
        public static event PlayerUpdateHandler OnPlayerUpdate = delegate { };
        static void TriggerOnPlayerUpdate(uint playerid)
        {
            Task.Run(() =>
            {
                Server.Players.TryGetValue(playerid, out Player player);
                OnPlayerUpdate(player);
            });
        }

        public delegate void OnKeyStateChangedHandler(Player player, int keycode, bool isUp);
        public static event OnKeyStateChangedHandler OnKeyStateChanged = delegate { };
        static void TriggerOnKeyStateChanged(uint playerid, int keycode, bool isUp)
        {
            Task.Run(() =>
            {
                Server.Players.TryGetValue(playerid, out Player player);
                OnKeyStateChanged(player, keycode, isUp);
            });
        }

        public delegate void OnEventHandler(string eventname, object[] args);
        public static event OnEventHandler OnEvent = delegate { };
        static void TriggerOnEvent(string e, object[] args)
        {
            Task.Run(() =>
            {
                switch (e)
                {
                    case "PlayerConnect":
                        {
                            Player player = new Player((uint)args[0]);
                            OnPlayerConnect(player);
                            return;
                        }
                    case "PlayerDisconnect":
                        {
                            Server.Players.TryGetValue((uint)args[0], out Player player);
                            OnPlayerDisconnect(player, (long)args[1]);
                            player.Dispose();
                            return;
                        }
                    case "PlayerDead":
                        {
                            uint playerid = (uint)args[0];
                            uint killerid = (uint)args[1];
                            Server.Players.TryGetValue(playerid, out Player player);
                            player.IsAlive = false;
                            if (playerid == killerid)
                            {
                                OnPlayerDeath(player, player, (long)args[2]);
                            }
                            else
                            {
                                Server.Players.TryGetValue(killerid, out Player killer);
                                OnPlayerDeath(player, killer, (long)args[2]);
                            }
                            return;
                        }
                    case "PlayerSpawn":
                        {
                            Server.Players.TryGetValue((uint)args[0], out Player player);
                            player.IsAlive = true;
                            OnPlayerRespawn(player, new Vector3((double)args[1], (double)args[2], (double)args[3]));
                            return;
                        }
                    case "EnterVehicle":
                        {
                            Server.Players.TryGetValue((uint)args[0], out Player player);
                            Server.Vehicles.TryGetValue((uint)args[1], out Vehicle vehicle);
                            player.Vehicle = vehicle;
                            OnPlayerEnterVehicle(player, vehicle);
                            return;
                        }
                    case "LeftVehicle":
                        {
                            Server.Players.TryGetValue((uint)args[0], out Player player);
                            Server.Vehicles.TryGetValue((uint)args[1], out Vehicle vehicle);
                            player.Vehicle = null;
                            OnPlayerExitVehicle(player, vehicle);
                            return;
                        }
                }
                /// DEBUG START
                try
                {
                    SharpOrange.Print($"Event '{e}' with args:\n");
                    string msg = "";
                    for (int i = 0; i < args.Length; i++)
                        msg += $"Index '{i}': {args[i]}\n";
                    Console.WriteLine(msg);

                }
                catch (Exception ex)
                {
                    SharpOrange.Print(ex.ToString());
                }
                /// DEBUG END
                OnEvent(e, args);
            });
        }
    }
}
