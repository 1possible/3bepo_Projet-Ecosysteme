using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    internal class ListSimulationObject : List<SimulationObject>, IObserver
    {
        List<SimulationObject> objAdd;
        List<SimulationObject> objRemove;
        public ListSimulationObject() : base() { 
            objAdd = new List<SimulationObject>();
            objRemove = new List<SimulationObject>();
        }

        void IObserver.notify(IObservable observable)
        {
            if (observable is SimulationObject)
            {
                if (observable is SimulationObject)
                {
                    this.temporaireAdd((observable as SimulationObject).appear());

                    if ((observable as SimulationObject).GetDisappearValue() == true)
                    {
                        this.removeTemp(observable as SimulationObject);
                    }
                }
            }
        }
        void temporaireAdd(SimulationObject obj)
        {
            if (obj != null)
            {
                objAdd.Add(obj);
            }
        }
        void removeTemp(SimulationObject simulationObject)
        {
            objRemove.Add(simulationObject);         
        }
        public void update()
        {

            foreach (SimulationObject obj in objRemove)
            {
                this.Remove(obj);
            }
            foreach (SimulationObject obj in objAdd)
            {
                this.Add(obj);
            }
            
            objAdd.Clear();
            objRemove.Clear();
        }
    }
}
