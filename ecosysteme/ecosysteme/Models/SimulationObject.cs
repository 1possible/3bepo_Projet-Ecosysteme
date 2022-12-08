using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public abstract class SimulationObject : DrawableObject
    {
        public SimulationObject(Color color, double x, double y) : base(color, x, y) { }

        abstract public void Update();
    }
}
