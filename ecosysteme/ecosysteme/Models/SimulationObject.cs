using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public abstract class SimulationObject : DrawableObject, IObservable
    {
        bool disappearValue;
        SimulationObject appearObj;

        List<IObserver> observers;

        public SimulationObject(Color color, double x, double y) : base(color, x, y)
        {
            disappearValue = false;
            appearObj = null;
            observers = new List<IObserver>();

        }
        abstract public void Update();

        protected virtual void Disappear()
        {
            disappearValue = true;
            callObserver();
        }

        public bool GetDisappearValue() { return disappearValue; }
        protected void SetDisappearValue(bool value) { disappearValue = value; }
        protected void SetAppearObj(SimulationObject value) { appearObj = value; }



        public SimulationObject appear()
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
        public void callObserver()
        {
            foreach (IObserver observer in listObserver)
            {
                observer.notify(this);
            }
        }
    }
}

