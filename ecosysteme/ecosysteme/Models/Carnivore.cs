using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    internal class Carnivore : Animal
    {
        public Carnivore(double x, double y) : base(Colors.Red, x, y, 20, 20, 1, 5)
        {

        }

        public override void Update()
        {
            base.Update();
            base.Move(5);
        }

        public override void Disappear()
        {
            
        }

    }
}
