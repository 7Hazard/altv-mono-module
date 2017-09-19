using SharpOrange.Math;
using System;

namespace SharpOrange.Objects
{
    public class Text3D : IDisposable
    {
        /// <summary>
        /// Create 3D Text for all players
        /// </summary>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        /// <param name="fontSize"></param>
        public Text3D(string text, Vector3 position, RGBA color, float fontSize)
        {
            ID = Server.Create3DText(text, position.x, position.y, position.z, color.UInt, color.UInt, fontSize);
            Server.text3ds.Add(ID, this);
        }

        /// <summary>
        /// Creates a 3D Text for all players
        /// </summary>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        /// <param name="outline"></param>
        /// <param name="fontSize"></param>
        public Text3D(string text, Vector3 position, RGBA color, RGBA outline, float fontSize)
        {
            ID = Server.Create3DText(text, position.x, position.y, position.z, color.UInt, outline.UInt, fontSize);
            Server.text3ds.Add(ID, this);
        }

        /// <summary>
        /// Create 3D Text for specified player
        /// </summary>
        /// <param name="text"></param>
        /// <param name="player"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        /// <param name="outline"></param>
        public Text3D(string text, Player player, Vector3 position, RGBA color, RGBA outline)
        {
            ID = Server.Create3DTextForPlayer(player.ID, text, position.x, position.y, position.z, color.UInt, outline.UInt);
            Server.text3ds.Add(ID, this);
        }

        ~Text3D()
        {
            if (!Server.Delete3DText(ID))
                SharpOrange.Print($"Failed to Dispose Holo Text '{ID}'!");
            Server.text3ds.Remove(ID);
        }

        /// <summary>
        /// Dispose 3D Text
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            if (!Server.Delete3DText(ID))
                SharpOrange.Print($"Failed to Dispose Holo Text '{ID}'!");
            Server.text3ds.Remove(ID);
        }

        /// <summary>
        /// 3D Text Unique ID
        /// </summary>
        public ulong ID { get; }

        /// <summary>
        /// Attach 3D Text to Player
        /// </summary>
        public void AttachTo(Player player, Vector3 rotation)
        {
            if (!Server.Attach3DTextToPlayer(ID, player.ID, rotation.x, rotation.y, rotation.z))
                SharpOrange.Print($"Failed to Attach Holo Text '{ID}' to Player '{player.ID}'!");
        }

        /// <summary>
        /// Attach 3D Text to Vehicle
        /// </summary>
        public void AttachTo(Vehicle vehicle, Vector3 rotation)
        {
            if (!Server.Attach3DTextToVehicle(ID, vehicle.ID, rotation.x, rotation.y, rotation.z))
                SharpOrange.Print($"Failed to Attach Holo Text '{ID}' to Vehicle '{vehicle.ID}'!");
        }
    }
}