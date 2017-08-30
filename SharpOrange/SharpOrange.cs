using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

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

        public static void HandleTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Error(e.ToString());
        }

        static string pluginsPath = @"modules/mono-module/";
        internal static void LoadPlugin(string name)
        {
            if (name == "SharpOrange")
                return;
            else if (name == "SharpOrangeSM")
            {
                SM.Init();
                return;
            }

            if (Server.plugins.Contains(name))
            {
                Print($"Plugin \"{name}\" is already loaded!");
                return;
            }

            try
            {
                Activator.CreateInstanceFrom($"{pluginsPath}{name}.dll",
                    name + "." + name);
            }
            catch (BadImageFormatException)
            {
                Error($"Resource assembly '{name}' is not targeting .NET Framework!");
                return;
            }
            catch (MissingMethodException)
            {
                Error($"Constructor in '{name}.{name}' is not public!");
                return;
            }
            catch (TypeLoadException)
            {
                Error($"Namespace, class and a public constructor must be named the same!\n" +
                    $"Namespace and Class: {name}, Constructor: 'public {name}'");
                return;
            }
            catch (Exception e)
            {
                Error($"Exception caught attempting to load assembly '{name}':\n{e}");
                return;
            }

            Server.plugins.Add(name);
        }

        static string resourcesPath = @"resources";
        internal static void LoadResource(string name)
        {
            if (Server.resources.Contains(name))
            {
                Print($"Resource \"{name}\" is already loaded!");
                return;
            }

            try
            {
                Activator.CreateInstanceFrom($"{resourcesPath}/{name}/{name}.dll",
                    name + "." + name);
            }
            catch (FileLoadException)
            {
                Error($"Resource assembly '{name}' failed to load!");
                return;
            }
            catch (BadImageFormatException)
            {
                Error($"Resource assembly '{name}' is not targeting .NET Framework!");
                return;
            }
            catch (MissingMethodException)
            {
                Error($"Constructor in '{name}.{name}' is not public!");
                return;
            }
            catch (TypeLoadException)
            {
                Error($"Namespace, class and a public constructor must be named the same!\n" +
                    $"Namespace and Class: {name}, Constructor: 'public {name}'");
                return;
            }
            catch (Exception e)
            {
                Error($"Exception caught attempting to load assembly '{name}':\n{e}");
                return;
            }

            Server.resources.Add(name);
            Print($"Loaded resource '{name}'");
        }

        public static void Exec(Action func)
        {
            try
            {
                func();
            } catch (Exception e)
            {
                Error(e.ToString());
            }
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
