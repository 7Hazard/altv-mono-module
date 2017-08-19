namespace SharpOrange
{
    public class SharpOrange
    {
        internal static void Print(string msg)
        {
            Server.Print("[SharpOrange] " + msg);
        }
        internal static void Error(string msg)
        {
            Server.Print("[SharpOrange] ERROR - " + msg);
        }
    }
}
