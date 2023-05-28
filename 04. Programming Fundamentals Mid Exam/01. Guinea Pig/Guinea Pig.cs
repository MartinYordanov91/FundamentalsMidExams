// Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
// Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/2031#0.

// Merry has a guinea pig named Puppy, that she loves very much. Every month she goes to the nearest pet store and buys him everything he needs – food, hay, and cover.
// On the first three lines, you will receive the quantity of food, hay, and cover, which Merry buys for a month (30 days). On the fourth line, you will receive the guinea pig's weight.
// Every day Puppy eats 300 gr of food. Every second day Merry first feeds the pet, then gives it a certain amount of hay equal to 5% of the rest of the food. On every third day, Merry puts Puppy cover with a quantity of 1/3 of its weight.
// Calculate whether the quantity of food, hay, and cover, will be enough for a month.
// If Merry runs out of food, hay, or cover, stop the program!
// Input
//     • On the first line – quantity food in kilograms - a floating-point number in the range [0.0 – 10000.0]
//     • On the second line – quantity hay in kilograms - a floating-point number in the range [0.0 – 10000.0]
//     • On the third line – quantity cover in kilograms - a floating-point number in the range [0.0 – 10000.0]
//     • On the fourth line – guinea's weight in kilograms - a floating-point number in the range [0.0 – 10000.0]
// Output
//     • If the food, the hay, and the cover are enough, print:
//         ◦ "Everything is fine! Puppy is happy! Food: {excessFood}, Hay: {excessHay}, Cover: {excessCover}."
//     • If one of the things is not enough, print:
//         ◦ "Merry must go to the pet store!"
// The output values must be formatted to the second decimal place!

using System;

namespace _01._Guinea_Pig
{
    internal class Program
    {
        static void Main()
        {
            double food = 1000 * double.Parse(Console.ReadLine());
            double hay = 1000 * double.Parse(Console.ReadLine());
            double cover = 1000 * double.Parse(Console.ReadLine());
            double weight = 1000 * double.Parse(Console.ReadLine());
            bool isHaveAll = true;

            weight /= 3;

            for (int i = 1; i <= 30; i++)
            {
                food -= 300;

                if (i % 2 == 0)
                {
                    hay -= food * 0.05;
                }

                if (i % 3 == 0)
                {
                    cover -= weight;
                }

                if (cover <= 0 || hay <= 0 || food <= 0)
                {
                    isHaveAll = false;
                    break;
                }
            }

            food /= 1000;
            hay /= 1000;
            cover /= 1000;

            if (isHaveAll)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food:f2}, Hay: {hay:f2}, Cover: {cover:f2}.");
            }
            if (!isHaveAll)
            {
                Console.WriteLine("Merry must go to the pet store!");
            }
        }
    }
}