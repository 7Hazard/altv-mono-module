#if !SM
using SharpOrange.Objects;
using SharpOrange.Math;
#endif
using System;
using System.Threading.Tasks;

namespace SharpOrange
{
    public class Event
    {
        /// <summary>
        /// Triggered before the server unloads/stops
        /// </summary>
        public static event Action OnServerUnload = delegate { };
        static void TriggerOnServerUnload()
        {
            Task.Run(() => SharpOrange.Exec(() => OnServerUnload()));
        }
        /// <summary>
        /// Triggered every server tick
        /// </summary>
        public static event Action OnTick = delegate { };
        static void TriggerOnTick()
        {
            Task.Run(() => SharpOrange.Exec(() => OnTick()));
        }

        public delegate void OnServerCommandHandler(string command);
        /// <summary>
        /// Triggered when command has been input on server console
        /// </summary>
        public static event OnServerCommandHandler OnServerCommand = delegate { };
#if !SM
        public delegate void OnPlayerConnectHandler(Player player);
        /// <summary>
        /// Triggered when player connects
        /// </summary>
        public static event OnPlayerConnectHandler OnPlayerConnect = delegate { };

        public delegate void OnPlayerDisconnectHandler(Player player, DisconnectReason reason);
        /// <summary>
        /// Triggered when player disconnects
        /// </summary>
        public static event OnPlayerDisconnectHandler OnPlayerDisconnect = delegate { };

        public delegate void OnPlayerDeathHandler(Player player, Player killer, long weapon);
        /// <summary>
        /// Triggered right before the black screen is supposed to go away
        /// Basically when a player respawn is requested
        /// </summary>
        public static event OnPlayerDeathHandler OnPlayerDeath = delegate { };

        public delegate void OnPlayerRespawnHandler(Player player);
        public static event OnPlayerRespawnHandler OnPlayerRespawn = delegate { };

        public delegate void OnPlayerEnterVehicleHandler(Player player, Vehicle vehicle);
        /// <summary>
        /// Triggered when a player enters a vehicle
        /// </summary>
        /// <param name="player"></param>
        /// <param name="vehicle"></param>
        public static event OnPlayerEnterVehicleHandler OnPlayerEnterVehicle = delegate { };

        public delegate void OnPlayerExitVehicleHandler(Player player, Vehicle vehicle);
        /// <summary>
        /// Triggered when a player exits the vehicle
        /// </summary>
        public static event OnPlayerExitVehicleHandler OnPlayerExitVehicle = delegate { };

        public delegate void PlayerUpdateHandler(Player player);
        /// <summary>
        /// Triggered when a player has been updated
        /// </summary>
        public static event PlayerUpdateHandler OnPlayerUpdate = delegate { };

        public delegate void OnClientEventHandler(Player player, string eventname, object[] args);
        /// <summary>
        /// Triggered when a client event is passed
        /// </summary>
        public static event OnClientEventHandler OnClientEvent = delegate { };
#endif
        public delegate void OnEventHandler(string eventname, object[] args);
        /// <summary>
        /// Triggered whenever any other client and server event is passed
        /// </summary>
        public static event OnEventHandler OnEvent = delegate { };
        static void TriggerOnEvent(string e, object[] args)
        {
#if !SM
            Task.Run(() => SharpOrange.SM.TriggerOnEvent(e, args));
#endif
            Task.Run(() =>
            {
                switch (e)
                {
                    case "ServerCommand":
                        {
                            SharpOrange.Exec(() => OnServerCommand((string)args[0]));
                            return;
                        }
#if !SM
                    case "ServerEvent":
                        {
                            SharpOrange.Exec(() =>
                            {
                                Player player;
                                Server.players.TryGetValue((uint)args[1], out player);
                                int arglen = args.Length;
                                object[] cliargs = new object[arglen - 2];
                                for (int i = 2; i < arglen; i++)
                                {
                                    cliargs[i - 2] = args[i];
                                }
                                OnClientEvent(player, (string)args[0], cliargs);
                            });
                            return;
                        }
                    case "PlayerConnect":
                        {
                            SharpOrange.Exec(() =>
                            {
                                Player player = new Player((uint)args[0], (string)args[1]);
                                OnPlayerConnect(player);
                            });
                            return;
                        }
                    case "PlayerDisconnect":
                        {
                            SharpOrange.Exec(() =>
                            {
                                Player player;
                                Server.Players.TryGetValue((uint)args[0], out player);
                                OnPlayerDisconnect(player, (DisconnectReason)(Int64)args[1]);
                                player.Dispose();
                            });
                            return;
                        }
                    case "PlayerUpdate":
                        {
                            SharpOrange.Exec(() =>
                            {
                                Player player;
                                Server.Players.TryGetValue((uint)args[0], out player);
                                OnPlayerUpdate(player);
                            });
                            return;
                        }
                    case "PlayerDead":
                        {
                            SharpOrange.Exec(() =>
                            {
                                uint playerid = (uint)args[0];
                                uint killerid = (uint)args[1];
                                Player player;
                                Server.Players.TryGetValue(playerid, out player);
                                player.IsAlive = false;
                                player.DeathPosition = new Vector3(player.Position);
                                if (playerid == killerid)
                                {
                                    OnPlayerDeath(player, player, (long)args[2]);
                                }
                                else
                                {
                                    Player killer;
                                    Server.Players.TryGetValue(killerid, out killer);
                                    OnPlayerDeath(player, killer, (long)args[2]);
                                }
                            });
                            return;
                        }
                    case "PlayerSpawn":
                        {
                            SharpOrange.Exec(() =>
                            {
                                Player player;
                                Server.Players.TryGetValue((uint)args[0], out player);
                                player.IsAlive = true;
                                OnPlayerRespawn(player);
                            });
                            return;
                        }
                    case "EnterVehicle":
                        {
                            SharpOrange.Exec(() =>
                            {
                                Player player;
                                Server.Players.TryGetValue((uint)args[0], out player);
                                Vehicle vehicle;
                                Server.Vehicles.TryGetValue((uint)args[1], out vehicle);
                                player.Vehicle = vehicle;
                                OnPlayerEnterVehicle(player, vehicle);
                            });
                            return;
                        }
                    case "LeftVehicle":
                        {
                            SharpOrange.Exec(() =>
                            {
                                Player player;
                                Server.Players.TryGetValue((uint)args[0], out player);
                                Vehicle vehicle;
                                Server.Vehicles.TryGetValue((uint)args[1], out vehicle);
                                player.Vehicle = null;
                                OnPlayerExitVehicle(player, vehicle);
                            });
                            return;
                        }
#endif
                }
                SharpOrange.Exec(() => OnEvent(e, args));
            });

        }
    }
}
