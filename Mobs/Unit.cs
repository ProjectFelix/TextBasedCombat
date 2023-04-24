using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedCombat
{
    public class Unit 
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int[] Damage { get; set; }
        public string RoomDesc { get; set; }
        public int NumAttacks { get; set; }
        public float Delay { get; set; }

        public Unit(string name, int health, int[] damage, string roomDesc)
        {
            Name = name;
            Health = health;
            Damage = damage;
            RoomDesc = roomDesc;
            NumAttacks = 2;
            Delay = 1.5f;
        }

    }
}
