using System;
using System.Runtime.InteropServices;

namespace SharpOrange
{
    public class Resource
    {
        public Resource()
        {
            AppDomain.CurrentDomain.UnhandledException += HandleException;
        }

        private void HandleException(object sender, UnhandledExceptionEventArgs e)
        {
            SharpOrange.Error(e.ToString());
            throw new Exception(e.ToString());
        }

        /*/// <summary>
        /// (Re)Load a plugin by name
        /// </summary>
        /// <param name="pluginName"></param>
        [DllImport("mono-module", EntryPoint = "LoadPlugin", CallingConvention = CallingConvention.Cdecl)]
        public static extern void LoadPlugin(string pluginName);
        /// <summary>
        /// Unload a plugin by name
        /// </summary>
        /// <param name="resourceName"></param>
        [DllImport("mono-module", EntryPoint = "UnloadPlugin", CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadPlugin(string resourceName);*/

        /// <summary>
        /// (Re)Load a resource by name
        /// </summary>
        /// <param name="resourceName"></param>
        [DllImport("mono-module", EntryPoint = "LoadResource", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Load(string resourceName);
        /// <summary>
        /// Unload a resource by name
        /// </summary>
        /// <param name="resourceName"></param>
        [DllImport("mono-module", EntryPoint = "UnloadResource", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Unload(string resourceName);
    }
}
