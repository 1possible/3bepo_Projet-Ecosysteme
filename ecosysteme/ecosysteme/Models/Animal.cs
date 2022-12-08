using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public class Animal
    {
        //public string Filename { get; set; }
        private string name;
        private int pv;
        private double decrasePV = 1000;
        private double waitTime = 0;
        public string Text { get; set; }

        public Animal(string name, int pv) {
            this.name = name;
            this.pv = pv;
            this.Text = name +" a "+ pv + " pv.";
        }
        private void decreasePV()
        {
            pv--;
            if(pv <= 0)
            {
                pv = 0;
            }
        }
        public void update(double timeUpdate)
        {
            waitTime += timeUpdate;
            if(waitTime >= decrasePV)
            {
                waitTime -= decrasePV;
                this.decreasePV();
                this.Text = name + " a " + pv + " pv.";
            }
        }
    }
}
