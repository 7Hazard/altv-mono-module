using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpOrange
{
    public static class Plugin
    {
        /*
        public Plugin()
        {
            AppDomain.CurrentDomain.UnhandledException += HandleException;
        }

        private void HandleException(object sender, UnhandledExceptionEventArgs e)
        {
            SharpOrange.Error(e.ToString());
            throw new Exception(e.ToString());
        }
        */

        /*
        /// <summary> !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// (Re)Load a plugin by name
        /// </summary>
        /// <param name="pluginName"></param>
        [DllImport("mono-module", EntryPoint = "LoadPlugin", CallingConvention = CallingConvention.Cdecl)]
        public static extern void LoadPlugin(string pluginName);
        /// <summary> !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// Unload a plugin by name
        /// </summary>
        /// <param name="resourceName"></param>
        [DllImport("mono-module", EntryPoint = "UnloadPlugin", CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadPlugin(string resourceName);
        */

        /// <summary>
        /// Load a plugin by name
        /// </summary>
        /// <param name="name"></param>
        public static void Load(string name)
        {
            SharpOrange.LoadPlugin(name);
        }
    }
}
