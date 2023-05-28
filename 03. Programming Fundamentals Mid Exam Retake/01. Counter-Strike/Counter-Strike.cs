// Problem 1 - Counter-Strike
// Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
// Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/2305#0.

// Write a program that keeps track of every won battle against an enemy. You will receive initial energy. Afterward, you will start receiving the distance you need to reach an enemy until the "End of battle" command is given, or you run out of energy.
// The energy you need for reaching an enemy is equal to the distance you receive. Each time you reach an enemy, you win a battle, and your energy is reduced. Otherwise, if you don't have enough energy to reach an enemy, end the program and print: "Not enough energy! Game ends with {count} won battles and {energy} energy".
// Every third won battle increases your energy with the value of your current count of won battles.
// Upon receiving the "End of battle" command, print the count of won battles in the following format:
// "Won battles: {count}. Energy left: {energy}" 
// Input / Constraints
//     • On the first line, you will receive initial energy – an integer [1-10000].
//     • On the following lines, you will be receiving the distance of an enemy – an integer [1-10000]
// Output
//     • The description contains the proper output messages for each case and the format they should be printed.

using System;

namespace _01._Counter_Strike
{
    internal class Program
    {
        static void Main()
        {
            int playrEnergy = int.Parse(Console.ReadLine());
            int countWon = 0;
            string batleComands = Console.ReadLine();

            while (batleComands != "End of battle")
            {
                int needEnergy = int.Parse(batleComands);

                if (playrEnergy >= needEnergy)
                {
                    playrEnergy -= needEnergy;
                    countWon++;
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {countWon} won battles and {playrEnergy} energy");
                    break;
                }

                if (countWon % 3 == 0) //&& playrEnergy + countWon >= needEnergy
                {
                    playrEnergy += countWon;
                }
                batleComands = Console.ReadLine();
            }

            if (batleComands == "End of battle")
            {
                Console.WriteLine($"Won battles: {countWon}. Energy left: {playrEnergy}");
            }

        }
    }
}