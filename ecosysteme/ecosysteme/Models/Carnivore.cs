using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ecosysteme.Models
{
    abstract class Carnivore : Animal
    {
        IComportement<Carnivore> comportement;
        private List<Type> prey; //liste des proie que le carnivore va chasser
        int attackPower;

        public Carnivore(double x, double y,int pv,int energie,int consEne,int nbrViande,int rayonContactZone,int rayonVisionZone,int speed,int attackPower): base(Colors.Red, x, y, pv, energie, consEne, nbrViande)
        {
            contactZone = new Zone(rayonContactZone);
            visionZone = new Zone(rayonVisionZone);
            SetDiet(new List<Type>
            {
                typeof(Meat)
            });
            SetPrey(new List<Type>
            {
                typeof(Herbivore)
            });
            this.SetSpeed(speed);
            this.attackPower = attackPower;
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

        /*protected override void Reproduce() 
        {
            AddToSimulation(new Carnivore(X, Y));
        }*/


        public bool CanAttack()
        {
            return ObjectInZone(contactZone, prey);
        }
        protected void Attack(LifeForm target)
        {
            target.LosePv(attackPower);
        }
        public bool SeePrey()
        {
            return ObjectInZone(visionZone, prey);
        }
        public void Attack()
        {
            Attack((LifeForm)contactZone.ClosestObject(this, prey));
        }
        public SimulationObject ClosestSeePrey()
        {
            return visionZone.ClosestObject(this, prey);
        }
    }
}
