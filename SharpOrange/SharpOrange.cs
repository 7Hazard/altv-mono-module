using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SharpOrange.Objects;
using System.Runtime.InteropServices;

namespace SharpOrange
{
    public class SharpOrange
    {
        SharpOrange()
        {
            AppDomain.CurrentDomain.SetupInformation.LoaderOptimization = LoaderOptimization.MultiDomainHost;

            Server.Plugins = new List<string>();
            Server.Resources = new List<string>();
            Server.Players = new Dictionary<long, Player>();
            Server.Vehicles = new Dictionary<ulong, Vehicle>();
            Server.Blips = new Dictionary<ulong, Blip>();
            Server.Markers = new Dictionary<ulong, Marker>();
            Server.HoloTexts = new Dictionary<ulong, HoloText>();
            Server.GTAObjects = new Dictionary<ulong, GTAObject>();

            var plugins = Directory
                .EnumerateFiles(pluginsPath, "*.dll")
                .Select(Path.GetFileNameWithoutExtension);
            foreach (string plugin in plugins)
                LoadPlugin(plugin);

            Print("Module successfully initialized"); 
        }

        static string pluginsPath = @"modules/mono-module";
        internal static void LoadPlugin(string pluginName)
        {
            if (pluginName == "SharpOrange")
                return;

            try
            {
                Activator.CreateInstanceFrom($"{pluginsPath}/{pluginName}.dll",
                    pluginName + "." + pluginName);
            }
            catch (BadImageFormatException)
            {
                Error($"Resource assembly '{pluginName}' is not targeting .NET Framework!");
                return;
            }
            catch (MissingMethodException)
            {
                Error($"Constructor in '{pluginName}.{pluginName}' is not public!");
                return;
            }
            catch (TypeLoadException)
            {
                Error($"Namespace, class and a public constructor must be named the same!\n" +
                    $"Namespace and Class: {pluginName}, Constructor: 'public {pluginName}'");
                return;
            }
            catch (Exception e)
            {
                Error($"Exception caught attempting to load assembly '{pluginName}':\n{e}");
                return;
            }

            Server.Plugins.Add(pluginName);
        }

        static string resourcesPath = @"resources";
        internal static void LoadResource(string resourceName)
        {
            try
            {
                Activator.CreateInstanceFrom($"{resourcesPath}/{resourceName}/{resourceName}.dll",
                    resourceName + "." + resourceName);
            }
            catch (FileLoadException)
            {
                Error($"Resource assembly '{resourceName}' failed to load!");
                return;
            }
            catch (BadImageFormatException)
            {
                Error($"Resource assembly '{resourceName}' is not targeting .NET Framework!");
                return;
            }
            catch (MissingMethodException)
            {
                Error($"Constructor in '{resourceName}.{resourceName}' is not public!");
                return;
            }
            catch (TypeLoadException)
            {
                Error($"Namespace, class and a public constructor must be named the same!\n" +
                    $"Namespace and Class: {resourceName}, Constructor: 'public {resourceName}'");
                return;
            }
            catch (Exception e)
            {
                Error($"Exception caught attempting to load assembly '{resourceName}':\n{e}");
                return;
            }

            Server.Resources.Add(resourceName);
            Print($"Loaded resource '{resourceName}'");
        }

        /*internal static Dictionary<string, AppDomain> Plugins = new Dictionary<string, AppDomain>();
        internal static void LoadPlugin(string plugin)
        {
            if (plugin == "SharpOrange")
                return;

                if (Plugins.ContainsKey(plugin))
                Plugins.Remove(plugin);

            try
            {
                Plugins.Add(plugin, CreateDomain(plugin, pluginsPath));
            }
            catch (FileNotFoundException)
            {
                Error($"Failed to load '{plugin}', assembly not found!");
                return;
            }
            catch (TypeLoadException)
            {
                Error($"Failed to load '{plugin}'! Namespace, class and assembly name must be the same with public constructor!");
                return;
            }
            catch (Exception e)
            {
                Error($"Exception caught while attempting to load assembly '{plugin}':\n" + e);
                return;
            }
        }
        internal static void UnloadPlugin(string pluginName)
        {
            Plugins.TryGetValue(pluginName, out AppDomain domain);
            AppDomain.Unload(domain);
            Print($"Addon '{pluginName}' has been unloaded");
        }

        internal static Dictionary<string, AppDomain> Resources = new Dictionary<string, AppDomain>();
        internal static void LoadResource(string resource)
        {
            if (Resources.ContainsKey(resource))
                UnloadResource(resource);

            try
            {
                Resources.Add(resource, CreateDomain(resource, $"resources/{resource}"));
            }
            catch (FileNotFoundException)
            {
                Error($"Failed to load '{resource}', assembly not found!");
                return;
            }
            catch (TypeLoadException)
            {
                Error($"Failed to load '{resource}'! Namespace, class and assembly name must be the same with public constructor!");
                return;
            }
            catch (Exception e)
            {
                Error($"Exception caught while attempting to load assembly '{resource}':\n" + e);
                return;
            }
            Print($"Loaded resource '{resource}'");
        }
        internal static void UnloadResource(string resource)
        {
            Resources.TryGetValue(resource, out AppDomain domain);
            AppDomain.Unload(domain);
            Resources.Remove(resource);
            Print($"Resource '{resource}' has been unloaded");
        }

        static AppDomain CreateDomain(string name, string path)
        {
            AppDomain domain = AppDomain.CreateDomain(name);
            domain.SetupInformation.LoaderOptimization = LoaderOptimization.MultiDomain;
            domain.CreateInstanceFrom($"{path}/{name}.dll", name+"."+name);
            return domain;
        }*/

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
