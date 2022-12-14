using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public class Simulation : IDrawable
    {
        List<SimulationObject> objects;
        public Simulation()
        {
            objects = new List<SimulationObject>();

            objects.Add(new Animal(100, 100));
            objects.Add(new Plant(50, 100));
        }

        public void Update()
        {
            foreach (SimulationObject simObj in objects)
            {
                simObj.Update();
            }
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            foreach (SimulationObject drawable in objects)
            {
                canvas.FillColor = drawable.Color;
                canvas.FillCircle(new Point(drawable.X, drawable.Y), 5.0);
            }
        }
    }
}
