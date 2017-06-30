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
        public Dictionary<string, Assembly> LoadedResources = new Dictionary<string, Assembly>();
        internal static API API = null;
        Server(ref IntPtr apiptr)
        {
            API = API.__CreateInstance(apiptr);
            APIPrint("Module successfully initialized");
        }

        void LoadResource(string resource)
        {
            Assembly asm;
            try
            {
                asm = Assembly.LoadFrom("resources/" + resource + "/" + resource + ".dll");
            }
            catch (FileNotFoundException)
            {
                APIPrint("Resource assembly '" + resource + ".dll' not found!");
                return;
            }
            catch (FileLoadException)
            {
                APIPrint("Resource assembly '" + resource + ".dll' failed to load!");
                return;
            }
            catch (BadImageFormatException)
            {
                APIPrint("Resource assembly '" + resource + ".dll' is not 64-bit compatible!");
                return;
            }

            Type type = asm.GetType(resource+"."+resource);
            ConstructorInfo ctor = type.GetConstructor(new Type[] { typeof(API) });
            if (ctor == null)
            {
                APIPrint(resource+" constructor not found, is not public or doesn't take the API as a parameter!");
                return;
            }
            APIPrint("Loaded resource "+resource);
            object instance = ctor.Invoke(new object[] { API });
            LoadedResources.Add(resource, asm);
        }

        internal static void APIPrint(string msg)
        {
            API.Print("[SharpOrange] "+msg);
        }
    }
}
