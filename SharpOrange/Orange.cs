using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpOrange
{
    internal static class Orange
    {
        // Server/Console
        [DllImport("mono-module", EntryPoint = "ServerEvent", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void TriggerEvent(string name, EValue[] args, int size);

        // Clients/Players
        [DllImport("mono-module", EntryPoint = "ClientEvent", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void TriggerEvent(long playerid, string name, EValue[] args, int size);

        [DllImport("mono-module", EntryPoint = "GetPlayerName", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void GetPlayerName(long playerid, StringBuilder sb);

        [DllImport("mono-module", EntryPoint = "SetPlayerSyncedData", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool SetPlayerSyncedData(long playerid, string key, EValue value);

        [DllImport("mono-module", EntryPoint = "GetPlayerSyncedData", CallingConvention = CallingConvention.Cdecl)]
        internal static extern EValue GetPlayerSyncedData(long playerid, string key);
    }

    /* I gave up on this
        static Dictionary<string, byte[]> scripts = new Dictionary<string, byte[]>();
        public static unsafe void AddScript(string file)
        {
            var stackTrace = new StackTrace();
            MethodBase method = stackTrace.GetFrame(1).GetMethod();
            string resource = method.ReflectedType.Name;

            if (File.Exists("resources/"+resource+"/"+file+".bc"))
                File.Delete("resources/" + resource + "/" + file + ".bc");

            byte[] bytecode;
            if (scripts.ContainsKey(resource+file))
            {
                scripts.TryGetValue(resource+file, out bytecode);
            }
            else if (File.Exists("resources/" + resource + "/" + file))
            {
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = Directory.GetCurrentDirectory()+"\\modules\\MonoOrange\\luajit",
                        Arguments = "-b resources/"+ resource + "/" + file + " resources/" + resource + "/" + file+".bc",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };
                proc.Start();
                bytecode = File.ReadAllBytes(@"resources/" + resource + "/" + file + ".bc");
                scripts.Add(resource + file, bytecode);
            } else
            {
                Server.APIPrint("The client script 'resources/" + resource + "/" + file + "' does not exist!");
                return;
            }

            fixed (byte* ptr = &bytecode[0])
            {
                sbyte* ptrs = (sbyte*)ptr;
                Server.API.LoadClientScript(file, ptrs, (ulong)bytecode.LongLength);
            }
            Server.APIPrint("Loaded client script '"+file+"'");
        }*/

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
            else if (t.Equals(typeof(float)))
            {
                type = EType.M_DOUBLE;
                value._double = (float)val;
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
            else if (t.Equals(typeof(char)))
            {
                type = EType.M_STRING;
                value._string = Marshal.StringToCoTaskMemAnsi(val.ToString());
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

        internal object GetObject()
        {
            switch (type)
            {
                case EType.M_BOOL:
                    return value._string;
                case EType.M_DOUBLE:
                    return value._double;
                case EType.M_INT:
                    return value._int;
                case EType.M_NIL:
                    return null;
                case EType.M_STRING:
                    return value._string;
                case EType.M_UINT:
                    return value._uint;
                case EType.M_DICT:
                    SharpOrange.Print("Tried to get a dictionary from an Event/Synced value which is not supported yet!");
                    return null;
                default:
                    return null;
            }
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
