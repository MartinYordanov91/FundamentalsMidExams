// Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
// Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/2517#0.

// Write a program that prints you a receipt for your new computer. You will receive the parts' prices (without tax) until you receive what type of customer this is - special or regular. Once you receive the type of customer you should print the receipt.
// The taxes are 20% of each part's price you receive. 
// If the customer is special, he has a 10% discount on the total price with taxes.
// If a given price is not a positive number, you should print "Invalid price!" on the console and continue with the next price.
// If the total price is equal to zero, you should print "Invalid order!" on the console.
// Input
//     • You will receive numbers representing prices (without tax) until command "special" or "regular":
// Output
//     • The receipt should be in the following format: 
// "Congratulations you've just bought a new computer!
// Price without taxes: {total price without taxes}$
// Taxes: {total amount of taxes}$
// -----------
// Total price: {total price with taxes}$"
// Note: All prices should be displayed to the second digit after the decimal point! The discount is applied only on the total price. Discount is only applicable to the final price!

using System;

namespace _01._Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string comand=Console.ReadLine();
            decimal sumTotalMoney = 0m;
            

            while (true)
            {

                if (comand == "special") break;
                if (comand == "regular") break;
                decimal curentMonesy = decimal.Parse(comand);

                if (curentMonesy < 0)
                {
                    Console.WriteLine("Invalid price!");
                    
                }
                else
                {
                    sumTotalMoney += curentMonesy;
                }
                comand = Console.ReadLine();
            }

            decimal taxes = sumTotalMoney * 0.2m;
            decimal endPryce = taxes + sumTotalMoney;

            if(comand == "special")
            {
                endPryce *= 0.9m;
            }

            if (sumTotalMoney == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                Console.WriteLine($"Congratulations you've just bought a new computer!\n" +
                    $"Price without taxes: {sumTotalMoney:f2}$\n" +
                    $"Taxes: {taxes:f2}$\n" +
                    $"----------- \n" +
                    $"Total price: {endPryce:f2}$");
            }

        }
    }
}