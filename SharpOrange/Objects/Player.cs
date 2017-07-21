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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Server.Players.Remove(ID);
        }

        public long ID { get; }
        public ulong ClientID { get; }

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

        // Maybe to be used if models get enum
        /*public long Model
        {
            get
            {
                return Server.GetPlayerModel(ID);
            }
            set
            {
                if (!Server.SetPlayerModel(ID, value))
                    SharpOrange.Print($"Failed to set model '{value}' to player '{Name}' ({ID})!");
            }
        }*/

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
                    SharpOrange.Print($"Failed to set model '{value}' to player '{Name}' ({ID})!");
            }
        }

        public bool IsAlive { get; internal set; }

        public long Money
        {
            get
            {
                return Server.GetPlayerMoney(ID);
            }
            set
            {
                if (!Server.SetPlayerMoney(ID, value))
                    SharpOrange.Print($"Failed to set money of player '{Name}' ({ID})!");
            }
        }
        public void GiveMoney(long money)
        {
            if (!Server.GivePlayerMoney(ID, money))
                SharpOrange.Print($"Failed to give money to player '{Name}' ({ID})!");
        }
        public void ResetMoney()
        {
            if (!Server.ResetPlayerMoney(ID))
                SharpOrange.Print($"Failed to reset money of player '{Name}' ({ID})!");
        }

        public float Health
        {
            get
            {
                return Server.GetPlayerHealth(ID);
            }
            set
            {
                if(!Server.SetPlayerHealth(ID, value))
                    SharpOrange.Print($"Failed to set health of player '{Name}' ({ID})!");
            }
        }

        public float Armor
        {
            get
            {
                return Server.GetPlayerArmour(ID);
            }
            set
            {
                if(!Server.SetPlayerArmour(ID, value))
                    SharpOrange.Print($"Failed to set armor of player '{Name}' ({ID})!");
            }
        }

        public uint Color
        {
            get
            {
                return Server.GetPlayerColor(ID);
            }
            set
            {
                if(!Server.SetPlayerColor(ID, value))
                    SharpOrange.Print($"Failed to set color of player '{Name}' ({ID})!");
            }
        }

        public bool IsInVehicle
        {
            get
            {
                if (Vehicle != null) return true;
                else return false;
            }
        }

        public Vehicle Vehicle { get; internal set; }
        public void PutInVehicle(Vehicle vehicle, char seat)
        {
            if (!Server.SetPlayerIntoVehicle(ID, vehicle.ID, seat))
                SharpOrange.Print($"Failed to put player '{Name}' ({ID}) into vehicle '{vehicle.Model}' ({vehicle.ID})!");
        }

        public bool IsHUDEnabled { get; internal set; }
        public void ToggleHUD()
        {
            if (IsHUDEnabled) Server.DisablePlayerHud(ID, true);
            else Server.DisablePlayerHud(ID, false);
        }

        public void Kick()
        {
            Server.KickPlayer(ID);
        }

        public void Kick(string reason)
        {
            Server.KickPlayer(ID, reason);
        }

        public void TriggerEvent(string name, object[] args)
        {
            Client.TriggerEvent(ID, name, args);
        }

        public void SendNotification(string message)
        {
            if (!Server.SendNotification(ID, message))
                SharpOrange.Print($"Failed to send notification to {Name} ({ID})!");
        }

        public bool HasInfoMessage { get; internal set; }
        public void SetInfoMessage(string message)
        {
            if (!Server.SetInfoMsg(ID, message))
            {
                SharpOrange.Print($"Failed to set InfoMessage to {Name} ({ID})!");
                return;
            }
            HasInfoMessage = true;
        }
        public void UnsetInfoMessage()
        {
            if (!Server.UnsetInfoMsg(ID))
            {
                SharpOrange.Print($"Failed to unset InfoMessage to {Name} ({ID})!");
                return;
            }
            HasInfoMessage = false;
        }
        public void SendMessage(string message, uint color)
        {
            if(!Server.SendClientMessage(ID, message, color))
                SharpOrange.Print($"Failed to send Message '{message}' to {Name} ({ID})!");
        }

        public void RemoveWeapons()
        {
            if (!Server.RemovePlayerWeapons(ID))
                SharpOrange.Print($"Failed to remove weapons from {Name} ({ID})!");
        }

        public void GiveWeapon(WeaponHash weapon, long ammo)
        {
            if (!Server.GivePlayerWeapon(ID, (long)weapon, ammo))
                SharpOrange.Print($"Failed to give weapon {weapon} with {ammo} ammo to {Name} ({ID})!");
        }

        public void GiveAmmo(WeaponHash weapon, long ammo)
        {
            if (!Server.GivePlayerAmmo(ID, (long)weapon, ammo))
                SharpOrange.Print($"Failed to give {ammo} ammo of {weapon} to {Name} ({ID})!");
        }
    }
}
