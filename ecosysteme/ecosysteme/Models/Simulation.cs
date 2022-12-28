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
            objects = new ListSimulationObject();

            objects.Add(new Carnivore(100, 150));
            objects.Add(new Herbivore(100, 100));
            objects.Add(new Carnivore(100, 150));
            objects.Add(new Herbivore(100, 100));
            objects.Add(new Carnivore(100, 150));
            objects.Add(new Herbivore(100, 100));
            objects.Add(new Plant(50, 100));
            objects.Add(new OrganicWaste(20,20,100,5));
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
                simobj.Update();
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