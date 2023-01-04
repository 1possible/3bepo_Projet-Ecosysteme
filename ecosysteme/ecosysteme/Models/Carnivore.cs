using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ecosysteme.Models
{
    internal class Carnivore : Animal
    {
        IComportement<Carnivore> comportement;
        private List<Type> prey; //liste des proie que le carnivore va chasser
        int attackPower;
        public Carnivore(double x, double y) : base(Colors.Red, x, y, 30, 20, 1, 5)
        {
            contactZone = new Zone(3);
            visionZone = new Zone(40);
            SetDiet(new List<Type>
            {
                typeof(Meat)
            });
            SetPrey(new List<Type>
            {
                typeof(Herbivore)
            });
            speed = 5;
            attackPower = 5;
            comportement = new ComportementCarnivoreDefault();
        }
        protected void SetPrey(List<Type> liste)
        {
            prey = new List<Type>();
            foreach (Type t in liste)
            {
                if (typeof(LifeForm).IsAssignableFrom(t))
                {
                    prey.Add(t);
                }
                else
                {
                    Console.Write(this + " attaquer " + t + " car ce n'est pas vivant.");
                }
            }
        }
        protected override void Update()
        {
            base.Update();
            comportement.UpdateEtat(this);
        }

        protected override void Reproduce() 
        {
            addToSimulation(new Carnivore(X, Y));
        }

        protected override void FindMate(ListSimulationObject listEnvironement)
        {
            List<double[]> visionArea = visionZone.Area(X, Y);
            double distance = 10000;
            double[] coordinate = new double[] {0,0};
            foreach (Carnivore carni in listEnvironement.getAll<Carnivore>())
            {
                foreach (double[] coord in visionArea)
                {
                    if (carni.GetCoord() == coord)
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
            MoveTo(5, coordinate[0], coordinate[1]);
        }
        protected override void Mate(ListSimulationObject listEnvironement)
        {
            List<double[]> contactArea = contactZone.Area(X, Y);
            foreach (Carnivore carni in listEnvironement.getAll<Carnivore>())
            {
                foreach (double[] coord in contactArea)
                {
                    if (carni.GetCoord() == coord && this.pregnant == false && this.sex != carni.sex)
                    {
                        this.GetPregnant();
                    }
                }
            }
        }
        public bool canAttack()
        {
            return ObjectInZone(contactZone, prey);
        }
        protected void Attack(LifeForm target)
        {
            target.losePv(attackPower);
        }
        public bool SeePrey()
        {
            return ObjectInZone(visionZone, prey);
        }
        public void Attack()
        {
            Attack((LifeForm)contactZone.closestObject(this, prey));
        }
        public SimulationObject closestSeePrey()
        {
            return visionZone.closestObject(this, prey);
        }
    }
}
