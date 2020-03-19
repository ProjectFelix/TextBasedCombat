using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TextBasedCombat.World;

namespace TextBasedCombat
{
    class Program
    {
        static void Main(string[] args)
        {
            GameState.GameInit();
            string userInput;
            string[] commands;
            Console.ForegroundColor = ConsoleColor.White;

            /* So this is my implementation of combat with different attack delays.
             * The hard part is figuring out how to display current status of player
             * life and mob life without littering the screen.
             * 
            */

            Console.WriteLine("Welcome to the Text Based Combat Simulator!\n");

            while (GameState.IsPlaying)
            {
                GameState.Player.DisplayPrompt();
                userInput = Console.ReadLine();
                commands = userInput.Split(' ');
                switch (commands[0])
                {
                    case "look":
                        GameState.Player.CurrentRoom.PrintDesc();
                        break;
                    case "kill":
                        foreach (Unit mob in GameState.Player.CurrentRoom.Mobs)
                        {
                            if (mob.Name.Contains(commands[1]))
                            {
                                StartCombat(mob);
                                break;
                            }
                        }
                        break;
                    case "help":
                        Console.WriteLine("Type \"kill <mob>\" to attack a mob");
                        Console.WriteLine("Type \"look\" to see the room you are in");
                        break;
                    default:
                        break;


                }
            }

            //StartCombat(GameState.Mobs[0]);

            // TODO: Implement round-based combat with prompt for health display and mob condition.

        }

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
                    return;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"You: <{you.CurrentHealth}/{you.MaxHealth} hp> Enemy: <{enemy.Health}>");
                Thread.Sleep(2400);
                //Console.WriteLine("Done waiting for NPC attack");
            }
        }

        static void StartCombat(Unit npc)
        {
            GameState.Player.inCombat = true;
            GameState.Player.Targeting = npc;
            Parallel.Invoke(MyCombat, NPCCombat);
        }


    }
}
