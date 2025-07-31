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
        try
        {
            var disp = DeviceDisplay.Current.MainDisplayInfo;

            // Add safety checks
            if (disp.Density <= 0)
            {
                // Fallback to default window creation
                return new Window(new MainPage()) { Title = "Road Runner" };
            }

            var screenWidth = disp.Width / disp.Density;
            var screenHeight = disp.Height / disp.Density;
            var windowWidth = Math.Max(800, screenWidth / 2); // Ensure minimum width

            var window = new Window(new MainPage()) { Title = "Road Runner" };

            // Ensure window fits on screen
            var x = Math.Max(0, screenWidth - windowWidth);
            var y = Math.Max(0, (screenHeight - WindowHeight) / 2);

            window.X = x;
            window.Y = y;
            window.Width = windowWidth;
            window.Height = WindowHeight;

            LogToEventLog("RoadRunner window created successfully", EventLogEntryType.Information);

            return window;
        }
        catch (Exception ex)
        {
            // Log the exception and return a basic window
            LogToEventLog($"Failed to create RoadRunner window: {ex.Message}\nStack: {ex.StackTrace}", EventLogEntryType.Error);
            return new Window(new MainPage()) { Title = "Road Runner" };
        }
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
