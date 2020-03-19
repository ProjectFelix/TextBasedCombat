using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedCombat.World
{
    class Node
    {
        public Room Room;
        public List<Room> Links;

        public Node(Room room)
        {
            Room = room;
            Links = new List<Room>();
        }

        public void AddConnection(Room room)
        {
            Links.Add(room);
        }

        public void DisplayExits()
        {
            Console.WriteLine("Connected rooms:");
            foreach (Room room in Links)
            {
                Console.WriteLine($"-{room.RoomName}");
            }
        }
    }
}
