using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SharpOrange
{
    public class Client
    {
        public unsafe static void TriggerEvent(long playerid, string name, object[] args)
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
                    API.ClientEvent(playerid, name, values, len);
                for (int i = 0; i < len; i++)
                {
                    if (values[i].type == EType.M_STRING)
                        Marshal.FreeCoTaskMem(values[i].value._string);
                }
            });
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
    }
}
