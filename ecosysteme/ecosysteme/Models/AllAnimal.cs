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
        public ObservableCollection<Animal> Animals { get; set; } = new ObservableCollection<Animal>();

        public AllAnimal() =>
            LoadAnimals();

        public void LoadAnimals()
        {
            Animals.Clear();

            // Get the folder where the notes are stored.
            //string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            Animal chat = new Animal();
            chat.Text = "c'est un chat.";
            Animal chien = new Animal();
            chien.Text = "c'est un chien";
            List<Animal> animals = new List<Animal>();
            animals.Add(chat);
            animals.Add(chien);

            // Add each note into the ObservableCollection
            foreach (Animal animal in animals)
                Animals.Add(animal);
        }
    }
}
