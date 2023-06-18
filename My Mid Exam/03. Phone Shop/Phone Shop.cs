namespace _03._Phone_Shop
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> phones = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string comand = string.Empty;
            while ((comand = Console.ReadLine()) != "End")
            {
                string[] comandArg = comand.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string operation = comandArg[0];
                string phone = comandArg[1];

                if(operation == "Add")
                {
                    if (phones.Any(p => p == phone) == false)
                    {
                        phones.Add(phone);
                    }
                }
                else if (operation == "Remove")
                {
                    if(phones.Any(p => p == phone))
                    {
                        phones.Remove(phone);
                    }
                }
                else if (operation == "Bonus phone")
                {
                    string[] distributor = phone.Split(":", StringSplitOptions.RemoveEmptyEntries);
                    string oldPhone = distributor[0];
                    string newPhone = distributor[1];

                    if(phones.Any(p => p == oldPhone))
                    {
                        int index = phones.IndexOf(oldPhone);
                        phones.Insert(index + 1, newPhone);
                    }
                }
                else if(operation == "Last")
                {
                    if (phones.Any(p => p == phone))
                    {
                        phones.Remove(phone);
                        phones.Add(phone);
                    }
                }
            }
            Console.WriteLine(string.Join(", " , phones));
        }
    }
}