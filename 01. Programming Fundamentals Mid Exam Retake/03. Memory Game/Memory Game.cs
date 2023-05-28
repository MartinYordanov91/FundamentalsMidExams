// Problem 3 - Memory game
// Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
// Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/2517#1.

// Write a program that recreates the Memory game.
// On the first line, you will receive a sequence of elements. Each element in the sequence will have a twin. Until the player receives "end" from the console, you will receive strings with two integers separated by a space, representing the indexes of elements in the sequence.
// If the player tries to cheat and enters two equal indexes or indexes which are out of bounds of the sequence, you should add two matching elements at the middle of the sequence in the following format:
// "-{number of moves until now}a" 
// Then print this message on the console:
// "Invalid input! Adding additional elements to the board"
// Input
//     • On the first line, you will receive a sequence of elements
//     • On the following lines, you will receive integers until the command "end"
// Output
//     • Every time the player hit two matching elements, you should remove them from the sequence and print on the console the following message:
// "Congrats! You have found matching elements - ${element}!"
//     • If the player hit two different elements, you should print on the console the following message:
// "Try again!"
//     • If the player hit all matching elements before he receives "end" from the console, you should print on the console the following message: 
// "You have won in {number of moves until now} turns!"
//     • If the player receives "end" before he hits all matching elements, you should print on the console the following message:
// "Sorry you lose :(
// {the current sequence's state}"
// Constraints
//     • All elements in the sequence will always have a matching element.

using System;

namespace _03._Memory_Game
{
    internal class Program
    {
        static void Main()
        {
            List<string> list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string comad = Console.ReadLine();

            int coutTurns = 0;

            while (comad != "end")
            {
                List<int> indexComand = comad.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();



                coutTurns++;

                if (list.Count > indexComand[0] && list.Count > indexComand[1]
                    && indexComand[0] > -1 && indexComand[1] > -1 && indexComand[0] != indexComand[1])
                {
                    if (list[indexComand[0]] == list[indexComand[1]])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {list[indexComand[0]]}!");

                        if (indexComand[0] > indexComand[1])
                        {
                            list.RemoveAt(indexComand[0]);
                            list.RemoveAt(indexComand[1]);
                        }
                        else
                        {
                            list.RemoveAt(indexComand[1]);
                            list.RemoveAt(indexComand[0]);
                        }

                    }
                    else
                    {

                        Console.WriteLine("Try again!");
                    }
                }
                else
                {
                    list.Insert(list.Count / 2, "-" + coutTurns + "a");
                    list.Insert(list.Count / 2, "-" + coutTurns + "a");

                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }

                if (list.Count == 0)
                {
                    Console.WriteLine($"You have won in {coutTurns} turns!");
                    return;
                }

                comad = Console.ReadLine();
            }

            
            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", list));
            

        }
    }
}