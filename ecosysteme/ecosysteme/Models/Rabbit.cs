using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    internal class Rabbit:Herbivore
    {
        public Rabbit(double x, double y) : base(x, y,5,20,1,5,6) { }

        protected override void Reproduce()
        {
            AddToSimulation(new Rabbit(X,Y));
        }

    }
}
