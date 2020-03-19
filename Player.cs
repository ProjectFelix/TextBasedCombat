using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedCombat
{
    class Player
    {
        public int CurrentHealth;
        public int MaxHealth;
        public int[] Damage;
        public bool inCombat;
        public Unit Targeting;

        public Player()
        {
            CurrentHealth = 400;
            MaxHealth = 400;
            Damage = new int[] { 6, 12 };
            inCombat = false;
        }

    }
}
