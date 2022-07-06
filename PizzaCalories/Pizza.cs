using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name, Dough dough)
        {
            this.Name = name; 
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get 
            { 
                return name; 
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public int NumberOfToppings => this.Toppings.Count;

        public double TotalCalories => CalculateTotalCals();

        private List<Topping> Toppings
        {
            get
            {
                return this.toppings;
            }
            set
            {
                this.toppings = value;
            }
        }

        private Dough Dough
        {
            get
            {
                return this.dough;
            }
            set
            {
                this.dough = value;
            }
        }

        private double CalculateTotalCals()
        {
            double totalCals = 0;

            foreach (var topping in this.Toppings)
            {
                totalCals += topping.TotalCals;
            }

            totalCals += this.Dough.TotalCalories;
            return totalCals;
        }

        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count == 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }

            this.Toppings.Add(topping);
        }
    }
}
