// Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
// Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/2028#1.

// You have initial health 100 and initial bitcoins 0. You will be given a string representing the dungeon's rooms. Each room is separated with '|' (vertical bar): "room1|room2|room3…"
// Each room contains a command and a number, separated by space. The command can be:
//     • "potion"
//         ◦ You are healed with the number in the second part. But your health cannot exceed your initial health (100).
//         ◦ First print: "You healed for {amount} hp."
//         ◦ After that, print your current health: "Current health: {health} hp."
//     • "chest"
//         ◦ You've found some bitcoins, the number in the second part.
//         ◦ Print: "You found {amount} bitcoins."
//     • In any other case, you are facing a monster, which you will fight. The second part of the room contains the attack of the monster. You should remove the monster's attack from your health. 
//         ◦ If you are not dead (health <= 0), you've slain the monster, and you should print: "You slayed {monster}."
//         ◦ If you've died, print "You died! Killed by {monster}." and your quest is over. Print the best room you've manage to reach: "Best room: {room}"
// If you managed to go through all the rooms in the dungeon, print on the following three lines: 
// "You've made it!"
// "Bitcoins: {bitcoins}"
// "Health: {health}"
// Input / Constraints
// You receive a string representing the dungeon's rooms, separated with '|' (vertical bar): "room1|room2|room3…".
// Output
// Print the corresponding messages described above.\

using System;
using System.Numerics;

namespace _02._MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> dungeons = Console.ReadLine().Split("|").ToList();
            int health = 100;
            int bitcoin = 0;
            bool isWin = true;

            for (int i = 0; i < dungeons.Count; i++)
            {
                List<string> comand = dungeons[i].Split(" ").ToList();

                if (comand[0] == "potion")
                {
                    int hpAdd = int.Parse(comand[1]);

                    if (hpAdd + health <= 100)
                    {
                        health += hpAdd;
                        Console.WriteLine($"You healed for {hpAdd} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else
                    {
                        hpAdd = 100 - health;
                        health = 100;
                        Console.WriteLine($"You healed for {hpAdd} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                }
                else if (comand[0] == "chest")
                {
                    int addBitcoin = int.Parse(comand[1]);
                    Console.WriteLine($"You found {addBitcoin} bitcoins.");
                    bitcoin += addBitcoin;
                }
                else
                {
                    string monster = comand[0];
                    int power = int.Parse(comand[1]);

                    health -= power;
                    if (health <= 0 )
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {i+1}");
                        isWin = false;
                        break;
                    }

                    if(isWin)
                    {
                        Console.WriteLine($"You slayed {monster}.");
                    }
                }
            }
            if(isWin)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoin}");
                Console.WriteLine($"Health: {health}");
            }

        }
    }
}