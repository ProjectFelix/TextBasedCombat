using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedCombat.Items
{
    abstract class Item
    {
        public string Name { get; set; }
        public string Slot { get; set; }
        public string Description { get; set; }

        public Item(string name, string slot)
        {
            Name = name;
            Slot = slot;
        }
    }
}
