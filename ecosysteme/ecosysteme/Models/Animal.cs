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

        public Animal(Color color,double x, double y, int pv, int energie, int consEne, int nbrViande) : base(color, x, y, pv , energie ,consEne) 
        {
            Random rnd = new Random();
            
            this.nbrViande = nbrViande;
            timeForOrganiqueWaste = 20;
            currentTimeForOrganiqueWaste = 0;
            nbrOganiqueWastePerTime = 2;
            sex = rnd.Next(2);
            pregnant = false;
            pregnantTime = 5;
            gestationTime = 0;

        }
        protected override void Update()
        {
            base.Update();
            OrganicWastePeriodic();
            if (this.pregnant == true) {
                PregnancyIteration();
            }
        }
        public override void Update(ListSimulationObject listEnvironement)
        {
            contactZone.updateObjectInZone(listEnvironement, this);
            visionZone.updateObjectInZone(listEnvironement, this);
            base.Update(listEnvironement);
        }

        protected void OrganicWastePeriodic() 
        //va faire apparaitre des matieres organique de facon periodique
        {
            currentTimeForOrganiqueWaste++;
            if(timeForOrganiqueWaste <= currentTimeForOrganiqueWaste)
            {
                addToSimulation(new OrganicWaste(X, Y, 1, nbrOganiqueWastePerTime));
                currentTimeForOrganiqueWaste = 0;
            }
        }

        protected override void Disappear()
            //fait apparaitre de la viande et fait disparaitre l'animal de la liste
        {
            SetAppearObj(new Meat(X, Y, 100, nbrViande,10));
            base.Disappear();
        }

        public void Move(int speed)
        {
            Random rnd = new Random();
            X += rnd.Next(-speed,speed);
            Y += rnd.Next(-speed,speed);
        }

        public void MoveTo(int speed, double x, double y) 
        {
            double distance = Zone.Distance(x, y, X, Y);
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
        protected abstract void FindMate(ListSimulationObject listEnvironement);
        protected abstract void Mate(ListSimulationObject listEnvironement);

        protected void GetPregnant()
        {
            if (this.sex == 1)
            {
                this.pregnant = true;
            }
        }
    }
}
