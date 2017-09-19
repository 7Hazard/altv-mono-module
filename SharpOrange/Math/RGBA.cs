using System;

namespace SharpOrange.Math
{
    public class RGBA
    {
        public readonly byte r, g, b, a;
        /// <summary>
        /// Create an RGBA color object
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        public RGBA(byte r, byte g, byte b, byte a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
            
            Hex = r.ToString("X2") + g.ToString("X2") + b.ToString("X2") + a.ToString("X2");
            try
            {
                UInt = uint.Parse(Hex, System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception)
            {
                SharpOrange.Error($"Failed to convert RGBA '{Hex}' to uint!");
                UInt = 0xFFFFFF;
            }
        }

        /// <summary>
        /// Int value (from hex)
        /// </summary>
        public readonly uint UInt;

        /// <summary>
        /// Hex value in format RRGGBB
        /// </summary>
        public readonly string Hex;
    }
}