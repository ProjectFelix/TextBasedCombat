﻿using System;
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
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentMana { get; set; }
        public int MaxMana { get; set; }
        public int[] Damage { get; set; }
        public bool inCombat { get; set; }
        public int NumAttacks { get; set; }
        public Unit Targeting { get; set; }
        public Room CurrentRoom { get; set; }
        public List<Item> Inventory { get; set; }
        public int Armor { get; set; }
        public int DodgeChance { get; set; }
        public float CritChance { get; set; }
        public Dictionary<string, Item> EquippedItems { get; set; } = new Dictionary<string, Item>
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
