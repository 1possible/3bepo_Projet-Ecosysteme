using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    internal class Herbivore : Animal
    {
        public Herbivore(double x, double y) : base(Colors.Black, x, y, 20, 20, 1,5)
        {

        }

        public override void Update()
        {
            base.Update();
            base.Move(3);
        }


        protected override void Eat(IFood consomable)
        {

        }

        protected override void Reproduce() { }
    }
}
