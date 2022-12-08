using ecosysteme.Models;
namespace ecosysteme.Views;

public partial class Graphics_EcoSystem : ContentPage
{
    IDispatcherTimer timer;
    Simulation simulation;
    public Graphics_EcoSystem()
	{
        InitializeComponent();

        simulation = Resources["simulation"] as Simulation;

        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(500);
        timer.Tick += this.OnTimeEvent;
        timer.Start();
    }

    private void OnTimeEvent(object source, EventArgs e)
    {
        simulation.Update();
        graphics.Invalidate();
    }
}