﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedCombat.World;

namespace TextBasedCombat
{
    static class GameState
    {
        public static List<Unit> Mobs = new List<Unit>();
        public static Player Player = new Player();
        public static bool IsPlaying = true;

        public static void GameInit()
        {
            
            Map.MapInit();
            Player.CurrentRoom = Map.Rooms[0].Room;
            CreateUnits();
        }


        public static void CreateUnits()
        {
            Player.CurrentRoom.Mobs.Add(new Unit("A kobold", 300, new int[] { 5, 10 }, "A kobold is here, growling as it looks you up and down."));
            Player.CurrentRoom.Mobs.Add(new Unit("A spider", 100, new int[] { 2, 4 }, "A small spider peeks out from behind a dusty book."));
            Player.CurrentRoom.Mobs.Add(new Unit("The Kobold King", 500, new int[] { 19, 30 }, "The Kobold King stands in the corner, dripping in blood and frothing with rage."));

        }
    }
}
