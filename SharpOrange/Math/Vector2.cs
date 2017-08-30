using System;

namespace SharpOrange.Math
{
    public class Vector2
    {
        public float x, y;
        /// <summary>
        /// Create a 2 value Vector
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

        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x + right.x, left.y + right.y);
        }
        
        public static Vector2 operator +(Vector2 left, float right)
        {
            return new Vector2(left.x + right, left.y + right);
        }
        
        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x + right.x, left.y + right.y);
        }
        
        public static Vector2 operator -(Vector2 left, float right)
        {
            return new Vector2(left.x - right, left.y - right);
        }
        
        public static Vector2 operator -(float left, Vector2 right)
        {
            return new Vector2(left - right.x, left - right.y);
        }
        
        public static Vector2 operator *(Vector2 value, float scale)
        {
            return new Vector2(value.x * scale, value.y * scale);
        }
        
        public static Vector2 operator *(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x * right.x, left.y * right.y);
        }
        
        public static Vector2 operator /(Vector2 left, float scale)
        {
            return new Vector2(left.x / scale, left.y / scale);
        }

        /// <summary>
        /// Gets the reversed direction of the vector.
        /// </summary>
        /// <returns>The vector facing in the opposite direction.</returns>
        public Vector2 negative()
        {
            return new Vector2(-x, -y);
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

        /// <summary>
        /// Calculates the distance between another vector.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public float distance(Vector2 vector)
        {
            float x = this.x - vector.x;
            float y = this.y - vector.y;
            return (float)System.Math.Sqrt((x * x) + (y * y));
        }

        /// <summary>
        /// Calculates the distance between two vectors.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static float Distance(Vector2 first, Vector2 second)
        {
            float x = first.x - second.x;
            float y = first.y - second.y;
            return (float)System.Math.Sqrt((x * x) + (y * y));
        }

        /// <summary>
        /// Shorthand for writing Vector2(0, 0).
        /// </summary>
        /// <returns></returns>
        public static Vector2 Zero()
        {
            return new Vector2(0, 0);
        }

        /// <summary>
        /// Shorthand for writing Vector2(1, 1).
        /// </summary>
        /// <returns></returns>
        public static Vector2 One()
        {
            return new Vector2(1, 1);
        }

        /// <summary>
        /// Shorthand for writing Vector2(0, -1).
        /// </summary>
        public static Vector2 Down()
        {
            return new Vector2(0, -1);
        }

        /// <summary>
        /// Shorthand for writing Vector2(0, 1).
        /// </summary>
        /// <returns></returns>
        public static Vector2 Up()
        {
            return new Vector2(0, 1);
        }

        /// <summary>
        /// Shorthand for writing Vector2(-1, 0).
        /// </summary>
        /// <returns></returns>
        public static Vector2 Left()
        {
            return new Vector2(-1, 0);
        }

        /// <summary>
        /// Shorthand for writing Vector2(1, 0).
        /// </summary>
        /// <returns></returns>
        public static Vector2 Right()
        {
            return new Vector2(1, 0);
        }
    }
}
