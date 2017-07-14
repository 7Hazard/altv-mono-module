using SharpOrange.Objects;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpOrange
{
    internal static class API
    {
        [DllImport("mono-module", EntryPoint = "GetPlayerName", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void GetPlayerName(long playerid, StringBuilder sb);
    }
}
