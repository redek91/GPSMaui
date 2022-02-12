using GPSMaui.Services.Interfaces;
using Microsoft.Maui.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPSMaui.Services.Impl
{
    public class LocationTrackingService : ILocationTrackingService
    {
        public event ILocationTrackingService.LocationUpdate LocationUpdated;

        private bool _serviceStoped = false;

        public void StartTracking()
        {
            _serviceStoped = false;
            LocationUpdateTask();
        }

        public void StopTracking()
        {
            _serviceStoped = true;
        }

        private async void LocationUpdateTask()
        {

            while (!_serviceStoped)
            {
                var location = await Geolocation.GetLocationAsync();
                LocationUpdated.Invoke(location);
                await Task.Delay(5000);
            }
        }
        
    }
}
