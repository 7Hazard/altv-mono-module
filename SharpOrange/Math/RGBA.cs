namespace SharpOrange.Math
{
    public class RGBA
    {
        public byte r, g, b, a;
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

            hex = int.Parse(r.ToString("X2") + g.ToString("X2") + b.ToString("X2"));
        }

        /// <summary>
        /// Hex value in RRGGBBAA format
        /// </summary>
        public int hex;
    }
}