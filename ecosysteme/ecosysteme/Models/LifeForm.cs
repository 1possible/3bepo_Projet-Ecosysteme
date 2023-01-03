using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        private List<Type> diet; //liste de type d'object que this object peut manger
        
        public LifeForm(Color color, double x, double y, int pv, int energie,int consEne) : base(color, x, y) {
       
            this.pv = pv;
            this.pvMax = pv;
            this.energie = energie;
            this.energieMax = energie;
            this.consomationEnergie = consEne;
            diet = new List<Type>();
        }
        public (int,int) getPv() { return (pv,pvMax); }
        public (int, int) getEnergie() { return (energie, energieMax); }
        protected List<Type> getDiet() { return diet; }
        protected void SetDiet(List<Type> liste)
        {
            diet = new List<Type>();
            foreach(Type t in liste)
            {
                if (typeof(IFood).IsAssignableFrom(t))
                {
                    diet.Add(t);
                }
                else
                {
                    Console.Write(this + " ne peut pas manger " + t + " car ce n'est pas de la nourriture.");
                }
            }
        }
        protected override void Update()
        {
            ConsumeEnergie();
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
            //verifier si l'animal est pas mort(pv<=0) si il est mort appel la fonction Disappear()
        {
            if (this.pv <= 0) 
            {
                Disappear();
            }
        }

        protected void Eat(IFood consomable)
        {//fait manger a l'object le consommable si il est d'un type defini dans diet
            bool foodenable = false;
            foreach (Type t in diet)
            {
                if (consomable.GetType().IsAssignableFrom(t))
                {
                    foodenable = true;
                }
            }
            if (foodenable)
            {
                int energiefood = consomable.IsEaten();
                this.energie = (energiefood + this.energie < energieMax)? energiefood + this.energie :energieMax;
            }
        }



        abstract protected void Reproduce();

        public int losePv(int nbrPv)
        {
            int pvLose = 0;
            if(nbrPv > pv)
            {
                pvLose = pv;
                pv = 0;
            }
            else
            {
                pvLose = nbrPv;
                pv -= nbrPv;
                Disappear();
            }
            return pvLose;

        }
    }
}
