// Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
// Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/2517#1.

// Write a program that finds a place for the tourist on a lift. 
// Every wagon should have a maximum of 4 people on it. If a wagon is full, you should direct the people to the next one with space available.
// Input
//     • On the first line, you will receive how many people are waiting to get on the lift
//     • On the second line, you will receive the current state of the lift separated by a single space: " ".
// Output
// When there is no more available space left on the lift, or there are no more people in the queue, you should print on the console the final state of the lift's wagons separated by " " and one of the following messages:
//     • If there are no more people and the lift have empty spots, you should print:
// "The lift has empty spots!
// {wagons separated by ' '}"
//     • If there are still people in the queue and no more available space, you should print:
// "There isn't enough space! {people} people in a queue!
// {wagons separated by ' '}"
//     • If the lift is full and there are no more people in the queue, you should print only the wagons separated by " "

using System;

namespace _02._The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wheitingPeople = int.Parse(Console.ReadLine());

            List<int> liftsvagons = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            for (int i = 0; i < liftsvagons.Count; i++)
            {
                if (liftsvagons[i]< 0)
                {
                    liftsvagons[i]= 0;
                }
            }

            for (int i = 0; i < liftsvagons.Count; i++)
            {
                if (wheitingPeople <= 0)
                {
                    break;
                }

                if (liftsvagons[i] < 4)
                {
                    if (wheitingPeople + liftsvagons[i] - 4 >= 0)
                    {
                        wheitingPeople += liftsvagons[i] - 4;
                        liftsvagons[i] = 4;

                    }
                    else
                    {
                        liftsvagons[i] += wheitingPeople;
                        wheitingPeople = 0;
                        break;
                    }
                }
            }
            if (liftsvagons.Sum() < liftsvagons.Count *4)
            {
                Console.WriteLine("The lift has empty spots!");
            }
            else if(wheitingPeople > 0) 
            {
                Console.WriteLine($"There isn't enough space! {wheitingPeople} people in a queue!");
            }
            Console.WriteLine(string.Join(" ", liftsvagons));
        }
    }
}