﻿using System;
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
            APIPrint("Module successfully initialized!");
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
                APIPrint(resource+" constructor not found, is not public or doesn't take the correct parameters!");
                return;
            }
            APIPrint(resource+" resource loaded!");
            object instance = ctor.Invoke(new object[] { API });
            LoadedResources.Add(resource, asm);
        }

        private static void APIPrint(string msg)
        {
            API.Print("[SharpOrange] "+msg);
        }
    }
}
