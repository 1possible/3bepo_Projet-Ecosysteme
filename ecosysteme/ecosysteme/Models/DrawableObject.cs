using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public class DrawableObject
    {
        Color color;
        double x, y;

        //Carnivore: rouge
        //herbivore: Noir
        //plante: vert
        //viande: rose
        //déchet organique: brun


        public DrawableObject(Color color, double x, double y)
        {
            this.color = color;
            this.x = x;
            this.y = y;
        }

        public Color Color { get { return this.color; } }
        public double X { get { return this.x; } set { this.x = value; } }
        public double Y { get { return this.y; } set { this.y = value; } }
    }
}
