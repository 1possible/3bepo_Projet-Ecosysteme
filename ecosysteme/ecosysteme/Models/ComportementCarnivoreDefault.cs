using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    internal class ComportementCarnivoreDefault : ComportementAnimalDefault<Carnivore>
    {
        enum ComportementEtat
        {
            None = 0,
            Alimentation = 1,
            Reproduction = 3,
            Hunt =4
        }
        enum ComportementsubEtat
        {
            None = 0,
            MoveTo = 1,
            Motionless = 2
        }
        ComportementEtat etat = ComportementEtat.None;
        ComportementsubEtat subEtat = ComportementsubEtat.None;
        public ComportementCarnivoreDefault() { }
        public override void UpdateEtat(Carnivore thisObject)
        {
            bool alimentationCond = CondWantFood(thisObject);
            if (alimentationCond && AvailableFoodMoveless(thisObject))
            {
                subEtat = ComportementsubEtat.Motionless;
                etat = ComportementEtat.Alimentation;
            }
            else if (alimentationCond && AvailableFoodMove(thisObject))
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
        protected override void ActionEtat(Carnivore thisObject)
        {
            switch (etat)
            {
                case ComportementEtat.Alimentation:
                    if (subEtat == ComportementsubEtat.Motionless)
                    {
                        ActionAlimentationMoveless(thisObject);
                    }
                    else if (subEtat == ComportementsubEtat.MoveTo)
                    {
                        ActionAlimentationMove(thisObject);
                    }
                    break;
                case ComportementEtat.Hunt:
                    if (subEtat == ComportementsubEtat.Motionless)
                    {
                        ActionHuntMoveless(thisObject);
                    }
                    else if (subEtat == ComportementsubEtat.MoveTo)
                    {
                        ActionHuntMove(thisObject);
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
        protected bool AvailableHuntMove(Carnivore thisObject)
        {
            return false;
        }
        protected bool AvailableHuntMoveless(Carnivore thisObject)
        {
            return false;
        }
        protected void ActionHuntMoveless(Carnivore thisObject)
        {
        }
        protected void ActionHuntMove(Carnivore thisObject)
        {
        }

    }
}
