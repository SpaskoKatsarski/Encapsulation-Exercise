using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaName = Console.ReadLine().Split();
                string[] doughInfo = Console.ReadLine().Split();
                Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));
                Pizza pizza = new Pizza(pizzaName[1], dough);

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingsInfo = input.Split();
                    Topping topping = new Topping(toppingsInfo[1], double.Parse(toppingsInfo[2]));
                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
