using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedCombat.World
{
    public class Room
    {
        public string RoomName { get; }
        public string Description { get; }
        public List<Unit> Mobs;

        public Room(string name, string desc)
        {
            RoomName = name;
            Description = FormatDescription(desc);
            Mobs = new List<Unit>();
        }

        public static string FormatDescription(string desc)
        {
            int rowLength = 60;
            int currentPos = 0;
            StringBuilder sb = new StringBuilder(desc);
            for (int i = 0; i < sb.Length; i++)
            {
                currentPos++;
                if (sb[i] == ' ' && currentPos >= rowLength)
                {
                    sb.Insert(i + 1, "\n");
                    currentPos = 0;
                }
            }
            return sb.ToString();
        }

        public void PrintDesc()
        {
            Console.WriteLine($"\n| {RoomName}");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine(Description);
            Console.WriteLine("\n");
            foreach (Unit mob in Mobs)
            {
                Console.WriteLine(mob.RoomDesc);
            }
        }

        public void AddMob(Unit mob)
        {
            Mobs.Add(mob);
        }

    }
}
