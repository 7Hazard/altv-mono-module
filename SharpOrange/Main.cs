using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharpOrange
{
    public class SharpOrange
    {
        public Dictionary<string, Assembly> LoadedResources = new Dictionary<string, Assembly>();
        public static API API = null;
        SharpOrange(ref IntPtr apiptr)
        {
            API = API.__CreateInstance(apiptr);
            SharpPrint("Module successfully initialized!");
        }

        void LoadResource(string resource)
        {
            SharpPrint("Attempting to load resource '"+resource+"'");
            Assembly asm;
            try
            {
                asm = Assembly.LoadFrom("resources/" + resource + "/" + resource + ".dll");
            }
            catch (FileNotFoundException)
            {
                SharpPrint("Resource assembly '" + resource + ".dll' not found!");
                return;
            }
            catch (FileLoadException)
            {
                SharpPrint("Resource assembly '" + resource + ".dll' failed to load!");
                return;
            }
            catch (BadImageFormatException)
            {
                SharpPrint("Resource assembly '" + resource + ".dll' is not 64-bit compatible!");
                return;
            }

            Type type = asm.GetType(resource+"."+resource);
            ConstructorInfo ctor = type.GetConstructor(new Type[] { typeof(API) });
            if (ctor == null)
            {
                SharpPrint(resource+" constructor not found or doesn't take the correct parameters!");
                return;
            }
            object instance = ctor.Invoke(new object[] { API });
            LoadedResources.Add(resource, asm);
        }

        private static void SharpPrint(string msg)
        {
            API.Print("[SharpOrange] "+msg);
        }
    }
}
