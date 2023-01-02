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
        public Plant(double x, double y) : base(Colors.Green, x, y, 10, 10, 1)
        {
            reproTime = 15;
            List<Type> diet = new List<Type>
            {
                typeof(OrganicWaste)
            };
            SetDiet(diet);
        }
        protected override void Update()
        {
            base.Update();
            if (!GetDisappearValue())
            {
                Reproduce();
                testAlimentaire();
            }
        }
        public override void Update(ListSimulationObject listEnvironement)
        {
            spreadZone.updateObjectInZone(listEnvironement, this);
            rootZone.updateObjectInZone(listEnvironement, this);
            base.Update(listEnvironement);
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
        //retourn si oui ou non il y a un object a manger dans sa spreadZone
        public bool CanEat()
        {
            bool haveFood = false;
            if (spreadZone.getObjectInZone().getAll(this.getDiet()).Count() > 0)
            {
                haveFood = true;
            }
            return haveFood;
        }
        public void Eat()
        {
            SimulationObject cible = spreadZone.closestObject(this, this.getDiet());
            if (cible != null)
            {
                if (cible is IFood)
                {
                    this.Eat((IFood)cible);
                }
            }
        }
        protected void testAlimentaire()
        {
            if (CanEat())
            {
                Eat();
            }
        }
    }
}
