namespace SharpOrange.Math
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

        /*public static implicit operator Vector3(double value)
        {
            return new Vector3(value);
        }*/

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return new Vector3(left.x + right.x, left.y + right.y, left.z + left.z);
        }

        /// <summary>
        /// Perform a component-wise addition
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector3 operator +(Vector3 left, float right)
        {
            return new Vector3(left.x + right, left.y + right, left.z + right);
        }

        /// <summary>
        /// Subtract vector by vector
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return new Vector3(left.x + right.x, left.y + right.y, left.z + right.z);
        }

        /// <summary>
        /// Perform a component-wise subtraction
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 left, float right)
        {
            return new Vector3(left.x - right, left.y - right, left.z - right);
        }

        /// <summary>
        /// Perform a component-wise subtraction
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector3 operator -(float left, Vector3 right)
        {
            return new Vector3(left - right.x, left - right.y, left - right.z);
        }

        /// <summary>
        /// Scales a vector by the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Vector3 operator *(Vector3 value, float scale)
        {
            return new Vector3(value.x * scale, value.y * scale, value.z * scale);
        }

        /// <summary>
        /// Multiplies a vector with another by performing component-wise multiplication.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector3 operator *(Vector3 left, Vector3 right)
        {
            return new Vector3(left.x * right.x, left.y * right.y, left.z * right.z);
        }

        /// <summary>
        /// Scales a vector by the given value.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Vector3 operator /(Vector3 left, float scale)
        {
            return new Vector3(left.x / scale, left.y / scale, left.z / scale);
        }

        /// <summary>
        /// Reverses the direction of a given vector.
        /// </summary>
        /// <param name="value">The vector to negate.</param>
        /// <returns>A vector facing in the opposite direction.</returns>
        public static Vector3 Negate(Vector3 value)
        {
            return new Vector3(-value.x, -value.y, -value.z);
        }

        /// <summary>
        /// Gets the negated vector
        /// </summary>
        /// <returns>The vector facing in the opposite direction.</returns>
        public Vector3 Negative()
        {
            return new Vector3(-x, -y, -z);
        }
    }
}
