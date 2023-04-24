using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedCombat.World
{
    public static class Map
    {
        // Im thinking about using a graph to create a map the player can navigate through
        // Just going to start off with basic rooms for now, though.
        public static List<Node> Rooms = new List<Node>();


        public static void MapInit()
        {
            Node first = new Node(new Room("Library", "You stand in a large, open room, towering bookshelves filled with dusty tomes reach high into the hazy darkness. Cobwebs stretch across vacant corners and shelves, their inhabitants eerily missing from this nightmarish landscape."));
            Console.WriteLine("First room created");
            Rooms.Add(first);
        }
    }
}
