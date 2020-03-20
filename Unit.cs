using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedCombat
{
    class Unit 
    {
        public string Name;
        public int Health;
        public int[] Damage;
        public string RoomDesc;
        public int NumAttacks;

        public Unit(string name, int health, int[] damage, string roomDesc)
        {
            Name = name;
            Health = health;
            Damage = damage;
            RoomDesc = roomDesc;
            NumAttacks = 2;
        }

    }
}
