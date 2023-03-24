using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedCombat.Items;

namespace TextBasedCombat.System
{
    public class Main
    {
        public void Main_Thread()
        {
            GameState.GameInit();
            string userInput;
            string[] commands;
            Console.ForegroundColor = ConsoleColor.White;
            string[] possibleCommands = { "inventory", "look", "equip", "kill", "flee" };

            /* So this is my implementation of combat with different attack delays.
             * The hard part is figuring out how to display current status of player
             * life and mob life without littering the screen.
            */

            Console.WriteLine("Welcome to the Text Based Combat Simulator!\n");

            while (GameState.IsPlaying)
            {
                GameState.Player.DisplayPrompt();
                Console.ForegroundColor = ConsoleColor.Yellow;
                userInput = Console.ReadLine();
                commands = userInput.Split(' ');
                Console.ForegroundColor = ConsoleColor.White;
                foreach (string command in possibleCommands)
                {
                    if (command.StartsWith(commands[0])) commands[0] = command;
                }

                switch (commands[0])
                {
                    case "look":
                        GameState.Player.CurrentRoom.PrintDesc();
                        break;
                    case "kill":
                        foreach (Unit mob in GameState.Player.CurrentRoom.Mobs)
                        {
                            if (mob.Name.ToLower().Contains(commands[1].ToLower()))
                            {
                                // This is the delay-based combat. But its running on the main thread
                                //StartCombat(mob);

                                // This is the round-based combat. Spawns a combat thread so player can still issue commands.
                                RoundCombat.SpawnCombatThread(mob);
                                break;
                            }
                        }
                        break;
                    case "help":
                        Console.WriteLine("\nkill <mob> - Attack a mob.");
                        Console.WriteLine("look - See the room you are in.");
                        Console.WriteLine("flee - Attempt to escape combat.");
                        Console.WriteLine("quit - Exit the game.");
                        Console.WriteLine("equip - View equipped items.");
                        Console.WriteLine("equip <item> - Equip item.");
                        Console.WriteLine("inv - View inventory.");
                        break;
                    case "flee":
                        if (!GameState.Player.inCombat) Console.WriteLine("You aren't in combat!");
                        else
                        {
                            Random r = new Random();
                            if (r.Next(100) > 25)
                            {
                                Console.WriteLine("You flee from combat!");
                                GameState.Player.inCombat = false;
                            }
                            else Console.WriteLine($"{RoundCombat.Enemy.Name} blocks you from fleeing!");
                        }
                        break;
                    case "quit":
                        GameState.IsPlaying = false;
                        break;
                    case "equip":
                        if (commands.Length == 1)
                        {
                            GameState.Player.DisplayEquipment();
                            break;
                        }
                        Item toEquip = null;
                        foreach (Item invItem in GameState.Player.Inventory)
                        {
                            if (invItem.Name.ToLower().Contains(commands[1].ToLower()))
                            {
                                toEquip = invItem;
                                break;
                            }
                        }
                        if (toEquip == null) Console.WriteLine("You do not have that item.");
                        GameState.Player.EquipItem(toEquip);
                        break;
                    case "inventory":
                        GameState.Player.DisplayInventory();
                        break;
                    default:
                        break;


                }
            }
        }
    }
}
