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
        public static Unit Enemy;
        public static Thread CombatThread;

        public static void SpawnCombatThread(Unit mob)
        {
            Enemy = mob;
            CombatThread = new Thread(new ThreadStart(EnterCombat));
            Console.WriteLine("Spawning thread.");
            CombatThread.Start();

        }

        public static void EnterCombat()
        {
            Console.WriteLine("In combat thread.\n");
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

    }
}
