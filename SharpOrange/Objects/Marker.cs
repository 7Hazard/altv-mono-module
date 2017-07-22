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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        public Marker(float x, float y, float z, float height, float radius)
        {
            ID = Server.CreateMarkerForAll(x, y, z, height, radius);
            Server.Markers.Add(ID, this);
        }
        /// <summary>
        /// Create map marker visible for the specified
        /// </summary>
        /// <param name="player"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        public Marker(Player player, float x, float y, float z, float height, float radius)
        {
            ID = Server.CreateMarkerForPlayer(player.ID, x, y, z, height, radius);
            Server.Markers.Add(ID, this);
        }
        /// <summary>
        /// Create map marker visible for the specified (using the direct player ID)
        /// </summary>
        /// <param name="playerid"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        public Marker(long playerid, float x, float y, float z, float height, float radius)
        {
            ID = Server.CreateMarkerForPlayer(playerid, x, y, z, height, radius);
            Server.Markers.Add(ID, this);
        }
        ~Marker()
        {

        }
        /// <summary>
        /// Proper method for disposing the Marker
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Server.DeleteMarker(ID);
            Server.Markers.Remove(ID);
        }
        /// <summary>
        /// The unique ID of the marker
        /// </summary>
        public ulong ID { get; internal set; }
    }
}