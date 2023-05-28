// Problem 3 - Numbers
// Write a program to read a sequence of integers and find and print the top 5 numbers greater than the average value in the sequence, sorted in descending order.
// Input
//     • Read from the console a single line holding space-separated integers.
// Output
//     • Print the above-described numbers on a single line, space-separated. 
//     • If less than 5 numbers hold the property mentioned above, print less than 5 numbers. 
//     • Print "No" if no numbers hold the above property.
// Constraints
//     • All input numbers are integers in the range [-1 000 000 … 1 000 000]. 
//     • The count of numbers is in the range [1…10 000].

using System;

namespace _03._Numbers
{
    internal class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            List<int> output = new List<int>();


            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > numbers.Average())
                {
                    output.Add(numbers[i]);
                }
            }

            if (output.Count < 6 && output.Count > 0)
            {
                
                for (int i = 0; i < 5; i++)
                {
                    if(output.Count == 0) { break; }
                    Console.Write(output.Max() + " ");
                    output.Remove(output.Max());
                }
            }
            else if (output.Count > 5) 
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(output.Max()+ " ");
                    output.Remove(output.Max());
                }
            }
            else
            {
                Console.WriteLine("No");
            }
            
        }
    }
}