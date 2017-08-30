using System;

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

        public Vector3(Vector3 vector)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
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
        /// Gets the reversed direction of the vector.
        /// </summary>
        /// <returns>The vector facing in the opposite direction.</returns>
        public Vector3 negative()
        {
            return new Vector3(-x, -y, -z);
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
        /// Calculates the distance between another vector.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public float distance(Vector3 vector)
        {
            float x = this.x - vector.x;
            float y = this.y - vector.y;
            float z = this.z - vector.z;
            return (float)System.Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        /// <summary>
        /// Calculates the distance between two vectors.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static float Distance(Vector3 first, Vector3 second)
        {
            float x = first.x - second.x;
            float y = first.y - second.y;
            float z = first.z - second.z;
            return (float)System.Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        /// <summary>
        /// Shorthand for writing Vector3(0, 0, 0).
        /// </summary>
        /// <returns></returns>
        public static Vector3 Zero()
        {
            return new Vector3(0, 0, 0);
        }

        /// <summary>
        /// Shorthand for writing Vector3(1, 1, 1).
        /// </summary>
        /// <returns></returns>
        public static Vector3 One()
        {
            return new Vector3(1, 1, 1);
        }

        /// <summary>
        /// Shorthand for writing Vector3(0, 0, 1).
        /// </summary>
        /// <returns></returns>
        public static Vector3 Forward()
        {
            return new Vector3(0, 0, 1);
        }

        /// <summary>
        /// Shorthand for writing Vector3(0, 0, -1).
        /// </summary>
        /// <returns></returns>
        public static Vector3 Back()
        {
            return new Vector3(0, 0, -1);
        }

        /// <summary>
        /// Shorthand for writing Vector3(0, -1, 0).
        /// </summary>
        public static Vector3 Down()
        {
            return new Vector3(0, -1, 0);
        }

        /// <summary>
        /// Shorthand for writing Vector3(0, 1, 0).
        /// </summary>
        /// <returns></returns>
        public static Vector3 Up()
        {
            return new Vector3(0, 1, 0);
        }

        /// <summary>
        /// Shorthand for writing Vector3(-1, 0, 0).
        /// </summary>
        /// <returns></returns>
        public static Vector3 Left()
        {
            return new Vector3(-1, 0, 0);
        }

        /// <summary>
        /// Shorthand for writing Vector3(1, 0, 0).
        /// </summary>
        /// <returns></returns>
        public static Vector3 Right()
        {
            return new Vector3(1, 0, 0);
        }
    }
}
