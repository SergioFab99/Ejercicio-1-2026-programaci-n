using System;
using System.Collections.Generic;
using System.Linq;

namespace Progra2261
{
    public class GameManager
    {
        private Player player;
        private List<Enemy> enemies;
        private List<int> potionInventory;

        public GameManager(Player player, List<Enemy> enemies)
        {
            this.player = player;
            this.enemies = enemies;
            this.potionInventory = new List<int>();
        }

        public bool IsGameOver() => !player.IsAlive() || enemies.Count == 0;

        public void ProcessPlayerAttack(int enemyIndex)
        {
            if (enemyIndex < 0 || enemyIndex >= enemies.Count) return;

            Enemy target = enemies[enemyIndex];
            target.TakeDamage(player.GetDamage());

            Console.WriteLine($"\n{player.GetName()} deals {player.GetDamage()} damage to {target.GetName()}!");

            if (!target.IsAlive())
            {
                Console.WriteLine($"{target.GetName()} died! +25 HP Potion found.");
                potionInventory.Add(25);
                enemies.RemoveAt(enemyIndex);
            }
        }

        public void UsePotion()
        {
            if (potionInventory.Any())
            {
                int heal = potionInventory[0];
                player.Heal(heal);
                potionInventory.RemoveAt(0);
                Console.WriteLine($"\n{player.GetName()} recovered {heal} HP!");
            }
        }

        public void ExecuteEnemyTurn()
        {
            if (enemies.Any() && player.IsAlive())
            {
                Enemy attacker = enemies[0];
                player.TakeDamage(attacker.GetDamage());
                Console.WriteLine($"\n{attacker.GetName()} attacks for {attacker.GetDamage()} damage!");
            }
        }

        public string GetPlayerInfo() => $"{player.GetName()} | HP: {player.GetHealth()}";
        public List<Enemy> GetEnemyList() => enemies;
        public int GetPotionsCount() => potionInventory.Count;
    }
}