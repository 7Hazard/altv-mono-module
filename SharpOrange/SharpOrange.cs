using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SharpOrange
{
    internal class SharpOrange
    {
        internal class SM {
            static object Instance;
            static MethodInfo MTriggerOnServerUnload;
            static MethodInfo MTriggerOnTick;
            static MethodInfo MTriggerOnEvent;

            internal static void Init()
            {
                Type t = Assembly.LoadFrom(pluginsPath + "SharpOrangeSM.dll").GetType("SharpOrange.Event");
                MTriggerOnServerUnload = t.GetMethod("TriggerOnServerUnload", new Type[] { });
                MTriggerOnTick = t.GetMethod("TriggerOnTick", new Type[] { });
                MTriggerOnEvent = t.GetMethod("TriggerOnEvent", new Type[] { typeof(string), typeof(object[]) });
                Instance = Activator.CreateInstance(t);
            }

            internal static void TriggerOnServerUnload()
            {
                MTriggerOnServerUnload.Invoke(Instance, null);
            }

            internal static void TriggerOnTick()
            {
                MTriggerOnTick.Invoke(Instance, null);
            }

            internal static void TriggerOnEvent(params object[] args)
            {
                MTriggerOnEvent.Invoke(Instance, args);
            }
        }

        SharpOrange()
        {
            var plugins = Directory
               .EnumerateFiles(pluginsPath, "*.dll")
               .Select(Path.GetFileNameWithoutExtension);
            foreach (string plugin in plugins)
                LoadPlugin(plugin);

            Print("Module successfully initialized");
        }

        static string pluginsPath = @"modules/mono-module/";
        internal static void LoadPlugin(string pluginName)
        {
            if (pluginName == "SharpOrange")
                return;
            else if (pluginName == "SharpOrangeSM")
            {
                SM.Init();
                return;
            }

            try
            {
                Activator.CreateInstanceFrom($"{pluginsPath}{pluginName}.dll",
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

            Server.plugins.Add(pluginName);
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

            Server.resources.Add(resourceName);
            Print($"Loaded resource '{resourceName}'");
        }

        private void HandleException(object sender, UnhandledExceptionEventArgs e)
        {
            Print(e.ToString());
            throw new Exception(e.ToString());
        }

        internal static void Print(string msg)
        {
            Server.Print("[SharpOrange] " + msg);
        }
        internal static void Error(string msg)
        {
            Server.Print("[SharpOrange] ERROR - " + msg);
        }
    }
}
