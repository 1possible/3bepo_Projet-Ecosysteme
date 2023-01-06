using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace ecosysteme.Models
{
    internal class Herbivore : Animal
    {
        IComportement<Herbivore> comportement;
        public Herbivore(double x, double y) : base(Colors.Black, x, y, 5, 20, 1,5)
        {
            contactZone = new Zone(2);
            visionZone = new Zone(30);
            SetDiet(new List<Type>
            {
                typeof(Plant)
            });
            speed = 3;
            comportement = new ComportementAnimalDefault<Herbivore>();
        }

        protected override void Update()
        {
            base.Update();
            //base.Move(speed);
            comportement.UpdateEtat(this);
        }


        protected override void Reproduce() 
        {
            addToSimulation(new Herbivore(X, Y));
        }
    }
}
