using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            visionZone = new Zone(100);
            SetDiet(new List<Type>
            {
                typeof(Meat)
            });
            SetPrey(new List<Type>
            {
                typeof(Herbivore)
            });

            speed = 10;
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
