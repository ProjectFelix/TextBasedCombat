using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextBasedCombat.System
{
    public class CombatSystem
    {
        private GameState GameState;
        public CombatSystem(GameState gameState) {
            GameState = gameState;
        }
        public Task StartCombat(Unit mob, CancellationTokenSource cts)
        {
            var Player = GameState.Player;
            Player.inCombat = true;
            Task playerMainhandTask = PlayerMainAttackAsync(mob, cts);
            Task npcTask = NPCMainAttackAsync(mob, cts);
            Task displayPrompt = CombatPrompt(mob, cts.Token);

            Task.WhenAll(playerMainhandTask, npcTask, displayPrompt);
            Player.inCombat = false;
            return Task.CompletedTask;
        }

        private async Task PlayerMainAttackAsync(Unit mob, CancellationTokenSource cts)
        {
            var Player = GameState.Player;
            Random rand = new Random();
            float delay = Player.Mainhand == null ?
                Player.Delay : Player.Mainhand.Delay;
            while (!cts.Token.IsCancellationRequested)
            {
                

                if (!cts.Token.IsCancellationRequested)
                {
                    int _damage = rand.Next(Player.Damage[0], Player.Damage[1]);
                    mob.Health -= _damage;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"You hit {mob.Name} for {_damage} points of damage!");

                    if (mob.Health <= 0)
                    {
                        Console.WriteLine($"{mob.Name} has been defeated!");
                        cts.Cancel();
                        GameState.Mobs.Remove( mob );
                        break;
                    }
                }

                await Task.Delay(TimeSpan.FromSeconds(delay), cts.Token);
            }
        }

        private async Task NPCMainAttackAsync(Unit mob, CancellationTokenSource cts)
        {
            Random rand = new Random();
            while (!cts.Token.IsCancellationRequested)
            {

                if (!cts.Token.IsCancellationRequested)
                {
                    int _damage = rand.Next(mob.Damage[0], mob.Damage[1]);
                    GameState.Player.CurrentHealth -= _damage;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{mob.Name} hits you for {_damage} points of damage!");

                    if (GameState.Player.CurrentHealth <= 0)
                    {
                        Console.WriteLine($"You died!");
                        cts.Cancel();
                        break;
                    }
                }
                await Task.Delay(TimeSpan.FromSeconds(mob.Delay), cts.Token);
            } 
        }

        public async Task CombatPrompt(Unit mob,CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(2), token);
                Console.ForegroundColor= ConsoleColor.Cyan;
                Console.WriteLine($"\n<{GameState.Player.CurrentHealth}/{GameState.Player.MaxHealth} hp> <Target: {mob.Name} | {mob.Health}hp>");
            }
        }
    }
}
