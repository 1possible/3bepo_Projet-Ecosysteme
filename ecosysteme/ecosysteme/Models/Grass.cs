using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    internal class Grass:Plant
    {
        public Grass(double x,double y) : base(x, y, 5, 5, 1, 4){}

        protected override void Reproduce()
        {
            this.SpawnInSpreadZone<Grass>();
        }
    }
}
