// Problem 3 - Moving Target
// Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
// Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/2305#2.

// You are at the shooting gallery again, and you need a program that helps you keep track of moving targets. On the first line, you will receive a sequence of targets with their integer values, split by a single space. Then, you will start receiving commands for manipulating the targets until the "End" command. The commands are the following:
//     • "Shoot {index} {power}"
//         ◦ Shoot the target at the index if it exists by reducing its value by the given power (integer value). 
//         ◦ Remove the target if it is shot. A target is considered shot when its value reaches 0.
//     • "Add {index} {value}"
//         ◦ Insert a target with the received value at the received index if it exists. 
//         ◦ If not, print: "Invalid placement!"
//     • "Strike {index} {radius}"
//         ◦ Remove the target at the given index and the ones before and after it depending on the radius.
//         ◦ If any of the indices in the range is invalid, print: "Strike missed!" and skip this command.
//  Example:  "Strike 2 2"

// {radius}
// {radius}
// {strikeIndex}
// {radius}
// {radius}



//     • "End"
//         ◦ Print the sequence with targets in the following format and end the program:
// "{target1}|{target2}…|{targetn}"
// Input / Constraints
//     • On the first line, you will receive the sequence of targets – integer values [1-10000].
//     • On the following lines, until the "End" will be receiving the command described above – strings.
//     • There will never be a case when the "Strike" command would empty the whole sequence.
// Output
//     • Print the appropriate message in case of any command if necessary.
//     • In the end, print the sequence of targets in the format described above.

using System;

namespace _03._Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> integerList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string inputComands = Console.ReadLine();

            while (inputComands != "End")
            {
                List<string> comand = inputComands.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                if (comand[0] == "Shoot")
                {
                    int index = int.Parse(comand[1]);
                    int power = int.Parse(comand[2]);

                    if (index >= 0 && index < integerList.Count)
                    {
                        if (integerList[index] <= power)
                        {
                            integerList.RemoveAt(index);
                        }
                        else
                        {
                            integerList[index] -= power;
                        }
                    }
                }
                else if (comand[0] == "Add")
                {
                    int index = int.Parse(comand[1]);
                    int value = int.Parse(comand[2]);

                    if (index >= 0 && index < integerList.Count)
                    {
                        integerList.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine(" Invalid placement!");
                    }
                }
                else if (comand[0] == "Strike")
                {
                    int index = int.Parse(comand[1]);
                    int radius = int.Parse(comand[2]);

                    if (index - radius >= 0 && index + radius < integerList.Count)
                    {
                        int takts = (radius + radius) + 1;

                        for (int i = 0; i < takts; i++)
                        {
                            integerList.RemoveAt(index - radius);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Strike missed!");
                    }
                }

                inputComands = Console.ReadLine();
            }
            Console.WriteLine(string.Join("|", integerList));
        }
    }
}