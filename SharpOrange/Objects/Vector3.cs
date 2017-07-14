using System;
using System.Collections.Generic;
using System.Text;

namespace SharpOrange.Objects
{
    public struct Vector3
    {
        public float x, y, z;
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
    }
}
