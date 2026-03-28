using System;
using System.Collections.Generic;

namespace Progra2261
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RPG CHARACTER CREATION");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Health: ");
            int health = int.Parse(Console.ReadLine());

            Console.Write("Damage: ");
            int damage = int.Parse(Console.ReadLine());

            Player player = new Player(name, health, damage);
            List<Enemy> enemies = new List<Enemy>
            {
                new Enemy("Nicol de Coll", 30, 8),
                new Enemy("Mateo Leon", 50, 12),
                new Enemy("Giacomo Nakama", 80, 20)
            };

            GameManager game = new GameManager(player, enemies);

            while (!game.IsGameOver())
            {
                Console.Clear();

                Console.WriteLine($"PLAYER: {game.GetPlayerInfo()} | ATK: {player.GetDamage()}");
                Console.WriteLine($"POTIONS: {game.GetPotionsCount()}");
                Console.WriteLine("-");

                List<Enemy> currentEnemies = game.GetEnemyList();
                for (int i = 0; i < currentEnemies.Count; i++)
                {
                    Console.WriteLine($"[{i}] {currentEnemies[i].GetName()} (HP: {currentEnemies[i].GetHealth()})");
                }

                Console.WriteLine("\nACTION: [1] Attack | [2] Use Potion");
                string action = Console.ReadLine();

                if (action == "1")
                {
                    Console.Write("Enter enemy index to attack: ");
                    if (int.TryParse(Console.ReadLine(), out int idx))
                    {
                        game.ProcessPlayerAttack(idx);
                    }
                }
                else if (action == "2")
                {
                    game.UsePotion();
                }
                else
                {
                    Console.WriteLine("Please choose only 1 or 2");
                }

                Console.WriteLine("\nPress any key for Enemy turn...");
                Console.ReadKey();

                if (!game.IsGameOver())
                {
                    game.ExecuteEnemyTurn();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }

            Console.Clear();
            if (game.IsGameOver() && enemies.Count == 0 && player.IsAlive())
            {
                Console.WriteLine("!VICTORY!");
                Console.WriteLine("You have defeated all enemies.");
            }
            else
            {
                Console.WriteLine("GAME OVER");
                Console.WriteLine("Your hero has fallen in battle.");
            }

            Console.WriteLine("\nFinalized. Press any key to exit.");
            Console.ReadKey();
        }
    }
}