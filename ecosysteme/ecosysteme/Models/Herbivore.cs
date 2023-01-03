using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace ecosysteme.Models
{
    internal class Herbivore : Animal
    {
        public Herbivore(double x, double y) : base(Colors.Black, x, y, 20, 20, 1,5)
        {
            contactZone = new Zone(2);
            visionZone = new Zone(30);
            SetDiet(new List<Type>
            {
                typeof(Plant)
            });
        }

        protected override void Update()
        {
            base.Update();
            base.Move(3);
        }


        protected override void Reproduce() 
        {
            addToSimulation(new Herbivore(X, Y));
        }

        protected override void FindMate(ListSimulationObject listEnvironement)
        {
            List<double[]> visionArea = visionZone.Area(X, Y);
            double distance = 10000;
            double[] coordinate = new double[] { 0, 0 };
            foreach (Herbivore herbi in listEnvironement.getAll<Herbivore>())
            {
                foreach (double[] coord in visionArea)
                {
                    if (herbi.GetCoord()== coord && this.pregnant == false && this.sex != herbi.sex)
                    {
                        if (Zone.Distance(X, Y, coord[0], coord[1]) < distance)
                        {
                            distance = Zone.Distance(X, Y, coord[0], coord[1]);
                            coordinate[0] = coord[0];
                            coordinate[1] = coord[1];
                        }
                    }
                }
            }
            MoveTo(3, coordinate[0], coordinate[1]);
        }
        protected override void Mate(ListSimulationObject listEnvironement)
        {
            List<double[]> contactArea = contactZone.Area(X, Y);
            foreach (Herbivore herbi in listEnvironement.getAll<Herbivore>())
            {
                foreach (double[] coord in contactArea) {
                    if (herbi.GetCoord() == coord && this.pregnant == false && this.sex != herbi.sex)
                    {
                        this.GetPregnant();
                    }
                }
            }
        }
    }
}
