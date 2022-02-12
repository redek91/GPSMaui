using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPSMaui.Services.Interfaces
{
    public interface ILocationTrackingService
    {
        delegate void LocationUpdate(Location location);
        event LocationUpdate LocationUpdated;

        void StartTracking();
        void StopTracking();
    }
}
