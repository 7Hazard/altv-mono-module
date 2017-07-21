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
        public static extern void KickPlayer(long guid);

        [DllImport("mono-module", EntryPoint = "KickPlayer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void KickPlayer(long guid, string reason);

        public static string GetPlayerName(long guid)
        {
            StringBuilder sb = new StringBuilder();
            API.GetPlayerName(guid, sb);
            return sb.ToString();
        }

        [DllImport("mono-module", EntryPoint = "SetPlayerName", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPlayerName(long guid, string name);

        [DllImport("mono-module", EntryPoint = "SetPlayerPosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPlayerPosition(long guid, float x, float y, float z);

        [DllImport("mono-module", EntryPoint = "GetPlayerPosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 GetPlayerPosition(long guid);

        [DllImport("mono-module", EntryPoint = "SetPlayerModel", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetPlayerModel(long guid, long model);

        [DllImport("mono-module", EntryPoint = "GetPlayerModel", CallingConvention = CallingConvention.Cdecl)]
        public static extern long GetPlayerModel(long guid);

        [DllImport("mono-module", EntryPoint = "RemovePlayerWeapons", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool RemovePlayerWeapons(long guid);

        [DllImport("mono-module", EntryPoint = "GivePlayerWeapon", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GivePlayerWeapon(long guid, long weapon, long ammo);

        [DllImport("mono-module", EntryPoint = "GivePlayerAmmo", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GivePlayerAmmo(long guid, long weapon, long ammo);

        // Vehicles
        public static Dictionary<ulong, Vehicle> Vehicles;

        [DllImport("mono-module", EntryPoint = "CreateVehicle", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong CreateVehicle(VehicleHash vehicle, float x, float y, float z);

        [DllImport("mono-module", EntryPoint = "DeleteVehicle", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool DeleteVehicle(ulong guid);

        [DllImport("mono-module", EntryPoint = "SetVehiclePosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehiclePosition(ulong guid, float x, float y, float z);

        [DllImport("mono-module", EntryPoint = "GetVehiclePosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 GetVehiclePosition(ulong guid);

        [DllImport("mono-module", EntryPoint = "SetVehicleRotation", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleRotation(ulong guid, float rx, float ry, float rz);

        [DllImport("mono-module", EntryPoint = "GetVehicleRotation", CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 GetVehicleRotation(ulong guid);
        
        [DllImport("mono-module", EntryPoint = "SetVehiclePrimaryColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehiclePrimaryColor(ulong guid, byte r, byte g, byte b);
        
        [DllImport("mono-module", EntryPoint = "GetVehiclePrimaryColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern RGB GetVehiclePrimaryColor(ulong guid);
        // TBT START
        [DllImport("mono-module", EntryPoint = "SetVehicleSecondaryColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleSecondaryColor(ulong guid, byte r, byte g, byte b);
        
        [DllImport("mono-module", EntryPoint = "GetVehicleSecondaryColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern RGB GetVehicleSecondaryColor(ulong guid);

        [DllImport("mono-module", EntryPoint = "SetVehicleEngineStatus", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleEngineStatus(ulong guid, bool status, bool locked);

        [DllImport("mono-module", EntryPoint = "GetVehicleEngineStatus", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GetVehicleEngineStatus(ulong guid);

        [DllImport("mono-module", EntryPoint = "SetVehicleLocked", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleLocked(ulong guid, bool locked);

        [DllImport("mono-module", EntryPoint = "IsVehicleLocked", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsVehicleLocked(ulong guid);

        [DllImport("mono-module", EntryPoint = "SetVehicleBodyHealth", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleBodyHealth(ulong guid, float health);

        [DllImport("mono-module", EntryPoint = "SetVehicleEngineHealth", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleEngineHealth(ulong guid, float health);

        [DllImport("mono-module", EntryPoint = "SetVehicleTankHealth", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleTankHealth(ulong guid, float health);

        [DllImport("mono-module", EntryPoint = "SetVehicleTankHealth", CallingConvention = CallingConvention.Cdecl)]
        public static extern VehicleHealth GetVehicleHealth(ulong guid);

        [DllImport("mono-module", EntryPoint = "SetVehicleNumberPlate", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleNumberPlate(ulong guid, string text);

        [DllImport("mono-module", EntryPoint = "GetVehicleNumberPlate", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetVehicleNumberPlate(ulong guid);

        [DllImport("mono-module", EntryPoint = "SetVehicleNumberPlateStyle", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GetVehicleNumberPlateStyle(ulong guid, byte style);

        [DllImport("mono-module", EntryPoint = "SetVehicleNumberPlateStyle", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte GetVehicleNumberPlateStyle(ulong guid);

        [DllImport("mono-module", EntryPoint = "SetVehicleSirenState", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleSirenState(ulong guid, bool state);

        [DllImport("mono-module", EntryPoint = "GetVehicleSirenState", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GetVehicleSirenState(ulong guid);

        [DllImport("mono-module", EntryPoint = "SetVehicleWheelColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleWheelColor(ulong guid, byte color);

        [DllImport("mono-module", EntryPoint = "GetVehicleWheelColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte GetVehicleWheelColor(ulong guid);

        [DllImport("mono-module", EntryPoint = "SetVehicleWheelType", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleWheelType(ulong guid, byte type);

        [DllImport("mono-module", EntryPoint = "GetVehicleWheelType", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte GetVehicleWheelType(ulong guid);

        [DllImport("mono-module", EntryPoint = "SetVehicleLights", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetVehicleLights(ulong guid, byte lightstate);

        [DllImport("mono-module", EntryPoint = "GetVehicleLights", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte GetVehicleLights(ulong guid);

        [DllImport("mono-module", EntryPoint = "GetVehicleDriver", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetVehicleDriver(ulong guid);
        
        [DllImport("mono-module", EntryPoint = "GetVehicleDriver", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint[] GetVehiclePassengers(ulong guid);
        // TBT END

        // Objects
        [DllImport("mono-module", EntryPoint = "CreateObject", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong CreateObject(long model, float x, float y, float z, float rx, float ry, float rz);

        [DllImport("mono-module", EntryPoint = "DeleteObject", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool DeleteObject(ulong guid);

        [DllImport("mono-module", EntryPoint = "CreatePickup", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CreatePickup(PickupHash pickup, float x, float y, float z, float scale);

        // 3D Texts
        [DllImport("mono-module", EntryPoint = "Create3DText", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong Create3DText(string text, float x, float y, float z, int color, int outColor, float fontSize);

        [DllImport("mono-module", EntryPoint = "Create3DTextForPlayer", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong Create3DTextForPlayer(long guid, string text, float x, float y, float z, int color, int outColor);

        [DllImport("mono-module", EntryPoint = "Delete3DText", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Delete3DText(ulong guid);

        [DllImport("mono-module", EntryPoint = "Attach3DTextToPlayer", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Attach3DTextToPlayer(ulong guid, long player, float x, float y, float z);

        [DllImport("mono-module", EntryPoint = "Attach3DTextToVehicle", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Attach3DTextToVehicle(ulong guid, ulong vehicle, float x, float y, float z);

        // Blips
        [DllImport("mono-module", EntryPoint = "CreateBlipForAll", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong CreateBlipForAll(string name, float x, float y, float z, float scale, int color, int sprite);

        [DllImport("mono-module", EntryPoint = "CreateBlipForPlayer", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong CreateBlipForPlayer(ulong guid, string name, float x, float y, float z, float scale, int color, int sprite);

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
    }
}