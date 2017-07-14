using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SharpOrange.Objects;

namespace SharpOrange
{
    class SharpOrange
    {
        SharpOrange()
        {
            Server.Players = new Dictionary<long, Player>();
            Print("Module successfully initialized");
        }

        static void LoadResource(string resource)
        {
            object obj;
            try
            {
                obj = Activator.CreateInstanceFrom($"resources/{resource}/{resource}.dll",
                    resource + "." + resource);
            }
            catch (FileNotFoundException)
            {
                PrintError($"Resource assembly '{resource}.dll' not found!");
                return;
            }
            catch (FileLoadException)
            {
                PrintError($"Resource assembly '{resource}.dll' failed to load!");
                return;
            }
            catch (BadImageFormatException)
            {
                PrintError($"Resource assembly '{resource}.dll' is not targeting .NET Framework!");
                return;
            }
            catch (MissingMethodException)
            {
                PrintError($"Constructor in '{resource}.{resource}' is not public or is missing!");
                return;
            }
            catch (Exception e)
            {
                PrintError("Exception caught attempting to load assembly:\n"+e);
                return;
            }

            Server.LoadedResources.Add(resource, obj);
            Print("Loaded resource " + resource);
        }

        internal static void Print(string msg)
        {
            Server.Print("[SharpOrange] " + msg);
        }
        internal static void PrintError(string msg)
        {
            Server.Print("[SharpOrange] ERROR - " + msg);
        }
    }
}
