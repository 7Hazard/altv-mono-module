using SharpOrange.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpOrange
{
    public class Server
    {
        // Server/Console
        public static Dictionary<string, object> LoadedResources = new Dictionary<string, object>();

        [DllImport("mono-module", EntryPoint = "Print", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Print(string text);

        [DllImport("mono-module", EntryPoint = "Hash", CallingConvention = CallingConvention.Cdecl)]
        public static extern long Hash(string text);

        [DllImport("mono-module", EntryPoint = "Shutdown", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Shutdown();
        
        public unsafe static void TriggerEvent(string name, object[] args)
        {
            Task.Run(() =>
            {
                int len = args.Length;
                EValue[] values = new EValue[len];
                for (int i = 0; i < len; i++)
                {
                    values[i] = new EValue(args[i]);
                }
                fixed (EValue* mvalues = &values[0])
                    API.ServerEvent(name, values, len);
                for (int i = 0; i < len; i++)
                {
                    if (values[i].type == EType.M_STRING)
                        Marshal.FreeCoTaskMem(values[i].value._string);
                }
            });
        }

        // Players
        public static Dictionary<long, Player> Players;

        public static void KickPlayer(Player player)
        {
            KickPlayer(player.ID);
        }

        public static void KickPlayer(Player player, string reason)
        {
            KickPlayer(player.ID, reason);
        }

        [DllImport("mono-module", EntryPoint = "KickPlayer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void KickPlayer(long playerid);

        [DllImport("mono-module", EntryPoint = "KickPlayer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void KickPlayer(long playerid, string reason);

        public static string GetPlayerName(long playerid)
        {
            StringBuilder sb = new StringBuilder();
            API.GetPlayerName(playerid, sb);
            return sb.ToString();
        }

        [DllImport("mono-module", EntryPoint = "SetPlayerName", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPlayerName(long playerid, string name);

        [DllImport("mono-module", EntryPoint = "SetPlayerPosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPlayerPosition(long playerid, float x, float y, float z);

        [DllImport("mono-module", EntryPoint = "GetPlayerPosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 GetPlayerPosition(long playerid);

        [DllImport("mono-module", EntryPoint = "SetPlayerModel", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetPlayerModel(long playerid, long model);

        [DllImport("mono-module", EntryPoint = "GetPlayerModel", CallingConvention = CallingConvention.Cdecl)]
        public static extern long GetPlayerModel(long playerid);

        [DllImport("mono-module", EntryPoint = "RemovePlayerWeapons", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool RemovePlayerWeapons(long playerid);

        [DllImport("mono-module", EntryPoint = "GivePlayerWeapon", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GivePlayerWeapon(long playerid, long weapon, long ammo);

        [DllImport("mono-module", EntryPoint = "GivePlayerAmmo", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GivePlayerAmmo(long playerid, long weapon, long ammo);

        // Vehicles
        public static Dictionary<ulong, Vehicle> Vehicles;

        [DllImport("mono-module", EntryPoint = "CreateVehicle", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong CreateVehicle(VehicleHash vehicle, float x, float y, float z);

        [DllImport("mono-module", EntryPoint = "DeleteVehicle", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool DeleteVehicle(ulong vehicleid);

        [DllImport("mono-module", EntryPoint = "SetVehiclePosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehiclePosition(ulong vehicleid, float x, float y, float z);

        [DllImport("mono-module", EntryPoint = "GetVehiclePosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 GetVehiclePosition(ulong vehicleid);

        [DllImport("mono-module", EntryPoint = "SetVehicleRotation", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleRotation(ulong vehicleid, float rx, float ry, float rz);

        [DllImport("mono-module", EntryPoint = "GetVehicleRotation", CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 GetVehicleRotation(ulong vehicleid);
        
        [DllImport("mono-module", EntryPoint = "SetVehiclePrimaryColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehiclePrimaryColor(ulong vehicleid, byte r, byte g, byte b);
        
        [DllImport("mono-module", EntryPoint = "GetVehiclePrimaryColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern RGB GetVehiclePrimaryColor(ulong vehicleid);
        [DllImport("mono-module", EntryPoint = "SetVehicleSecondaryColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleSecondaryColor(ulong vehicleid, byte r, byte g, byte b);
        
        [DllImport("mono-module", EntryPoint = "GetVehiclePrimaryColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern RGB GetVehicleSecondaryColor(ulong vehicleid);

        [DllImport("mono-module", EntryPoint = "SetVehicleEngineStatus", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleEngineStatus(ulong vehicleid, bool status, bool locked);

        [DllImport("mono-module", EntryPoint = "GetVehicleEngineStatus", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GetVehicleEngineStatus(ulong vehicleid);

        [DllImport("mono-module", EntryPoint = "SetVehicleLocked", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleLocked(ulong vehicleid, bool locked);

        [DllImport("mono-module", EntryPoint = "IsVehicleLocked", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsVehicleLocked(ulong vehicleid);

        [DllImport("mono-module", EntryPoint = "SetVehicleBodyHealth", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleBodyHealth(ulong vehicleid, float health);

        [DllImport("mono-module", EntryPoint = "SetVehicleEngineHealth", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleEngineHealth(ulong vehicleid, float health);

        [DllImport("mono-module", EntryPoint = "SetVehicleTankHealth", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleTankHealth(ulong vehicleid, float health);

        [DllImport("mono-module", EntryPoint = "SetVehicleTankHealth", CallingConvention = CallingConvention.Cdecl)]
        public static extern VehicleHealth GetVehicleHealth(ulong vehicleid);
    }
}