#if !SM
using SharpOrange.Math;
using System;

namespace SharpOrange.Objects
{
    public class Blip : IDisposable
    {
        /// <summary>
        /// Create blip for all player
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <param name="color"></param>
        /// <param name="sprite"></param>
        public Blip(string name, Vector3 position, RGB color, float scale, int sprite)
        {
            ID = Server.CreateBlipForAll(name, position.x, position.y, position.z, scale, color.r, sprite);
            Server.blips.Add(ID, this);
        }
        /// <summary>
        /// Create Blip for specified player
        /// </summary>
        /// <param name="name"></param>
        /// <param name="player"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        /// <param name="scale"></param>
        /// <param name="sprite"></param>
        public Blip(string name, Player player, Vector3 position, RGB color, float scale, int sprite)
        {
            ID = Server.CreateBlipForPlayer(player.ID, name, position.x, position.y, position.z, scale, color.r, sprite);
            Server.blips.Add(ID, this);
        }
        ~Blip()
        {
            Server.DeleteBlip(ID);
            Server.blips.Remove(ID);
        }
        /// <summary>
        /// Dispose the Blip
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Server.DeleteBlip(ID);
            Server.blips.Remove(ID);
        }
        /// UID of Blip
        /// </summary>
        public ulong ID { get; }
        /// <summary>
        /// Set name of Blip
        /// </summary>
        public string Name
        {
            set
            {
                Server.SetBlipName(ID, value);
            }
        }
        /// <summary>
        /// Set color of Blip
        /// </summary>
        public int Color
        {
            set
            {
                Server.SetBlipColor(ID, value);
            }
        }
        /// <summary>
        /// Set Blip Sprite
        /// </summary>
        public int Sprite
        {
            set
            {
                Server.SetBlipSprite(ID, value);
            }
        }
        /// <summary>
        /// Set if Blip is routed
        /// </summary>
        public bool Route
        {
            set
            {
                Server.SetBlipRoute(ID, value);
            }
        }
        /// <summary>
        /// Set to Short Range Blip
        /// </summary>
        public bool IsShortRange
        {
            set
            {
                Server.SetBlipAsShortRange(ID, value);
            }
        }
        /// <summary>
        /// Attach Blip to player
        /// </summary>
        public Player Player
        {
            set
            {
                Server.AttachBlipToPlayer(ID, value.ID);
            }
        }
        /// <summary>
        /// Attach Blip to Vehicle
        /// </summary>
        public Vehicle Vehicle
        {
            set
            {
                Server.AttachBlipToVehicle(ID, value.ID);
            }
        }
    }
}
#endif