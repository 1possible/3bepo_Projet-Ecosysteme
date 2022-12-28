using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    internal class Carnivore : Animal
    {
        Zone contactZone = new Zone(3);
        Zone visionZone = new Zone(20);
        public Carnivore(double x, double y) : base(Colors.Red, x, y, 20, 20, 1, 5)
        {

        }

        public override void Update()
        {
            base.Update();
            Move(5);
        }


        protected override void Eat(IFood consomable)
        {

        }
        protected override void Reproduce() { }

    }
}
