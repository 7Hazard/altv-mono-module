using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpOrange.Objects
{
    /// <summary>
    /// Vehicle object which is automatically added to Server.Vehicles dictionary.
    /// </summary>
    public class Vehicle : IDisposable
    {
        /// <summary>
        /// Creates a new Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="position"></param>
        public Vehicle(VehicleHash vehicle, Vector3 position)
        {
            ID = Server.CreateVehicle(vehicle, position.x, position.y, position.z, 0);
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
        /// <summary>
        /// Proper vehicle disposition, prevents Garbage collection to wrongfully dispose it
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            if (!Server.DeleteVehicle(ID))
                SharpOrange.Print($"Failed to delete vehicle! ID: '{ID}', Model: '{Model}'");
            Server.Vehicles.Remove(ID);
        }
        /// <summary>
        /// Vehicle ID used for unmanaged usage
        /// </summary>
        public ulong ID { get; }
        /// <summary>
        /// Model of the vehicle
        /// </summary>
        public VehicleHash Model { get; }
        /// <summary>
        /// Get/Set Vehicle position
        /// </summary>
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
        /// <summary>
        /// Set Yaw, Pitch and Roll
        /// </summary>
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
        /// <summary>
        /// Get/Set lock state of vehicle
        /// </summary>
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
        /// <summary>
        /// Get/Set health of vehicle
        /// </summary>
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
        /// <summary>
        /// Get/Set Primary Color of Vehicle
        /// </summary>
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
        /// <summary>
        /// Get/Set Secondary Color of Vehicle
        /// </summary>
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
