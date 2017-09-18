using SharpOrange.Math;
using System;

namespace SharpOrange.Objects
{
    /// <summary>
    /// Marker for the normal GTA V Map
    /// </summary>
    public class Marker : IDisposable
    {
        /// <summary>
        /// Create map marker visible for all players
        /// </summary>
        /// <param name="position"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        public Marker(Vector3 position, float height, float radius)
        {
            ID = Server.CreateMarkerForAll(position.x, position.y, position.z, height, radius);
            Server.markers.Add(ID, this);
        }
        /// <summary>
        /// Create map marker visible for the specified
        /// </summary>
        /// <param name="player"></param>
        /// <param name="position"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        public Marker(Player player, Vector3 position, float height, float radius)
        {
            ID = Server.CreateMarkerForPlayer(player.ID, position.x, position.y, position.z, height, radius);
            Server.markers.Add(ID, this);
        }
        ~Marker()
        {
            Server.DeleteMarker(ID);
            Server.markers.Remove(ID);
        }
        /// <summary>
        /// Proper method for disposing the Marker
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Server.DeleteMarker(ID);
            Server.markers.Remove(ID);
        }
        /// <summary>
        /// The unique ID of the marker
        /// </summary>
        public ulong ID { get; internal set; }
    }
}