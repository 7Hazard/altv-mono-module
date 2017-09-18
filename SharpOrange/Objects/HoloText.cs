using SharpOrange.Math;
using System;

namespace SharpOrange.Objects
{
    public class HoloText : IDisposable
    {
        /// <summary>
        /// Create Holo Text for all players
        /// </summary>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        /// <param name="fontSize"></param>
        public HoloText(string text, Vector3 position, RGB color, float fontSize)
        {
            ID = Server.Create3DText(text, position.x, position.y, position.z, color.r, color.r, fontSize);
            Server.holotexts.Add(ID, this);
        }
        /// <summary>
        /// Create Holo Text for specified player
        /// </summary>
        /// <param name="text"></param>
        /// <param name="player"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        /// <param name="outline"></param>
        public HoloText(string text, Player player, Vector3 position, RGB color, RGB outline)
        {
            ID = Server.Create3DTextForPlayer(player.ID, text, position.x, position.y, position.z, color.r, outline.r);
            Server.holotexts.Add(ID, this);
        }
        ~HoloText()
        {
            if (!Server.Delete3DText(ID))
                SharpOrange.Print($"Failed to Dispose Holo Text '{ID}'!");
            Server.holotexts.Remove(ID);
        }
        /// <summary>
        /// Dispose Holo Text
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            if (!Server.Delete3DText(ID))
                SharpOrange.Print($"Failed to Dispose Holo Text '{ID}'!");
            Server.holotexts.Remove(ID);
        }
        /// <summary>
        /// 3D Holo Text Unique ID
        /// </summary>
        public ulong ID { get; }
        /// <summary>
        /// Attach Holo Text to Player
        /// </summary>
        public void AttachToPlayer(Player player, Vector3 rotation)
        {
            if (!Server.Attach3DTextToPlayer(ID, player.ID, rotation.x, rotation.y, rotation.z))
                SharpOrange.Print($"Failed to Attach Holo Text '{ID}' to Player '{player.ID}'!");
        }
        /// <summary>
        /// Attach Holo Text to Vehicle
        /// </summary>
        public void AttachToVehicle(Vehicle vehicle, Vector3 rotation)
        {
            if (!Server.Attach3DTextToVehicle(ID, vehicle.ID, rotation.x, rotation.y, rotation.z))
                SharpOrange.Print($"Failed to Attach Holo Text '{ID}' to Vehicle '{vehicle.ID}'!");
        }
    }
}