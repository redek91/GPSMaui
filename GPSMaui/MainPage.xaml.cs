namespace GPSMaui;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnClicked(object sender, EventArgs e)
	{
		var location = await Microsoft.Maui.Essentials.Geolocation.GetLocationAsync();

		Geolocation.Text = $"Lat:{location.Latitude}, Lon:{location.Longitude}";

		SemanticScreenReader.Announce(Geolocation.Text);
	}
}

