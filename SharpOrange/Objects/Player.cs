using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpOrange.Objects
{
    public class Player : IDisposable
    {
        internal Player(long playerid)
        {
            ID = playerid;
            ClientID = Server.GetPlayerGUID(playerid);
            Server.Players.Add(playerid, this);
        }

        ~Player()
        {
            Server.Players.Remove(ID);
        }
        /// <summary>
        /// USE KICK METHOD AND NOT THIS!
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Server.Players.Remove(ID);
        }
        /// <summary>
        /// The unique ID of the player for it's current session
        /// </summary>
        public long ID { get; }
        /// <summary>
        /// The Client GUID
        /// </summary>
        public ulong ClientID { get; }
        /// <summary>
        /// Get/Set the name of the player
        /// </summary>
        public string Name
        {
            get
            {
                return Server.GetPlayerName(ID);
            }
            set
            {
                Server.SetPlayerName(ID, value);
            }
        }
        /// <summary>
        /// Get/Set position of the player
        /// </summary>
        public Vector3 Position
        {
            get
            {
                return Server.GetPlayerPosition(ID);
            }
            set
            {
                Server.SetPlayerPosition(ID, value.x, value.y, value.z);
            }
        }
        /// <summary>
        /// Get/Set the Z rotation/heading of the player
        /// </summary>
        public float Rotation
        {
            get
            {
                return Server.GetPlayerHeading(ID);
            }
            set
            {
                if (!Server.SetPlayerHeading(ID, value))
                    SharpOrange.Print($"Failed to set Heading for the player '{Name}' ({ID})!");
            }
        }
        /// <summary>
        /// Get/Set the model of the player using the Model name (http://slice.wikidot.com/)
        /// </summary>
        public string Model
        {
            get
            {
                return Server.GetPlayerModel(ID).ToString();
            }
            set
            {
                long hash = Server.Hash(value);
                if (!Server.SetPlayerModel(ID, hash))
                    SharpOrange.Print($"Failed to set Model '{value}' to player '{Name}' ({ID})!");
            }
        }
        /// <summary>
        /// If player is alive
        /// </summary>
        public bool IsAlive { get; internal set; }
        /// <summary>
        /// Get/Set money of player (check below for alternative methods)
        /// </summary>
        public long Money
        {
            get
            {
                return Server.GetPlayerMoney(ID);
            }
            set
            {
                if (!Server.SetPlayerMoney(ID, value))
                    SharpOrange.Print($"Failed to set Money of player '{Name}' ({ID})!");
            }
        }
        /// <summary>
        /// Add money to what the player currently already has
        /// </summary>
        /// <param name="money"></param>
        public void GiveMoney(long money)
        {
            if (!Server.GivePlayerMoney(ID, money))
                SharpOrange.Print($"Failed to Give Money to player '{Name}' ({ID})!");
        }
        /// <summary>
        /// Totally resets the money of the player
        /// </summary>
        public void ResetMoney()
        {
            if (!Server.ResetPlayerMoney(ID))
                SharpOrange.Print($"Failed to Reset Money of player '{Name}' ({ID})!");
        }
        /// <summary>
        /// Get/Set the player's health
        /// </summary>
        public float Health
        {
            get
            {
                return Server.GetPlayerHealth(ID);
            }
            set
            {
                if(!Server.SetPlayerHealth(ID, value))
                    SharpOrange.Print($"Failed to Set Health of player '{Name}' ({ID})!");
            }
        }
        /// <summary>
        /// Get/Set the player's armor
        /// </summary>
        public float Armor
        {
            get
            {
                return Server.GetPlayerArmour(ID);
            }
            set
            {
                if(!Server.SetPlayerArmour(ID, value))
                    SharpOrange.Print($"Failed to Set Armor of player '{Name}' ({ID})!");
            }
        }
        /// <summary>
        /// If player is in a vehicle
        /// </summary>
        public bool IsInVehicle
        {
            get
            {
                if (Vehicle != null) return true;
                else return false;
            }
        }
        /// <summary>
        /// Get the vehicle of the player
        /// </summary>
        public Vehicle Vehicle { get; internal set; }
        /// <summary>
        /// Put player in a vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="seat"></param>
        public void PutInVehicle(Vehicle vehicle, char seat)
        {
            if (!Server.SetPlayerIntoVehicle(ID, vehicle.ID, seat))
                SharpOrange.Print($"Failed to Put player '{Name}' ({ID}) into Vehicle '{vehicle.Model}' ({vehicle.ID})!");
        }
        /// <summary>
        /// If player's HUD is enabled
        /// </summary>
        public bool IsHUDEnabled { get; internal set; }
        /// <summary>
        /// Toggle the player's HUD
        /// </summary>
        public void ToggleHUD()
        {
            if (IsHUDEnabled) Server.DisablePlayerHud(ID, true);
            else Server.DisablePlayerHud(ID, false);
        }
        /// <summary>
        /// Kick the player
        /// </summary>
        public void Kick()
        {
            Server.KickPlayer(ID);
        }
        /// <summary>
        /// Kick the player with a reason
        /// </summary>
        /// <param name="reason"></param>
        public void Kick(string reason)
        {
            Server.KickPlayer(ID, reason);
        }
        /// <summary>
        /// Trigger a client event for the player
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        public void TriggerEvent(string name, params object[] args)
        {
            Client.TriggerEvent(ID, name, args);
        }
        /// <summary>
        /// Send a notification to the player
        /// </summary>
        /// <param name="message"></param>
        public void SendNotification(string message)
        {
            if (!Server.SendNotification(ID, message))
                SharpOrange.Print($"Failed to Send Notification to {Name} ({ID})!");
        }
        /// <summary>
        /// If player has the info message set
        /// </summary>
        public bool HasInfoMessage { get; internal set; }
        /// <summary>
        /// Set InfoMessage, set to null, string.Empty or "" to Unset
        /// </summary>
        public string InfoMessage
        {
            set
            {
                if (value == null || value == string.Empty || value == "")
                {
                    if (!Server.UnsetInfoMsg(ID))
                    {
                        SharpOrange.Print($"Failed to unset Info Message to {Name} ({ID})!");
                        return;
                    }
                    HasInfoMessage = false;
                }
                if (!Server.SetInfoMsg(ID, value))
                {
                    SharpOrange.Print($"Failed to Set Info Message to {Name} ({ID})!");
                    return;
                }
                HasInfoMessage = true;
            }
        }
        /*/// <summary>
        /// Send a client message to the player
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public void SendMessage(string message, uint color)
        {
            if(!Server.SendClientMessage(ID, message, color))
                SharpOrange.Print($"Failed to Send Message '{message}' to {Name} ({ID})!");
        }*/
        /// <summary>
        /// Remove all weapons of the player
        /// </summary>
        public void RemoveWeapons()
        {
            if (!Server.RemovePlayerWeapons(ID))
                SharpOrange.Print($"Failed to Remove Weapons from {Name} ({ID})!");
        }
        /// <summary>
        /// Give a weapon to the player
        /// </summary>
        /// <param name="weapon"></param>
        /// <param name="ammo"></param>
        public void GiveWeapon(WeaponHash weapon, long ammo)
        {
            if (!Server.GivePlayerWeapon(ID, (long)weapon, ammo))
                SharpOrange.Print($"Failed to Give Weapon {weapon} with {ammo} Ammo to {Name} ({ID})!");
        }
        /// <summary>
        /// Give ammo of a specific weapon to the player
        /// </summary>
        /// <param name="weapon"></param>
        /// <param name="ammo"></param>
        public void GiveAmmo(WeaponHash weapon, long ammo)
        {
            if (!Server.GivePlayerAmmo(ID, (long)weapon, ammo))
                SharpOrange.Print($"Failed to Give {ammo} Ammo of {weapon} to {Name} ({ID})!");
        }
    }
}
