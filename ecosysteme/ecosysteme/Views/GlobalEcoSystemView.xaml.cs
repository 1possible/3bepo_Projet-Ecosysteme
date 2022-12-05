namespace ecosysteme.Views;

public partial class GlobalEcoSystemView : ContentPage
{
    public GlobalEcoSystemView()
    {
        InitializeComponent();

        BindingContext = new Models.AllAnimal();
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
}