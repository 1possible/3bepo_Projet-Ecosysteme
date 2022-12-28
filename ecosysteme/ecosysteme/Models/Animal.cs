//using MetalPerformanceShaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public abstract class Animal : LifeForm
    {
        int nbrViande;                       // nombre de viande que laisse un animal après sa mort
        public Animal(Color color,double x, double y, int pv, int energie, int consEne, int nbrViande) : base(color, x, y, pv , energie ,consEne) 
        {
            this.nbrViande = nbrViande;
        }
        public override void Update()
        {
            base.Update();  
        }

        protected override void Disappear()
        {
            SetAppearObj(new Meat(X, Y, 100, nbrViande,10));
            base.Disappear();
        }

        public void Move(int speed)
        {
            Random rnd = new Random();
            X += rnd.Next(-speed,speed);
            Y += rnd.Next(-speed,speed);
        }

    }
}
