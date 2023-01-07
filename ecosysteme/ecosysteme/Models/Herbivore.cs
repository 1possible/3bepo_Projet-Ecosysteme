using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace ecosysteme.Models
{
    internal abstract class Herbivore : Animal
    {
        IComportement<Herbivore> comportement;
        public Herbivore(double x, double y,int pv,int energie,int consEne,int nbrViande,int speed) : base(Colors.Black, x, y, pv,energie,consEne,nbrViande)
        {
            contactZone = new Zone(2);
            visionZone = new Zone(100);
            SetDiet(new List<Type>
            {
                typeof(Plant)
            });
            SetSpeed(speed);
            comportement = new ComportementAnimalDefault<Herbivore>();
        }

        protected override void Update()
        {
            base.Update();
            //base.Move(speed);
            comportement.UpdateEtat(this);
        }


        /*protected override void Reproduce() 
        {
            AddToSimulation(new Herbivore(X, Y));
        }*/
    }
}
