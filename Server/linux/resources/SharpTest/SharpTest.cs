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
			Server.Print(player.Name);
            throw new Exception("JIZZ MAN");
            Server.Print(player.Name);
		}
	}
}

