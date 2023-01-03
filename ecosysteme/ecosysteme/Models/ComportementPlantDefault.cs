using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public class ComportementPlantDefault : IComportement<Plant>
    {
        protected enum etatComportementBase
        {
            None = 0,
            Alimentation = 1
        }
        etatComportementBase etat = etatComportementBase.None;

        public ComportementPlantDefault(Plant thisObject) { }
        public void UpdateEtat(Plant thisObject)
        {
            (int,int) energie = thisObject.getEnergie();
            if (energie.Item1 / energie.Item2 < 0.5 && thisObject.CanEat())
            {
                etat = etatComportementBase.Alimentation;
            }
            else
            {
                etat = etatComportementBase.None;
            }
            ActionEtat(thisObject);
        }
        protected void ActionEtat(Plant thisObject)
        {
            switch(etat)
            {
                case etatComportementBase.Alimentation:
                    ActionAlimentation(thisObject);
                    break;
            }
        }
        protected void ActionAlimentation(Plant thisObject)
        {
            thisObject.Eat();
        }

        //reporduction pas prit en charge par le comportement de la plant
        /*
        void ActionReproduction(Plant thisObject)
        {
            throw new NotImplementedException();
        }
        bool AvailableReproduction(Plant thisObject)
        {
            throw new NotImplementedException();
        }*/
    }
}
