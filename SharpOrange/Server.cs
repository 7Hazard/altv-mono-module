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
        /// Server/Console
        public static Dictionary<string, object> LoadedResources = new Dictionary<string, object>();

        [DllImport("mono-module", EntryPoint = "Print", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Print(string text);

        /// Players
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

        [DllImport("mono-module", EntryPoint = "GetPlayerPosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 GetPlayerPosition(long playerid);

        [DllImport("mono-module", EntryPoint = "SetPlayerPosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPlayerPosition(long playerid, float x, float y, float z);
    }
}