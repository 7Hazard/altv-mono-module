namespace SharpOrange.Math
{
    public class Vector2
    {
        public float x, y;
        /// <summary>
        /// Create a 3 value Vector, primarily used for positions and rotations
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(float[] pos)
        {
            x = pos[0];
            y = pos[1];
        }

        public Vector2(double x, double y)
        {
            this.x = (float)x;
            this.y = (float)y;
        }

        public Vector2(Vector2 pos)
        {
            x = pos.x;
            y = pos.y;
        }

        /*public static implicit operator Vector2(double value)
        {
            return new Vector2(value);
        }*/

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x + right.x, left.y + right.y);
        }

        /// <summary>
        /// Perform a component-wise addition
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator +(Vector2 left, float right)
        {
            return new Vector2(left.x + right, left.y + right);
        }

        /// <summary>
        /// Perform a component-wise addition
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x + right.x, left.y + right.y);
        }

        /// <summary>
        /// Perform a component-wise subtraction
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator -(Vector2 left, float right)
        {
            return new Vector2(left.x - right, left.y - right);
        }

        /// <summary>
        /// Perform a component-wise subtraction
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator -(float left, Vector2 right)
        {
            return new Vector2(left - right.x, left - right.y);
        }

        /// <summary>
        /// Scales a vector by the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Vector2 operator *(Vector2 value, float scale)
        {
            return new Vector2(value.x * scale, value.y * scale);
        }

        /// <summary>
        /// Multiplies a vector with another by performing component-wise multiplication.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator *(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x * right.x, left.y * right.y);
        }

        /// <summary>
        /// Scales a vector by the given value.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Vector2 operator /(Vector2 left, float scale)
        {
            return new Vector2(left.x / scale, left.y / scale);
        }

        /// <summary>
        /// Reverses the direction of a given vector.
        /// </summary>
        /// <param name="value">The vector to negate.</param>
        /// <returns>A vector facing in the opposite direction.</returns>
        public static Vector2 Negate(Vector2 value)
        {
            return new Vector2(-value.x, -value.y);
        }
    }
}
