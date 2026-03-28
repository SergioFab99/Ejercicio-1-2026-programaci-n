using System;
using System.Collections.Generic;
using System.Linq;

namespace Progra2261
{
    internal class Program
    {
        class Entity
        {
            public string Name;
            public int Health;
            public int Damage;
            public bool IsAlive => Health > 0;
        }

        static void Main(string[] args)
        {

            Console.WriteLine("CHARACTER CREATION");
            Entity player = new Entity();

            Console.Write("Enter your name: ");
            player.Name = Console.ReadLine();

            Console.Write("Health Points: ");
            player.Health = int.Parse(Console.ReadLine());

            Console.Write("Damage Points: ");
            player.Damage = int.Parse(Console.ReadLine());

            List<Entity> enemies = new List<Entity>
            {
                new Entity { Name = "Slime", Health = 25, Damage = 8 },
                new Entity { Name = "Skeleton", Health = 40, Damage = 12 },
                new Entity { Name = "Guardian", Health = 60, Damage = 15 }
            };

            List<int> potions = new List<int>();

            
            while (player.IsAlive && enemies.Count > 0)
            {
                Console.Clear();
                Console.WriteLine($"PLAYER: {player.Name} | HP: {player.Health} | ATK: {player.Damage}");
                Console.WriteLine($"Enemies remaining: {enemies.Count}\n");

                
                Console.WriteLine("YOUR TURN: [1] Attack | [2] Use Potion (" + potions.Count + ")");
                string action = Console.ReadLine();

                if (action == "1")
                {
                    Console.WriteLine("Who do you attack?");
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        Console.WriteLine($"[{i}] {enemies[i].Name} (HP: {enemies[i].Health})");
                    }

                    int targetIndex = int.Parse(Console.ReadLine());
                    Entity currentEnemy = enemies[targetIndex];

                    currentEnemy.Health -= player.Damage;
                    Console.WriteLine($"You hit {currentEnemy.Name} for {player.Damage}!");

                    if (!currentEnemy.IsAlive)
                    {
                        Console.WriteLine($"{currentEnemy.Name} defeated. It dropped a +25 HP potion!");
                        potions.Add(25);
                        enemies.RemoveAt(targetIndex);
                    }
                }
                else if (action == "2" && potions.Any())
                {
                    player.Health += potions[0];
                    Console.WriteLine($"You used a potion. You recovered {potions[0]} HP.");
                    potions.RemoveAt(0);
                }
                else
                {
                    Console.WriteLine("Invalid action or you have no potions. You lose your turn.");
                }
                
                if (enemies.Any() && player.IsAlive)
                {
                    Console.WriteLine("\nENEMY TURN:");
                    Entity attacker = enemies[0];
                    player.Health -= attacker.Damage;
                    Console.WriteLine($"{attacker.Name} attacked you and dealt {attacker.Damage} damage.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }

            Console.Clear();
            if (player.IsAlive)
                Console.WriteLine("VICTORY! You cleared the area of enemies.");
            else
                Console.WriteLine("YOU DIED. Game Over.");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}