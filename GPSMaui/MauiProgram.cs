using GPSMaui.Services.Impl;
using GPSMaui.Services.Interfaces;

namespace GPSMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddSingleton<ILocationTrackingService, LocationTrackingService>();
		builder.Services.AddSingleton<MainPage>();

		return builder.Build();
	}
}
