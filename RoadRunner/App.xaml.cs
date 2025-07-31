using Contracts;
using LoggerService;
using System.Diagnostics;

namespace RoadRunner;

public partial class App : Application
{
    const int WindowHeight = 1080;    

    public App()
    {
        InitializeComponent();        
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // get screen size
        var disp = DeviceDisplay.Current.MainDisplayInfo;

        var windowWidth = disp.Width / 2;

        var window = new Window(new MainPage()) { Title = "Road Runner" };

        // Set the window position to the right hand side of the screen
        // Center the window on the screen
        window.X = disp.Width / disp.Density - windowWidth; // Position the window on the right side of the screen
        window.Y = (disp.Height / disp.Density - WindowHeight) / 2; // Center the window vertically            

        window.Width = windowWidth; // Set the window width to 1920
        window.Height = WindowHeight; // Set the window height to 1080

        return window; // Return the created window
    }

    private void LogToEventLog(string message, EventLogEntryType type)
    {
        try
        {
            using var eventLog = new EventLog("Application");
            eventLog.Source = "RoadRunner";
            eventLog.WriteEntry(message, type);
        }
        catch
        {
            // Silently fail if we can't write to event log
            System.Diagnostics.Debug.WriteLine($"Event log write failed: {message}");
        }
    }
}
