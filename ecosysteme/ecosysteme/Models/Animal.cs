using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public class Animal : LifeForm
    {
        public Animal(double x, double y) : base(Colors.Red, x, y,20,20,1) { }
        public override void Update()
        {
            base.Update();
            //X = X + 5;
        }
    }
}
