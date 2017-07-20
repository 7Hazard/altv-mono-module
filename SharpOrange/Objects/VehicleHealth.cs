namespace SharpOrange.Objects
{
    public class VehicleHealth
    {
        public float body, engine, tank;
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
