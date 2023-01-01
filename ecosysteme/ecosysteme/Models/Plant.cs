using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public class Plant : LifeForm
    {
        Zone spreadZone = new Zone(50);
        Zone rootZone = new Zone(20);
        int reproTime;
        public Plant(double x, double y) : base(Colors.Green, x, y, 20, 20, 1) 
        {
            reproTime = 15;
        }

        public override void Update()
        {
            base.Update();
            Reproduce();
        }

        protected override void Disappear()
        {//fait apparaitre de la matiere organique et fait disparaitre cet object 
            SetAppearObj(new OrganicWaste(X, Y, 1, 20));
            base.Disappear();
        }

        protected override void Reproduce() 
        {
            reproTime--;

            List<double[]> spreadArea = spreadZone.Area(X, Y);
            
            Random rnd = new Random();
            int randomCoord = rnd.Next(0, spreadArea.Count);
            
            if (reproTime <= 0)
            {
                //fait apparaitre une plante à des coordonnées aléatoires dans la zone.
                addToSimulation(new Plant(spreadArea[randomCoord][0], spreadArea[randomCoord][1]));
                reproTime = 15;
            }
        }
    }
}
