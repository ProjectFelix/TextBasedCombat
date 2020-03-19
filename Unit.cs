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

        public Unit(string name, int health, int[] damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
    }
}
