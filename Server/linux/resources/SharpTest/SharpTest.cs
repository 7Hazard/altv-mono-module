using System;
using SharpOrange;
using SharpOrange.Math;

namespace SharpTest
{
	public class SharpTest
	{
		public SharpTest ()
		{
			Server.Print ("SHARPTEST STARTED");

			Event.OnPlayerConnect += Event_OnPlayerConnect;
		}

		void Event_OnPlayerConnect (SharpOrange.Objects.Player player)
		{
			Server.Print ("PLAYER CONNECTED");
			//Vector3 pos = player.Position;
			//player.Position = new Vector3(pos.x, pos.y, pos.z+1000);
			player.Position = new Vector3(100, 100, 100);
		}
	}
}

