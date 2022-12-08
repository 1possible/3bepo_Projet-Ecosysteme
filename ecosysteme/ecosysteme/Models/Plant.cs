using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public class Plant : SimulationObject
    {
        public Plant(double x, double y) : base(Colors.Green, x, y) { }

        public override void Update()
        {

        }
    }
}
