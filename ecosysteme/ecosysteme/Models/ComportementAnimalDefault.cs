using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public class ComportementAnimalDefault<T> : IComportement<T> where T : Animal
    {
        private enum ComportementEtat {
            None,
            Alimentation,
            Reproduction
        }
        enum ComportementSubEtat{
            None,
            MoveTo,
            Motionless
        }
        ComportementEtat etat=ComportementEtat.None;
        ComportementSubEtat subEtat = ComportementSubEtat.None;

        public ComportementAnimalDefault<T>[] Comportements { get; set; }
        public virtual void UpdateEtat(T thisObject)
        {
            bool alimentationCond = CondWantFood( thisObject );
            if (alimentationCond && AvailableFoodMoveless(thisObject))
            {
                subEtat = ComportementSubEtat.Motionless;
                etat = ComportementEtat.Alimentation;
            }
            else if(alimentationCond && AvailableFoodMove(thisObject))
            {
                subEtat = ComportementSubEtat.MoveTo;
                etat = ComportementEtat.Alimentation;
            }
            else if (AvailableReproductionMoveless(thisObject))
            {
                subEtat = ComportementSubEtat.Motionless;
                etat = ComportementEtat.Reproduction;
            }
            else if (AvailableReproductionMove(thisObject))
            {
                subEtat = ComportementSubEtat.MoveTo;
                etat = ComportementEtat.Reproduction;
            }
            else
            {
                subEtat = ComportementSubEtat.None;
                etat = ComportementEtat.None;
            }
            ActionEtat(thisObject);
        }
        protected virtual void ActionEtat(T thisObject)
        {
            switch (etat)
            {
                case ComportementEtat.Alimentation:
                    if (subEtat == ComportementSubEtat.Motionless)
                    {
                        ActionAlimentationMoveless(thisObject);
                    }
                    else if(subEtat == ComportementSubEtat.MoveTo)
                    {
                        ActionAlimentationMove(thisObject);
                    }
                    break;
                case ComportementEtat.Reproduction:
                    if (subEtat == ComportementSubEtat.Motionless)
                    {
                        ActionReproductionMoveless(thisObject);
                    }
                    else if (subEtat == ComportementSubEtat.MoveTo)
                    {
                        ActionReproductionMove(thisObject);
                    }
                    break;
                default:
                    ActionDefault(thisObject);
                    break;
            }
        }
        protected virtual void ActionDefault(T thisObject)
        {
            thisObject.Move();
        }
        protected virtual bool CondWantFood(T thisObject)
        {
            (int, int) energie = thisObject.GetEnergie();
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
            thisObject.MoveTo(cibleFood.X,cibleFood.Y);
        }

        protected virtual void ActionReproductionMove(T thisObject)
        {
            SimulationObject target = thisObject.ClosestP();
            if (target != null)
            {
                thisObject.MoveTo(target.X, target.Y);
            }
        }
        protected virtual void ActionReproductionMoveless(T thisObject)
        {
            thisObject.Mate();
        }
        protected virtual bool AvailableReproductionMoveless(T thisObject)
        {
            return thisObject.CanMate();
        }
        protected bool AvailableReproductionMove(T thisObject)
        {
            return thisObject.CanFindMate();
        }

    }
}
