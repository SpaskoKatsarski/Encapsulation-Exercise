using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double BaseCalsPerGram = 2;
        private const double WhiteCals = 1.5;
        private const double WholegrainCals = 1.0;

        private const double CrispyCals = 0.9;
        private const double ChewyCals = 1.1;
        private const double HomemadeCals = 1.0;

        private string type;
        private string bakingTechnique;
        private double grams;

        public Dough(string type, string bakingTechnique, double grams)
        {
            this.Type = type;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }

        public double TotalCalories => this.CalculateCals();

        private string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.type = value;
            }
        }

        private string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.bakingTechnique = value;   
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
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }

                this.grams = value;
            }
        }

        private double CalculateCals()
        {
            double totalCalsPerGram = BaseCalsPerGram;

            if (this.Type.ToLower() == "white")
            {
                totalCalsPerGram *= WhiteCals;
            }
            else if (this.Type.ToLower() == "wholegrain")
            {
                totalCalsPerGram *= WholegrainCals;
            }

            if (this.BakingTechnique.ToLower() == "crispy")
            {
                totalCalsPerGram *= CrispyCals;
            }
            else if (this.BakingTechnique.ToLower() == "chewy")
            {
                totalCalsPerGram *= ChewyCals;
            }
            else if (this.BakingTechnique.ToLower() == "homemade")
            {
                totalCalsPerGram *= HomemadeCals;
            }

            return totalCalsPerGram * this.Grams;
        }
    }
}
