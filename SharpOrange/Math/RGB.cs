﻿namespace SharpOrange.Math
{
    public struct RGB
    {
        public byte r, g, b;
        /// <summary>
        /// Create an RGB color object
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        public RGB(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;

            hex = int.Parse(r.ToString("X2") + g.ToString("X2") + b.ToString("X2"));
        }

        /// <summary>
        /// Hex value in RRGGBB format
        /// </summary>
        public int hex;
    }
}
