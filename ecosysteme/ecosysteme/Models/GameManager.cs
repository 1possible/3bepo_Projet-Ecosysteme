using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public class GameManager
    {
        private DateTime lastUpdate;
        private Simulation simulation;
        public GameManager()
        {
            this.lastUpdate = DateTime.UtcNow;
            simulation = new Simulation();
        }
        public void update()
        {

            var currentUpdate = DateTime.UtcNow;
            var timeSinceLastUpdate = currentUpdate - lastUpdate;

            lastUpdate = currentUpdate;

            simulation.update(timeSinceLastUpdate.TotalMilliseconds);
        }
        public List<Animal> Animals() { return simulation.Animals; }
    }
}
