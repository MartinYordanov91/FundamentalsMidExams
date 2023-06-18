namespace _02._Space_Travel
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] traveling = Console.ReadLine()
                .Split("||", StringSplitOptions.RemoveEmptyEntries);
            int fuel = int.Parse(Console.ReadLine());
            int amunition = int.Parse(Console.ReadLine());
            

            for (int i = 0; i < traveling.Length; i++)
            {
                if (traveling[i] != "Titan")
                {
                    string[] comandArg = traveling[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string comand = comandArg[0];
                    int consomation = int.Parse(comandArg[1]);

                    if (comand == "Travel")
                    {
                        if (fuel >= consomation)
                        {
                            fuel -= consomation;
                            Console.WriteLine($"The spaceship travelled {consomation} light-years.");
                        }
                        else
                        {
                            Console.WriteLine("Mission failed.");
                            
                            break;
                        }
                    }
                    else if (comand == "Enemy")
                    {
                        if (amunition >= consomation)
                        {
                            amunition -= consomation;
                            Console.WriteLine($"An enemy with {consomation} armour is defeated.");
                        }
                        else if (fuel >= consomation * 2)
                        {
                            fuel -= consomation * 2;
                            Console.WriteLine($"An enemy with {consomation} armour is outmaneuvered.");
                        }
                        else
                        {
                            
                            Console.WriteLine("Mission failed.");
                            break;
                        }
                    }
                    else if (comand == "Repair")
                    {
                        fuel += consomation;
                        amunition += consomation * 2;
                        Console.WriteLine($"Ammunitions added: {consomation * 2}.");
                        Console.WriteLine($"Fuel added: {consomation}.");
                    }
                }

                if (traveling[i] == "Titan")
                {
                    Console.WriteLine("You have reached Titan, all passengers are safe.");
                    break;
                }

            }
        }
    }
}