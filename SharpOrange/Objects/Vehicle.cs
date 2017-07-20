using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpOrange.Objects
{
    public class Vehicle : IDisposable
    {
        public Vehicle(VehicleHash vehicle, Vector3 position)
        {
            ID = Server.CreateVehicle(vehicle, position.x, position.y, position.z);
            if (ID == 0)
            {
                SharpOrange.Print($"Failed to create vehicle with model {vehicle}!");
                return;
            }
            Model = vehicle;
            Server.Vehicles.Add(ID, this);
        }
        ~Vehicle()
        {
            if (!Server.DeleteVehicle(ID))
                SharpOrange.Print($"Failed to delete vehicle! ID: '{ID}', Model: '{Model}'");
            Server.Vehicles.Remove(ID);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            if (!Server.DeleteVehicle(ID))
                SharpOrange.Print($"Failed to delete vehicle! ID: '{ID}', Model: '{Model}'");
            Server.Vehicles.Remove(ID);
        }

        public ulong ID { get; }
        public VehicleHash Model { get; }
        public Vector3 Position
        {
            get
            {
                return Server.GetVehiclePosition(ID);
            }
            set
            {
                if(!Server.SetVehiclePosition(ID, value.x, value.y, value.z))
                    SharpOrange.Error($"Failed to set Position of vehicle '{ID}'!");
            }
        }

        public Vector3 Rotation
        {
            get
            {
                return Server.GetVehicleRotation(ID);
            }
            set
            {
                if(!Server.SetVehicleRotation(ID, value.x, value.y, value.z))
                    SharpOrange.Error($"Failed to set Rotation of vehicle '{ID}'!");
            }
        }

        public bool Locked
        {
            get
            {
                return Server.IsVehicleLocked(ID);
            }
            set
            {
                if(!Server.SetVehicleLocked(ID, value))
                    SharpOrange.Error($"Failed to Lock vehicle ID '{ID}'!");
            }
        }

        public VehicleHealth Health
        {
            get
            {
                return Server.GetVehicleHealth(ID);
            }
            set
            {
                if (!Server.SetVehicleBodyHealth(ID, value.body))
                    SharpOrange.Error($"Failed to set VehicleBodyHealth of vehicle ID '{ID}'!");
                if (!Server.SetVehicleEngineHealth(ID, value.engine))
                    SharpOrange.Error($"Failed to set VehicleEngineHealth of vehicle ID '{ID}'!");
                if (!Server.SetVehicleTankHealth(ID, value.tank))
                    SharpOrange.Error($"Failed to set VehicleTankHealth of vehicle ID '{ID}'!");
            }
        }

        public RGB PrimaryColor
        {
            get
            {
                return Server.GetVehiclePrimaryColor(ID);
            }
            set
            {
                if (!Server.SetVehiclePrimaryColor(ID, value.r, value.g, value.b))
                    SharpOrange.Error($"Failed to set PrimaryColor of vehicle '{ID}'!");
            }
        }

        public RGB SecondaryColor
        {
            get
            {
                return Server.GetVehicleSecondaryColor(ID);
            }
            set
            {
                if (!Server.SetVehicleSecondaryColor(ID, value.r, value.g, value.b))
                    SharpOrange.Error($"Failed to set PrimaryColor of vehicle '{ID}'!");
            }
        }
    }
}
