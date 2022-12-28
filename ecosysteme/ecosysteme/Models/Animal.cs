//using MetalPerformanceShaders;
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
        public Animal(Color color,double x, double y, int pv, int energie, int consEne, int nbrViande) : base(color, x, y, pv , energie ,consEne) 
        {
            this.nbrViande = nbrViande;
            timeForOrganiqueWaste = 5;
            currentTimeForOrganiqueWaste = 0;
            nbrOganiqueWastePerTime = 2;
        }
        public override void Update()
        {
            base.Update();
            OrganicWastePeriodic();
        }

        protected void OrganicWastePeriodic() 
        //va faire apparaitre des matiere organique de facon periodique
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

    }
}
