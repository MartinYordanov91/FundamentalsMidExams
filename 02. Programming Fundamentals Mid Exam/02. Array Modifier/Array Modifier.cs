// Problem 2 - Array Modifier
// Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
// Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/2474#1.

// You are given an array with integers. Write a program to modify the elements after receiving the following commands:
//     • "swap {index1} {index2}" takes two elements and swap their places.
//     • "multiply {index1} {index2}" takes element at the 1st index and multiply it with the element at 2nd index. Save the product at the 1st index.
//     • "decrease" decreases all elements in the array with 1.
// Input
// On the first input line, you will be given the initial array values separated by a single space.
// On the next lines you will receive commands until you receive the command "end". The commands are as follow: 
//     • "swap {index1} {index2}"
//     • "multiply {index1} {index2}"
//     • "decrease"
// Output
// The output should be printed on the console and consist of elements of the modified array – separated by a comma and a single space ", ".
// Constraints
//     • Elements of the array will be integer numbers in the range [-231...231]
//     • Count of the array elements will be in the range [2...100]
//     • Indexes will be always in the range of the array

using System;

namespace _02._Array_Modifier
{
    internal class Program
    {
        static void Main()
        {
            List<int> integerList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            string inputComand = Console.ReadLine();
            while (inputComand != "end")
            {

                List<string> comandList = inputComand
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .ToList();

                if (comandList[0] == "swap")
                {
                    int firstIndex = int.Parse(comandList[1]);
                    int secondIndex = int.Parse(comandList[2]);
                    (integerList[firstIndex], integerList[secondIndex]) = (integerList[secondIndex], integerList[firstIndex]);

                    // Console.WriteLine(string.Join(" ", integerList));
                }
                else if (comandList[0] == "multiply")
                {
                    int firstIndex = int.Parse(comandList[1]);
                    int secondIndex = int.Parse(comandList[2]);

                    integerList[firstIndex] *= integerList[secondIndex];
                    // Console.WriteLine(string.Join(" ", integerList));
                }
                else if (comandList[0] == "decrease")
                {
                    for (int i = 0; i < integerList.Count; i++)
                    {
                        integerList[i] -= 1;
                    }
                }

                inputComand = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", integerList));
        }
    }
}