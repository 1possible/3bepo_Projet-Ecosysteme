using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public class Simulation {


        private List<Animal> animals;
        public Simulation() { 
            animals = new List<Animal>();
            Animal chien = new Animal("chien", 10);
            Animal chat = new Animal("chat", 15);
            animals.Add(chien);
            animals.Add(chat);

        }
        public List<Animal> Animals { get { return animals; } }

        public void update(double time)
        {
            foreach(var animal in animals)
            {
                animal.update(time);
            }
        }
    }
}
