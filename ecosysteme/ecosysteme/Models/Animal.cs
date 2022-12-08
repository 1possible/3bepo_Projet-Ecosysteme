using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public class Animal : SimulationObject
    {
        public Animal(double x, double y) : base(Colors.Red, x, y) { }
        public override void Update()
        {
            X = X + 5;
        }
    }
}
