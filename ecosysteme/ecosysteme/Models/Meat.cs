using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    internal class Meat : SimulationObject,IFood
    {
        int pv;                             //ex = 5 pv
        int energieParPv;                   //ex = 100 cal        quand un carnivore consomme de la viande,
        int peremptionTime;                 //             il mange 1 ou plusieurs pv de viande ce qui lui rend un certain nombre de calories

        public Meat(double x, double y, int energie, int nbrViande,int perTime) : base(Colors.Pink, x, y)
        {
            this.pv = nbrViande;
            this.energieParPv = energie;
            this.peremptionTime = perTime;
        }

        public override void Update()
        {
            Expiration();
        }

        protected override void Disappear()
        {
            SetAppearObj(new OrganicWaste(X, Y, 1, 20));
            base.Disappear();
        }

        int IFood.IsEaten(int nbrPVTake) 
        {
            int energieGive = 0;
            if(this.pv - nbrPVTake >= 0)
            {
                energieGive = nbrPVTake * energieParPv;
                this.pv = pv - nbrPVTake;
            }
            else
            {
                energieGive = pv * energieParPv;
                pv = 0;
            }
            if(this.pv== 0) { Disappear(); }
            return energieGive;
        }

        protected void Expiration() 
        {
            peremptionTime--;

            if (peremptionTime <= 0) 
            {
                Disappear();
            }
        }
    }
}
