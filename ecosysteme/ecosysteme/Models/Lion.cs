using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    internal class Lion : Carnivore
    {
        public Lion(double X, double Y) : base(X, Y,20,20,1,5,3,100,10,5) { }
        protected override void Reproduce() 
        {
            AddToSimulation(new Lion(X, Y));
        }
    }
}
