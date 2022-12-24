using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public interface IObserver
    {
        public void notify(IObservable observable);
    }
}
