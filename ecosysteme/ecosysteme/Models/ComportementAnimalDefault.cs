﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public class ComportementAnimalDefault<T> : IComportement<T> where T : Animal
    {
        protected enum ComportementEtat {
            None = 0,
            Alimentation = 1,
            Reproduction = 3,
        }
        protected enum ComportementsubEtat{
            None = 0,
            MoveTo =1,
            Motionless = 2
        }
        ComportementEtat etat=ComportementEtat.None;
        ComportementsubEtat subEtat = ComportementsubEtat.None;

        public ComportementAnimalDefault<T>[] Comportements { get; set; }
        public virtual void UpdateEtat(T thisObject)
        {
            bool alimentationCond = CondWantFood( thisObject );
            if (alimentationCond && AvailableFoodMoveless(thisObject))
            {
                subEtat = ComportementsubEtat.Motionless;
                etat = ComportementEtat.Alimentation;
            }
            else if(alimentationCond && AvailableFoodMove(thisObject))
            {
                subEtat = ComportementsubEtat.MoveTo;
                etat = ComportementEtat.Alimentation;
            }
            /*else if (AvailableReproductionMoveless(thisObject))
            {
                subEtat = ComportementsubEtat.Motionless;
                etat = ComportementEtat.Reproduction;
            }
            else if (AvailableReproductionMove(thisObject))
            {
                subEtat = ComportementsubEtat.MoveTo;
                etat = ComportementEtat.Reproduction;
            }*/
            else
            {
                subEtat = ComportementsubEtat.None;
                etat = ComportementEtat.None;
            }
            ActionEtat(thisObject);
        }
        protected virtual void ActionEtat(T thisObject)
        {
            switch (etat)
            {
                case ComportementEtat.Alimentation:
                    if (subEtat == ComportementsubEtat.Motionless)
                    {
                        ActionAlimentationMoveless(thisObject);
                    }
                    else if(subEtat == ComportementsubEtat.MoveTo)
                    {
                        ActionAlimentationMove(thisObject);
                    }
                    break;
                /*case ComportementEtat.Reproduction:
                    if (subEtat == ComportementsubEtat.Motionless)
                    {
                        ActionReproductionMoveless(thisObject);
                    }
                    else if (subEtat == ComportementsubEtat.MoveTo)
                    {
                        ActionReproductionMove(thisObject);
                    }
                    break;*/
                default:
                    ActionDefault(thisObject);
                    break;
            }
        }
        protected virtual void ActionDefault(T thisObject)
        {
            thisObject.Move(thisObject.GetSpeed());
        }
        protected virtual bool CondWantFood(T thisObject)
        {
            (int, int) energie = thisObject.getEnergie();
            return (double)energie.Item1 / energie.Item2 < 0.5;
        }
        protected virtual bool AvailableFoodMoveless(T thisObject)
        {
            return thisObject.CanEat() ;
        }
        protected virtual bool AvailableFoodMove(T thisObject)
        {
            return thisObject.SeeFood();
        }
        protected virtual void ActionAlimentationMoveless(T thisObject)
        {
            thisObject.Eat();
        }
        protected virtual void ActionAlimentationMove(T thisObject)
        {
            SimulationObject cibleFood = thisObject.closestFood();
            thisObject.MoveTo(thisObject.GetSpeed(),cibleFood.X,cibleFood.Y);
        }

        /*protected abstract void ActionReproductionMove(T thisObject);
        protected abstract void ActionReproductionMoveless(T thisObject);
        protected abstract bool AvailableReproductionMoveless(T thisObject);
        protected abstract bool AvailableReproductionMove(T thisObject);*/

    }
}
