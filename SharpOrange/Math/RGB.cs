using System;

namespace SharpOrange.Math
{
    public struct RGB
    {
        public readonly byte r, g, b;
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

            Hex = r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
            try
            {
                Int = int.Parse(Hex, System.Globalization.NumberStyles.HexNumber);
            } catch (Exception)
            {
                SharpOrange.Error($"Failed to convert RGB '{Hex}' to int!");
                Int = 0xFFFFFF;
            }
        }

        /// <summary>
        /// Int value (from hex)
        /// </summary>
        public readonly int Int;

        /// <summary>
        /// Hex value in format RRGGBB
        /// </summary>
        public readonly string Hex;
    }
}
