using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedCombat.Items
{
    class Armor : Item
    {
        public int ArmorValue { get; }
        public int DodgeChance { get; }
        public int BlockChance { get; }

        public Armor(string name, string slot, int armorValue, int dodgeChance, int blockChance) : base(name, slot)
        {
            Name = name;
            Slot = slot;
            ArmorValue = ArmorValue;
            DodgeChance = dodgeChance;
            BlockChance = blockChance;
        }
    }
}
