using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public class Zone
    {
        double rayon;
        public Zone(double rayon)
        {
            this.rayon = rayon;
        }
        public double getRayon() { return this.rayon;}
    }
}
