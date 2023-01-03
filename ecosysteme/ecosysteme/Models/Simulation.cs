using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public class Simulation : IDrawable
    {
        ListSimulationObject objects;
        public Simulation()
        {
            //int i = 0;
            Random rnd = new Random();
            objects = new ListSimulationObject();
            /*while (i<20)
            {
                objects.Add(new Herbivore(rnd.Next(1, 1000), rnd.Next(1, 800)));
                objects.Add(new Carnivore(rnd.Next(1, 1000), rnd.Next(1, 800)));
                objects.Add(new Plant(rnd.Next(1, 1000), rnd.Next(1, 800)));
                i++;
            }*/
            objects.Add(new Herbivore(200, 210));
            objects.Add(new Plant(200, 200,4));
            objects.Add(new Herbivore(210, 200));
            objects.Add(new OrganicWaste(200,200,100,5));
            objects.Add(new Meat(40, 40, 100, 5,10));

            foreach(var obj in objects)
            {
                obj.addObserver(objects);
            }
        }

        public void Update()
        {
            foreach (SimulationObject simobj in objects)
            {
                simobj.Update(objects);
            }
            objects.update();//va mettre a jour la liste avec les modification qu'il y a eu
            //car on peut pas la modifier quand elle est parcourue
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            foreach (SimulationObject drawable in objects.getAll<OrganicWaste>())
            {
                DrawObject(canvas,dirtyRect,drawable);
            }
            foreach (SimulationObject drawable in objects.getAll<Meat>())
            {
                DrawObject(canvas, dirtyRect, drawable);
            }
            foreach (SimulationObject drawable in objects.getAll<Plant>())
            {
                DrawObject(canvas, dirtyRect, drawable);
            }
            foreach (SimulationObject drawable in objects.getAll<Animal>())
            {
                DrawObject(canvas, dirtyRect, drawable);
            }
        }
        private void DrawObject(ICanvas canvas, RectF dirtyRect, SimulationObject drawable)
        {
            canvas.FillColor = drawable.Color;
            canvas.FillCircle(new Point(drawable.X, drawable.Y), 5.0);
        }
    }
}