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
            Server.Vehicles = new Dictionary<ulong, Vehicle>();
            Server.Blips = new Dictionary<ulong, Blip>();
            Server.Markers = new Dictionary<ulong, Marker>();
            Server.HoloTexts = new Dictionary<ulong, HoloText>();
            Server.GTAObjects = new Dictionary<ulong, GTAObject>();
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
                Error($"Resource assembly '{resource}.dll' not found!");
                return;
            }
            catch (FileLoadException)
            {
                Error($"Resource assembly '{resource}.dll' failed to load!");
                return;
            }
            catch (BadImageFormatException)
            {
                Error($"Resource assembly '{resource}.dll' is not targeting .NET Framework!");
                return;
            }
            catch (MissingMethodException)
            {
                Error($"Constructor in '{resource}.{resource}' is not public or is missing!");
                return;
            }
            catch (Exception e)
            {
                Error("Exception caught attempting to load assembly:\n"+e);
                return;
            }

            Server.LoadedResources.Add(resource, obj);
            Print("Loaded resource " + resource);
        }

        internal static void Print(string msg)
        {
            Server.Print("[SharpOrange] " + msg);
        }
        internal static void Error(string msg)
        {
            Server.Print("[SharpOrange] ERROR - " + msg);
        }

        internal static T GetEnum<T>(object obj)
        {
            T enumVal = (T)Enum.Parse(typeof(T), obj.ToString());
            return enumVal;
        }
    }
}
