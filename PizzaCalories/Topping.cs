﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double BaseCalsPerGram = 2;

        private const double CalsPerGramForMeat = 1.2;
        private const double CalsPerGramForVeggies = 0.8;
        private const double CalsPerGramForCheese = 1.1;
        private const double CalsPerGramForSauce = 0.9;

        private string type;
        private double grams;

        public Topping(string type, double grams)
        {
            this.Type = type;
            this.Grams = grams;
        }

        private string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        private double Grams
        {
            get
            {
                return this.grams;
            }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{this.Type} weight should be in the range [1..50].");
                }

                this.grams = value;
            }
        }

        public double TotalCals => CalculateTotalCals();

        private double CalculateTotalCals()
        {
            double totalCals = BaseCalsPerGram;

            if (this.Type == "Meat")
            {
                totalCals *= CalsPerGramForMeat;
            }
            else if (this.Type == "Veggies")
            {
                totalCals *= CalsPerGramForVeggies;
            }
            else if (this.Type == "Cheese")
            {
                totalCals *= CalsPerGramForCheese;
            }
            else if (this.Type == "Sauce")
            {
                totalCals *= CalsPerGramForSauce;
            }

            return totalCals * this.Grams;
        }
    }
}
