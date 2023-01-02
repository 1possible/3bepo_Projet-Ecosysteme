using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    internal interface IComportement<T>
    {
        enum etatComportementBase
        {
            None = 0,
            Alimentation = 1,
            reproduction = 2
        }


        abstract public void UpdateEtat(T thisObject);

        abstract protected bool AvailableAlimentation(T thisObject);
        abstract protected void ActionAlimentation(T thisObject);
        abstract protected bool AvailableReproduction(T thisObject);
        abstract protected void ActionReproduction(T thisObject);
    }
}
