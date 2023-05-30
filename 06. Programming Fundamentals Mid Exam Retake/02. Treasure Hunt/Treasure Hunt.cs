// Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
// Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/1773#1.

// The pirates need to carry a treasure chest safely back to the ship, looting along the way.
// Create a program that manages the state of the treasure chest along the way. On the first line, you will receive the initial loot of the treasure chest, which is a string of items separated by a "|".
// "{loot1}|{loot2}|{loot3} … {lootn}"
// The following lines represent commands until "Yohoho!" which ends the treasure hunt:
//     • "Loot {item1} {item2}…{itemn}":
//         ◦ Pick up treasure loot along the way. Insert the items at the beginning of the chest. 
//         ◦ If an item is already contained, don't insert it.
//     • "Drop {index}":
//         ◦ Remove the loot at the given position and add it at the end of the treasure chest. 
//         ◦ If the index is invalid, skip the command.
//     • "Steal {count}":
//         ◦ Someone steals the last count loot items. If there are fewer items than the given count, remove as much as there are. 
//         ◦ Print the stolen items separated by ", ":
// "{item1}, {item2}, {item3} … {itemn}"
// In the end, output the average treasure gain, which is the sum of all treasure items length divided by the count of all items inside the chest formatted to the second decimal point:
// "Average treasure gain: {averageGain} pirate credits."
// If the chest is empty, print the following message:
// "Failed treasure hunt."
// Input
//     • On the 1st line, you are going to receive the initial treasure chest (loot separated by "|")
//     • On the following lines, until "Yohoho!", you will be receiving commands.
// Output
//     • Print the output in the format described above.
// Constraints
//     • The loot items will be strings containing any ASCII code.
//     • The indexes will be integers in the range [-200…200]
//     • The count will be an integer in the range [1….100]

using System;

namespace _02._Treasure_Hunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> treasure = Console.ReadLine().Split("|").ToList();

            string pirateComands = Console.ReadLine();
            while (pirateComands != "Yohoho!")
            {
                List<string> curentComands = pirateComands.Split().ToList();

                if (curentComands[0] == "Loot")
                {
                    for (int i = 1; i < curentComands.Count; i++)
                    {
                        if (!treasure.Contains(curentComands[i]))
                        {
                            treasure.Insert(0, curentComands[i]);
                        }
                    }
                }
                else if (curentComands[0] == "Drop")
                {
                    int index = int.Parse(curentComands[1]);

                    if (index < treasure.Count && index >= 0)
                    {
                        treasure.Add(treasure[index]);
                        treasure.RemoveAt(index);
                    }
                    
                }
                else if (curentComands[0] == "Steal")
                {
                    List<string> StoleItems = new List<string>();
                    int count = int.Parse(curentComands[1]);

                    if (count < treasure.Count)
                    {
                        int position = treasure.Count - count ;
                        for (int i = position; i < treasure.Count; i++)
                        {
                            StoleItems.Add(treasure[i]);
                        }

                        treasure.RemoveRange(position, count);
                        
                        Console.WriteLine(string.Join(", " ,StoleItems));
                    }
                    else
                    {
                        Console.WriteLine(string.Join(", " , treasure));
                        for (int i = 0; i < treasure.Count; )
                        {
                            treasure.RemoveAt(0);
                        }
                    }
                }

                pirateComands = Console.ReadLine();
            }
            if (treasure.Count == 0) { Console.WriteLine("Failed treasure hunt."); }
            else
            {
                double percent = 0;

                for (int i = 0; i < treasure.Count; i++)
                {
                    string curentItem = treasure[i];
                    percent += curentItem.Length;
                }

                percent /= treasure.Count;
                Console.WriteLine($"Average treasure gain: {percent:f2} pirate credits.");
            }
            //Console.WriteLine(string.Join(" ", treasure));
        }
    }
}