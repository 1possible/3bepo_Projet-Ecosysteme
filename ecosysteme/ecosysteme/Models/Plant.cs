using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public class Plant : LifeForm
    {

        public Plant(double x, double y) : base(Colors.Green, x, y, 20, 20, 1) { }

        public override void Update()
        {
            base.Update();
        }

        protected override void Disappear()
        {
            SetAppearObj(new OrganicWaste(X, Y, 1, 20));
            base.Disappear();
        }
    }
}
