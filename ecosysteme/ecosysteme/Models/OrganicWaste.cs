﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    internal class OrganicWaste : SimulationObject,IFood
    {
        int pv;                             
        int energieParPv;                   

        public OrganicWaste(double x, double y, int energie, int nbrViande) : base(Colors.Brown, x, y)
        {
            this.pv = nbrViande;
            this.energieParPv = energie;
        }

        public override void Update()
        {
        }
        protected override void Disappear()
        {
        }

        int IFood.IsEaten()
        {
            return 1;
        }
    }
}
