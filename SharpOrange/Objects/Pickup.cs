﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpOrange.Objects
{
    public static class Pickup
    {
        /// <summary>
        /// Create a pickup
        /// </summary>
        /// <param name="pickup"></param>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        public static void Create(PickupHash pickup, Vector3 position, float scale)
        {
            Server.CreatePickup((long)pickup, position.x, position.y, position.z, scale);
        }
    }
}
