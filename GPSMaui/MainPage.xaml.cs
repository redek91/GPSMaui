using GPSMaui.Services.Interfaces;

namespace GPSMaui;

public partial class MainPage : ContentPage
{
    private readonly ILocationTrackingService _locationTrackingService;

    public MainPage(ILocationTrackingService locationTrackingService)
	{
		InitializeComponent();
        _locationTrackingService = locationTrackingService ?? throw new ArgumentNullException(nameof(locationTrackingService));

		_locationTrackingService.LocationUpdated += UpdateLocationLabel;
    }

	private void UpdateLocationLabel(Location location)
    {
		Geolocation.Text = $"Lat:{location.Latitude}, Lon:{location.Longitude}";
        System.Diagnostics.Debug.WriteLine("Location was updated!");
		SemanticScreenReader.Announce(Geolocation.Text);
	}

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            _locationTrackingService?.StartTracking();
        }
        else
        {
            _locationTrackingService?.StopTracking();
        }

    }
}

