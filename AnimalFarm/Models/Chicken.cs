using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalFarm.Models
{
    public class Chicken
    {
        private const int MinAge = 0;
        private const int MaxAge = 15;

        private string name;
        private int age;

        public Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new ArgumentException($"Age should be between {MinAge} and {MaxAge}.");
                }

                this.age = value;
            }
        }

        public double ProductPerDay => CalculateProductPerDay();

        private double CalculateProductPerDay()
        {
            if (this.Age == 0 || this.Age == 1 || this.Age == 2 || this.Age == 3)
            {
                return 1.5;
            }
            else if (this.Age == 4 || this.Age == 5 || this.Age == 6 || this.Age == 7)
            {
                return 2;
            }
            else if (this.Age == 8 || this.Age == 9 || this.Age == 10 || this.Age == 11)
            {
                return 1;
            }
            else
            {
                return 0.75;
            }
        }
    }
}
