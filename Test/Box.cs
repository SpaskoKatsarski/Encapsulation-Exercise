using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    internal class Box
    {
        private readonly List<int> numbers = new List<int>();


        public IReadOnlyCollection<int> Numbers
        {
            get 
            { 
                return this.numbers; 
            }
        }
    }
}
