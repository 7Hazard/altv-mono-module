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
            Server.Players.Add(playerid, this);
            // DEBUG
            SharpOrange.Print($"PLAYER ID {ID}");
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
        public long Model
        {
            get
            {
                return Server.GetPlayerModel(ID);
            }
            set
            {
                Server.SetPlayerModel(ID, value);
            }
        }

        public bool IsAlive { get; internal set; }
        public bool IsInVehicle
        {
            get
            {
                if (Vehicle != null) return true;
                else return false;
            }
        }
        public Vehicle Vehicle { get; internal set; }

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
        public void GiveWeapon(WeaponHash weapon, long ammo)
        {
            if (!Server.GivePlayerWeapon(ID, (long)weapon, ammo))
                SharpOrange.Print($"Failed to give weapon {weapon} with {ammo} ammo to {Name}");
        }
        public void GiveAmmo(WeaponHash weapon, long ammo)
        {
            if (!Server.GivePlayerAmmo(ID, (long)weapon, ammo))
                SharpOrange.Print($"Failed to give {ammo} ammo of {weapon} to {Name}");
        }
        public void RemoveWeapons()
        {
            if (!Server.RemovePlayerWeapons(ID))
                SharpOrange.Print($"Failed to remove weapons from {Name}");
        }
    }
}
