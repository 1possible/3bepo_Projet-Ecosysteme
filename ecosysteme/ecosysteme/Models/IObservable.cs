using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
     public interface IObservable
    {

        List<IObserver> listObserver { get; }

        public void addObserver(IObserver observer);
        public void removeObserver(IObserver observer);
        public void callObserver();
    }
}
