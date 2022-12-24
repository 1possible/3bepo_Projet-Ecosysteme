﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    internal class Meat : SimulationObject,IFood
    {
        int pv;                             //ex = 5 pv
        int energieParPv;                   //ex = 100 cal        quand un carnivore consomme de la viande,
        int peremptionTime;                 //             il mange 1 ou plusieurs pv de viande ce qui lui rend un certain nombre de calories

        public Meat(double x, double y, int energie, int nbrViande,int perTime) : base(Colors.Pink, x, y)
        {
            this.pv = nbrViande;
            this.energieParPv = energie;
            this.peremptionTime = perTime;
        }

        public override void Update()
        {
            Expiration();
        }

        protected override void Disappear()
        {

        }

        void IFood.IsEaten() 
        { 
            Disappear();
        }

        private void Expiration() 
        {
            this.peremptionTime--;

            if (this.peremptionTime <= 0) 
            {
                Disappear();
            }
        }
    }
}
