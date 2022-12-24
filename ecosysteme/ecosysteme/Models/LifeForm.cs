using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public abstract class LifeForm : SimulationObject
    {
        int pv;
        int pvMax;
        int energie;
        int energieMax;
        int consomationEnergie;

        public LifeForm(Color color, double x, double y, int pv, int energie,int consEne) : base(color, x, y) {
       
            this.pv = pv;
            this.pvMax = pv;
            this.energie = energie;
            this.energieMax = energie;
            this.consomationEnergie = consEne;
        }

        public override void Update()
        {
            consumeEnergie();
            isDeath();

        }
        protected void ConsumeEnergie()
        {
            if (this.energie - this.consomationEnergie >= 0)
            {
                this.energie = this.energie - this.consomationEnergie;
            }
            else
            {
                this.pv = (this.pv - (this.consomationEnergie - this.energie)>0)? this.pv - (this.consomationEnergie - this.energie) :0;
                this.energie = 0;
            }

        }
        protected void isDeath()
        {
            if (this.pv <= 0) 
            {
                Disappear();
            }
        }

        abstract protected void Eat(IFood consomable);


        abstract protected void Reproduce();
    }
}
