﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public interface IFood
    {
        abstract public int IsEaten(int nbrPVTake);

        public int IsEaten() { return IsEaten(1); }
    }
}
