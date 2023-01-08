using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public interface IComportement<T>
    {
        public void UpdateEtat(T thisObject);
        //protected void ActionEtat(T thisObject);
        //protected void ActionAlimentation(T thisObject);
        //abstract protected void ActionReproduction(T thisObject);
    }
}
