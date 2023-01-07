//using MetalPerformanceShaders;
using Microsoft.Maui.Graphics.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public abstract class Animal : LifeForm
    {
        int nbrViande;                       // nombre de viande que laisse un animal après sa mort
        int timeForOrganiqueWaste;           // nombre de temps qu'il faut pour faire apparaitre de la matiere organique
        int currentTimeForOrganiqueWaste;    // le temps actuelle passe depuis l'apparition de matiere organique
        int nbrOganiqueWastePerTime;         // le nombre de matiere organique laisser par l'animal
        protected Zone contactZone;
        protected Zone visionZone;
        protected int sex;                             // 1 = femelle, 0 = Male
        protected bool pregnant;
        protected int pregnantTime;
        protected int gestationTime;
        protected int speed;

        public Animal(Color color,double x, double y, int pv, int energie, int consEne, int nbrViande, int sex) : base(color, x, y, pv , energie ,consEne) 
        {
            this.nbrViande = nbrViande;
            timeForOrganiqueWaste = 20;
            currentTimeForOrganiqueWaste = 0;
            nbrOganiqueWastePerTime = 2;
            this.sex = sex;
            pregnant = false;
            pregnantTime = 0;
            gestationTime = 5;
        }
        public Animal(Color color, double x, double y, int pv, int energie, int consEne, int nbrViande) : this(color, x, y, pv, energie, consEne, nbrViande, new Random().Next(0,2))
        {}
        public int GetSpeed() { return speed; }
        protected void SetSpeed(int speed) {
            if(speed > 0)
            {
                this.speed = speed;
            }
            else
            {
                this.speed = 1;
                Console.WriteLine("valeur " + speed + " est invalide: speed doit etre positif.");
            }
        }
        protected override void Update()
        {
            base.Update();
            OrganicWastePeriodic();
            if (this.pregnant == true) {
                PregnancyIteration();
            }
        }
        public override void Update(ListSimulationObject listEnvironment)
        {
            contactZone.updateObjectInZone(listEnvironment, this);
            visionZone.updateObjectInZone(listEnvironment, this);
            base.Update(listEnvironment);
        }

        protected void OrganicWastePeriodic() 
        //va faire apparaitre des matieres organique de facon periodique
        {
            currentTimeForOrganiqueWaste++;
            if(timeForOrganiqueWaste <= currentTimeForOrganiqueWaste)
            {
                AddToSimulation(new OrganicWaste(X, Y, 1, nbrOganiqueWastePerTime));
                currentTimeForOrganiqueWaste = 0;
            }
        }

        protected override void Disappear()
            //fait apparaitre de la viande et fait disparaitre l'animal de la liste
        {
            SetAppearObj(new Meat(X, Y, 100, nbrViande,10));
            base.Disappear();
        }

        private void Move(int speed)
        {
            Random rnd = new Random();
            X += rnd.Next(-speed,speed);
            Y += rnd.Next(-speed,speed);
        }
        public void Move() { Move(speed); }
        private void MoveTo(int speed, double x, double y) 
        {
            double distance = Zone.Distance(x, y, this.X, this.Y);
            if (distance < speed ) 
            {
                X = x;
                Y = y;
            }
            else 
            {
                X += speed * Zone.Direction(X,Y,x,y)[0];
                Y += speed * Zone.Direction(X,Y,x,y)[1];
            }
        }
        public void MoveTo(double x, double y) { MoveTo(speed, x, y); }
        private void PregnancyIteration()
        {
            if (pregnantTime == gestationTime)
            {
                pregnant = false;
                pregnantTime = 0;
                this.Reproduce();
            }
            else { pregnantTime++; }
        }
        protected ListSimulationObject FindMate(ListSimulationObject listEnvironment)
        {
            ListSimulationObject potentialpartner = new ListSimulationObject();
            foreach (SimulationObject elem in listEnvironment)
            {
                if (elem.GetType() == this.GetType())
                {
                    if (((Animal)elem).pregnant == false && ((Animal)elem).sex == 1 && this.sex == 0 )
                    {
                        potentialpartner.Add(elem);
                    }
                }
            }
            return potentialpartner;
        }


        public SimulationObject ClosestPartner(ListSimulationObject list)
        {//closestObject(this,new list<Type>{this.GetType()}); ne marche pas?
            double distance = visionZone.GetRayon();
            SimulationObject closest = null;
            foreach (SimulationObject objectSim in list)
            {
                double distanceTemp = Zone.Distance(objectSim.X, objectSim.Y, this.X, this.Y);
                if (distanceTemp <= distance)
                {
                    closest = objectSim;
                    distance = distanceTemp;
                }
            }
            return closest;
        }

        public SimulationObject ClosestP()
        {
            return ClosestPartner(this.FindMate(this.visionZone.GetObjectInZone()));
        }

        protected void Mate(ListSimulationObject listEnvironment)
        {
            foreach (SimulationObject elem in listEnvironment)
            {
                if (elem.GetType() == this.GetType())
                {
                    if (((Animal)elem).pregnant == false && ((Animal)elem).sex == 1 && this.sex == 0)
                    {
                        ((Animal)elem).GetPregnant();
                    }
                }
            }
        }
        protected void GetPregnant()
        {
            if (this.sex == 1)
            {
                this.pregnant = true;
            }
        }
        public void Mate() { Mate(contactZone.GetObjectInZone()); }

        public bool CanMate()
        {
            return ObjectInZone(contactZone, new List<Type> { this.GetType() })&& !this.pregnant;
        }
        public bool CanFindMate()
        {
            return ObjectInZone(visionZone, new List<Type> { this.GetType() }) && !this.pregnant;
        }
        //---fonction Alimentation---
        public override bool CanEat()
        {
            return ObjectInZone(contactZone,this.GetDiet());
        }
        public override void Eat()
        {
            Eat(contactZone);
        }
        public bool SeeFood()
        {
            return ObjectInZone(visionZone,this.GetDiet());
        }
        public SimulationObject closestFood()
        {
            return visionZone.ClosestObject(this, GetDiet());
        }
    }
}
