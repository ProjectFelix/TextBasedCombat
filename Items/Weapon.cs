using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedCombat.Items
{
    class Weapon : Item
    {
        public int[] Damage { get; }
        public string AttackType { get; }

        public Weapon(string name, string slot, int[] dmg, string att_type) : base(name, slot)
        {
            Name = name;
            Slot = slot;
            Damage = dmg;
            AttackType = att_type;
        }
    }
}
