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

	private void OnClickedStart(object sender, EventArgs e)
	{
		_locationTrackingService.StartTracking();
	}

	private void OnClickedStop(object sender, EventArgs e)
    {
		_locationTrackingService.StopTracking();
    }

	private void UpdateLocationLabel(Location location)
    {
		Geolocation.Text = $"Lat:{location.Latitude}, Lon:{location.Longitude}";

		SemanticScreenReader.Announce(Geolocation.Text);
	}
}

