using SharpOrange.Objects;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpOrange
{
    internal static class API
    {
        // Server/Console
        [DllImport("mono-module", EntryPoint = "ServerEvent", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ServerEvent(string name, EValue[] args, int size);

        // Clients
        [DllImport("mono-module", EntryPoint = "ClientEvent", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ClientEvent(long playerid, string name, EValue[] args, int size);

        // Players
        [DllImport("mono-module", EntryPoint = "GetPlayerName", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void GetPlayerName(long playerid, StringBuilder sb);
    }

    
    internal struct EValue
    {
        internal EType type;
        internal Value value;

        internal EValue(object val)
        {
            Type t = val.GetType();
            value = new Value();
            if (t.Equals(typeof(bool)))
            {
                type = EType.M_BOOL;
                value._bool = (bool)val;
            }
            else if (t.Equals(typeof(int)))
            {
                type = EType.M_INT;
                value._int = (int)val;
            }
            else if (t.Equals(typeof(uint)))
            {
                type = EType.M_UINT;
                value._uint = (uint)val;
            }
            else if (t.Equals(typeof(ulong)))
            {
                type = EType.M_UINT;
                value._uint = (uint)val;
            }
            else if (t.Equals(typeof(double)))
            {
                type = EType.M_DOUBLE;
                value._double = (double)val;
            }
            else if (t.Equals(typeof(string)))
            {
                type = EType.M_STRING;
                value._string = Marshal.StringToCoTaskMemAnsi((string)val);
            }
            else
            {
                type = EType.M_NIL;
                value._int = 0;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct Value
        {
            [FieldOffset(0)] internal bool _bool;
            [FieldOffset(0)] internal int _int;
            [FieldOffset(0)] internal uint _uint;
            [FieldOffset(0)] internal double _double;
            [FieldOffset(0)] internal IntPtr _string;
            //[FieldOffset(0)] internal Dict _dict;
        }

    }
    internal enum EType
    {
        M_NIL,
        M_BOOL,
        M_INT,
        M_UINT,
        M_DOUBLE,
        M_STRING,
        M_DICT
    }
}
