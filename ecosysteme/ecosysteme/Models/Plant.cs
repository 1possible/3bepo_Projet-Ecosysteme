using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public abstract class Plant : LifeForm, IFood
    {
        Zone spreadZone = new Zone(50);
        Zone rootZone = new Zone(20);
        int reproTime;
        IComportement<Plant> comportement;
        int energiePerPv;
        public Plant(double x, double y,int pv,int energie,int consEne,int energiePerPv) : base(Colors.Green, x, y, pv, energie, consEne)
        {
            reproTime = 15;
            List<Type> diet = new List<Type>
            {
                typeof(OrganicWaste)
            };
            SetDiet(diet);
            comportement = new ComportementPlantDefault(this);
            this.energiePerPv = energiePerPv;
        }
        protected override void Update()
        {
            base.Update();
            if (!GetDisappearValue())
            {
                Reproduce();
                comportement.UpdateEtat(this);
            }
        }
        public override void Update(ListSimulationObject listEnvironement)
        {
            spreadZone.updateObjectInZone(listEnvironement, this);
            rootZone.updateObjectInZone(listEnvironement, this);
            base.Update(listEnvironement);
        }

        protected override void Disappear()
        {//fait apparaitre de la matiere organique et fait disparaitre cet object 
            SetAppearObj(new OrganicWaste(X, Y, 1, 20));
            base.Disappear();
        }

        protected void SpawnInSpreadZone<T>() where T : SimulationObject
        {
            reproTime--;

            List<double[]> spreadArea = spreadZone.Area(X, Y);
            
            Random rnd = new Random();
            int randomCoord = rnd.Next(0, spreadArea.Count);
            
            if (reproTime <= 0)
            {
                //fait apparaitre une plante à des coordonnées aléatoires dans la zone.
                Type classType = typeof(T);
                ConstructorInfo classConstructor = classType.GetConstructor(new Type[] { typeof(double),typeof(double) });
                T classInstance = (T)classConstructor.Invoke(new object[] { spreadArea[randomCoord][0], spreadArea[randomCoord][1] });
                AddToSimulation(classInstance);
                reproTime = 15;
            }
        }

        //---Fonction Alimentation---
        //retourn si oui ou non il y a un object a manger dans sa spreadZone
        public override bool CanEat()
        {
            return ObjectInZone(spreadZone,this.GetDiet());
        }
        //fonction qui fait manger la plantes la nourriture la plus proche dans sa zone spreadZone
        public override void Eat()
        {
            Eat(spreadZone);
        }
        //---interface IFood---
        public int IsEaten(int nbrPVTake)
        {
            int energieGive = LosePv(nbrPVTake) * energiePerPv;
            return energieGive;
        }
    }
}
