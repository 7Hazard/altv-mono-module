namespace SharpOrange.Structs
{
    public struct VehicleHealth
    {
        public float body, engine, tank;
        /// <summary>
        /// Create a VehicleHealth info object
        /// </summary>
        /// <param name="body"></param>
        /// <param name="engine"></param>
        /// <param name="tank"></param>
        public VehicleHealth(float body, float engine, float tank)
        {
            this.body = body;
            this.engine = engine;
            this.tank = tank;
        }

        public VehicleHealth(float[] health)
        {
            body = health[0];
            engine = health[1];
            tank = health[2];
        }

        public VehicleHealth(double body, double engine, double tank)
        {
            this.body = (float)body;
            this.engine = (float)engine;
            this.tank = (float)tank;
        }

        public VehicleHealth(VehicleHealth health)
        {
            body = health.body;
            engine = health.engine;
            tank = health.tank;
        }
    }
}