using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedCombat.World;
using TextBasedCombat.Items;

namespace TextBasedCombat
{
    class Player
    {
        public int CurrentHealth;
        public int MaxHealth;
        public int CurrentMana;
        public int MaxMana;
        public int[] Damage;
        public bool inCombat;
        public int NumAttacks;
        public Unit Targeting;
        public Room CurrentRoom;
        public List<Item> Inventory;
        public int Armor;
        public int DodgeChance;
        public float CritChance;
        public Dictionary<string, Item> EquippedItems = new Dictionary<string, Item>
        {
            {"Head", null },
            {"Chest", null },
            {"Hands", null },
            {"Legs", null },
            {"Feet", null },
            {"Mainhand", null },
            {"Offhand", null }
        };

        public Player()
        {
            CurrentHealth = 400;
            MaxHealth = 400;
            CurrentMana = 300;
            MaxMana = 300;
            Damage = new int[] { 6, 12 };
            inCombat = false;
            NumAttacks = 2;
            Inventory = new List<Item>();
            Armor = 2;
            DodgeChance = 0;
            CritChance = 5;
        }

        public void DisplayPrompt()
        {
            Console.WriteLine($"\n<{CurrentHealth}/{MaxHealth} hp>");
        }

        public void AddItemToInventory(Item item)
        {
            Inventory.Add(item);
        }

        public void DisplayInventory()
        {
            Console.WriteLine("Current inventory:");
            foreach (Item item in Inventory)
            {
                Console.WriteLine($"{item.Name}");
            }
        }

        public void EquipItem(Item item) 
        {
            
            if (EquippedItems[item.Slot] != null) AddItemToInventory(EquippedItems[item.Slot]);
            EquippedItems[item.Slot] = item;
            Inventory.Remove(item);
            
        }

        public void DisplayEquipment()
        {
            Console.WriteLine("Equipped items:");
            foreach (KeyValuePair<string, Item> item in EquippedItems)
            {
                if (item.Value != null) Console.WriteLine($"{item.Key}: {item.Value.Name}");
            }
        }

    }
}
