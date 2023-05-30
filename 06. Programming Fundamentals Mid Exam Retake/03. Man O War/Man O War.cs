// Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
// Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/1773#2.

// The pirates encounter a huge Man-O-War at sea. 
// Create a program that tracks the battle and either chooses a winner or prints a stalemate. On the first line, you will receive the status of the pirate ship, which is a string representing integer sections separated by ">". On the second line, you will receive the same type of status, but for the warship: 
// "{section1}>{section2}>{section3}… {sectionn}"
// On the third line, you will receive the maximum health capacity a section of the ship can reach. 
// The following lines represent commands until "Retire":
//     • "Fire {index} {damage}" - the pirate ship attacks the warship with the given damage at that section. Check if the index is valid and if not, skip the command. If the section breaks (health <= 0) the warship sinks, print the following and stop the program: "You won! The enemy ship has sunken."
//     • "Defend {startIndex} {endIndex} {damage}" - the warship attacks the pirate ship with the given damage at that range (indexes are inclusive). Check if both indexes are valid and if not, skip the command. If the section breaks (health <= 0) the pirate ship sinks, print the following and stop the program:
// "You lost! The pirate ship has sunken."
//     • "Repair {index} {health}" - the crew repairs a section of the pirate ship with the given health. Check if the index is valid and if not, skip the command. The health of the section cannot exceed the maximum health capacity.
//     • "Status" - prints the count of all sections of the pirate ship that need repair soon, which are all sections that are lower than 20% of the maximum health capacity. Print the following:
// "{count} sections need repair."
// In the end, if a stalemate occurs, print the status of both ships, which is the sum of their individual sections, in the following format:
// "Pirate ship status: {pirateShipSum}
// Warship status: {warshipSum}"
// Input
//     • On the 1st line, you are going to receive the status of the pirate ship (integers separated by '>')
//     • On the 2nd line, you are going to receive the status of the warship
//     • On the 3rd line, you will receive the maximum health a section of a ship can reach.
//     • On the following lines, until "Retire", you will be receiving commands.
// Output
//     • Print the output in the format described above.
// Constraints
//     • The section numbers will be integers in the range [1….1000]
//     • The indexes will be integers [-200….200]
//     • The damage will be an integer in the range [1….1000]
//     • The health will be an integer in the range [1….1000]

using System;

namespace _03._Man_O_War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            List<int> warShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();

            int maxHealt = int.Parse(Console.ReadLine());

            string comands = Console.ReadLine();
            bool areYouWon = true;
            bool areYouLose = false;

            while (comands != "Retire")
            {
                List<string> curentComand = comands.Split(" ").ToList();

                if (curentComand[0] == "Fire")
                {
                    int index = int.Parse(curentComand[1]);
                    int damage = int.Parse(curentComand[2]);

                    if (index >= 0 && index < warShip.Count)
                    {
                        if (damage < warShip[index])
                        {
                            warShip[index] -= damage;
                        }
                        else
                        {
                            warShip[index] = 0;
                            areYouWon = false;
                            break;
                        }
                    }
                }
                else if (curentComand[0] == "Defend")
                {
                    int startIndex = int.Parse(curentComand[1]);
                    int endtIndex = int.Parse(curentComand[2]);
                    int damage = int.Parse(curentComand[3]);

                    if (startIndex >= 0 && startIndex < endtIndex && endtIndex < pirateShip.Count)
                    {
                        for (int i = startIndex; i <= endtIndex; i++)
                        {
                            if (pirateShip[i] - damage > 0)
                            {
                                pirateShip[i] -= damage;
                            }
                            else
                            {
                                pirateShip[i] = 0;
                                areYouLose = true;
                                break;
                            }
                        }
                    }

                    if (areYouLose)
                    {
                        break;
                    }
                }
                else if (curentComand[0] == "Repair")
                {
                    int index = int.Parse(curentComand[1]);
                    int healt = int.Parse(curentComand[2]);

                    if (index >= 0 && index < pirateShip.Count)
                    {
                        if (pirateShip[index] + healt <= maxHealt)
                        {
                            pirateShip[index] += healt;
                        }
                        else
                        {
                            pirateShip[index] = maxHealt;
                        }
                    }
                }
                else if (curentComand[0] == "Status")
                {
                    int count = 0;
                    double percent = maxHealt * 0.2;
                    for (int i = 0; i < pirateShip.Count; i++)
                    {
                        if (pirateShip[i] < percent) { count++; }
                    }

                    Console.WriteLine($"{count} sections need repair.");
                }

                comands = Console.ReadLine();
            }

            if (!areYouWon)
            {
                Console.WriteLine("You won! The enemy ship has sunken.");
            }

            if (areYouLose)
            {
                Console.WriteLine("You lost! The pirate ship has sunken.");
            }
            //Console.WriteLine(string.Join(" ", pirateShip));
            //Console.WriteLine(string.Join(" ", warShip));
            if(areYouWon && !areYouLose)
            {
                Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
                Console.WriteLine($"Warship status: {warShip.Sum()}");
            }
        }
    }
}