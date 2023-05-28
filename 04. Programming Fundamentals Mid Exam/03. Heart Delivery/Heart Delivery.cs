// Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
// Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/2031#2.

// Valentine's day is coming, and Cupid has minimal time to spread some love across the neighborhood. Help him with his mission!
// You will receive a string with even integers, separated by a "@" - this is our neighborhood. After that, a series of Jump commands will follow until you receive "Love!". Every house in the neighborhood needs a certain number of hearts delivered by Cupid so it can celebrate Valentine's day. The integers in the neighborhood indicate those needed hearts.
// Cupid starts at the position of the first house (index 0) and must jump by a given length. The jump commands will be in this format: "Jump {length}". 
// Every time he jumps from one house to another, the needed hearts for the visited house are decreased by 2: 
//     • If the needed hearts for a certain house become equal to 0, print on the console "Place {house_index} has Valentine's day." 
//     • If Cupid jumps to a house where the needed hearts are already 0, print on the console "Place {house_index} already had Valentine's day."
//     • Keep in mind that Cupid can have a larger jump length than the size of the neighborhood, and if he does jump outside of it, he should start from the first house again (index 0)
// For example, we are given this neighborhood: 6@6@6. Cupid is at the start and jumps with a length of 2. He will end up at index 2 and decrease the needed hearts by 2: [6, 6, 4]. Next, he jumps again with a length of 2 and goes outside the neighborhood, so he goes back to the first house (index 0) and again decreases the needed hearts there: [4, 6, 4].
// Input
//     • On the first line, you will receive a string with even integers separated by "@" – the neighborhood and the number of hearts for each house.
//     • On the next lines, until "Love!" is received, you will be getting jump commands in this format: "Jump {length}".
// Output
// In the end, print Cupid's last position and whether his mission was successful or not:
//     • "Cupid's last position was {last_position_index}."
//     • If each house has had Valentine's day, print: 
//         ◦ "Mission was successful."
//     • If not, print the count of all houses that didn't celebrate Valentine's Day:
//         ◦ "Cupid has failed {houseCount} places."
// Constraints
//     • The neighborhood's size will be in the range [1…20]
//     • Each house will need an even number of hearts in the range [2 … 10]
//     • Each jump length will be an integer in the range [1 … 20]

using System;

namespace _03._Heart_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> houseHerds = Console.ReadLine().Split("@", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int curentHouse = 0;

            string comandInput = Console.ReadLine();

            while (comandInput != "Love!")
            {
                List<string> helper = comandInput.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                int jumpIndex = int.Parse(helper[1]);
                if (curentHouse + jumpIndex < houseHerds.Count)
                {
                    curentHouse += jumpIndex;
                    if (houseHerds[curentHouse] != 0)
                    {
                        houseHerds[curentHouse] -= 2;

                        if (houseHerds[curentHouse] == 0)
                        {
                            Console.WriteLine($"Place {curentHouse} has Valentine's day.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Place {curentHouse} already had Valentine's day.");
                    }
                }
                else
                {
                    curentHouse = 0;

                    if (houseHerds[0] != 0)
                    {
                        houseHerds[0] -= 2;

                        if (houseHerds[0] == 0)
                        {
                            Console.WriteLine($"Place {curentHouse} has Valentine's day.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Place {curentHouse} already had Valentine's day.");
                    }
                }
                comandInput = Console.ReadLine();
            }

            if (houseHerds.Sum() == 0)
            {
                Console.WriteLine($"Cupid's last position was {curentHouse}.");
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid's last position was {curentHouse}.");
                curentHouse = 0;

                for (int i = 0; i < houseHerds.Count; i++)
                {
                    if (houseHerds[i] != 0)
                    {
                        curentHouse++;
                    }
                }
                Console.WriteLine($"Cupid has failed {curentHouse} places.");
            }
        }
    }
}