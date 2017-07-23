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
        /// <summary>
        /// Dictionary/Map of loaded resources
        /// </summary>
        public static Dictionary<string, object> LoadedResources = new Dictionary<string, object>();
        /// <summary>
        /// Print a server message
        /// </summary>
        /// <param name="text"></param>
        [DllImport("mono-module", EntryPoint = "Print", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Print(string text);
        /// <summary>
        /// Text (string) to hash (long)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [DllImport("mono-module", EntryPoint = "Hash", CallingConvention = CallingConvention.Cdecl)]
        public static extern long Hash(string text);
        /// <summary>
        /// Shut down the server
        /// </summary>
        [DllImport("mono-module", EntryPoint = "Shutdown", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Shutdown();
        /// <summary>
        /// Trigger a server event
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
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
        /// <summary>
        /// Dictionary/Map of the currently connected Players
        /// </summary>
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

        [DllImport("mono-module", EntryPoint = "GetPlayerPosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 GetPlayerPosition(long playerid);

        [DllImport("mono-module", EntryPoint = "SetPlayerPosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPlayerPosition(long playerid, float x, float y, float z);

        [DllImport("mono-module", EntryPoint = "IsPlayerInRange", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsPlayerInRange(long playerid, float x, float y, float z, float range);

        [DllImport("mono-module", EntryPoint = "SetPlayerHeading", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetPlayerHeading(long playerid, float angle);

        [DllImport("mono-module", EntryPoint = "GetPlayerHeading", CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetPlayerHeading(long playerid);

        public static string GetPlayerName(long playerid)
        {
            StringBuilder sb = new StringBuilder();
            API.GetPlayerName(playerid, sb);
            return sb.ToString();
        }

        [DllImport("mono-module", EntryPoint = "SetPlayerName", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPlayerName(long playerid, string name);

        [DllImport("mono-module", EntryPoint = "RemovePlayerWeapons", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool RemovePlayerWeapons(long playerid);

        [DllImport("mono-module", EntryPoint = "GivePlayerWeapon", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GivePlayerWeapon(long playerid, long weapon, long ammo);

        [DllImport("mono-module", EntryPoint = "GivePlayerAmmo", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GivePlayerAmmo(long playerid, long weapon, long ammo);

        [DllImport("mono-module", EntryPoint = "GivePlayerMoney", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GivePlayerMoney(long playerid, long money);

        [DllImport("mono-module", EntryPoint = "SetPlayerMoney", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetPlayerMoney(long playerid, long money);

        [DllImport("mono-module", EntryPoint = "ResetPlayerMoney", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool ResetPlayerMoney(long playerid);

        [DllImport("mono-module", EntryPoint = "GetPlayerMoney", CallingConvention = CallingConvention.Cdecl)]
        public static extern long GetPlayerMoney(long playerid);

        [DllImport("mono-module", EntryPoint = "SetPlayerModel", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetPlayerModel(long playerid, long model);

        [DllImport("mono-module", EntryPoint = "GetPlayerModel", CallingConvention = CallingConvention.Cdecl)]
        public static extern long GetPlayerModel(long playerid);

        [DllImport("mono-module", EntryPoint = "SetPlayerHealth", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetPlayerHealth(long playerid, float health);

        [DllImport("mono-module", EntryPoint = "GetPlayerHealth", CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetPlayerHealth(long playerid);

        [DllImport("mono-module", EntryPoint = "SetPlayerArmour", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetPlayerArmour(long playerid, float armour);

        [DllImport("mono-module", EntryPoint = "GetPlayerArmour", CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetPlayerArmour(long playerid);
        /// <summary>
        /// Broadcast client message to all players
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        [DllImport("mono-module", EntryPoint = "SetPlayerColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern void BroadcastClientMessage(string message, uint color);

        [DllImport("mono-module", EntryPoint = "SendClientMessage", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SendClientMessage(long playerid, string message, uint color);

        [DllImport("mono-module", EntryPoint = "SetPlayerIntoVehicle", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetPlayerIntoVehicle(long playerid, ulong vehicle, char seat);

        [DllImport("mono-module", EntryPoint = "DisablePlayerHud", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisablePlayerHud(long playerid, bool disabled);

        [DllImport("mono-module", EntryPoint = "GetPlayerGUID", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong GetPlayerGUID(long playerid);

        [DllImport("mono-module", EntryPoint = "SendNotification", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SendNotification(long playerid, string msg);

        [DllImport("mono-module", EntryPoint = "SetInfoMsg", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetInfoMsg(long playerid, string msg);

        [DllImport("mono-module", EntryPoint = "UnsetInfoMsg", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool UnsetInfoMsg(long playerid);

        // Vehicles
        /// <summary>
        /// Dictionary/Map of Vehicles
        /// </summary>
        public static Dictionary<ulong, Vehicle> Vehicles;

        [DllImport("mono-module", EntryPoint = "CreateVehicle", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong CreateVehicle(long vehicle, float x, float y, float z, float heading);

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

        [DllImport("mono-module", EntryPoint = "SetVehicleTyresBulletproof", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleTyresBulletproof(ulong vehicleid, bool bulletproof);

        [DllImport("mono-module", EntryPoint = "GetVehicleTyresBulletproof", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GetVehicleTyresBulletproof(ulong vehicleid);

        [DllImport("mono-module", EntryPoint = "HasVehicleCustomColours", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool[] HasVehicleCustomColours(ulong vehicleid);

        [DllImport("mono-module", EntryPoint = "SetVehiclePrimaryColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehiclePrimaryColor(ulong vehicleid, byte r, byte g, byte b);
        
        [DllImport("mono-module", EntryPoint = "GetVehiclePrimaryColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern RGB GetVehiclePrimaryColor(ulong vehicleid);
        
        [DllImport("mono-module", EntryPoint = "SetVehicleSecondaryColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleSecondaryColor(ulong vehicleid, byte r, byte g, byte b);
        
        [DllImport("mono-module", EntryPoint = "GetVehicleSecondaryColor", CallingConvention = CallingConvention.Cdecl)]
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

        [DllImport("mono-module", EntryPoint = "SetVehicleNumberPlate", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleNumberPlate(ulong vehicleid, string text);

        [DllImport("mono-module", EntryPoint = "GetVehicleNumberPlate", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetVehicleNumberPlate(ulong vehicleid);

        [DllImport("mono-module", EntryPoint = "SetVehicleNumberPlateStyle", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleNumberPlateStyle(ulong vehicleid, byte style);

        [DllImport("mono-module", EntryPoint = "SetVehicleNumberPlateStyle", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte GetVehicleNumberPlateStyle(ulong vehicleid);

        [DllImport("mono-module", EntryPoint = "SetVehicleSirenState", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleSirenState(ulong vehicleid, bool state);

        [DllImport("mono-module", EntryPoint = "GetVehicleSirenState", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GetVehicleSirenState(ulong vehicleid);

        [DllImport("mono-module", EntryPoint = "SetVehicleWheelColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleWheelColor(ulong vehicleid, byte color);

        [DllImport("mono-module", EntryPoint = "GetVehicleWheelColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte GetVehicleWheelColor(ulong vehicleid);

        [DllImport("mono-module", EntryPoint = "SetVehicleWheelType", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleWheelType(ulong vehicleid, byte type);

        [DllImport("mono-module", EntryPoint = "GetVehicleWheelType", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte GetVehicleWheelType(ulong vehicleid);

        [DllImport("mono-module", EntryPoint = "SetVehicleLights", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleLights(ulong vehicleid, byte lightstate);

        [DllImport("mono-module", EntryPoint = "GetVehicleLights", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte GetVehicleLights(ulong vehicleid);

        [DllImport("mono-module", EntryPoint = "GetVehicleDriver", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetVehicleDriver(ulong vehicleid);
        
        [DllImport("mono-module", EntryPoint = "GetVehicleDriver", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint[] GetVehiclePassengers(ulong vehicleid);

        // Objects
        /// <summary>
        /// Dictionary of holo texts
        /// </summary>
        public static Dictionary<ulong, GTAObject> GTAObjects;

        [DllImport("mono-module", EntryPoint = "CreateObject", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong CreateObject(long model, float x, float y, float z, float rx, float ry, float rz);

        [DllImport("mono-module", EntryPoint = "DeleteObject", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool DeleteObject(ulong guid);

        // 3D Texts
        /// <summary>
        /// Dictionary of holo texts
        /// </summary>
        public static Dictionary<ulong, HoloText> HoloTexts;

        [DllImport("mono-module", EntryPoint = "Create3DText", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong Create3DText(string text, float x, float y, float z, int color, int outColor, float fontSize);

        [DllImport("mono-module", EntryPoint = "Create3DTextForPlayer", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong Create3DTextForPlayer(long guid, string text, float x, float y, float z, int color, int outColor);

        [DllImport("mono-module", EntryPoint = "Delete3DText", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Delete3DText(ulong guid);

        [DllImport("mono-module", EntryPoint = "Attach3DTextToPlayer", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Attach3DTextToPlayer(ulong guid, long player, float pitch, float yaw, float roll);

        [DllImport("mono-module", EntryPoint = "Attach3DTextToVehicle", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Attach3DTextToVehicle(ulong guid, ulong vehicle, float pitch, float yaw, float roll);

        // Blips
        /// <summary>
        /// Dictionary of Blips
        /// </summary>
        public static Dictionary<ulong, Blip> Blips;

        [DllImport("mono-module", EntryPoint = "CreateBlipForAll", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong CreateBlipForAll(string name, float x, float y, float z, float scale, int color, int sprite);

        [DllImport("mono-module", EntryPoint = "CreateBlipForPlayer", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong CreateBlipForPlayer(long playerid, string name, float x, float y, float z, float scale, int color, int sprite);

        [DllImport("mono-module", EntryPoint = "DeleteBlip", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeleteBlip(ulong guid);

        [DllImport("mono-module", EntryPoint = "SetBlipColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetBlipColor(ulong guid, int color);

        [DllImport("mono-module", EntryPoint = "SetBlipScale", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetBlipScale(ulong guid, float scale);

        [DllImport("mono-module", EntryPoint = "SetBlipRoute", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetBlipRoute(ulong guid, bool route);

        [DllImport("mono-module", EntryPoint = "SetBlipSprite", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetBlipSprite(ulong guid, int sprite);

        [DllImport("mono-module", EntryPoint = "SetBlipName", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetBlipName(ulong guid, string name);

        [DllImport("mono-module", EntryPoint = "SetBlipAsShortRange", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetBlipAsShortRange(ulong guid, bool shortrange);

        [DllImport("mono-module", EntryPoint = "AttachBlipToPlayer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AttachBlipToPlayer(ulong guid, long player);

        [DllImport("mono-module", EntryPoint = "AttachBlipToVehicle", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AttachBlipToVehicle(ulong guid, ulong vehicle);

        // Markers
        /// <summary>
        /// Dictionary/Map of markers for the GTA V map
        /// </summary>
        public static Dictionary<ulong, Marker> Markers;

        [DllImport("mono-module", EntryPoint = "CreateMarkerForAll", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong CreateMarkerForAll(float x, float y, float z, float height, float radius);

        [DllImport("mono-module", EntryPoint = "CreateMarkerForPlayer", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong CreateMarkerForPlayer(long playerid, float x, float y, float z, float height, float radius);

        [DllImport("mono-module", EntryPoint = "DeleteMarker", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeleteMarker(ulong guid);

        // Misc
        [DllImport("mono-module", EntryPoint = "CreatePickup", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CreatePickup(long pickup, float x, float y, float z, float scale);
    }
}