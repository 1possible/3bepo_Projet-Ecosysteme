using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public abstract class SimulationObject : DrawableObject, IObservable
    {
        bool disappearValue;                //true => l'object doit disparaitre de la liste , false l'object doit rester dans la liste
        SimulationObject appearObj;         //l'object que l'on fait apparaitre quand on appel callObserver()
        List<IObserver> observers;          //liste des observers (sert a modifier la liste)
        public SimulationObject(Color color, double x, double y) : base(color, x, y)
        {
            disappearValue = false;
            appearObj = null;
            observers = new List<IObserver>();
        }
        abstract protected void Update();

        virtual public void Update(ListSimulationObject listEnvironement)
        {
            Update();
        }

        protected virtual void Disappear()//fait disparaitre l'object
        {
            if (!disappearValue) {
            disappearValue = true;//met que l'object doit disparaitre
            callObserver(); //notifie observer (la liste de simulation) qu'il y a eu un changement (ici la disparition de l'object)
        }
    }

        public bool GetDisappearValue() { return disappearValue; }//retourne la valeur Disappearvalue
        private void SetAppearObj(SimulationObject value) { appearObj = value; }//change la valeur SetAppearObj

        protected void AddToSimulation(SimulationObject value)
            //rajoute dans les observer (la liste simulation) un object
        {
            SetAppearObj(value);
            callObserver();
            SetAppearObj(null);
        }

        public SimulationObject GetAppearObj() 
            //retourne juste l'object appear (sert pour le Observer)
        {
            return appearObj;
        }

        //IObservable
        public List<IObserver> listObserver => observers;
        public void addObserver(IObserver observer)
        {
            listObserver.Add(observer);
        }
        public void removeObserver(IObserver observer)
        {
            for (int i = 0; i < listObserver.Count; i++)
            {
                if (listObserver[i] == observer)
                {
                    listObserver.RemoveAt(i);
                }
            }
        }
        public void callObserver()//va notifier tout les observers d'un changement (mort ou/et rajout d'un obj (appear))
        {
            foreach (IObserver observer in listObserver)
            {
                observer.notify(this);
            }
        }
    }
}

