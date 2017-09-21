using SharpOrange.Math;
using System;
using System.Collections.Generic;

namespace SharpOrange.Objects
{
    public class Vehicle : IDisposable
    {
        /// <summary>
        /// Creates a new Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="position"></param>
        public Vehicle(VehicleHash model, Vector3 position)
        {
            ID = Server.CreateVehicle((long)model, position.x, position.y, position.z, 0);
            if (ID == 0)
            {
                SharpOrange.Print($"Failed to create vehicle with model {model} | hash {(long)model}!");
                return;
            }
            Hash = (long)model;
            Model = model;
            Server.vehicles.Add(ID, this);
        }

        /// <summary>
        /// Creates a new Vehicle using vehicle hash
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="position"></param>
        public Vehicle(long hash, Vector3 position)
        {
            ID = Server.CreateVehicle(hash, position.x, position.y, position.z, 0);
            if (ID == 0)
            {
                SharpOrange.Print($"Failed to create vehicle with hash {hash}!");
                return;
            }
            Hash = hash;
            Server.vehicles.Add(ID, this);
        }

        ~Vehicle()
        {
            if (!Server.DeleteVehicle(ID))
                SharpOrange.Print($"Failed to delete vehicle! ID: '{ID}', Hash: '{Hash}'");
            Server.vehicles.Remove(ID);
        }

        /// <summary>
        /// Proper vehicle disposition, prevents garbage collector to wrongfully dispose it
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            if (!Server.DeleteVehicle(ID))
                SharpOrange.Print($"Failed to delete vehicle! ID: '{ID}', Hash: '{Hash}'");
            Server.vehicles.Remove(ID);
        }

        /// <summary>
        /// Vehicle ID used for unmanaged usage
        /// </summary>
        public ulong ID { get; }

        /// <summary>
        /// Hash of the vehicle
        /// </summary>
        public long Hash { get; }

        /// <summary>
        /// Get/Set the model of the car
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
        /// Set Pitch, Yaw and Roll
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
        /// Get/Set primary color of vehicle
        /// </summary>
        public byte PrimaryColor
        {
            get
            {
                return Server.GetVehiclePrimaryColor(ID);
            }
            set
            {
                if (!Server.SetVehiclePrimaryColor(ID, value))
                    SharpOrange.Error($"Failed to set PrimaryColor '{value}' of vehicle '{ID}'!");
            }
        }

        /// <summary>
        /// Get/Set secondary color of vehicle
        /// </summary>
        public byte SecondaryColor
        {
            get
            {
                return Server.GetVehicleSecondaryColor(ID);
            }
            set
            {
                if (!Server.SetVehicleSecondaryColor(ID, value))
                    SharpOrange.Error($"Failed to set SecondaryColor '{value}' of vehicle '{ID}'!");
            }
        }

        /// <summary>
        /// Get/Set custom primary color of vehicle
        /// </summary>
        public RGB CustomPrimaryColor
        {
            get
            {
                return Server.GetVehicleCustomPrimaryColor(ID);
            }
            set
            {
                if (!Server.SetVehicleCustomPrimaryColor(ID, value.r, value.g, value.b))
                    SharpOrange.Error($"Failed to set CustomPrimaryColor '{value.r}, {value.g}, {value.b}' of vehicle '{ID}'!");
            }
        }

        /// <summary>
        /// Get/Set custom secondary color of vehicle
        /// </summary>
        public RGB CustomSecondaryColor
        {
            get
            {
                return Server.GetVehicleCustomSecondaryColor(ID);
            }
            set
            {
                if (!Server.SetVehicleCustomSecondaryColor(ID, value.r, value.g, value.b))
                    SharpOrange.Error($"Failed to set CustomSecondaryColor '{value.r}, {value.g}, {value.b}' of vehicle '{ID}'!");
            }
        }

        /// <summary>
        /// Get/Set bulletproof tires to vehicle
        /// </summary>
        public bool BulletproofTires
        {
            get
            {
                return Server.GetVehicleTyresBulletproof(ID);
            }
            set
            {
                if (!Server.SetVehicleTyresBulletproof(ID, value))
                    SharpOrange.Print($"Failed to set Bulletproof Tires to Vehicle '{ID}'!");
            }
        }

        /// <summary>
        /// Get/Set license/number plate style of vehicle
        /// </summary>
        public byte PlateStyle
        {
            get
            {
                return Server.GetVehicleNumberPlateStyle(ID);
            }
            set
            {
                if (!Server.SetVehicleNumberPlateStyle(ID, value))
                    SharpOrange.Print($"Failed to set Plate Style of Vehicle '{ID}'!");
            }
        }

        /// <summary>
        /// Get/Set license/number plate content of vehicle
        /// </summary>
        public string Plate
        {
            get
            {
                return Server.GetVehicleNumberPlate(ID);
            }
            set
            {
                if (!Server.SetVehicleNumberPlate(ID, value))
                    SharpOrange.Print($"Failed to set Plate content of Vehicle '{ID}'!");
            }
        }

        /// <summary>
        /// Get/Set siren state On/Off (True/False)
        /// </summary>
        public bool Sirens
        {
            get
            {
                return Server.GetVehicleSirenState(ID);
            }
            set
            {
                if (!Server.SetVehicleSirenState(ID, value))
                    SharpOrange.Print($"Failed to set Sirens State of Vehicle '{ID}'!");
            }
        }

        /// <summary>
        /// Get/Set vehicle lights state
        /// </summary>
        public byte Lights
        {
            get
            {
                return Server.GetVehicleLights(ID);
            }
            set
            {
                if(!Server.SetVehicleLights(ID, value))
                    SharpOrange.Print($"Failed to set Lights of Vehicle '{ID}'!");
            }
        }

        /// <summary>
        /// Get/Set the vehicle driver
        /// </summary>
        public Player Driver
        {
            get
            {
                Player player;
                Server.Players.TryGetValue(Server.GetVehicleDriver(ID), out player);
                return player;
            }
            set
            {
                if (!Server.SetPlayerIntoVehicle(value.ID, ID, '0'))
                    SharpOrange.Print($"Failed to set Driver of Vehicle '{ID}'!");
            }
        }

        /// <summary>
        /// Returns passengers in a List of Players
        /// </summary>
        public List<Player> Passengers
        {
            get
            {
                List<Player> passengers = new List<Player>();
                uint[] playerids = Server.GetVehiclePassengers(ID);
                foreach(uint playerid in playerids)
                {
                    Player player;
                    Server.Players.TryGetValue(playerid, out player);
                    passengers.Add(player);
                }
                return passengers;
            }
        }
    }
}