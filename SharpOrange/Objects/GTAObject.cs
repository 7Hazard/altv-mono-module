#if !SM
using SharpOrange.Structs;
using System;

namespace SharpOrange.Objects
{
    public class GTAObject
    {
        /// <summary>
        /// Create GTA Object with object name
        /// </summary>
        /// <param name="model"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        public GTAObject(string model, Vector3 position, Vector3 rotation)
        {
            ID = Server.CreateObject(Server.Hash(model), position.x, position.y, position.z,
                rotation.x, rotation.y, rotation.z);
            Server.gtaobjects.Add(ID, this);
        }
        ~GTAObject()
        {
            if (!Server.DeleteObject(ID))
                SharpOrange.Print($"Failed to Dispose object '{ID}'!");
            Server.gtaobjects.Remove(ID);
        }
        /// <summary>
        /// Dispose the GTA Object
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            if (!Server.DeleteObject(ID))
                SharpOrange.Print($"Failed to Dispose object '{ID}'!");
            Server.gtaobjects.Remove(ID);
        }
        /// <summary>
        /// GUID of object
        /// </summary>
        public ulong ID { get; }
    }
}
#endif