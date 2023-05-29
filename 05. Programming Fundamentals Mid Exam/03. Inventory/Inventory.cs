// Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
// Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/2028#2.

// As a young traveler, you gather items and craft new items.
// Input / Constraints
// You will receive a journal with some collecting items, separated with a comma and a space (", "). After that, until receiving "Craft!" you will be receiving different commands split by " - ":
//     • "Collect - {item}" - you should add the given item to your inventory. If the item already exists, you should skip this line.
//     • "Drop - {item}" - you should remove the item from your inventory if it exists.
//     • "Combine Items - {old_item}:{new_item}" - you should check if the old item exists. If so, add the new item after the old one. Otherwise, ignore the command.
//     • "Renew – {item}" – if the given item exists, you should change its position and put it last in your inventory.
// Output
// After receiving "Craft!" print the items in your inventory, separated by ", ".

using System;

namespace _03._Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inventory = Console.ReadLine().Split(", ").ToList();

            string inputComand = Console.ReadLine();

            while (inputComand != "Craft!")
            {
                List<string> curentComand = inputComand.Split(" - ").ToList();

                if (curentComand[0] == "Collect")
                {
                    if (!inventory.Contains(curentComand[1]))
                    {
                        inventory.Add(curentComand[1]);
                    }
                }
                else if (curentComand[0] == "Drop")
                {
                    if (inventory.Contains(curentComand[1]))
                    {
                        inventory.Remove(curentComand[1]);
                    }

                }
                else if (curentComand[0] == "Combine Items")
                {
                    string oldNew = curentComand[1];
                    List<string> curentItems = oldNew.Split(":").ToList();

                    if (inventory.Contains(curentItems[0]))
                    {
                        int indexOld = inventory.IndexOf(curentItems[0]);
                        inventory.Insert(indexOld + 1, curentItems[1]);
                    }
                }
                else if (curentComand[0] == "Renew")
                {
                    if (inventory.Contains(curentComand[1]))
                    {
                        inventory.Remove(curentComand[1]);
                        inventory.Add(curentComand[1]);
                    }
                }

                inputComand = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", inventory));
        }
    }
}