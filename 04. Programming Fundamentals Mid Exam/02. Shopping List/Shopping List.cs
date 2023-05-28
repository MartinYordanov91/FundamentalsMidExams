// Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
// Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/2031#1.

// It's the end of the week, and it is time for you to go shopping, so you need to create a shopping list first.
// Input
// You will receive an initial list with groceries separated by an exclamation mark "!".
// After that, you will be receiving 4 types of commands until you receive "Go Shopping!".
//     • "Urgent {item}" - add the item at the start of the list.  If the item already exists, skip this command.
//     • "Unnecessary {item}" - remove the item with the given name, only if it exists in the list. Otherwise, skip this command.
//     • "Correct {oldItem} {newItem}" - if the item with the given old name exists, change its name with the new one. Otherwise, skip this command.
//     • "Rearrange {item}" - if the grocery exists in the list, remove it from its current position and add it at the end of the list. Otherwise, skip this command.
// Constraints
//     • There won't be any duplicate items in the initial list
// Output
//     • Print the list with all the groceries, joined by ", ":
// "{firstGrocery}, {secondGrocery}, … {nthGrocery}"
// Examples

using System;

namespace _02._Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> groceryList = Console.ReadLine().Split("!", StringSplitOptions.RemoveEmptyEntries).ToList();

            string comandInput = Console.ReadLine();

            while (comandInput != "Go Shopping!")
            {
                List<string> curentComands = comandInput.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                if (curentComands[0] == "Urgent")
                {
                    if (!groceryList.Contains(curentComands[1]))
                    {
                        groceryList.Insert(0, curentComands[1]);
                    }
                }
                else if (curentComands[0] == "Unnecessary")
                {
                    if (groceryList.Contains(curentComands[1]))
                    {
                        groceryList.Remove(curentComands[1]);
                    }
                }
                else if (curentComands[0] == "Correct")
                {
                    if (groceryList.Contains(curentComands[1]))
                    {
                        int oldItemIndex = groceryList.IndexOf(curentComands[1]);

                        groceryList.Remove(curentComands[1]);
                        groceryList.Insert(oldItemIndex, curentComands[2]);

                    }
                }
                else if (curentComands[0] == "Rearrange")
                {
                    if (groceryList.Contains(curentComands[1]))
                    {
                        string item = curentComands[1];
                        groceryList.Remove(item);
                        groceryList.Add(item);

                    }
                }
                comandInput = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", groceryList));
        }
    }
}