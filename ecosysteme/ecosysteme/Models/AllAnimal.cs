using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ecosysteme.Models
{
    internal class AllAnimal
    {
        GameManager manager;

        public AllAnimal()
        {
            manager = new GameManager();
            LoadAnimals();
        }
        public ObservableCollection<Animal> Animals { get; set; } = new ObservableCollection<Animal>();

        //public AllAnimal() =>
        //    LoadAnimals();

        public void LoadAnimals()
        {
            Animals.Clear();

            // Get the folder where the notes are stored.
            //string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            //manager.Update();
            List<Animal> animals =manager.Animals();

            // Add each note into the ObservableCollection
            foreach (Animal animal in animals)
                Animals.Add(animal);
        }

        public void update()
        {
            manager.update();
        }
    }
}
