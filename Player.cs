using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedCombat.World;

namespace TextBasedCombat
{
    class Player
    {
        public int CurrentHealth;
        public int MaxHealth;
        public int[] Damage;
        public bool inCombat;
        public Unit Targeting;
        public Room CurrentRoom;

        public Player()
        {
            CurrentHealth = 400;
            MaxHealth = 400;
            Damage = new int[] { 6, 12 };
            inCombat = false;
        }

        public void DisplayPrompt()
        {
            Console.WriteLine($"\n<{CurrentHealth}/{MaxHealth} hp>");
        }

    }
}
