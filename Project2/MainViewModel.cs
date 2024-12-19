using Microsoft.Maui.Controls;
using ReactiveUI.Fody.Helpers;
using Shiny.Locations;

namespace Project2
{
    public partial class MainViewModel : ObservableObject
    {
        private IGeofenceManager _geofenceManager;
        public MainViewModel(IGeofenceManager geofenceManager)
        {
            _geofenceManager = geofenceManager;
        }

        public ICommand Start => new Command(async () =>
        {
            await _geofenceManager.RequestAccess();
            var geofenceId = "TestGeofence";
            var latitude = 59.91383192462088;
            var longitude = 10.752177345138199;
            var radius = 100; // meters

            var r = new GeofenceRegion(geofenceId, new Shiny.Locations.Position(latitude, longitude),
                Distance.FromMeters(radius));
            await _geofenceManager.StartMonitoring(r);

            var test = await _geofenceManager.RequestState(r);
            ;
        });

    }
}