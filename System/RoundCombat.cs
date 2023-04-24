using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TextBasedCombat
{
    static class RoundCombat
    {
        public static Unit Enemy { get; set; }
        public static Thread CombatThread { get; set; }

        public static void SpawnCombatThread(Unit mob)
        {
            Enemy = mob;
            CombatThread = new Thread(new ThreadStart(EnterCombat));
            //Console.WriteLine("Spawning thread.");
            CombatThread.Start();

        }

        public static void EnterCombat()
        {
            //Console.WriteLine("In combat thread.\n");
            Random rand = new Random();
            Player you = GameState.Player;
            you.inCombat = true;
            while (GameState.Player.inCombat)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                for (int a = 0; a < you.NumAttacks; a++)
                {
                    int dmg = rand.Next(you.Damage[0], you.Damage[1]);
                    Console.WriteLine($"You hit {Enemy.Name} for {dmg} points of damage!");
                    Enemy.Health -= dmg;
                    if (Enemy.Health <= 0)
                    {
                        Console.WriteLine($"You killed {Enemy.Name}!");
                        you.inCombat = false;
                        GameState.Player.CurrentRoom.Mobs.Remove(Enemy);
                        Enemy = null;
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                }
                if (!GameState.Player.inCombat) break;
                Console.ForegroundColor = ConsoleColor.Red;
                for (int a = 0; a < Enemy.NumAttacks; a++)
                {
                    int dmg = rand.Next(Enemy.Damage[0], Enemy.Damage[1]);
                    Console.WriteLine($"{Enemy.Name} hits YOU for {dmg} points of damage!");
                    you.CurrentHealth -= dmg;
                    if (you.CurrentHealth < 1)
                    {
                        Console.WriteLine($"{Enemy.Name} has killed you!");
                        you.inCombat = false;
                        Console.ForegroundColor = ConsoleColor.White;
                        GameState.IsPlaying = false;
                        Enemy = null;
                        Console.WriteLine(" You are DEAD. Game over.");
                        break;
                    }
                    
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\nYou: <{you.CurrentHealth}/{you.MaxHealth} hp> Enemy: <{Enemy.Health} hp>\n");
                Thread.Sleep(2400);
            }
            GameState.Player.DisplayPrompt();
        }

        // Everything below is for delay-based combat. Switch the methods in the "kill" case to see this.
        static void MyCombat()
        {
            Random rand = new Random();
            Player you = GameState.Player;
            Unit enemy = you.Targeting;
            while (you.inCombat)
            {
                int dmg = rand.Next(you.Damage[0], you.Damage[1]);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nYou attack {enemy.Name} for {dmg} points of damage.");
                enemy.Health -= dmg;
                if (enemy.Health <= 0)
                {
                    Console.WriteLine($"You killed {enemy.Name}!");
                    you.inCombat = false;
                    you.Targeting = null;
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"You: <{you.CurrentHealth}/{you.MaxHealth} hp> Enemy: <{enemy.Health}>");
                Thread.Sleep(2000);
            }
        }

        static void NPCCombat()
        {
            Random rand = new Random();
            Player you = GameState.Player;
            Unit enemy = you.Targeting;
            Thread.Sleep(100); // Just putting this in to stop the first few lines from running synchronously
            while (you.inCombat)
            {
                int dmg = rand.Next(enemy.Damage[0], enemy.Damage[1]);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{enemy.Name} hits YOU for {dmg} points of damage!");
                you.CurrentHealth -= dmg;
                if (you.CurrentHealth < 1)
                {
                    Console.WriteLine($"{enemy.Name} has killed you!");
                    you.inCombat = false;
                    you.Targeting = null;
                    Console.ForegroundColor = ConsoleColor.White;
                    GameState.IsPlaying = false;
                    Console.WriteLine(" You are DEAD. Game over.");
                    return;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"You: <{you.CurrentHealth}/{you.MaxHealth} hp> Enemy: <{enemy.Health}>");
                Thread.Sleep(2400);
                //Console.WriteLine("Done waiting for NPC attack");
            }
        }

        void StartCombat(Unit npc)
        {
            GameState.Player.inCombat = true;
            GameState.Player.Targeting = npc;
            Parallel.Invoke(MyCombat, NPCCombat);
        }

    }
}
