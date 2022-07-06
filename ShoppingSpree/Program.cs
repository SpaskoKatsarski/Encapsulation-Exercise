using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Person> customers = new List<Person>();
                List<Product> products = new List<Product>();

                string[] peopleInput = Console.ReadLine() //Peter=11;George=4
                    .Split(new char[] { ';', '=' }); //{"Peter", "11", "George", "4"}

                for (int i = 0; i < peopleInput.Length; i += 2)
                {
                    Person person = new Person(peopleInput[i], decimal.Parse(peopleInput[i + 1]));
                    customers.Add(person);
                }

                string[] productsInput = Console.ReadLine() //Bread=10;Milk=2;
                    .Split(new char[] { ';', '=' }); //{"Bread", "10", "Milk", "2"}

                for (int i = 0; i < productsInput.Length; i += 2)
                {
                    Product product = new Product(productsInput[i], decimal.Parse(productsInput[i + 1]));
                    products.Add(product);
                }

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] cmdArgs = command
                        .Split();

                    string customerName = cmdArgs[0];
                    string productToBuy = cmdArgs[1];

                    Person currCustomer = customers.First(p => p.Name == customerName);
                    Product currProduct = products.First(p => p.Name == productToBuy);

                    if (currCustomer.Money >= currProduct.Cost)
                    {
                        currCustomer.Money -= currProduct.Cost;
                        currCustomer.Products.Add(currProduct.Name);
                        Console.WriteLine($"{currCustomer.Name} bought {currProduct.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{currCustomer.Name} can't afford {currProduct.Name}");
                    }
                }

                foreach (var customer in customers)
                {
                    string bothItems = customer.Products.Count > 0 ? string.Join(", ", customer.Products) : "Nothing bought";
                    Console.WriteLine($"{customer.Name} - {bothItems}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
