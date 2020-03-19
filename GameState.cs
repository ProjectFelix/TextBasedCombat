using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedCombat
{
    static class GameState
    {
        public static List<Unit> Mobs = new List<Unit>();
        public static Player Player = new Player();


        public static void CreateUnits()
        {
            Mobs.Add(new Unit("A kobold", 300, new int[] { 5, 10 }));
        }
    }
}
