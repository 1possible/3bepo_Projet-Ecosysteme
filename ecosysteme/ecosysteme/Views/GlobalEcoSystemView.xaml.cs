using ecosysteme.Models;
//using UIKit;

namespace ecosysteme.Views;

public partial class GlobalEcoSystemView : ContentPage
{
    IDispatcherTimer timer;
    public GlobalEcoSystemView()
    {
        InitializeComponent();

        BindingContext = new Models.AllAnimal();

        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(500);
        timer.Tick += this.OnTimeEvent;
        timer.Start();
    }

    protected override void OnAppearing()
    {
        ((Models.AllAnimal)BindingContext).LoadAnimals();
    }

    /*private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NotePage));
    }*/

    private async void animalsCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the animal model
            var animal = (Models.Animal)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            //await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.Filename}");

            // Unselect the UI
            animalsCollection.SelectedItem = null;
        }
    }
    private void OnTimeEvent(object source, EventArgs e)
    {
        ((Models.AllAnimal)BindingContext).update();
        //animalsCollection.Invalidate();
    }
}
