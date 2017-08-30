using System;
using System.Collections.Generic;
using System.Text;

namespace SharpOrange.Objects
{
    public struct Vector3
    {
        public float x, y, z;
        /// <summary>
        /// Create a 3 value Vector, primarily used for positions and rotations
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(float[] pos)
        {
            x = pos[0];
            y = pos[1];
            z = pos[2];
        }

        public Vector3(double x, double y, double z)
        {
            this.x = (float)x;
            this.y = (float)y;
            this.z = (float)z;
        }

        public Vector3(Vector3 pos)
        {
            x = pos.x;
            y = pos.y;
            z = pos.z;
        }
    }
}
