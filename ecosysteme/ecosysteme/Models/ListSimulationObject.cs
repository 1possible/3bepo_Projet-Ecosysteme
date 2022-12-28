using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    internal class ListSimulationObject : List<SimulationObject>, IObserver
    {
        //liste qui va temporairement contenir les objects qu'il faut ajouter ou retirer
        //car on ne peut pas modifier directement la liste quand elle est entrain d'etre parcouru
        //la liste se met a jour avec update
        List<SimulationObject> objAdd;       
        List<SimulationObject> objRemove;
        public ListSimulationObject() : base() { 
            objAdd = new List<SimulationObject>();
            objRemove = new List<SimulationObject>();
        }

        void IObserver.notify(IObservable observable)
        //va rajouter si il le faut des object dans la liste objAdd ou/et objRemove
        //cette fonction est appeler par l'observable des qu'il y a un changement qui doit etre fait dans la liste
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
        //rajoute dans la liste objAdd pour que l'object soit rajouter dans la liste lors de this.Update()
        {
            if (obj != null)
            {
                objAdd.Add(obj);
            }
        }
        void removeTemp(SimulationObject simulationObject)
        //rajoute dans la liste objRemove pour que l'oject soit retirer de la liste lors de this.Update()
        {
            objRemove.Add(simulationObject);         
        }
        public void update()
            //met a jour la liste
            //rajoute et retire les element des liste objAdd et objRemove
        {

            foreach (SimulationObject obj in objRemove)
            {
                this.Remove(obj);
            }
            foreach (SimulationObject obj in objAdd)
            {
                obj.addObserver(this); 
                //rajoute cet observer a observable sinon l'object ne peut plus modifier la liste si besoin
                this.Add(obj);
            }
            
            objAdd.Clear();
            objRemove.Clear();
        }
        public ListSimulationObject getAll<T>()
        {
            ListSimulationObject list = new ListSimulationObject();
            foreach (SimulationObject obj in this)
            {
                if (obj is T)
                {
                    list.Add(obj);
                }
            }
            return list;
        }
    }
}
